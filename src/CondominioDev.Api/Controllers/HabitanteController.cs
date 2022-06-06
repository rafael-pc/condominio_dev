using CondominioDev.Api.DTOs.Request;
using CondominioDev.Core.Entities;
using CondominioDev.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CondominioDev.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HabitanteController : ControllerBase
    {
        private readonly IHabitanteService _habitanteService;

        public HabitanteController(IHabitanteService habitanteService)
        {
            _habitanteService = habitanteService;
        }

        /// <summary>
        /// Retorna todos habitantes
        /// </summary>
        /// <response code="200">Retorna todos habitantes</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(List<Habitante>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public ActionResult<List<Habitante>> ObterTodosHabitantes()
        {
            var habitantes = _habitanteService.ObterTodosHabitantes();
            if (habitantes == null || habitantes.Count == 0)
                return NoContent();

            return Ok(habitantes);
        }

        /// <summary>
        /// Retorna idade de habitante superior a 30
        /// </summary>
        /// <param idade="age">Dados do habitante</param>
        /// <returns>Retorna a idade do habitante</returns>
        /// <response code="200">Retorna a idade do habitante</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(List<Habitante>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{dataDeNascimento}/idade")]
        public ActionResult<List<Habitante>> ObterIdadeHabitantes(DateTime dataDeNascimento)
        {
            var habitantes = _habitanteService.ObterIdadeHabitantes(dataDeNascimento);

            DateTime now = DateTime.Today;
            int age = now.Year - dataDeNascimento.Year;
            if (now < dataDeNascimento.AddYears(age))
                age--;
            if (habitantes == null || habitantes.Count == 0)
                return NoContent();
            if (age <= 30)
                return NotFound();

            return Ok(age);
        }

        /// <summary>
        /// Retorna habitante por nome
        /// </summary>
        /// <param name="nome">Dados do habitante</param>
        /// <returns>Retorna o nome do habitante</returns>
        /// <response code="200">Retorna o habitante</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{nome}/nome")]
        public ActionResult<List<Habitante>> ObterHabitantesPorNome(string nome)
        {
            var habitantes = _habitanteService.ObterHabitantesPorNome(nome);
            if (habitantes == null || habitantes.Count == 0)
                return NoContent();

            return Ok(habitantes);
        }

        /// <summary>
        /// Retorna habitante pelo id
        /// </summary>
        /// <param Id="id">Dados do habitante</param>
        /// <returns>Retorna habitante pelo id</returns>
        /// <response code="200">Retorna habitante</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public ActionResult<Habitante> ObterHabitantePorId(int id)
        {
            var habitante = _habitanteService.ObterHabitantePorId(id);
            if (habitante == null)
                return NotFound();

            return Ok(habitante);
        }

        /// <summary>
        /// Retorna habitante por data de nascimento
        /// </summary>
        /// <param data="dataDeNascimento">Dados do habitante</param>
        /// <returns>Retorna habitante data de nascimento</returns>
        /// <response code="200">Retorna habitante</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [HttpGet("{dataDeNascimento}/data")]
        public ActionResult<Habitante> ObterHabitanteMes(DateTime dataDeNascimento)
        {
            var habitante = _habitanteService.ObterHabitantePorData(dataDeNascimento);
            if (habitante == null)
                return NotFound();

            return Ok(habitante);
        }

        /// <summary>
        /// Cadastro de habitantes
        /// </summary>
        /// <param Habitante="habitante">Dados do habitantes</param>
        /// <returns>Retorna o dados do habitante criado</returns>
        /// <response code="201">Retorno de habitante criado</response>
        /// <response code="400">Retorna erros de validação</response>
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult CriarHabitante(HabitanteRequest habitante)
        {
            var habitanteEntidade = habitante.ConverterParaEntidade();
            var id = _habitanteService.CriarHabitante(habitanteEntidade);
            return CreatedAtAction(nameof(ObterHabitantePorId), new { Id = id }, id);
        }

        /// <summary>
        /// Exclui habitante pelo id
        /// </summary>
        /// <param Id="id">Codigo do habitante</param>
        /// <returns></returns>
        /// <response code="204">Retorna sucesso</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult ExcluirHabitante(int id)
        {
            try
            {
                _habitanteService.RemoverHabitante(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName.Equals("id"))
                    return NotFound();
                
                return BadRequest();
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, new { Mensagem = ex.Message });
            }
        }
    }
}