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

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // define a string de conex�o.
            builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Registrando os servi�os das repositorys(Inje��o de dependencia).

            //Scoped -> Nova instancia � criada a cada request, a cada requisi��o temos uma nova instancia
            //Singleton -> apenas uma instancia de servi�o � criada para todas as instancias.
            //Transient -> Nova instancia � criada quando o servi�o � solicitado
            builder.Services.AddTransient<ILanchesRepository, LanchesRepository>();
            builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
