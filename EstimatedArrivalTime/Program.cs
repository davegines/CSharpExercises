using EstimatedArrivalTime.RulesEngineSolution;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
  .ConfigureServices(services =>
  {
    services.AddSingleton<ArrivalTimePrediction>();
  })
  .Build();

var arrivalTimePrediction = host.Services.GetService<ArrivalTimePrediction>();
arrivalTimePrediction!.Run();

await host.RunAsync();
