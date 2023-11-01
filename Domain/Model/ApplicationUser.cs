using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ApplicationUser   {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
