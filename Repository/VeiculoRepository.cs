using ProjetoLucas.Model;

namespace ProjetoLucas.Repository
{
	public class VeiculoRepository : IVeiculoRepository
	{
		private readonly BdContext _context = new BdContext();
		public void Add(Veiculo veiculo)
		{
			_context.Veiculos.Add(veiculo);
			_context.SaveChanges();
		}

		public bool Delete(int id)
		{
			var veiculo = GetById(id);

			if (veiculo != null)
			{
				_context.Veiculos.Remove(veiculo);
				_context.SaveChanges();
				return true;
			}
			else
			{
				throw new Exception("Houve um erro na deleção de dados");
			}
		}

		public List<Veiculo> Get()
		{
			return _context.Veiculos.ToList();	
		}

		public Veiculo GetById(int idVeiculo)
		{
			return _context.Veiculos.FirstOrDefault(x => x.id == idVeiculo);
		}

		public Veiculo GetByPlaca(string placa)
		{
			return _context.Veiculos.FirstOrDefault(x => x.placa == placa);
		}

		public bool Update(int id, Veiculo veiculoAtualizado)
		{
			var veiculo = GetById(id);

			if (veiculo == null)
			{
				return false;
			}
			veiculo.placa = veiculoAtualizado.placa;
			_context.SaveChanges();
			return true; 
		}
	}
}
