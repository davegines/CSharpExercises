namespace EstimatedArrivalTime.RulesEngineSolution.WeatherConditionRules;

public class ClearConditionRule : ITravelRule
{
  public bool IsApplicable(TravelDefinition travelDefinition) => travelDefinition.WeatherCondition == 1;

  public void Apply(TravelDefinition travelDefinition)
  {
  }
}