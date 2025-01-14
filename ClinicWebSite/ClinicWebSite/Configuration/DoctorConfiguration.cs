using ClinicWebSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicWebSite.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.DoctorName).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(d => d.FacebookLink).IsRequired().HasColumnType("varchar(200)");
            builder.Property(d => d.TwitterLink).IsRequired().HasColumnType("varchar(200)");
            builder.Property(d => d.InstagramLink).IsRequired().HasColumnType("varchar(200)");
        }
    }
}
