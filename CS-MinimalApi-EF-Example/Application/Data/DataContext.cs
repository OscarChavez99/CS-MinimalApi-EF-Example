﻿using CS_MinimalApi_EF_Example.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CS_MinimalApi_EF_Example.Application.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
