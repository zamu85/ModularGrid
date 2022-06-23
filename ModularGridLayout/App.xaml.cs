using System;
using System.Windows;
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
using View.ViewModel;
using View.ViewModel.Exam;
using View.ViewModel.File;
using View.ViewModel.Patient;

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

        public static ExamViewModel ExamVM
        {
            get
            {
                return ServiceProvider.GetRequiredService<ExamViewModel>();
            }
        }

        public static FileViewModel FileVM
        {
            get
            {
                return ServiceProvider.GetRequiredService<FileViewModel>();
            }
        }

        public static MainWindowViewModel MainWindowVM

        {
            get
            {
                return ServiceProvider.GetRequiredService<MainWindowViewModel>();
            }
        }

        public static PatientViewModel PatientVM
        {
            get
            {
                return ServiceProvider.GetRequiredService<PatientViewModel>();
            }
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        //protected async void OnStartup(StartupEventArgs e)
        //{
        //    await host.StartAsync();

        // var window = ServiceProvider.GetRequiredService<MainWindow>(); window.Show();

        //    base.OnStartup(e);
        //}
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await host.StartAsync();

            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();

            //base.OnStartup(e);
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddScoped<PatientService>();
            services.AddScoped<ExamService>();
            services.AddScoped<FileService>();

            services.AddDbContext<PatientContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Register all ViewModels.
            services.AddSingleton<PatientViewModel>();
            services.AddSingleton<ExamViewModel>();
            services.AddSingleton<FileViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            // Register all the Windows of the applications.
            services.AddTransient<MainWindow>();
        }
    }
}
