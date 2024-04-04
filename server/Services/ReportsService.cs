
namespace help_reviews.Services;

public class ReportsService
{
  private readonly ReportsRepository _repository;
  private readonly RestaurantsService _restaurantsService;

  public ReportsService(ReportsRepository repository, RestaurantsService restaurantsService)
  {
    _repository = repository;
    _restaurantsService = restaurantsService;
  }

  internal Report CreateReport(Report reportData)
  {
    Restaurant restaurant = _restaurantsService.GetRestaurantById(reportData.RestaurantId, reportData.CreatorId);

    if (restaurant.IsShutdown == true) throw new Exception($"{restaurant.Name} is currently shutdown, no longer accepting reports.");

    Report report = _repository.Create(reportData);
    return report;
  }
}