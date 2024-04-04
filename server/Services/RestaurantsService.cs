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

  internal string DestroyRestaurant(int restaurantId, string userId)
  {
    Restaurant restaurantToDestroy = GetRestaurantById(restaurantId, userId);

    if (restaurantToDestroy.CreatorId != userId) throw new Exception("NOT YOUR RESTAURANT");

    _repository.Destroy(restaurantId);

    return $"{restaurantToDestroy.Name} has been deleted";
  }

  internal Restaurant GetRestaurantByIdAndIncrementVisits(int restaurantId, string userId)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId, userId);

    restaurant.Visits++;

    _repository.Update(restaurant);

    return restaurant;
  }

  internal Restaurant GetRestaurantById(int restaurantId, string userId)
  {
    Restaurant restaurant = _repository.GetById(restaurantId);

    if (restaurant == null) throw new Exception($"Invalid id: {restaurantId}");

    if (restaurant.IsShutdown == true && userId != restaurant.CreatorId)
    {
      throw new Exception($"Invalid id: {restaurantId} 😉");
    }

    return restaurant;
  }

  internal List<Restaurant> GetRestaurants(string userId)
  {
    List<Restaurant> restaurants = _repository.GetAll();

    restaurants = restaurants.FindAll(restaurant => restaurant.IsShutdown == false || restaurant.CreatorId == userId);

    return restaurants;
  }

  internal Restaurant UpdateRestaurant(int restaurantId, Restaurant restaurantData, string userId)
  {
    Restaurant restaurantToUpdate = GetRestaurantById(restaurantId, userId);

    if (restaurantToUpdate.CreatorId != userId) throw new Exception("NOT YOUR RESTAURANT");

    restaurantToUpdate.Name = restaurantData.Name ?? restaurantToUpdate.Name;
    restaurantToUpdate.Description = restaurantData.Description ?? restaurantToUpdate.Description;
    restaurantToUpdate.IsShutdown = restaurantData.IsShutdown ?? restaurantToUpdate.IsShutdown; // must set IsShutdown to nullable in model

    Restaurant restaurant = _repository.Update(restaurantToUpdate);
    return restaurant;
  }
}