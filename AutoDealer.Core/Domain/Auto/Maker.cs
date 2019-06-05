using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealer.Core.Domain
{
    public class Maker:BaseEntity
    {
        public Maker()
        {
            this.Brand = new HashSet<Brand>();
            this.Auto = new HashSet<Auto>();
        }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Brand> Brand { get; set; }
        [JsonIgnore]
        public virtual ICollection<Auto> Auto { get; set; }
    }
}
