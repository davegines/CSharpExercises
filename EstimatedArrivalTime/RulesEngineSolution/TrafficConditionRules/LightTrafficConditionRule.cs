namespace EstimatedArrivalTime.RulesEngineSolution.TrafficConditionRules;

public class LightTrafficConditionRule : ITravelRule
{
  public bool IsApplicable(TravelDefinition travelDefinition) => travelDefinition.TrafficCondition == 1;

  public void Apply(TravelDefinition travelDefinition)
  {
  }
}