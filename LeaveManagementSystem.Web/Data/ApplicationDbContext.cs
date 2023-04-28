﻿using LeaveManagementSystem.Web.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models;

namespace LeaveManagementSystem.Web.Data
{
    //Add the Employee to the Identity Context
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());

        }

        public DbSet<LeaveType>  LeaveTypes { get; set; }
		public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
	
	
		
		
	}
}