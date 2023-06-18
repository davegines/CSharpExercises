namespace EstimatedArrivalTime.RulesEngineSolution;

public interface ITravelRule
{
  bool ShouldRun(TravelDefinition travelDefinition);
  TravelDefinition Apply(TravelDefinition travelDefinition);
}