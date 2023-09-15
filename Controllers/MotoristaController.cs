using Microsoft.AspNetCore.Mvc;
using ProjetoLucas.Model;
using ProjetoLucas.Repository;
using ProjetoLucas.ViewModel;

namespace ProjetoLucas.Controllers
{
	[ApiController]
	[Route("api/v1/motorista")]
	public class MotoristaController : ControllerBase
	{
		private readonly IMotoristaRepository _motoristarepository;
		private readonly BdContext _context = new BdContext();
		public MotoristaController(IMotoristaRepository motoristarepository)
		{
			_motoristarepository = motoristarepository;
		}

		[HttpPost]
		public IActionResult Create([FromForm] MotoristaViewModel motoristaView)
		{
			var motorista = new Motorista(motoristaView.nome,motoristaView.cpf);
			var CPFExists = _motoristarepository.GetByCpf(motoristaView.cpf);

			if (CPFExists != null)
			{
				return BadRequest("CPF já existe");
			}
			_motoristarepository.Add(motorista);	
			return Ok(motorista);
		}

		[HttpGet]
		public IActionResult Get()
		{
			var motoristas = _motoristarepository.Get();
			return Ok(motoristas);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var Motorista = _motoristarepository.GetById(id);
			return Ok(Motorista);
		}

		[HttpGet("by-cpf/{cpf}")]

		public IActionResult GetCpf(string cpf)
		{
			var motorista = _motoristarepository.GetByCpf(cpf);

			if (motorista != null)
			{
				return Ok(motorista);
			}
			else
			{
				return NotFound("Motorista não encontrado");
			}
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			_motoristarepository.Delete(id);
			return Ok();
		}
		
		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] MotoristaViewModel motoristaView)
		{
			var motoristaAtualizado = new Motorista(motoristaView.nome, motoristaView.cpf);
			var sucesso = _motoristarepository.Update(id, motoristaAtualizado);

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
