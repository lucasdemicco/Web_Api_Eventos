using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Identity
{
    public class Usuario : Microsoft.AspNetCore.Identity.IdentityUser<int>
    {
        [Column(TypeName ="nvarchar(150)")]
        public string FullName { get; set; }
        public List<UsuarioPapeis> UsuarioPapeis { get; set; }
    }
}
