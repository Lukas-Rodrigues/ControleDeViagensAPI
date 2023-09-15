using ProjetoLucas.Model;

namespace ProjetoLucas.Repository
{
	public class LinhaRepository : ILinhaRepository
	{
		private readonly BdContext _context = new BdContext();
		public void Add(Linha linha)
		{
			_context.Linhas.Add(linha);
			_context.SaveChanges();
		}

		public bool Delete(int id)
		{
			var linha = GetById(id);

			if (linha != null)
			{
				_context.Linhas.Remove(linha);
				_context.SaveChanges();
				return true;
			}
			else
			{
				throw new Exception("Houve um erro na deleção de dados");
			}
		}

		public List<Linha> Get()
		{

			return _context.Linhas.ToList();
		}

		public Linha GetByNumber(int numeroLinha)
		{
			return _context.Linhas.FirstOrDefault(x => x.numero == numeroLinha);
		}

		public Linha GetById(int idLinha)
		{
			return _context.Linhas.FirstOrDefault(x => x.id == idLinha);
		}
		public bool Update(int id, Linha LinhaAtualizada)
		{
			var linha = GetById(id);

			if (LinhaAtualizada == null)
			{
				return false;
			}
			linha.nome = LinhaAtualizada.nome;
			linha.numero = LinhaAtualizada.numero;
			linha.destino = LinhaAtualizada.destino;
			linha.origem = LinhaAtualizada.origem;
			_context.SaveChanges();
			return true;
		}
	}
}
