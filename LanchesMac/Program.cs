using LanchesMac.Context;
using LanchesMac.Repositories;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // define a string de conexão.
            builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddMemoryCache(); // habilitando armazenamento em cache
            builder.Services.AddSession(); //habilitando as sessoes no projeto

            //Registrando os serviços das repositorys(Injeção de dependencia).

            //AddScoped    -> Nova instancia é criada a cada request, a cada requisição temos uma nova instancia
            //AddSingleton -> apenas uma instancia de serviço é criada para todas as instancias.
            //AddTransient -> Nova instancia é criada quando o serviço é solicitado
            
            builder.Services.AddTransient<ILanchesRepository, LanchesRepository>();
            builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //recupera uma instancia do HTTP Acessor e usamos os recursos de HTTPContext


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
