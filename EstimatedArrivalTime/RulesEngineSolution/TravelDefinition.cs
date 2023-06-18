namespace EstimatedArrivalTime.RulesEngineSolution;

public record TravelDefinition(
  DateTime StartTime,
  double Distance,
  int TravelTime,
  TrafficConditionEnum TrafficCondition,
  int AdditionalTravelTime = 0
);