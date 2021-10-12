using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Identity
{
    public class UsuarioPapeis : Microsoft.AspNetCore.Identity.IdentityUserRole<int>
    {
        public Usuario usuario { get; set; }
        public Papeis papeis { get; set; }
    }
}
