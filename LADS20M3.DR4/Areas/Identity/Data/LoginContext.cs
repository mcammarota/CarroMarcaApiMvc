﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LADS20M3.DR4.Areas.Identity.Data
{
    //add-migration CreateLogin -context LoginContext -outputdir Areas\Identity\Data\Migrations
    //update-database -context LoginContext
    public class LoginContext : IdentityDbContext<IdentityUser>
    {
        public LoginContext(DbContextOptions<LoginContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
