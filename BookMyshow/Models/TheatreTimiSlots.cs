using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyshow.Models
{
    public class TheatreTimiSlots
    {
        public int TheatreId { get; set; }
        public List<TimeSpan> Slots { get; set; }
        public TheatreTimiSlots(int id,List<TimeSpan> slots)
        {
            this.TheatreId = id;
            this.Slots = slots;
        }
    }
}