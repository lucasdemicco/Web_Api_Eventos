using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.DTO
{
    public class RedeSocialDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da Rede social é obrigatório")]
        public string Nome { get; set; }
        public string Url { get; set; }
    }
}
