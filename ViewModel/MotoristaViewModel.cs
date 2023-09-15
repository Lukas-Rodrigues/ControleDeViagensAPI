using System.ComponentModel.DataAnnotations;

namespace ProjetoLucas.ViewModel
{
	public class MotoristaViewModel
	{
		[Required(ErrorMessage = "Digite o nome") ]
		public string nome { get; set; }
		[Required(ErrorMessage = "Digite o cpf")]
		public string cpf { get; set;}
	}
}
