using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoLucas.Model
{
	public class Viagem
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Id_Linha")]
		public int IdLinha { get; set; }
		[ForeignKey("Id_Motorista")]
		public int? IdMotorista { get; set; }
		[ForeignKey("Id_Veiculo")]
		public int? IdVeiculo { get; set; }
		public string NumeroServico { get; set; }
		public DateTime DataPartida { get; set; } 
		public DateTime DataChegada { get; set; } 
		[JsonIgnore]
		public Linha linha { get; set; }
		[JsonIgnore]
		public Motorista motorista { get; set; }
		[JsonIgnore]
		public Veiculo veiculo { get; set; }

		public Viagem() { }
		public Viagem(string numeroServico, int idLinha, int? idVeiculo, int? idMotorista,DateTime dataPartida, DateTime dataChegada)
		{
			NumeroServico = numeroServico;
			IdLinha = idLinha;
			IdMotorista = idMotorista;
			IdVeiculo = idVeiculo;
			DataPartida = dataPartida;
			DataChegada = dataChegada;
		}



	}

}
