using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using BusinessLogic.Services;
using BusinessLogic.Validators;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebPage
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var builder = new ContainerBuilder();
            
            CompositionRootRegistration(builder);

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
            
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        private void CompositionRootRegistration(ContainerBuilder builder)
        {
            // Register validators
            builder.RegisterType<EmailValidator>().As<IEmailValidator>().InstancePerLifetimeScope();

            // Register DataAccess
            builder.Register<DbContext>(context => new DataContext(Configuration.GetSection("Database")["DbName"]));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            // Register BL Services
            builder.RegisterType<UserTicketService>().As<IUserTicketService>().InstancePerLifetimeScope();

            // Automapper
            builder.Register(context => new MapperConfiguration(Mappings.ConfigureMapper).CreateMapper());
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging")).AddDebug();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());

            if (env.IsDevelopment())
            {
                // Only for demo purposes
                var context = new DataContext(Configuration.GetSection("Database")["DbName"]);
                context.Database.EnsureCreated();

                app.UseDeveloperExceptionPage();
            }
        }
    }
}
