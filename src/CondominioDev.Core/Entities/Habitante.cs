using System.ComponentModel.DataAnnotations;

namespace CondominioDev.Core.Entities
{
    public class Habitante : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O {0} tem que ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Nome { get; private set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100, ErrorMessage = "O {0} tem que ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Sobrenome { get; private set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public DateTime DataDeNascimento { get; private set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public decimal Renda { get; private set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public string CPF { get; private set; }

        public Habitante()
        {
        }

        public Habitante(string nome, string sobrenome, DateTime dataDeNascimento, decimal renda, string cpf)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataDeNascimento = dataDeNascimento;
            Renda = renda;
            CPF = cpf;
        }
    }
}