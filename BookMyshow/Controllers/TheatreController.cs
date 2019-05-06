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
           
            var a =Session["userId"];
            var result1 = entities.checkTheatre(Convert.ToInt32(Session["userId"])).Single();
            var result = entities.checkTheatre(Convert.ToInt32(Session["userId"])).Count();
            if (result != 0)
            {
                ViewBag.collection =Convert.ToDecimal(entities.TotalCollection(result1).Single());
                return View("RegisteredTheatreAdminHome");
            }
            return View("TheatreAdminHome");
        }
        public ActionResult TheatreRegister()
        {
            if (Session != null)
            {
                ViewData["cities"] = new SelectList(entities.Cities, "CityId", "CityName");
                return View();
            }else
            {
                return RedirectToAction("Index", "UserHome");
            }
          
        }
        [HttpPost]
        public PartialViewResult TheatreRegister(FormCollection theatre)
        {   
            Theatre newtheatre = new Theatre();
            newtheatre.TheatreName = theatre["TheatreName"];
            newtheatre.Capacity = Convert.ToInt32(theatre["Capacity"]);
            newtheatre.CityId = Convert.ToInt32(theatre["cities"]);
            entities.Theatres.Add(newtheatre);
            entities.SaveChanges();
            int idd = entities.Theatres.Max(t => t.TheatreId);
            int uid = Convert.ToInt32(Session["userId"]);
            entities.InsertTheatreUser(idd,uid);
            return PartialView("_theatreSuccess");
        }
        public PartialViewResult SelectLayout()
        {
            int userid = Convert.ToInt32(Session["userId"]);
            try
            {
                var theatreId = Convert.ToInt32(entities.checkTheatre(userid).Single());
            }
            catch (Exception)
            {

                ViewBag.name = Session["userName"];
                return PartialView("_RegisterFirstMessage");
            }
                
                return PartialView("_SeatLayoutSelection");

        }
        [HttpPost]
        public ActionResult SelectLayout(string key, string[] value)
        {
            int userid =Convert.ToInt32(Session["userId"]);
            int theatreId =Convert.ToInt32(entities.checkTheatre(userid).Single());
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
                    command.Parameters.AddWithValue("@TheatreId", theatreId);
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
            ViewBag.movielist = new SelectList(entities.Movies, "MovieId", "MovieName");
            ViewBag.SlotList = new SelectList(entities.Slots, "SlotId", "StartTime");
            return PartialView("_AddMovie");
        }
        [HttpPost]
        public PartialViewResult AddMovie(FormCollection form)
        {
            int movId = Convert.ToInt32(form["movielist"]);
            int SlotId = Convert.ToInt32(form["SlotList"]);
            decimal price = Convert.ToDecimal(form["Price"]);
            int uId =Convert.ToInt32(Session["userId"]);
         //  int tid=Convert.ToInt32(entities.checkTheatre(uId));
            int tid = 2;
         //   entities.InsertTheatreMovy(tid, movId);
            //theatreMovie.TheatreId = 1;
            //theatreMovie.MovieId = movId;

            //entities.TheatreMovies.Add(theatreMovie);
            //entities.SaveChanges();
            TimeSlot timeSlot = new TimeSlot();
            timeSlot.TheatreId = tid;
            timeSlot.Movieid = movId;
            timeSlot.SlotId = SlotId;
            timeSlot.Price = price;
            entities.TimeSlots.Add(timeSlot);
            entities.SaveChanges();
            return PartialView("RegisteredTheatreAdminHome");
        }
        public PartialViewResult RemoveMovie()
        {
            //  var mlist = ;
            // List<string> movies = mlist.ToList();
            int uid = Convert.ToInt32(Session["userId"]);
            int tid =Convert.ToInt32(entities.checkTheatre(uid).Single());
           ViewBag.movielist = new SelectList(entities.GetMoviesList(tid), "MovieId", "MovieName");
            ViewBag.SlotList = new SelectList(entities.Slots, "SlotId", "StartTime");
            return PartialView("_RemoveMovie");
        }
        [HttpPost]
        public ActionResult RemoveMovie(FormCollection form)
        {
            int mvId = Convert.ToInt32(form["movielist"]);
            int slotid = Convert.ToInt32(form["SlotList"]);
            entities.deleteMovie(1, mvId, slotid);
            return View("RegisteredTheatreAdminHome");
        }
    }
}