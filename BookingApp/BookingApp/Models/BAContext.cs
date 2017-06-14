using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using BookingApp.Models.AppModel;

namespace BookingApp.Models
{
    public class BAContext: IdentityDbContext<BAIdentityUser>
    {   
        public virtual DbSet<AppUser> AppUsers { get; set; }

        public virtual DbSet<Accommodation> Accommodations { get; set; }

        public virtual DbSet<AccommodationType>  AccommodationTypes{ get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Place> Places { get; set; }

        public virtual DbSet<Region> Regions { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<RoomReservations> RoomsReservations { get; set; }

        public BAContext()
<<<<<<< HEAD
            : base("MVBookingDB")
=======
            : base("MVBookingDB11")
>>>>>>> cae89cd3ebe4c6522cb7438dbead7addb3656258
        {
        }

        public static BAContext Create()
        {
            return new BAContext();
        }
    }
}