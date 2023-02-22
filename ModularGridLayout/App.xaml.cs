using Commonality.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;
using ModularGridLayout.View;
using Persistence;
using Persistence.UnitOfWork;
using Services.Exam;
using Services.File;
using Services.Patient;
using System;
using System.Windows;
using View.ViewModel;
using View.ViewModel.CustomComponent;

namespace ModularGridLayout
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()  // Use default settings
                                                //new HostBuilder()          // Initialize an empty HostBuilder
                .ConfigureAppConfiguration((context, builder) =>
                {
                    // Add other configuration files...
                    //builder.AddJsonFile("appsettings.local.json", optional: true);
                }).ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .ConfigureLogging(logging =>
                {
                    // Add other loggers...
                })
                .Build();

            ServiceProvider = host.Services;
        }

        public static MainWindowViewModel MainWindowVM

        {
            get
            {
                return ServiceProvider.GetRequiredService<MainWindowViewModel>();
            }
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await host.StartAsync();

            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddScoped<PatientService>();
            services.AddScoped<ExamService>();
            services.AddScoped<FileService>();

            services.AddDbContextFactory<PatientContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register all ViewModels.
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<QuickSearchViewModel>();

            // Register all the Windows of the applications.
            services.AddTransient<MainWindow>();
        }
    }
}
