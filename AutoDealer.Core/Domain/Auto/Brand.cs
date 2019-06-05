using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealer.Core.Domain
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Auto> Auto { get; set; }
    }
}
