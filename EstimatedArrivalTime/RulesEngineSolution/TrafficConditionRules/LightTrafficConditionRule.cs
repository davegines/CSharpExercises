namespace EstimatedArrivalTime.RulesEngineSolution.TrafficConditionRules;

public class LightTrafficConditionRule : ITravelRule
{
  public bool ShouldRun(TravelDefinition travelDefinition) =>
    travelDefinition.TrafficCondition == TrafficConditionEnum.Light;

  public TravelDefinition Apply(TravelDefinition travelDefinition)
    => travelDefinition with
    {
      AdditionalTravelTime = travelDefinition.AdditionalTravelTime + (int)Math.Round(travelDefinition.Distance / 60 * 60)
    };
}