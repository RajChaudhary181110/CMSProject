using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class DataLayer
    {
        string Constr = "";
        public DataLayer()
        {
            Constr = ConfigurationManager.AppSettings.Get("Conn");
        }

        internal bool CollegeRegistration(College obj)
        {
            bool status = false;
            using (SqlConnection con = new SqlConnection(Constr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlTransaction trans = con.BeginTransaction();
                try
                {
                            SqlParameter[] sp = new SqlParameter[5];
                            sp[0] = new SqlParameter("@Office_Name", obj.College_Name);
                            sp[1] = new SqlParameter("@District_Id", obj.District_Id);
                            sp[2] = new SqlParameter("@OfficeType_Id", obj.CollegeType_Id);
                            sp[3] = new SqlParameter("@UdiseCode", obj.College_Code);
                            sp[4] = new SqlParameter("@Division_Id", obj.Mandal_Id);
                            status = ExecuteProcedureWithSqlParameterTransactions("sp_InsertCollegeRegistration", con, trans, sp);
                            if (status)
                            {
                                trans.Commit();
                            }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    status = false;
                }
                return status;
            }
        }




        private bool ExecuteProcedureWithSqlParameterTransactions(string ProcedureName, SqlConnection sqlConnection, SqlTransaction trans, SqlParameter[] sp)
        {
            bool flag = false;
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand command1 = new SqlCommand();
            command1.Connection = sqlConnection;
            command1.CommandType = CommandType.StoredProcedure;
            command1.Transaction = trans;
            command1.Parameters.AddRange(sp);
            command1.CommandText = ProcedureName;
            command1.CommandTimeout = 100000000;
            // HttpContext.Current.Session["SqlQuery"] = GetProcedureAndParameter(ProcedureName, sp);
            if (command1.ExecuteNonQuery() > 0)
            {
                flag = true; ;
            }
            else
            {
                flag = false;
            }
            return flag;
        }



        internal DataTable GetDivision()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteProcedureWithoutParametreToGetDataTable("Sp_GetDivision");

            }
            catch
            {
                dt = null;
            }
            return dt;
        }



        private DataTable ExecuteProcedureWithoutParametreToGetDataTable(string ProcedureName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constr))
            {
                SqlCommand cmd = new SqlCommand(ProcedureName, sqlConnection);
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 20000;
                dataAdapter.Fill(dt);
                sqlConnection.Close();
                return dt;
            }
        }


        internal DataTable GetOfficeType()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteProcedureWithoutParametreToGetDataTable("Sp_GetOfficeType");

            }
            catch
            {
                dt = null;
            }
            return dt;
        }

       
        internal DataTable GetDistrictAccordingtoDivision(string Division_Id)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@Division_Id", Division_Id);
            dt = ExecuteProcedureToGetDataTable("sp_GetDistrictAccordingToDivision", sp);

            return dt;
        }

        private DataTable ExecuteProcedureToGetDataTable(string ProcedureName, SqlParameter[] sp)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constr))
            {
                SqlCommand command = new SqlCommand(ProcedureName, sqlConnection);
                if (command.Connection.State == ConnectionState.Closed)
                {
                    command.Connection.Open();
                }
                DataTable dataTable = new DataTable();
                command.CommandType = CommandType.StoredProcedure;
                if (sp != null && sp.Length > 0)
                {
                    for (int i = 0; i < sp.Length; i++)
                    {
                        command.Parameters.Add(sp[i]);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.CommandTimeout = 8000000;
                da.Fill(dataTable);
                sqlConnection.Close();
                return dataTable;
            }
        }


    }
}

