using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class RestaurantsRepository : IRepository<Restaurant>
{
  private readonly IDbConnection _db;

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Restaurant Create(Restaurant data)
  {
    string sql = @"
    INSERT INTO
    restaurants(name, imgUrl, description, creatorId)
    VALUES(@Name, @ImgUrl, @Description, @CreatorId);

    SELECT
    restaurant.*,
    account.*
    FROM restaurants restaurant
    JOIN accounts account ON restaurant.creatorId = account.id
    WHERE restaurant.id = LAST_INSERT_ID();";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, _populateCreator, data).FirstOrDefault();
    return restaurant;
  }

  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<Restaurant> GetAll()
  {
    string sql = @"
    SELECT
    restaurant.*,
    account.*
    FROM restaurants restaurant
    JOIN accounts account ON restaurant.creatorId = account.id;";

    List<Restaurant> restaurants = _db.Query<Restaurant, Profile, Restaurant>(sql, _populateCreator).ToList();

    return restaurants;
  }

  public Restaurant GetById(int id)
  {
    string sql = @"
    SELECT
    restaurant.*,
    account.*
    FROM restaurants restaurant
    JOIN accounts account ON account.id = restaurant.creatorId
    WHERE restaurant.id = @id;";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, _populateCreator, new { id }).FirstOrDefault();
    return restaurant;
  }

  public Restaurant Update(Restaurant data)
  {
    throw new NotImplementedException();
  }

  private Restaurant _populateCreator(Restaurant restaurant, Profile profile)
  {
    restaurant.Creator = profile;
    return restaurant;
  }
}