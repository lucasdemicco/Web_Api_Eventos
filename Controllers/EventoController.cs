using AutoMapper;
using Eventos.Data;
using Eventos.DTO;
using Eventos.Models;
using Eventos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventosRepository _repo;

        private readonly IMapper _mapper;

        public EventoController(IEventosRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventos()
        {
            try 
            {
                var eventos = await _repo.GetAllEventosAsync(true);
                var resultados = _mapper.Map<EventoDto[]>(eventos);
                return Ok(resultados);
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEventosPorId(int Id)
        {
            try
            {
                var evento = await _repo.GetEventosById(Id, true);
                var resultados = _mapper.Map<EventoDto>(evento);
                return Ok(resultados);
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> GetEventosPorTema(string tema)
        {
            try
            {
                var eventos = await _repo.GetEventosByTema(tema, true);
                var resultados = _mapper.Map<EventoDto[]>(eventos);
                return Ok(resultados);
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostEvento(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _repo.Add(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", _mapper.Map<Evento>(model));
                }
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutEvento(int Id, EventoDto model)
        {
            try
            {
                var evento = await _repo.GetEventosById(Id, false);
                if (evento == null) return NotFound();

                _mapper.Map(model, evento);

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", _mapper.Map<Evento>(model));
                }
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEvento(int Id)
        {
            try
            {
                var evento = await _repo.GetEventosById(Id, false);
                if (evento == null) return NotFound();

                _repo.Delete(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest();
        }


    }
}
