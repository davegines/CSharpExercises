namespace EstimatedArrivalTime.RulesEngineSolution;

public class TravelDefinition
{
  public DateTime StartTime { get; init; }
  public double Distance { get; init; }
  public int TravelTime { get; init; }
  public int TrafficCondition { get; init; }
  public int WeatherCondition { get; init; }

  public int AdditionalTravelTime { get; set; } = 0;

  public TravelDefinition(
    DateTime startTime,
    double distance,
    int travelTime,
    int trafficCondition,
    int weatherCondition
  )
  {
    StartTime = startTime;
    Distance = distance;
    TravelTime = travelTime;
    TrafficCondition = trafficCondition;
    WeatherCondition = weatherCondition;
  }
}