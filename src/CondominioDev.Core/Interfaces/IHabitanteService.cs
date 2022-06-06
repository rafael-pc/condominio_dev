using CondominioDev.Core.Entities;

namespace CondominioDev.Core.Interfaces
{
    public interface IHabitanteService
    {
        public List<Habitante> ObterTodosHabitantes();
        public List<Habitante> ObterIdadeHabitantes(DateTime dataDeNascimento);
        public List<Habitante> ObterHabitantesPorNome(string nome);
        public Habitante? ObterHabitantePorId(int id);
        public Habitante? ObterHabitantePorData(DateTime dataDeNascimento);
        public int CriarHabitante(Habitante habitante);
        public void RemoverHabitante(int id);
    }
}