using ProjetoLucas.Model;
using ProjetoLucas.ViewModel;

namespace ProjetoLucas.Repository
{
    public interface IViagemRepository
    {
        void Add(Viagem viagem);
        List<ViagemViewModelExibir> Get();
        List<ViagemViewModelExibir> GetViagensPorData(DateTime data);
		Viagem GetById(int id);
		bool Delete(int id);
		bool Update(int id, Viagem viagem);
		Viagem GetByNumeroServicoEDataPartida(string numeroServico, DateTime dataPartida);
	}
}
