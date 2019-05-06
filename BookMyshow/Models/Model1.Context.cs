﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ShowBookingEntities : DbContext
    {
        public ShowBookingEntities()
            : base("name=ShowBookingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookedSeat> BookedSeats { get; set; }
        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<MovieOfferDetail> MovieOfferDetails { get; set; }
        public virtual DbSet<Movy> Movies { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PlayOffer> PlayOffers { get; set; }
        public virtual DbSet<Play> Plays { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<Theatre> Theatres { get; set; }
        public virtual DbSet<TheatreSeat> TheatreSeats { get; set; }
        public virtual DbSet<TicketDetail> TicketDetails { get; set; }
        public virtual DbSet<TicketSeat> TicketSeats { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual int FillSeats(Nullable<int> seatNumber)
        {
            var seatNumberParameter = seatNumber.HasValue ?
                new ObjectParameter("seatNumber", seatNumber) :
                new ObjectParameter("seatNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FillSeats", seatNumberParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int InsertIntoTheatreSeats(Nullable<int> theatreId, string seatNumber, string status)
        {
            var theatreIdParameter = theatreId.HasValue ?
                new ObjectParameter("TheatreId", theatreId) :
                new ObjectParameter("TheatreId", typeof(int));
    
            var seatNumberParameter = seatNumber != null ?
                new ObjectParameter("SeatNumber", seatNumber) :
                new ObjectParameter("SeatNumber", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertIntoTheatreSeats", theatreIdParameter, seatNumberParameter, statusParameter);
        }
    
        public virtual ObjectResult<GetCasts_Result> GetCasts(Nullable<int> moviId)
        {
            var moviIdParameter = moviId.HasValue ?
                new ObjectParameter("moviId", moviId) :
                new ObjectParameter("moviId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCasts_Result>("GetCasts", moviIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> checkTheatre(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("checkTheatre", userIdParameter);
        }
    
        public virtual ObjectResult<GetMoviesDescription_Result> GetMoviesDescription()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMoviesDescription_Result>("GetMoviesDescription");
        }
    
        public virtual ObjectResult<Nullable<int>> GetTheatres(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetTheatres", idParameter);
        }
    
        public virtual ObjectResult<Nullable<System.TimeSpan>> GetSlots(Nullable<int> tId, Nullable<int> mId)
        {
            var tIdParameter = tId.HasValue ?
                new ObjectParameter("tId", tId) :
                new ObjectParameter("tId", typeof(int));
    
            var mIdParameter = mId.HasValue ?
                new ObjectParameter("mId", mId) :
                new ObjectParameter("mId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.TimeSpan>>("GetSlots", tIdParameter, mIdParameter);
        }
    
        public virtual ObjectResult<MovyByCity_Result> MovyByCity(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MovyByCity_Result>("MovyByCity", idParameter);
        }
    
        public virtual ObjectResult<string> GetSelectSeats(Nullable<int> theatreId)
        {
            var theatreIdParameter = theatreId.HasValue ?
                new ObjectParameter("theatreId", theatreId) :
                new ObjectParameter("theatreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetSelectSeats", theatreIdParameter);
        }
    
        public virtual ObjectResult<string> GetBlockedSeats(Nullable<int> theatreId, Nullable<int> slotId, Nullable<int> movieId)
        {
            var theatreIdParameter = theatreId.HasValue ?
                new ObjectParameter("TheatreId", theatreId) :
                new ObjectParameter("TheatreId", typeof(int));
    
            var slotIdParameter = slotId.HasValue ?
                new ObjectParameter("SlotId", slotId) :
                new ObjectParameter("SlotId", typeof(int));
    
            var movieIdParameter = movieId.HasValue ?
                new ObjectParameter("MovieId", movieId) :
                new ObjectParameter("MovieId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetBlockedSeats", theatreIdParameter, slotIdParameter, movieIdParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> GetPrice(Nullable<int> theatreId, Nullable<int> movieId, Nullable<int> slotId)
        {
            var theatreIdParameter = theatreId.HasValue ?
                new ObjectParameter("TheatreId", theatreId) :
                new ObjectParameter("TheatreId", typeof(int));
    
            var movieIdParameter = movieId.HasValue ?
                new ObjectParameter("MovieId", movieId) :
                new ObjectParameter("MovieId", typeof(int));
    
            var slotIdParameter = slotId.HasValue ?
                new ObjectParameter("slotId", slotId) :
                new ObjectParameter("slotId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("GetPrice", theatreIdParameter, movieIdParameter, slotIdParameter);
        }
    
        public virtual int InsertTicketSeats(Nullable<int> ticketId, string seat)
        {
            var ticketIdParameter = ticketId.HasValue ?
                new ObjectParameter("ticketId", ticketId) :
                new ObjectParameter("ticketId", typeof(int));
    
            var seatParameter = seat != null ?
                new ObjectParameter("seat", seat) :
                new ObjectParameter("seat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertTicketSeats", ticketIdParameter, seatParameter);
        }
    
        public virtual int InsertBookedSeat(Nullable<int> theatreId, Nullable<int> slotId, Nullable<int> movieId, string seat, Nullable<int> userId)
        {
            var theatreIdParameter = theatreId.HasValue ?
                new ObjectParameter("theatreId", theatreId) :
                new ObjectParameter("theatreId", typeof(int));
    
            var slotIdParameter = slotId.HasValue ?
                new ObjectParameter("slotId", slotId) :
                new ObjectParameter("slotId", typeof(int));
    
            var movieIdParameter = movieId.HasValue ?
                new ObjectParameter("MovieId", movieId) :
                new ObjectParameter("MovieId", typeof(int));
    
            var seatParameter = seat != null ?
                new ObjectParameter("seat", seat) :
                new ObjectParameter("seat", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertBookedSeat", theatreIdParameter, slotIdParameter, movieIdParameter, seatParameter, userIdParameter);
        }
    
        public virtual int InsertTheatreMovy(Nullable<int> theatreId, Nullable<int> movieId)
        {
            var theatreIdParameter = theatreId.HasValue ?
                new ObjectParameter("theatreId", theatreId) :
                new ObjectParameter("theatreId", typeof(int));
    
            var movieIdParameter = movieId.HasValue ?
                new ObjectParameter("movieId", movieId) :
                new ObjectParameter("movieId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertTheatreMovy", theatreIdParameter, movieIdParameter);
        }
    
        public virtual ObjectResult<GetMoviesList_Result> GetMoviesList(Nullable<int> theatreId)
        {
            var theatreIdParameter = theatreId.HasValue ?
                new ObjectParameter("theatreId", theatreId) :
                new ObjectParameter("theatreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMoviesList_Result>("GetMoviesList", theatreIdParameter);
        }
    
        public virtual int deleteMovie(Nullable<int> theatreaid, Nullable<int> movieId, Nullable<int> slotId)
        {
            var theatreaidParameter = theatreaid.HasValue ?
                new ObjectParameter("theatreaid", theatreaid) :
                new ObjectParameter("theatreaid", typeof(int));
    
            var movieIdParameter = movieId.HasValue ?
                new ObjectParameter("MovieId", movieId) :
                new ObjectParameter("MovieId", typeof(int));
    
            var slotIdParameter = slotId.HasValue ?
                new ObjectParameter("slotId", slotId) :
                new ObjectParameter("slotId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteMovie", theatreaidParameter, movieIdParameter, slotIdParameter);
        }
    
        public virtual int deleteMovie1(Nullable<int> theatreaid, Nullable<int> movieId, Nullable<int> slotId)
        {
            var theatreaidParameter = theatreaid.HasValue ?
                new ObjectParameter("theatreaid", theatreaid) :
                new ObjectParameter("theatreaid", typeof(int));
    
            var movieIdParameter = movieId.HasValue ?
                new ObjectParameter("MovieId", movieId) :
                new ObjectParameter("MovieId", typeof(int));
    
            var slotIdParameter = slotId.HasValue ?
                new ObjectParameter("slotId", slotId) :
                new ObjectParameter("slotId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteMovie1", theatreaidParameter, movieIdParameter, slotIdParameter);
        }
    
        public virtual ObjectResult<GetMoviesList1_Result> GetMoviesList1(Nullable<int> theatreId)
        {
            var theatreIdParameter = theatreId.HasValue ?
                new ObjectParameter("theatreId", theatreId) :
                new ObjectParameter("theatreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMoviesList1_Result>("GetMoviesList1", theatreIdParameter);
        }
    
        public virtual int sp_alterdiagram1(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram1", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram1(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram1", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram1(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram1", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition1_Result> sp_helpdiagramdefinition1(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition1_Result>("sp_helpdiagramdefinition1", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams1_Result> sp_helpdiagrams1(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams1_Result>("sp_helpdiagrams1", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram1(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram1", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams1");
        }
    
        public virtual int InsertTheatreUser(Nullable<int> theatreId, Nullable<int> userId)
        {
            var theatreIdParameter = theatreId.HasValue ?
                new ObjectParameter("TheatreId", theatreId) :
                new ObjectParameter("TheatreId", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertTheatreUser", theatreIdParameter, userIdParameter);
        }
    }
}
