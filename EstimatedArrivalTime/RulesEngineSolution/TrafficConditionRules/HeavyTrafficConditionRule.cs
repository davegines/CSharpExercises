namespace EstimatedArrivalTime.RulesEngineSolution.TrafficConditionRules;

public class HeavyTrafficConditionRule : ITravelRule
{
  public bool ShouldRun(TravelDefinition travelDefinition) => travelDefinition.TrafficCondition == 3;

  public void Apply(TravelDefinition travelDefinition)
    => travelDefinition.AdditionalTravelTime += (int)Math.Round(travelDefinition.Distance / 15 * 60);
}