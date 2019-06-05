using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using AutoDealer.Core.Domain;

namespace AutoDealer.Data.Mapping
{
    public class AutoMap : EntityTypeConfiguration<Auto>
    {
        public AutoMap()
        {
            this.HasKey(a => a.ID);
            this.Property(a => a.Name).IsRequired().HasMaxLength(64);
            this.Property(a => a.Price);
            this.Property(a => a.CreateDate);
            this.Property(a => a.Year);
            this.Property(a => a.Mileage);
            this.Property(a => a.ExteriorColor).HasMaxLength(32);
            this.Property(a => a.InteriorColor).HasMaxLength(32);
            this.Property(a => a.InteriorColor).HasMaxLength(32);
            this.Property(a => a.BodyStyle).HasMaxLength(32);
            this.Property(a => a.Description).HasMaxLength(2000);
            this.Property(a => a.Transmission).HasMaxLength(32);
            this.Property(a => a.Condition).HasMaxLength(32);
            this.Property(a => a.Engine).HasMaxLength(32);
            this.Property(a => a.DriveType).HasMaxLength(32);
            this.HasOptional(a => a.Img);
            this.Property(a => a.Status);
            this.Property(a => a.Sort);
        }
    }

    public class MakerMap : EntityTypeConfiguration<Maker>
    {
        public MakerMap()
        {
            this.HasKey(m => m.ID);
            this.Property(m => m.Name).IsRequired().HasMaxLength(64);
            this.HasOptional(m=>m.Brand);
            this.HasOptional(m=>m.Auto);
        }
    }

    public class BrandMap : EntityTypeConfiguration<Brand>
    {
        public BrandMap()
        {
            this.HasKey(b => b.ID);
            this.Property(b => b.Name).IsRequired().HasMaxLength(64);
            this.HasOptional(b=>b.Auto);
        }
    }

    public class ImgMap : EntityTypeConfiguration<Img>
    {
        public ImgMap()
        {
            this.HasKey(i => i.ID);
            this.Property(i => i.Name).IsRequired().HasMaxLength(64);
            this.Property(i => i.Address).IsRequired().HasMaxLength(512);
        }
    }
}
