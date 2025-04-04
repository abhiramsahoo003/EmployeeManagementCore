﻿using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementCore.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
        {
        }

        public DbSet<EmployeeModel> Employee { get; set; }
    }
}

