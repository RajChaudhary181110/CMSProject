using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class College
    {
        DataLayer objdata = new DataLayer();
        public int College_Id { get; set; }
        public string College_Name  { get; set; }
        public string  College_Code { get; set; }
        public int CollegeType_Id { get; set; }
        public int District_Id { get; set; }
        public int Division_Id { get; set; }
        public int Division_Name { get; set; }
        public string District_Name { get; set; }
        public int Mandal_Id  { get; set; }
        public string Mandal_Name { get; set; }

 
     
    }

}