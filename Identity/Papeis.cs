using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Identity
{
    public class Papeis : IdentityRole<int>
    {
        public List<UsuarioPapeis> UsuarioPapeis { get; set; }
    }
}
