
using API_Teste_Tecnico.Service.UsuarioService;

namespace API_Teste_Tecnico
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Aqui informamos ao Program.cs que quando fizer uma injeção de dependeica da interface
            // IUsuarioInterface - queremos na verdade que sejam utilizados os métodos da classe
            // UsuarioService que impletmenta da interface IUsuarioInterface
            builder.Services.AddHttpClient<IUsuarioInterface,UsuarioService>();

            // ==============================
            // Configuração de CORS
            // ==============================
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // URL do Angular
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // ==============================
            // Usar CORS antes do Authorization
            // ==============================
            app.UseCors("AllowAngularDev");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
