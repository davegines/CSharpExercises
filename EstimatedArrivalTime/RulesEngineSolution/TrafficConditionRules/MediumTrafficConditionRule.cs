namespace EstimatedArrivalTime.RulesEngineSolution.TrafficConditionRules;

public class MediumTrafficConditionRule : ITravelRule
{
  public bool ShouldRun(TravelDefinition travelDefinition) =>
    travelDefinition.TrafficCondition == TrafficConditionEnum.Medium;

  public TravelDefinition Apply(TravelDefinition travelDefinition)
    => travelDefinition with
    {
      AdditionalTravelTime = travelDefinition.AdditionalTravelTime + (int)Math.Round(travelDefinition.Distance / 30 * 60)
    };
}