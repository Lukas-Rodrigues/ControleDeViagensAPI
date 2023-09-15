using System.ComponentModel.DataAnnotations;

namespace ProjetoLucas.ViewModel
{
	public class LinhaViewModel
	{
		[Required(ErrorMessage = "Digite o nome")]
		public string nome { get; set; }
		[Required(ErrorMessage = "Digite o número")]
		public int numero { get; set; }
		[Required(ErrorMessage = "Digite a origem")]
		public string origem { get; set; }
		[Required(ErrorMessage = "Digite o destino")]
		public string destino { get; set; }
	}
}
