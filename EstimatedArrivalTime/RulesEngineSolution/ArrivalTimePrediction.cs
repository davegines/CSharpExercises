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
      userInput.trafficCondition
    );

    Console.WriteLine("Expected arrival time: " + expectedArrivalTime.ToString("hh:mm tt"));
  }
  
  private (int travelTime, double distance, int trafficCondition) PromptForUserInput()
  {
    Console.Write("Enter expected travel time in minutes: ");
    int travelTime = int.Parse(Console.ReadLine());

    Console.Write("Enter distance from destination in kilometers: ");
    double distance = double.Parse(Console.ReadLine());

    Console.Write("Enter traffic condition (1 = light, 2 = moderate, 3 = heavy): ");
    int trafficCondition = int.Parse(Console.ReadLine());

    return (travelTime, distance, trafficCondition);
  }

  private DateTime CalculateExpectedArrivalTime(
    DateTime currentTime,
    int travelTime,
    double distance,
    int trafficCondition
  )
  {
    DateTime expectedArrivalTime = currentTime.AddMinutes(travelTime);
    TravelDefinition travelDefinition = new(currentTime, distance, travelTime, (TrafficConditionEnum)trafficCondition);
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
      .Where(t => t.IsAssignableFrom(typeof(ITravelRule)) && t is {IsInterface: false})
      .Select(t => Activator.CreateInstance(t) as ITravelRule);
}