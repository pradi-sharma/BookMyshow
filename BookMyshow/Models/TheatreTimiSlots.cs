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

        public string Theatrename { get; set; }
        public List<string> Slots { get; set; }
        public TheatreTimiSlots(int id,List<string> slots,string name)
        {
            this.TheatreId = id;
            this.Slots = slots;
            this.Theatrename = name;
        }
    }
}