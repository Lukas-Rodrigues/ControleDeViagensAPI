using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLucas.Model
{
	[Table("Veiculo")]
	public class Veiculo
	{
		[Key]
		public int id { get; set; }
		public string placa { get; set; }
		public Veiculo(string placa)
		{
			this.placa = placa;	
		}
		public Veiculo() { }
		

		
	}
}
