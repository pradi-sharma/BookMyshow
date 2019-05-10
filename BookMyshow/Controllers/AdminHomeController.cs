using BookMyshow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Helpers;
using System.Drawing;

namespace BookMyshow.Controllers
{
    public class AdminHomeController : Controller
    {
        ShowBookingEntities entities = new ShowBookingEntities();
        // GET: AdminHome
        public ActionResult Index()
        {
            return View("Admin");
        }

        #region OffersMthods 

        public PartialViewResult AddPlay()
        {
            return PartialView("_AddPlay");
        }
        public PartialViewResult AddOffers()
        {
            return PartialView("_AddOffers");
        }
       [HttpPost]
        public PartialViewResult AddOffers1(FormCollection form)
        {
            Offer offer = new Offer();
            offer.OfferName = form["Offername"];
            offer.Discount = Convert.ToInt32(form["discount"]);
            // offer.CouponCode = form.CouponCode;
            entities.Offers.Add(offer);
            entities.SaveChanges();
            return PartialView("_DisplayOffers", entities.Offers);
        }
        public PartialViewResult DisplayOffers()
        {
            return PartialView("_DisplayOffers", entities.Offers);
        }
        public PartialViewResult AddMovieOffers()
        {

            ViewBag.movielist = new SelectList(entities.Movies, "MovieId", "MovieName");
            ViewBag.offerlist = new SelectList(entities.Offers, "OfferId", "OfferName");
            return PartialView("_AddMovieoffer");
        }
        [HttpPost]
        public PartialViewResult AddMovieOffers(FormCollection form)
        {
            int offerId = Convert.ToInt32(form["offerlist"]);
            int movieId = Convert.ToInt32(form["movielist"]);
            MovieOfferDetail movieOffer = new MovieOfferDetail();
            movieOffer.OfferId = offerId;
            movieOffer.MovieId = movieId;
            movieOffer.CouponCode = form["Coupon"];
            entities.MovieOfferDetails.Add(movieOffer);
            entities.SaveChanges();

            return PartialView("_Displayoffers", entities.Offers);
        }
        [HttpPost]
        public PartialViewResult DeleteOffer(int id)
        {
            var offer = entities.Offers.Find(id);
            var playoffer = entities.PlayOffers.Where(o => o.OfferId == id).FirstOrDefault();
            if (playoffer != null)
            {
                entities.PlayOffers.Remove(playoffer);
                entities.SaveChanges();
            }
            var movieoffer = entities.MovieOfferDetails.Where(o => o.OfferId == id).FirstOrDefault();
            if (movieoffer != null)
            {
                entities.MovieOfferDetails.Remove(movieoffer);
                entities.SaveChanges();
            }
            entities.Offers.Remove(offer);
            entities.SaveChanges();
            return PartialView("_Displayoffers",entities.Offers);
        } 
        #endregion 


        public PartialViewResult AddTheatreAdmin()
        {
            return PartialView("_TheatreAdmin");
        }
        [HttpPost]
        public ActionResult AddTheatreAdmin(FormCollection form)
        {
            try
            {
                UserDetail newadmin = new UserDetail();
            newadmin.UserName = form["Username"];
            newadmin.Password = form["Password"];
            int r =Convert.ToInt32(form["RoleDropdown"]);
            if (r == 1)
            {
                newadmin.Role = "theatreAdmin";
            }
            else if (r == 2)
            {
                newadmin.Role = "admin";
            }
            newadmin.Email = form["Email"];
            newadmin.Contact = Convert.ToInt64(form["Contact"]);
            entities.UserDetails.Add(newadmin);
            entities.SaveChanges();
            return View("Admin");
            }
            catch (Exception ex)
            {

                return View("Error", new HandleErrorInfo(ex, "UserHome", "Search"));
            }
        }
        public PartialViewResult AddMovie()
        {
            try {
            DateTime date = DateTime.Now;
            TempData["currentdate"] = date.Year + "-0" + date.Month + "-0" + date.Day;
            return PartialView("_AddMovie");
            }
            catch (Exception ex) { throw ex; }
        }
        public PartialViewResult DisplayAllMovies()
        {
            return PartialView("_DisplayMovies", entities.Movies);
        }
        [HttpPost]
        public PartialViewResult AddMovie(Movy form, HttpPostedFileBase poster1)
        {

            try { 
            Movy movie = new Movy();
            movie.MovieName = form.MovieName;
            movie.ReleaseDate = Convert.ToDateTime(form.ReleaseDate).Date;
            movie.Synopsis = form.Synopsis;
            movie.VideoLink = form.VideoLink;
            if (poster1 != null)
            {
                movie.Poster = new byte[poster1.ContentLength];
                poster1.InputStream.Read(movie.Poster, 0, poster1.ContentLength);
            }
            entities.Movies.Add(movie);
            entities.SaveChanges();
            return PartialView("_AddMovieSuccess");
            }
            catch (Exception ex) { throw ex; }
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