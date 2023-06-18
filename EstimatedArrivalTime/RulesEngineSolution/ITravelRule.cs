namespace EstimatedArrivalTime.RulesEngineSolution;

public interface ITravelRule
{
  bool ShouldRun(TravelDefinition travelDefinition);
  void Apply(TravelDefinition travelDefinition);
}