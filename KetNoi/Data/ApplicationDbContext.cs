using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NghiepVu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoiDB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelNumber> HotelNumbers { get; set; }
        public DbSet<Amentity> Amentities { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "La Vela Saigon Hotel",
                    Description = "TP. Hồ Chí Minh, Việt Nam",
                    Price = 100,
                    SquareMeters = 20,
                    Occupancy = 2,
                    ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/464640824.jpg?k=2ce1467d833309a6d9e4f1e5d35ba87454a50bcf620cc5926b410aca8148c219&o=&hp=1",
                },
                new Hotel
                {
                    Id = 2,
                    Name = "La Vela Saigon Hotel",
                    Description = "TP. Hồ Chí Minh, Việt Nam",
                    Price = 100,
                    SquareMeters = 20,
                    Occupancy = 2,
                    ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/325222137.jpg?k=56c624212a1b3f9257f34cc3980bc256becdc6bd4483079fac54b5d42e1c7147&o=&hp=1",
                },
                new Hotel
                {
                    Id = 3,
                    Name = "La Vela Saigon Hotel",
                    Description = "TP. Hồ Chí Minh, Việt Nam",
                    Price = 100,
                    SquareMeters = 20,
                    Occupancy = 2,
                    ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/257933259.jpg?k=ce22ef5c93a25d9c1667f09f8c4caf2fea5c7d094433788b71a37dbb16d96c15&o=&hp=1",
                },
                new Hotel
                {
                    Id = 4,
                    Name = "La Vela Saigon Hotel",
                    Description = "TP. Hồ Chí Minh, Việt Nam",
                    Price = 100,
                    SquareMeters = 20,
                    Occupancy = 2,
                    ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/388865161.jpg?k=02afa7769a3ec4fb788fdcefac0ad814a36e43d2022b92b5e5e3114cb98040c7&o=&hp=1",
                }
                );

            modelBuilder.Entity<HotelNumber>().HasData(
                new HotelNumber
                {
                    Hotel_Number = 101,
                    HotelId = 1,
                },
                new HotelNumber
                {
                    Hotel_Number = 102,
                    HotelId = 1,
                },
                new HotelNumber
                { 
                    Hotel_Number = 103,
                    HotelId = 1,
                },
                new HotelNumber
                { 
                    Hotel_Number = 104,
                    HotelId = 1,
                }
                );

            modelBuilder.Entity<Amentity>().HasData(
                new Amentity
                {
                    Id = 1,
                    Name = "Bể bơi",
                    Description = "Bể bơi ngoài trời",
                    HotelId = 1,
                },
                new Amentity
                {
                    Id = 2,
                    Name = "Bể bơi",
                    Description = "Bể bơi trong nhà",
                    HotelId = 1,
                },
                new Amentity
                {
                    Id = 3,
                    Name = "Wifi",
                    Description = "Wifi 5G",
                    HotelId = 2,
                }
                );
        }
    }
}
