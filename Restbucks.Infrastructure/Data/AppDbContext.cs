// <copyright file="AppDbContext.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Restbucks.Core
{
    using Microsoft.EntityFrameworkCore;
    using Restbucks.Core.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders => this.Set<Order>();
    }
}