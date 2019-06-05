using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealer.Core.Domain
{
    public class Role:IdentityRole
    {
        public Role() : base() { }
        public Role(string name) : base(name) { }
        public string RoleType { get; set; }
    }
}
