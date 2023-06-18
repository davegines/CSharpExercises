namespace EstimatedArrivalTime.RulesEngineSolution;

public interface ITravelRule
{
  bool IsApplicable(TravelDefinition travelDefinition);
  void Apply(TravelDefinition travelDefinition);
}