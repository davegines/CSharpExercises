using System.Reflection;

namespace EstimatedArrivalTime.RulesEngineSolution;

public class ArrivalTimePrediction
{
  public void Run()
  {
    DateTime currentTime = DateTime.Now;

    var userInput = PromptForUserInput();

    var expectedArrivalTime = CalculateExpectedArrivalTime(
      currentTime,
      userInput.travelTime,
      userInput.distance,
      userInput.trafficCondition,
      userInput.weatherCondition
    );

    Console.WriteLine("Expected arrival time: " + expectedArrivalTime.ToString("hh:mm tt"));
  }
  
  private (int travelTime, double distance, int trafficCondition, int weatherCondition) PromptForUserInput()
  {
    Console.Write("Enter expected travel time in minutes: ");
    int travelTime = int.Parse(Console.ReadLine());

    Console.Write("Enter distance from destination in kilometers: ");
    double distance = double.Parse(Console.ReadLine());

    Console.Write("Enter traffic condition (1 = light, 2 = moderate, 3 = heavy): ");
    int trafficCondition = int.Parse(Console.ReadLine());

    Console.Write("Enter weather condition (1 = Clear, 2 = Fog, 3 = Snow): ");
    int weatherCondition = int.Parse(Console.ReadLine());

    return (travelTime, distance, trafficCondition, weatherCondition);
  }

  private DateTime CalculateExpectedArrivalTime(
    DateTime currentTime,
    int travelTime,
    double distance,
    int trafficCondition,
    int weatherCondition
  )
  {
    DateTime expectedArrivalTime = currentTime.AddMinutes(travelTime);
    TravelDefinition travelDefinition = new(currentTime, distance, travelTime, trafficCondition, weatherCondition);
    int additionalMinutes = CalculateAdditionalTravelTime(travelDefinition);

    return expectedArrivalTime.AddMinutes(additionalMinutes);
  }

  private int CalculateAdditionalTravelTime(TravelDefinition travelDefinition)
  {
    var rules = GetAllRules();

    foreach (var rule in rules)
    {
      if (rule is not null && rule.ShouldRun(travelDefinition))
      {
        rule.Apply(travelDefinition);
      }
    }

    return travelDefinition.AdditionalTravelTime;
  }

  private IEnumerable<ITravelRule?> GetAllRules()
    => Assembly.GetExecutingAssembly().GetTypes()
      .Where(t => typeof(ITravelRule).IsAssignableFrom(t) && t is {IsInterface: false})
      .Select(t => Activator.CreateInstance(t) as ITravelRule);
}