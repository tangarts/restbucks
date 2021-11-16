﻿using Microsoft.EntityFrameworkCore;

namespace RestbucksCore
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
    }
}
