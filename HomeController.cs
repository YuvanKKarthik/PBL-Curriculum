using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yk.Models;

namespace yk.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["podata"].ConnectionString);
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult pblo()
        {
            return View();
        }

        public ActionResult Userhome()
        {
            return View();
        }
        public ActionResult Login(User_details UD)
        {
            Conn.Open();
            SqlCommand selectUserQuery = new SqlCommand("SELECT * from Login where UserID = @UserID and Password = @Password", Conn);
            selectUserQuery.Parameters.AddWithValue("@UserID", UD.UserID);
            selectUserQuery.Parameters.AddWithValue("@Password", UD.Password);

            SqlDataReader Reader = selectUserQuery.ExecuteReader();
            while (Reader.Read())
            {
                Session["User ID"] = Reader[0].ToString();
                Session["Dept"] = Reader[2].ToString();
                Session["Admin"] = Reader[3].ToString();

                Conn.Close();
                if(Session["Dept"].ToString() == "Professional Skills")
                {
                    return RedirectToAction("ps", "Home", new { Info = "Welcome" });
                }
                if(Session["Dept"].ToString()=="Mechanical Engineering")
                {
                    return RedirectToAction("Userhome", "Home", new { Info = "Welcome" });
                }
                
            }
            Conn.Close();

            return RedirectToAction("Home", "Home", new { Info = "Invalid User ID/Password" });
        }
        public ActionResult Logout()
        {
            Session["User ID"] = "";
            Session["Dept"] = "";
            Session["Admin"] = "";
            return RedirectToAction("Home", "Home", new { Info = "Logout Successfull" });
        }
        public ActionResult po_folder()
        {
            if (Session["Admin"].ToString() == "1")
            {
                System.Diagnostics.Process.Start("explorer", Server.MapPath("~/Data/" + Session["Dept"] + "/po"));
                return RedirectToAction("pblo", "Home", new { Info = "folder opeened sucessfully " });
            }
            if (Session["Admin"].ToString() == "0")
            {
                
                return RedirectToAction("uso", "Home", new { Info = "folder opeened sucessfully " });
            }
            else
            {
                return RedirectToAction("uso", "Home", new { Info = "folder opeened sucessfully " }); ;
            }
        }

        public ActionResult sk_folder()
        {
            if (Session["Admin"].ToString() == "1")
            {
                System.Diagnostics.Process.Start("explorer", Server.MapPath("~/Data/" + Session["Dept"] + "/Skill loop"));
                return RedirectToAction("pblo", "Home", new { Info = "folder opeened sucessfully " });
            }
            if (Session["Admin"].ToString() == "0")
            {

                return RedirectToAction("skill", "Home", new { Info = "folder opeened sucessfully " });
            }
            else
            {
                return RedirectToAction("skill", "Home", new { Info = "folder opeened sucessfully " }); ;
            }
        }
        public ActionResult sk_task()
        {
            if (Session["Admin"].ToString() == "1")
            {
                System.Diagnostics.Process.Start("explorer", Server.MapPath("~/Data/" + Session["Dept"] + "/Skill task"));
                return RedirectToAction("pblo", "Home", new { Info = "folder opeened sucessfully " });
            }
            if (Session["Admin"].ToString() == "0")
            {

                return RedirectToAction("task", "Home", new { Info = "folder opeened sucessfully " });
            }
            else
            {
                return RedirectToAction("task", "Home", new { Info = "folder opeened sucessfully " }); ;
            }
        }
        public ActionResult task()
        {
            return View();
        }
        public ActionResult skill()
        {
            return View();
        }
        public ActionResult uso()
        {
            return View();
        }
        public ActionResult ps()
        {
            return View();
        }
        public ActionResult ps_out()
        {
            if (Session["Admin"].ToString() == "1")
            {
                System.Diagnostics.Process.Start("explorer", Server.MapPath("~/Data/" + Session["Dept"] + "/OUTCOMES"));
                return RedirectToAction("ps", "Home", new { Info = "folder opeened sucessfully " });
            }
            if (Session["Admin"].ToString() == "0")
            {

                return RedirectToAction("pso", "Home", new { Info = "folder opened sucessfully " });
            }
            else
            {
                return RedirectToAction("pso", "Home", new { Info = "folder opened sucessfully " }); ;
            }
        }
        public ActionResult ps_course()
        {
            if (Session["Admin"].ToString() == "1")
            {
                System.Diagnostics.Process.Start("explorer", Server.MapPath("~/Data/" + Session["Dept"] + "/COURSES"));
                return RedirectToAction("ps", "Home", new { Info = "folder opeened sucessfully " });
            }
            if (Session["Admin"].ToString() == "0")
            {

                return RedirectToAction("psc", "Home", new { Info = "folder opened sucessfully " });
            }
            else
            {
                return RedirectToAction("psc", "Home", new { Info = "folder opened sucessfully " }); ;
            }
        }
        public ActionResult ps_data()
        {
            if (Session["Admin"].ToString() == "1")
            {
                System.Diagnostics.Process.Start("explorer", Server.MapPath("~/Data/" + Session["Dept"] + "/DATA"));
                return RedirectToAction("ps", "Home", new { Info = "folder opeened sucessfully " });
            }
            if (Session["Admin"].ToString() == "0")
            {

                return RedirectToAction("psd", "Home", new { Info = "folder opened sucessfully " });
            }
            else
            {
                return RedirectToAction("psd", "Home", new { Info = "folder opened sucessfully " }); ;
            }
        }
        public ActionResult ps_report()
        {
            if (Session["Admin"].ToString() == "1")
            {
                System.Diagnostics.Process.Start("explorer", Server.MapPath("~/Data/" + Session["Dept"] + "/REPORTS"));
                return RedirectToAction("ps", "Home", new { Info = "folder opeened sucessfully " });
            }
            if (Session["Admin"].ToString() == "0")
            {

                return RedirectToAction("psr", "Home", new { Info = "folder opened sucessfully " });
            }
            else
            {
                return RedirectToAction("psr", "Home", new { Info = "folder opened sucessfully " }); ;
            }
        }
        public ActionResult psr()
        {
            return View();
        }
        public ActionResult pso()
        {
            return View();
        }
        public ActionResult psc()
        {
            return View();
        }
        public ActionResult psd()
        {
            return View();
        }



    }
    }




        