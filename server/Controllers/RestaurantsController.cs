namespace help_reviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController
{
  private readonly RestaurantsService _restaurantsService;
  private readonly Auth0Provider _auth0Provider;

  public RestaurantsController(Auth0Provider auth0Provider, RestaurantsService restaurantsService)
  {
    _auth0Provider = auth0Provider;
    _restaurantsService = restaurantsService;
  }
}