namespace help_reviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
  private readonly RestaurantsService _restaurantsService;
  private readonly Auth0Provider _auth0Provider;

  public RestaurantsController(Auth0Provider auth0Provider, RestaurantsService restaurantsService)
  {
    _auth0Provider = auth0Provider;
    _restaurantsService = restaurantsService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Restaurant>> CreateRestaurant([FromBody] Restaurant restaurantData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      restaurantData.CreatorId = userInfo.Id;
      Restaurant restaurant = _restaurantsService.CreateRestaurant(restaurantData);
      return Ok(restaurant);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}