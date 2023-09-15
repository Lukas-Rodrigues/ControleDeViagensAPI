using Microsoft.EntityFrameworkCore;
using ProjetoLucas.Model;
using ProjetoLucas.ViewModel;

namespace ProjetoLucas.Repository
{
	public class ViagemRepository : IViagemRepository
	{
		private readonly BdContext _context = new BdContext();
		public void Add(Viagem viagem)
		{
			_context.Viagens.Add(viagem);
			_context.SaveChanges();
		}

		public bool Delete(int id)
		{
			var viagem = GetById(id);

			if (viagem != null)
			{
				_context.Viagens.Remove(viagem);
				_context.SaveChanges();
				return true;
			}
			else
			{
				throw new Exception("Houve um erro na deleção de dados");
			}
		}

		public List<ViagemViewModelExibir> Get()
		{
			var viagensComJoin = _context.Viagens
				.Include(v => v.linha)
				.Include(v => v.motorista)
				.Include(v => v.veiculo)
				.Select(viagem => new ViagemViewModelExibir
				{
					NumeroServico = viagem.NumeroServico,
					NumeroLinha = viagem.linha.numero, 
					Origem = viagem.linha.origem,           
					Destino = viagem.linha.destino,         
					NomeMotorista = viagem.motorista.nome,   
					PlacaVeiculo = viagem.veiculo.placa,     
					DataPartida = viagem.DataPartida,
					DataChegada = viagem.DataChegada
				})
				.ToList();

			return viagensComJoin;
		}
		public Viagem GetById(int idViagem)
		{
			return _context.Viagens.FirstOrDefault(x => x.Id == idViagem);
		}

		public Viagem GetByNumeroServicoEDataPartida(string numeroServico, DateTime dataPartida)
		{
			return _context.Viagens.FirstOrDefault(v => v.NumeroServico == numeroServico && v.DataPartida.Date == dataPartida.Date);

		}

		public List<ViagemViewModelExibir> GetViagensPorData(DateTime dataPartida)
		{
			var viagensComJoin = _context.Viagens
				.Include(v => v.linha)
				.Include(v => v.motorista)
				.Include(v => v.veiculo)
				.Where(viagem => viagem.DataPartida.Date == dataPartida.Date)
				.Select(viagem => new ViagemViewModelExibir
				{
					NumeroServico = viagem.NumeroServico,
					NumeroLinha = viagem.linha.numero,
					Origem = viagem.linha.origem,
					Destino = viagem.linha.destino,
					NomeMotorista = viagem.motorista.nome,
					PlacaVeiculo = viagem.veiculo.placa,
					DataPartida = viagem.DataPartida,
					DataChegada = viagem.DataChegada
				})
				.ToList();

			return viagensComJoin;
		}


		public bool Update(int id, Viagem viagemAtualizada)
		{
			var viagem = GetById(id);

			if (viagem == null)
			{
				return false; 
			}
			if (viagemAtualizada == null)
			{
				return false; 
			}
			viagem.IdVeiculo = viagemAtualizada.IdVeiculo;
			viagem.DataPartida = viagemAtualizada.DataPartida;
			viagem.DataChegada = viagemAtualizada.DataChegada;
			viagem.NumeroServico = viagemAtualizada.NumeroServico;
			viagem.IdMotorista = viagemAtualizada.IdMotorista;
			viagem.IdLinha = viagemAtualizada.IdLinha;

			try
			{
				_context.SaveChanges();
				return true; 
			}
			catch (Exception ex)
			{
				return false;
			}
		}


	}
}
