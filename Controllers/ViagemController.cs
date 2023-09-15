using Microsoft.AspNetCore.Mvc;
using ProjetoLucas.Model;
using ProjetoLucas.Repository;
using ProjetoLucas.ViewModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ProjetoLucas.Controllers
{
	[ApiController]
	[Route("api/v1/viagem")]
	public class ViagemController : ControllerBase
	{
		private readonly IViagemRepository _viagemRepository;
		private readonly BdContext _context = new BdContext();
		public ViagemController(IViagemRepository viagemRepository)
		{
			_viagemRepository = viagemRepository;
		}

		[HttpPost]
		public IActionResult Create([FromForm] ViagemViewModel viagemView)
		{
			var existingViagem = _viagemRepository.GetByNumeroServicoEDataPartida(viagemView.NumeroServico, viagemView.DataPartida);

			if (existingViagem != null)
			{
				return BadRequest("Já existe uma viagem com o mesmo número de serviço e data de partida.");
			}

			var viagem = new Viagem(viagemView.NumeroServico, viagemView.IdLinha, viagemView.IdMotorista, viagemView.IdVeiculo, viagemView.DataPartida, viagemView.DataChegada);

			_viagemRepository.Add(viagem);
			return Ok(viagem);
		}

		[HttpGet]
		public IActionResult Get()
		{

			var viagens = _viagemRepository.Get();

			return Ok(viagens);
		}

		[HttpGet("por-data/{dataPartida:datetime}")]
		public IActionResult GetViagensPorData([FromQuery] DateTime datapartida)
		{
			var viagens = _viagemRepository.GetViagensPorData(datapartida);

			if (viagens != null)
			{
				return Ok(viagens);
			}
			else
			{
				return NotFound("não existe viagens com essa data");
			}
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] ViagemViewModel viagemView)
		{
			var viagem = new Viagem(viagemView.NumeroServico, viagemView.IdLinha, viagemView.IdMotorista, viagemView.IdVeiculo, viagemView.DataPartida, viagemView.DataChegada);
			var sucesso = _viagemRepository.Update(id, viagem);
			if (sucesso)
			{
				return Ok(" atualizado com sucesso");
			}
			else
			{
				return NotFound("Viagem não encontrada");
			}
		}
			
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			_viagemRepository.Delete(id);
			return Ok();
		}


	}

}
