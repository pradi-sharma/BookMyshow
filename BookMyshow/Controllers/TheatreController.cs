using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMyshow.Models;

namespace BookMyshow.Controllers
{
    public class TheatreController : Controller
    {
        ShowBookingEntities entities = new ShowBookingEntities();
       
        public ActionResult Index()
        {
            var result = entities.checkTheatre(Convert.ToInt32(Session["userId"]));
            if (result != null)
            {
                return View("TheatreAdminHome");
            }
            return View("RegisteredTheatreAdminHome");
        }
        public ActionResult TheatreRegister()
        {
            ViewData["cities"] = new SelectList(entities.Cities, "CityId", "CityName");
            return View();
        }
        [HttpPost]
        public ActionResult TheatreRegister(FormCollection theatre)
        {   
            Theatre newtheatre = new Theatre();
            newtheatre.TheatreName = theatre["TheatreName"];
            newtheatre.Capacity = Convert.ToInt32(theatre["Capacity"]);
            newtheatre.CityId = Convert.ToInt32(theatre["cities"]);
            entities.Theatres.Add(newtheatre);
            entities.SaveChanges();
            return View("_theatreSuccess");
        }
        public ActionResult SelectLayout()
        {
            Session["sampledata"] = "sample";
            return View();
        }
        [HttpPost]
        public ActionResult SelectLayout(string key, string[] value)
        {
            Session[key] = value;

            SqlConnection connection = new SqlConnection("database=ShowBooking;server=VDI-NET-0006\\LOCAL;trusted_connection=true");
            connection.Open();
            //if (value.ToString().Contains(','))
            //{
             //   string[] arrval = value.ToString().Split(',');
                int j = value.Length;
              //  int i = 0;
                for (int i = 0; i < j; i++)
            {
                SqlCommand command = new SqlCommand("InsertIntoTheatreSeats", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TheatreId", 5);
                    command.Parameters.AddWithValue("@SeatNumber", value[i].ToString());
                    command.Parameters.AddWithValue("@Status", "S");
                    command.ExecuteNonQuery();

                }
            //}
            //else
            //{
            //    command.Parameters.AddWithValue("@TheatreId", 1);
            //    command.Parameters.AddWithValue("@SeatNumber", value);
            //    command.Parameters.AddWithValue("@Status", "S");
            //    command.ExecuteNonQuery();
            //}
            ViewBag.Message = Session[key];
            return this.Json(new { success = true });
        }
        public PartialViewResult AddMovie()
        {
            return PartialView();
        }
    }
}