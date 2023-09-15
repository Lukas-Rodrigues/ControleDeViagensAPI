using ProjetoLucas.Model;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLucas.ViewModel
{
	public class ViagemViewModel
	{
		public string NumeroServico { get; set; }
		public int IdLinha { get; set; }
		public int? IdMotorista { get; set; }
		public int? IdVeiculo { get; set; }
		public DateTime DataPartida { get; set; }
		public DateTime DataChegada { get; set; }
	}
}
