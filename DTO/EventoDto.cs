using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.DTO
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O tema deve ser preenchido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Deve conter de 3 a 100 caracteres")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "O local deve ser preenchido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Deve conter de 3 a 100 caracteres")]
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Range(2,120000, ErrorMessage ="Evento deve conter de 2 a 120mil pessoas")]
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string ImagemUrl { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes{ get; set; }
    }
}
