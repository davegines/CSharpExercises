namespace EstimatedArrivalTime.RulesEngineSolution.WeatherConditionRules;

public class SnowConditionRule : ITravelRule
{
  public bool IsApplicable(TravelDefinition travelDefinition) => travelDefinition.WeatherCondition == 3;

  public void Apply(TravelDefinition travelDefinition)
    => travelDefinition.AdditionalTravelTime += (int)Math.Round(travelDefinition.Distance / 5 * 60);
}