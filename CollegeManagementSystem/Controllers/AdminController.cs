using CollegeManagementSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        BusinessLayer objbus = new BusinessLayer();
        [HttpGet]
        public ActionResult CollegeRegistration()
        {
            DataTable dt = objbus.GetDivision();
            ViewBag.Division = AllClass.CreateDropDownList(dt);
            DataTable dt1 = objbus.GetOfficeType();
            ViewBag.OfficeType = AllClass.CreateDropDownList(dt1);
            return View();

        }
        [HttpPost]
        public bool CollegeRegistration(College objmain)
        {
            bool flag = false;   
            BusinessLayer objbus = new BusinessLayer();
            DataTable dt = objbus.GetDivision();
            ViewBag.Division = AllClass.CreateDropDownList(dt);
            flag = objbus.CollegeRegistration(objmain);
            if (flag==true)
            {
                Response.Write("<Script>alert('Data Save Successfully!');window.location.href='/Admin/CollegeRegistration'</script>");
            }
            else
	        {
                Response.Write("<Script>alert('Data not Save!')</script>");
	        }
            return flag;
        }
        public string GetDistrictAccordingtoDivision(string Division_Id)
        {
            string res="";
            DataTable dt = objbus.GetDistrictAccordingtoDivision(Division_Id);
            res = JsonConvert.SerializeObject(dt);
            return res;
        }


	}
}