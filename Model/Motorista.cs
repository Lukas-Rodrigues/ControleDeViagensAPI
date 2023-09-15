using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLucas.Model
{
	[Table("Motorista")]
	public class Motorista
	{
		[Key]
		public int id { get; private set; }
		public string nome { get; set; }
		public string cpf { get; set; }

		public Motorista() { }
		public Motorista(string Nome, string Cpf)
		{
			this.nome = Nome;
			this.cpf = Cpf;	
		}


	}
}
