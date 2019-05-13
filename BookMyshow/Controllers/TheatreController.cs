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
            if (Session["userId"] != null)
            {

                try
                {
                    var result = entities.checkTheatre(Convert.ToInt32(Session["userId"])).Count();
                    ViewBag.count = result;
                    var result1 = entities.checkTheatre(Convert.ToInt32(Session["userId"])).FirstOrDefault();
                    ViewBag.collection = Convert.ToDecimal(entities.TotalCollection(result1).Single());
                }
                catch (Exception)
                {
                    ViewBag.count = 0;
                   
                }
                //if (result != 0)
                //{
                //    var result1 = entities.checkTheatre(Convert.ToInt32(Session["userId"])).Single();
                //    ViewBag.collection = Convert.ToDecimal(entities.TotalCollection(result1).Single());

                //    return View("RegisteredTheatreAdminHome");
                //}
                return View("RegisteredTheatreAdminHome");

            }
            else
            {
                return RedirectToAction("Index", "UserHome");
            }
          
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
            if (Session["userId"] != null)
            {

                Theatre newtheatre = new Theatre();
                newtheatre.TheatreName = theatre["TheatreName"];
                newtheatre.Capacity = Convert.ToInt32(theatre["Capacity"]);
                newtheatre.CityId = Convert.ToInt32(theatre["cities"]);
                entities.Theatres.Add(newtheatre);
                entities.SaveChanges();
                int idd = entities.Theatres.Max(t => t.TheatreId);
                int uid = Convert.ToInt32(Session["userId"]);
                entities.InsertTheatreUser(idd, uid);
                return PartialView("_theatreSuccess");
            }
            return PartialView("_LoggedOut");
        }
        public ActionResult SelectLayout()
        {
            //int userid = Convert.ToInt32(Session["userId"]);
            //try
            //{
            //    var theatreId = Convert.ToInt32(entities.checkTheatre(userid).Single());
            //}
            //catch (Exception)
            //{

                ViewBag.name = Session["userName"];
            //    return PartialView("_RegisterFirstMessage");
            //}
                
                return View("SelectLayout");

        }
        [HttpPost]
        public ActionResult SelectLayout(string key, string[] value)
        {
            //try
            //{
                int userid =Convert.ToInt32(Session["userId"]);
            int theatreId =Convert.ToInt32(entities.checkTheatre(userid).FirstOrDefault());
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
            //}
            //catch (Exception ex)
            //{

            //    return View("Error", new HandleErrorInfo(ex, "UserHome", "Search"));
            //}
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
            //try { 
            int movId = Convert.ToInt32(form["movielist"]);
            int SlotId = Convert.ToInt32(form["SlotList"]);
            decimal price = Convert.ToDecimal(form["Price"]);
            DateTime date = Convert.ToDateTime(form["date"]);
            int uId =Convert.ToInt32(Session["userId"]);
           int tid=Convert.ToInt32(entities.checkTheatre(uId).FirstOrDefault());
         //   int tid = ;
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
            timeSlot.Date = date;
            entities.TimeSlots.Add(timeSlot);
            entities.SaveChanges();
            return PartialView("_MovieSuccess");
            //}
            //catch (Exception ex) { throw ex; }
        }
        public PartialViewResult RemoveMovie()
        {
            //  var mlist = ;
            // List<string> movies = mlist.ToList();
            try { 
            int uid = Convert.ToInt32(Session["userId"]);
            int tid =Convert.ToInt32(entities.checkTheatre(uid).FirstOrDefault());

                var result = entities.RemoveMoviesList(tid).ToList();
           ViewBag.movielist = new SelectList(entities.GetMoviesList(tid), "MovieId", "MovieName");
            ViewBag.SlotList = new SelectList(entities.Slots, "SlotId", "StartTime");
           //     ViewBag.SlotList=new SelectList(entities.GetSlotsList(tid,))
            return PartialView("_RemoveList",result);
            }
            catch (Exception ex) { throw ex; }
        }
        //[HttpPost]
        //public ActionResult RemoveMovie(FormCollection form)
        //{
        //    try {
        //        int tid = Convert.ToInt32(Session["userId"]);
        //    int mvId = Convert.ToInt32(form["movielist"]);
        //    int slotid = Convert.ToInt32(form["SlotList"]);
        //    entities.deleteMovie(tid, mvId, slotid);
        //    return View("RegisteredTheatreAdminHome");
        //    }
        //    catch (Exception ex) { throw ex; }
        //}
        [HttpPost]
        public PartialViewResult RemoveMovie(int id,int tid,int sid,DateTime d)
        {
            var result = entities.TimeSlots.Where(ts => ts.Movieid == id && ts.SlotId == sid && ts.Date == d.Date).FirstOrDefault();
            entities.TimeSlots.Remove(result);
            entities.SaveChanges();
      
            return PartialView("_RemoveMovieSuccess");
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            //Logging the Exception
            filterContext.ExceptionHandled = true;


            var Result = this.View("Error", new HandleErrorInfo(exception,
                filterContext.RouteData.Values["controller"].ToString(),
                filterContext.RouteData.Values["action"].ToString()));

            filterContext.Result = Result;

        }

        public PartialViewResult UpdatePassword()
        {
            return PartialView("_UpdatePassword");
        }
        [HttpPost]
        public PartialViewResult UpdatePassword(UserDetail form)
        {
            string username = Session["userName"].ToString();
            string password = form.Password;
            bool status = IsPasswordExist(username, password);
            if (status)
            {
                ModelState.AddModelError("Password", "Password is not correct");
                return PartialView("_UpdatePassword",form);
            }
            string newPassword = form.NewPassword;
            var user = entities.UserDetails.Where(u => u.UserName == username).FirstOrDefault();
            user.Password = newPassword;
            entities.SaveChanges();

            return PartialView("_UserPasswordSuccess");
        }
        [NonAction]
        public bool IsPasswordExist(string username,string password)
        {
            var pwd = entities.UserDetails.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
            if (pwd != null) { return false; }
            else
            { return true; }
        }
    }
}