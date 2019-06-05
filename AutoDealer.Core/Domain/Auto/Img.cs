using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealer.Core.Domain
{
    public class Img:BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }
}
