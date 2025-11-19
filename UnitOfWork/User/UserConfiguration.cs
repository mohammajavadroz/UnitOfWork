using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Infrastructure.User
{
    public class UserConfiguration : IEntityTypeConfiguration<UnitOfWork.Domain.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User.User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
        }
    }
}
