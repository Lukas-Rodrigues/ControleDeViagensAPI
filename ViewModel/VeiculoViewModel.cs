using System.ComponentModel.DataAnnotations;

namespace ProjetoLucas.ViewModel
{
	public class VeiculoViewModel
	{
		[Required(ErrorMessage = "Digite a placa do veiculo")]
		public string placa { get; set; }

	}
}
