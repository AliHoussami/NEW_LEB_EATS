﻿using Microsoft.EntityFrameworkCore;
namespace TEST2.Models

{
    public class YourDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {

        }
    }
}
