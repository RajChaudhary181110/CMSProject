using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagementSystem.Models
{
    public class AllClass
    {
        //internal static dynamic CreateDropDownList(System.Data.DataTable dt)
        //{
        //    throw new NotImplementedException();
        //}
        internal static List<SelectListItem> CreateDropDownList(System.Data.DataTable dt)
        {
            List<SelectListItem> lstItem = new List<SelectListItem>();
            lstItem.Add(new SelectListItem() { Text = "All", Value = "0" });
            if (dt!=null && dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    lstItem.Add(new SelectListItem() { Text = dt.Rows[i][1].ToString(), Value = dt.Rows[i][0].ToString() });
                    
                }
            }
            else
            {
                lstItem.Add(new SelectListItem() { Text = "None", Value = "-1" });

            }
            return lstItem;
        }
    }
}