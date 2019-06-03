using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGatewayApp.MiddleWare;
using PaymentGatewayApp.Models;
using PaymentGatewayApp.Providers.interfaces;
using PaymentGatewayApp.Repositories;
using PaymentGatewayApp.Services;
using PaymentGatewayApp.Services.interfaces;
using PaymentGatewayApp.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using PaymentGatewayApp.Jobs.interfaces;
using Hangfire;
using System;
using PaymentGatewayApp.Jobs;
using Hangfire.MySql.Core;

namespace PaymentGatewayApp
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
            var connString = Configuration["ConnectionString"];
            services.AddDbContext<AppDBContext>(opts => opts.UseMySQL(connString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
       
            services.AddHangfire(config =>
            {
                var options = new MySqlStorageOptions
                {
                    TablePrefix = "Custom",
                    QueuePollInterval = TimeSpan.FromMinutes(5)
                };
                config.UseStorage(new MySqlStorage(connString,options));
            });

            services.AddScoped<IDataRepository<PaymentOption>, PaymentOptionDataRepository>();
            services.AddScoped<IPaymentOptions, PaymentOptionsService>();
            services.AddScoped<IDataRepository<Bank>, BanksRepository>();
            services.AddScoped<IBankService, BankService>();

            services.AddScoped<IDataRepository<Transaction>, TransactionRespository>();
            services.AddScoped<ITransactionService, TransactionService>();


            services.AddSingleton<IReportJob, ReportJob>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "Payment GateWay Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Paymentgateway", Email = "contact@paymentgateway.com", Url = "www.google.com" }
                });
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            
            app.UseHangfireDashboard("/api/hangfire", new DashboardOptions
            {
                AppPath = "/"
            });

            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                WorkerCount = 1
            });

            //RecurringJob.RemoveIfExists(nameof(ReportJob));
            //RecurringJob.AddOrUpdate("MyJob", () => ScheduledJob(), Cron.Weekly());
            //RecurringJob.AddOrUpdate<ReportJob>(nameof(ReportJob), job => job.Run(JobCancellationToken.Null), Cron.Minutely, TimeZoneInfo.Local);
            //RecurringJob.Trigger("1212121");
           //RecurringJob.AddOrUpdate<ReportJob>(nameof(ReportJob), job => job.Run(JobCancellationToken.Null), Cron.Daily(12, 0), TimeZoneInfo.Local);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
