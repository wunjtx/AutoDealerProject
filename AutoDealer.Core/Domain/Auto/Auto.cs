using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealer.Core.Domain
{
    public class Auto : BaseEntity
    {
        public string Name { get; set; }

        public double? Price { get; set; }

        public DateTime? CreateDate { get; set; }

        public string Description { get; set; }

        public int? Mileage { get; set; }

        public int? Sort { get; set; }

        public DateTime? Year  { get; set; }

        public string ExteriorColor { get; set; }

        public string InteriorColor { get; set; }

        public string BodyStyle { get; set; }

        public string Transmission { get; set; }

        public string Condition { get; set; }

        public string Engine { get; set; }

        public string DriveType { get; set; }

        public short? Status { get; set; }

        public Brand Brand { get; set; }

        public Maker Maker { get; set; }

        [JsonIgnore]
        public virtual ICollection<Img> Img { get; set; }
    }
}
