using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Coravel;
using Capillary.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Capillary.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hosting = CreateHostBuilder(args).Build();
            hosting.Services.UseScheduler(scheduler =>
            {
                //Criando agendamento
                var capillarySchedule = scheduler.Schedule<ProcessOrder>();
                // capillarySchedule.DailyAtHour(9).Weekday(); //Executar a cada dia as 9:00'
                capillarySchedule.EverySeconds(2).PreventOverlapping("ProcessOrderCapillary");
            });


            hosting.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //webBuilder.UseStartup<Startup>();
                    services.AddScheduler();
                    services.AddTransient<ProcessOrder>();
                });
    }
}
