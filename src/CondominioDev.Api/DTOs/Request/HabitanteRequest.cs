using CondominioDev.Core.Entities;

namespace CondominioDev.Api.DTOs.Request
{
    public class HabitanteRequest
    {      
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public decimal Renda { get; set; }
        public string CPF { get; set; }

        public Habitante ConverterParaEntidade()
        {
            return new Habitante(Nome, Sobrenome, DataDeNascimento, Renda, CPF);
        }
    }
}