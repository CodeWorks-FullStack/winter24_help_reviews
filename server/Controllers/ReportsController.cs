namespace help_reviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController
{

  private readonly ReportsService _reportsService;
  private readonly Auth0Provider _auth0Provider;

  public ReportsController(Auth0Provider auth0Provider, ReportsService reportsService)
  {
    _auth0Provider = auth0Provider;
    _reportsService = reportsService;
  }
}