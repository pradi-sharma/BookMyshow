using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMyshow.Models;

namespace BookMyshow.Controllers
{
    public class UserHomeController : Controller
    {
      static int sId = 0;
       static int mvId = 0;
       static int thId = 0;

        List<string> actorphotolist = new List<string>();
        ShowBookingEntities entities = new ShowBookingEntities();
        // GET: MoviesTicket
        public ActionResult Index()
        {
            try { 
            List<MoviePosters> moviesDescription = new List<MoviePosters>();

            List<Movy> movies = Getmovies();
            // Movy movy = entities.Movies.Where(id => id.MovieId == 1).FirstOrDefault();
            List<string> movielist = new List<string>();

            for (int i = 0; i < movies.Count; i++)
            {
                string movie = string.Format("data:image/png;base64," + Convert.ToBase64String(movies[i].Poster, 0, movies[i].Poster.Length));
                MoviePosters moviePosters = new MoviePosters(movies[i].MovieId, movie,movies[i].MovieName);
                moviesDescription.Add(moviePosters);
                movielist.Add(movie);
               
            }


            ViewBag.list = movielist;
            if (Session["userId"] !=null)
            {
                return View("UserIndex");
            }
    
            return View(moviesDescription.ToList());
            }
            catch (Exception ex) { throw ex; }
        }

        public ActionResult MovieDescription(int id)
        {
            try { 
            //List<Movy> movies = Getmovies();
            Movy movy = entities.Movies.Where(id1 => id1.MovieId == id).FirstOrDefault();
            ViewBag.FirstMovie = "data:image/png;base64," + Convert.ToBase64String(movy.Poster, 0, movy.Poster.Length);

            //FOR CAST LIST
            var result = entities.GetCasts(id);
            List<GetCasts_Result> abc = result.ToList();



            for (int i = 0; i < abc.Count; i++)
            {
                string actor = string.Format("data:image/png;base64," + Convert.ToBase64String(abc[i].ActorPhoto, 0, abc[i].ActorPhoto.Length));
                actorphotolist.Add(actor);
            
            }
          
            ViewBag.Castphotos = actorphotolist;
           
            return View(movy);
            }
            catch (Exception ex) { throw ex; }
        }

        public ActionResult Search(FormCollection form)
        {
            try
            {

            
            string value = form["searchInput"];
            int result = entities.Movies.Where(a => a.MovieName == value).FirstOrDefault().MovieId;
            //int id1 = result.MovieId;
            //ViewBag.FirstMovie = "data:image/png;base64," + Convert.ToBase64String(result.Poster, 0, result.Poster.Length);
            //return RedirectToAction("MovieDescription", new {id = result });
            //  return this.Json(new { success = result });
            return RedirectToAction("MovieDescription", new { id = result });
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "UserHome", "Search"));
            }
        }

        public List<Movy> Getmovies()
        {
            
            List<Movy> mylist = new List<Movy>();
            var m = entities.Movies;
            try { 
            foreach (var item in m)
            {
                mylist.Add(item);
            }
            return mylist;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        } 

        public ActionResult Login(FormCollection form)
        { string username = form["username"];
            string password = form["password"];
            UserDetail user = new UserDetail();
            var result = entities.UserDetails.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
           int count= entities.UserDetails.Where(u => u.UserName == username && u.Password == password).Count();
            if (count != 0)
            {
               string role = result.Role;
                if (role == "user")
                {
                    Session["userId"] = result.UserId;
                    Session["userName"] = result.UserName;
                    return RedirectToAction("Index");
                }
                else if (role == "admin")
                {
                    Session["userId"] = result.UserId;
                    Session["userName"] = result.UserName;
                    return RedirectToAction("Index", "AdminHome");
                }
                else if (role == "theatreAdmin")
                {
                    Session["userId"] = result.UserId;
                    Session["userName"] = result.UserName;
                    return RedirectToAction("Index", "Theatre");
                }
                else
                {
                    return View("loginfail");
                }
            }
            else
            {
                return View("loginfail");
            }

        }
        public ActionResult LogOut()
        {
            Session.Abandon();
           // return RedirectToAction("Index");
            return RedirectToAction("Index", "UserHome");
        }

        public ActionResult BookMovie(int id)
        {
            try { 
            //var result = entities.Movies.Where(movieId => movieId.MovieId == id).FirstOrDefault();
            var theatre = entities.GetTheatres(id);
            List<TheatreTimiSlots> theatreTimeSlotList = new List<TheatreTimiSlots>();
            foreach(int item in theatre.ToList())
            {
                List<string> spans = new List<string>();
                //var times = from t in entities.TimeSlots
                //            join s in entities.Slots
                //            on t.SlotId equals s.SlotId
                //            where t.TheatreId == item & t.Movieid == id
                //            select new { startTime=s.StartTime};
                var times = entities.GetSlots(item, id);


                // TimeSpan xyz = times.StartTime;
                foreach (TimeSpan item1 in times.ToList())
                {
                    string ntime = string.Format("{0:00}:{1:00}", item1.Hours, item1.Minutes); // it should display 00:00
                    spans.Add(ntime);
                }
                string tname = entities.Theatres.Where(i => i.TheatreId == item).Select(t => t.TheatreName).Single();
                ViewBag.movieId = id;
                TheatreTimiSlots theatreTimeSlot = new TheatreTimiSlots(item,spans,tname);
                theatreTimeSlotList.Add(theatreTimeSlot);
            }
          //  ViewBag.theatrelist = theatre.ToList();
            return View(theatreTimeSlotList.ToList());
            }
            catch (Exception ex) { throw ex; }
        }
     
        [HttpPost]
        public ActionResult TimingsByTheatre(FormCollection form)
        {
            try { 
            int theatreId = Convert.ToInt32(form["theatreId"]);
            TimeSpan slot = Convert.ToDateTime(form["slotId"]).TimeOfDay;
            int movieId = Convert.ToInt32(form["theatreId"]);
            int slotid = entities.Slots.Where(s => s.StartTime == slot).FirstOrDefault().SlotId;

            //to set global variables
            sId = slotid;
            mvId = movieId;
            thId = theatreId;

            // List<string>notSelectedSeats = entities.GetSelectSeats(5).ToList();
            List<string> notSelectedSeats = entities.GetBlockedSeats(theatreId, slotid, movieId).ToList();

            var p = entities.GetPrice(theatreId, movieId,sId).Single();
            ViewBag.Price =Convert.ToDecimal(p);
            ViewBag.arr = notSelectedSeats;
          
            return View("UserSeatSelection");
            }
            catch (Exception ex) { throw ex; }
        }
        //public ActionResult BookTicket(int[]key,string[] value)
        //{
        //    decimal amount = key[0];

        //    return View();
        //}
      

        public ActionResult SelectedSeats(decimal key,string[] value)
        {

            try { 
            TempData["amount2"] = key;
            TempData["ss"] = value.ToList();
            TempData.Keep();


            return this.Json(new { success = "true" });
            }
            catch (Exception ex) { throw ex; }
        }
        public ActionResult MakePayment()
        {
         
            if (Session["userId"] != null)
            {
                ViewBag.amt2 = TempData["amount2"];
                TempData.Keep();
                return View("Payment");
            }
            else
            {
                return RedirectToAction("Index", "UserHome");
            }
           

        }
        [HttpPost]
        public ActionResult ApplyOffer(string key,string value)
        {
            try { 
            string ofrcode = value;
            int result = entities.MovieOfferDetails.Where(o => o.CouponCode == ofrcode).FirstOrDefault().OfferId;
            int discount = entities.Offers.Where(i => i.OfferId == result).FirstOrDefault().Discount;
           int amt =Convert.ToInt32(TempData["amount2"]);
            ViewBag.newamt = (amt * discount) / 100;
            return this.Json(new { success = true });
            }
            catch (Exception ex) { throw ex; }
        }


        public ActionResult GenerateTicket()
        {
            try { 
            ViewBag.amt2 = TempData["amount2"];
            List<string> seatslist = (List<string>)TempData["ss"];

            TicketDetail ticket = new TicketDetail();
            ticket.MovieId = mvId;
            ticket.TheatreId = thId;
            ticket.Price=Convert.ToDecimal(TempData["amount2"]);
            entities.TicketDetails.Add(ticket);
            entities.SaveChanges();
            int identity = entities.TicketDetails.Select(t => t.TicketId).Max();
            int newIdentity = identity + 1;
            foreach (var item in seatslist)
            {
                entities.InsertTicketSeats(newIdentity, item);
            }
            foreach (var item in seatslist)
            {
                BookedSeat bookedSeat = new BookedSeat();
                bookedSeat.MovieId = mvId;
                bookedSeat.SlotId = sId;
                bookedSeat.TheatreId = thId;
                bookedSeat.UserId = 1;
                bookedSeat.SeatNumber = item;
                entities.BookedSeats.Add(bookedSeat);
                entities.SaveChanges();
            }

            return View("Ticket");
            }
            catch (Exception ex) { throw ex; }
        }

        public ActionResult SearchByCity()
        {
            try { 
            ViewBag.City = new SelectList(entities.Cities.ToList(), "CityId", "CityName");
            return View();
            }
            catch (Exception ex) { throw ex; }
        }
        [HttpPost]
        public PartialViewResult SearchByCity(FormCollection fc)
        {
            try { 
            //Inserting into Dropdown
            ViewBag.City = new SelectList(entities.Cities, "CityId", "CityName");
            int value = Convert.ToInt32(fc["CityId"]);
            //var result = entities.Movies.Where(a=>a.MovieName == value).FirstOrDefault().MovieId;

            var display = entities.MovyByCity(value);




            return PartialView("_MoviesByCityList", display.ToList());
            }
            catch (Exception ex) { throw ex; }
        }



        public ActionResult SearchMovies(int id)
        {
            //Inserting into Dropdown
            //ViewBag.City = new SelectList(entities.Cities, "CityId", "CityName");
            //int value = Convert.ToInt32(fc["CityId"]);
            try { 
            var c = entities.Cities.Where(c1 => c1.CityId == id).FirstOrDefault();

            ViewBag.cname = c.CityName;
            var display = entities.MovyByCity(id);

            return View("MoviesByCity", display);
            }
            catch (Exception ex) { throw ex; }

        }
        public ActionResult Register(FormCollection fc)
        {
            try { 
            string Username = fc["username"];
            string Password = fc["password"];
            string role = "user";
            long Contact = Convert.ToInt64(fc["contact"]);

            string email = fc["email"];


            UserDetail user = new UserDetail { UserName = Username, Password = Password, Role = role, Contact = Contact, Email = email };
            entities.UserDetails.Add(user);
            entities.SaveChanges();
        
            
            return RedirectToAction("Index");
            }
            catch (Exception ex) {
                throw ex;
                    }

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

    }
}