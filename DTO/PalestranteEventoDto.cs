﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.DTO
{
    public class PalestranteEventoDto
    {
        public int PalestranteId { get; set; }
        public PalestranteDto Palestrante { get; set; }
        public int EventoId { get; set; }
        public EventoDto Evento { get; set; }
        public List<EventoDto> Eventos { get; set; }
    }
}
