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
    }
}