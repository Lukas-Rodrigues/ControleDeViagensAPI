using ProjetoLucas.Model;

namespace ProjetoLucas.Repository
{
    public interface IVeiculoRepository
    {
        void Add(Veiculo Veiculo);
        List<Veiculo> Get();
        Veiculo GetById(int id);
		Veiculo GetByPlaca(string placa);
		bool Delete(int id);
		bool Update(int id, Veiculo motoristaAtualizado);

	}
}
