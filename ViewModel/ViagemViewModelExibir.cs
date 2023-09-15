using ProjetoLucas.Model;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLucas.ViewModel
{
	public class ViagemViewModelExibir
	{
		public string NumeroServico { get; set; }
		public int NumeroLinha { get; set; }
		public string Origem { get; set; }
		public string Destino { get; set; }
		public string NomeMotorista { get; set; }
		public string PlacaVeiculo { get; set; }
		public DateTime DataPartida { get; set; }
		public DateTime DataChegada { get; set; }
	}

}
