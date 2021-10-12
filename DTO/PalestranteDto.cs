using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.DTO
{
    public class PalestranteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Deve conter de 3 a 100 caracteres")]
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemUrl { get; set; }

        [Phone]
        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<EventoDto> Eventos { get; set; }
    }
}
