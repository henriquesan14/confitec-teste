using AutoMapper;
using Confitec.API.Extensions;
using Confitec.API.Filters;
using Confitec.Application.Commands.CadastrarUsuario;
using Confitec.Application.Mappers;
using Confitec.Application.Validators;
using Confitec.Infrastructure.Context;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Confitec.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "CorsPolicy";

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var connectionString = Configuration.GetConnectionString("DbConnection");
            services.AddDbContext<ConfitecContext>(options => options.UseSqlServer(connectionString));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UsuarioMapper>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddInfrastructure();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UsuarioConfitec API", Version = "v1" });
            });

            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CadastrarUsuarioCommandValidator>());

            services.AddMediatR(typeof(CadastrarUsuarioCommand));

            services.JsonSerializationConfig();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuarioConfitec API V1");
            });
        }
    }
}
