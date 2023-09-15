using ProjetoLucas.Model;
using ProjetoLucas.ViewModel;

namespace ProjetoLucas.Repository
{
	public class MotoristaRepository : IMotoristaRepository
	{
		private readonly BdContext _context = new BdContext();
		public void Add(Motorista motorista)
		{
			_context.Motoristas.Add(motorista);	
			_context.SaveChanges();		
		}

		public bool Delete(int id)
		{
			var motorista = GetById(id);	
			
			if (motorista != null) 
			{ 
				_context.Motoristas.Remove(motorista);	
				_context.SaveChanges();
				return true;
			}
			else
			{
				throw new Exception("Houve um erro na deleção de dados");
			}
		}

		public List<Motorista> Get()
		{

			return _context.Motoristas.ToList();
		}

		public Motorista GetByCpf(string motoristaCpf)
		{
			return _context.Motoristas.FirstOrDefault(x => x.cpf == motoristaCpf);
		}

		public Motorista GetById(int idMotorista)
		{
			return _context.Motoristas.FirstOrDefault(x => x.id == idMotorista);
		}
		public bool Update(int id, Motorista motoristaAtualizado)
		{
			var motorista = GetById(id);

			if (motorista == null)
			{
				return false; 
			}
			motorista.nome = motoristaAtualizado.nome;
			motorista.cpf = motoristaAtualizado.cpf;
			_context.SaveChanges();
			return true;
		}



	}
}
