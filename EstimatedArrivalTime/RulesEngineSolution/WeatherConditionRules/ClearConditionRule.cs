namespace EstimatedArrivalTime.RulesEngineSolution.WeatherConditionRules;

public class ClearConditionRule : ITravelRule
{
  public bool ShouldRun(TravelDefinition travelDefinition) => travelDefinition.WeatherCondition == 1;

  public void Apply(TravelDefinition travelDefinition)
  {
  }
}