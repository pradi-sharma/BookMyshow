//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookMyshow.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movy()
        {
            this.BookedSeats = new HashSet<BookedSeat>();
            this.MovieOfferDetails = new HashSet<MovieOfferDetail>();
            this.TicketDetails = new HashSet<TicketDetail>();
            this.TimeSlots = new HashSet<TimeSlot>();
            this.Casts = new HashSet<Cast>();
            this.Theatres = new HashSet<Theatre>();
        }
    
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Synopsis { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public byte[] Poster { get; set; }
        public int IntrestedUsers { get; set; }
        public string VideoLink { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookedSeat> BookedSeats { get; set; }
        public virtual Cast Cast { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieOfferDetail> MovieOfferDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeSlot> TimeSlots { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cast> Casts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Theatre> Theatres { get; set; }
    }
}
