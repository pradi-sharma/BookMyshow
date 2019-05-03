using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyshow.Models
{
    public class MoviePosters
    {
        public int MovieId { get; set; }
        public string MoviePhoto { get; set; }
        public string Moviename { get; set; }
        public MoviePosters(int id,string poster,string moviename)
        {
            this.MovieId = id;
            this.MoviePhoto = poster;
            this.Moviename = moviename;
        }
    }
}