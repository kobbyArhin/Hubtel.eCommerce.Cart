using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Hubtel.eCommerce.Cart.Api.Models.EntityFrameWork;
using Hubtel.eCommerce.Cart.Api.Service;
using Hubtel.eCommerce.Cart.Api.Models.GenericRepository.Repository;
using Hubtel.eCommerce.Cart.Api.Models.GenericRepository.Implementation;

namespace Hubtel.eCommerce.Cart.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<EnityFramWorkDbContext>(opt =>
                                               opt.UseInMemoryDatabase("CartDB"));
            services.AddSwaggerGen();
            services.AddScoped<ICartService, CartServices>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRepository, EntityFrameworkRepository>();
            services.AddScoped<IRepositoryReadOnly, EntityFrameworkRepositoryReadOnly>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
