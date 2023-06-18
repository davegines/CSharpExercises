namespace EstimatedArrivalTime.RulesEngineSolution.WeatherConditionRules;

public class FogConditionRule : ITravelRule
{
  public bool ShouldRun(TravelDefinition travelDefinition) => travelDefinition.WeatherCondition == 2;

  public void Apply(TravelDefinition travelDefinition)
    => travelDefinition.AdditionalTravelTime += (int)Math.Round(travelDefinition.Distance / 50 * 60);
}