using Eventos.Data;
using Eventos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Repositories
{
    public class EventosRepository : IEventosRepository
    {

        private readonly DataContext _context;

        public EventosRepository(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }


        //EVENTOS
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query.Include(p => p.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async  Task<Evento> GetEventosById(int Id, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
           .Include(c => c.Lotes)
           .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query.Include(p => p.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetEventosByTema(string Tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
           .Include(c => c.Lotes)
           .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query.Include(p => p.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Tema.ToLower().Contains(Tema.ToLower()));

            return await query.ToArrayAsync();
        }

        //PALESTRANTES
        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
           .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.Where(p => nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> GetPalestranteById(int PalestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
           .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(c => c.Nome)
                .Where(c => c.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
