// <copyright file="OrderDbContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Restbucks.Core
{
    using Microsoft.EntityFrameworkCore;
    using Restbucks.Core.Models;

    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders => this.Set<Order>();
    }
}