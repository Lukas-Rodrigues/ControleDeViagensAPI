using ProjetoLucas.Model;

namespace ProjetoLucas.Repository
{
    public interface ILinhaRepository
    {
		void Add(Linha linha);
		List<Linha> Get();
		Linha GetById(int id);
		Linha GetByNumber(int numero);
		bool Delete(int id);
		bool Update(int id, Linha linha);

	}
}
