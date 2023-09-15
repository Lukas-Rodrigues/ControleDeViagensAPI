using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLucas.Model
{
	[Table ("Linha")]
	public class Linha
	{
		[Key]
		public int id { get; set; }
		public string nome { get; set; }
		public int numero { get; set; }
		public string origem { get; set; }
		public string destino { get; set; }

		public Linha() { }
		public Linha(string Nome, int numero,string origem,string destino)
		{
			this.nome = Nome;
			this.numero = numero;
			this.origem = origem;
			this.destino= destino;	
		}

	}
}
