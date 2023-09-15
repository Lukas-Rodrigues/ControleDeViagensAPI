using ProjetoLucas.Model;
using ProjetoLucas.ViewModel;

namespace ProjetoLucas.Repository
{
    public interface IMotoristaRepository
    {
        void Add(Motorista motorista);
        List<Motorista> Get();
        Motorista GetById(int id);
		Motorista GetByCpf(string cpf);
		bool Delete(int id);
		bool Update(int id, Motorista motoristaAtualizado);
		


	}
}
