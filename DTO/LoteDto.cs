using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.DTO
{
    public class LoteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do lote é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Deve conter de 3 a 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço do lote é obrigatório")]
        public string Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }

        [Required(ErrorMessage ="Quantidade de Lotes é obrigatório")]
        public int Quantidade { get; set; }
    }
}
