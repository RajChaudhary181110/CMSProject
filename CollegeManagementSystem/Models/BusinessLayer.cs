using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class BusinessLayer
    {
        DataLayer objdata = new DataLayer();
        internal bool CollegeRegistration(College objmain)
        {
            return objdata.CollegeRegistration(objmain);
        }

        internal System.Data.DataTable GetDivision()
        {
            return objdata.GetDivision();
        }

        internal System.Data.DataTable GetOfficeType()
        {
            return objdata.GetOfficeType();
        }

        internal System.Data.DataTable GetDistrictAccordingtoDivision(string Division_Id)
        {
            return objdata.GetDistrictAccordingtoDivision(Division_Id);
        }
    }
}