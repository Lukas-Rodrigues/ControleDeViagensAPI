
using ProjetoLucas.Repository;

namespace ProjetoLucas
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			builder.Services.AddTransient<IVeiculoRepository, VeiculoRepository>();
			builder.Services.AddTransient<IMotoristaRepository, MotoristaRepository>();
			builder.Services.AddTransient<ILinhaRepository, LinhaRepository>();
			builder.Services.AddTransient<IViagemRepository, ViagemRepository>();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}