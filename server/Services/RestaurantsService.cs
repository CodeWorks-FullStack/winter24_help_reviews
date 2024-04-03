


namespace help_reviews.Services;

public class RestaurantsService
{
  private readonly RestaurantsRepository _repository;

  public RestaurantsService(RestaurantsRepository repository)
  {
    _repository = repository;
  }

  internal Restaurant CreateRestaurant(Restaurant restaurantData)
  {
    Restaurant restaurant = _repository.Create(restaurantData);
    return restaurant;
  }

  internal Restaurant GetRestaurantById(int restaurantId)
  {
    Restaurant restaurant = _repository.GetById(restaurantId);

    if (restaurant == null) throw new Exception($"Invalid id: {restaurantId}");

    return restaurant;
  }

  internal List<Restaurant> GetRestaurants()
  {
    List<Restaurant> restaurants = _repository.GetAll();
    return restaurants;
  }
}