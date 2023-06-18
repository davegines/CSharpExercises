namespace EstimatedArrivalTime.RulesEngineSolution.TrafficConditionRules;

public class HeavyTrafficConditionRule : ITravelRule
{
  public bool ShouldRun(TravelDefinition travelDefinition) =>
    travelDefinition.TrafficCondition == TrafficConditionEnum.Heavy;

  public TravelDefinition Apply(TravelDefinition travelDefinition)
    => travelDefinition with
    {
      AdditionalTravelTime = travelDefinition.AdditionalTravelTime + (int)Math.Round(travelDefinition.Distance / 15 * 60)
    };
}