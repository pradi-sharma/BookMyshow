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
    
    public partial class Play
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Play()
        {
            this.PlayOffers = new HashSet<PlayOffer>();
        }
    
        public int PlayId { get; set; }
        public string PlayName { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public byte[] Poster { get; set; }
        public string Synopsis { get; set; }
        public Nullable<int> IntrestedUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayOffer> PlayOffers { get; set; }
    }
}
