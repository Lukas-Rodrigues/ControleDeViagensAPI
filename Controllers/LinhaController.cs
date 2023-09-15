using Microsoft.AspNetCore.Mvc;
using ProjetoLucas.Model;
using ProjetoLucas.Repository;
using ProjetoLucas.ViewModel;

namespace ProjetoLucas.Controllers
{
	[ApiController]
	[Route("api/v1/linha")]
	public class LinhaController : ControllerBase
	{
		private readonly ILinhaRepository _linhaRepository;
		private readonly BdContext _context = new BdContext();
		public LinhaController(ILinhaRepository linhaRepository)
		{
			_linhaRepository = linhaRepository;
		}

		[HttpPost]
		public IActionResult Create([FromForm] LinhaViewModel linhaView)
		{
			var linha = new Linha(linhaView.nome, linhaView.numero, linhaView.destino, linhaView.origem);

			_linhaRepository.Add(linha);
			return Ok(linha);
		}

		[HttpGet]
		public IActionResult Get()
		{
			var Linha = _linhaRepository.Get();
			return Ok(Linha);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var linha = _linhaRepository.GetById(id);
			return Ok(linha);
		}

		[HttpGet("by-Number/{number}")]

		public IActionResult GetNumber(int numero)
		{
			var linha = _linhaRepository.GetByNumber(numero);

			if (linha != null)
			{
				return Ok(linha);
			}
			else
			{
				return NotFound("Motorista não encontrado");
			}
		}



		[HttpDelete]
		public IActionResult Delete(int id)
		{
			_linhaRepository.Delete(id);
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] LinhaViewModel linhaView)
		{
			var linhaAtualizada = new Linha(linhaView.nome, linhaView.numero, linhaView.destino, linhaView.origem);
			var sucesso = _linhaRepository.Update(id, linhaAtualizada);

			if (sucesso)
			{
				return Ok("Motorista atualizado com sucesso");
			}
			else
			{
				return NotFound("Motorista não encontrado");
			}
		}






	}
}
