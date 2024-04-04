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
    string sql = "DELETE FROM restaurants WHERE id = @id LIMIT 1;";

    _db.Execute(sql, new { id });
  }

  public List<Restaurant> GetAll()
  {
    string sql = @"
    SELECT
    restaurant.*,
    COUNT(report.id) AS reportCount,
    account.*
    FROM restaurants restaurant
    LEFT JOIN reports report ON report.restaurantId = restaurant.id
    JOIN accounts account ON restaurant.creatorId = account.id
    GROUP BY (restaurant.id);";

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
    string sql = @"
    UPDATE restaurants
    SET
    name = @Name,
    description = @Description,
    isShutdown = @IsShutdown
    WHERE id = @Id;
    
    SELECT
    restaurant.*,
    account.*
    FROM restaurants restaurant
    JOIN accounts account ON account.id = restaurant.creatorId
    WHERE restaurant.id = @Id;";

    Restaurant restaurant = _db.Query<Restaurant, Profile, Restaurant>(sql, _populateCreator, data).FirstOrDefault();

    return restaurant;
  }

  private Restaurant _populateCreator(Restaurant restaurant, Profile profile)
  {
    restaurant.Creator = profile;
    return restaurant;
  }
}