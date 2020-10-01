using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContextLib.Confg
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "RegisteredUser",
                    NormalizedName = "REGISTEREDUSER"
                },
                new IdentityRole
                {
                    Name = "Author",
                    NormalizedName = "AUTHOR"
                });
        }
    }
}
