using Microsoft.AspNetCore.Mvc;
using ProjetoLucas.Model;
using ProjetoLucas.Repository;
using ProjetoLucas.ViewModel;

namespace ProjetoLucas.Controllers
{
	[ApiController]
	[Route("api/v1/veiculo")]
	public class VeiculoController : ControllerBase
	{
		private readonly IVeiculoRepository _veiculoRepository;
		private readonly BdContext _context = new BdContext();
		public VeiculoController(IVeiculoRepository veiculorepository)
		{
			_veiculoRepository = veiculorepository;
		}

		[HttpPost]
		public IActionResult Create(VeiculoViewModel veiculoView)
		{
			var veiculo = new Veiculo(veiculoView.placa);
			_veiculoRepository.Add(veiculo);
			return Ok(veiculo);
		}
		[HttpGet]
		public IActionResult Get()
		{
			var veiculos = _veiculoRepository.Get();
			return Ok(veiculos);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var Motorista = _veiculoRepository.GetById(id);
			return Ok(Motorista);
		}

		[HttpGet("by-placa/{placa}")]
		public IActionResult GetPlaca(string placa)
		{
			var veiculo = _veiculoRepository.GetByPlaca(placa);

			if (veiculo != null)
			{
				return Ok(veiculo);
			}
			else
			{
				return NotFound("veiculo não encontrado");
			}
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			_veiculoRepository.Delete(id);
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] VeiculoViewModel veiculoView)
		{
			var veiculoAtualizado = new Veiculo(veiculoView.placa);
			var sucesso = _veiculoRepository.Update(id, veiculoAtualizado);

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
