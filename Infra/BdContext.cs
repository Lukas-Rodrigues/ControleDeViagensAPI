using Microsoft.EntityFrameworkCore;
using ProjetoLucas.Model;

public class BdContext : DbContext
{
	public DbSet<Veiculo> Veiculos { get; set; }
	public DbSet<Motorista> Motoristas { get; set; }
	public DbSet<Linha> Linhas { get; set; }
	public DbSet<Viagem> Viagens { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;initial catalog=SistemaViagem;Integrated Security=True;Encrypt=False");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Configura as relações entre as tabelas usando chaves estrangeiras
		modelBuilder.Entity<Viagem>()
			.HasOne(v => v.linha)
			.WithMany()
			.HasForeignKey(v => v.IdLinha);

		modelBuilder.Entity<Viagem>()
			.HasOne(v => v.motorista)
			.WithMany()
			.HasForeignKey(v => v.IdMotorista);

		modelBuilder.Entity<Viagem>()
			.HasOne(v => v.veiculo)
			.WithMany()
			.HasForeignKey(v => v.IdVeiculo);

		// Configura o nome da tabela para "Viagens"
		modelBuilder.Entity<Viagem>()
			.ToTable("Viagem");

		modelBuilder.Entity<Motorista>()
			.Property(m => m.cpf)
			.HasColumnName("Cpf");
	}

}
