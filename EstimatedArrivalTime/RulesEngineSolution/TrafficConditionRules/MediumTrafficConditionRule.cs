namespace EstimatedArrivalTime.RulesEngineSolution.TrafficConditionRules;

public class MediumTrafficConditionRule : ITravelRule
{
  public bool ShouldRun(TravelDefinition travelDefinition) => travelDefinition.TrafficCondition == 2;

  public void Apply(TravelDefinition travelDefinition)
    => travelDefinition.AdditionalTravelTime += (int)Math.Round(travelDefinition.Distance / 30 * 60);
}