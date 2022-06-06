using CondominioDev.Core.Data.Context;
using CondominioDev.Core.Entities;
using CondominioDev.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondominioDev.Core.Services
{
    public class HabitanteService : IHabitanteService
    {
        private readonly DataContext _context;
        public HabitanteService(DataContext context)
        {
            _context = context;
        }
        public List<Habitante> ObterTodosHabitantes()
        {
            return _context.Habitantes
                .ToList();
        }
        public List<Habitante> ObterIdadeHabitantes(DateTime dataDeNascimento)
        {
            return _context.Habitantes
                .ToList();
        }
        public List<Habitante> ObterHabitantesPorNome(string nome)
        {
            return _context.Habitantes             
                .Where(p => string.IsNullOrWhiteSpace(nome) || p.Nome.Contains(nome))
                .ToList();
        }
        public Habitante? ObterHabitantePorId(int id)
        {
            return _context.Habitantes
                .FirstOrDefault(p => p.Id == id);
        }
        public Habitante? ObterHabitantePorData(DateTime dataDeNascimento)
        {
            return _context.Habitantes
                .FirstOrDefault(p => p.DataDeNascimento == dataDeNascimento);
        }
        public int CriarHabitante(Habitante habitante)
        {
            _context.Habitantes.Add(habitante);
            _context.SaveChanges();
            return habitante.Id;
        }
        public void RemoverHabitante(int id)
        {
            var habitante = ObterHabitantePorId(id);
            if (habitante == null)
                throw new ArgumentException("O habitante com o identificador informado não existe", "id");

            _context.Habitantes.Remove(habitante);
            _context.SaveChanges();
        }
    }
}