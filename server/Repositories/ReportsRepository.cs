
using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class ReportsRepository : IRepository<Report>
{
  private readonly IDbConnection _db;

  public ReportsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Report Create(Report data)
  {
    string sql = @"
    INSERT INTO
    reports(title, body, creatorId, restaurantId, pictureOfDisgust)
    VALUES(@Title, @Body, @CreatorId, @RestaurantId, @PictureOfDisgust);
    
    SELECT
    report.*,
    account.*
    FROM reports report
    JOIN accounts account ON account.id = report.creatorId
    WHERE report.id = LAST_INSERT_ID();";

    // Report report = _db.Query<Report, Profile, Report>(sql, (report, profile) =>
    // {
    //   report.Creator = profile;
    //   return report;
    // }, data).FirstOrDefault();

    Report report = _db.Query<Report, Profile, Report>(sql, _populateCreator, data).FirstOrDefault();

    return report;
  }

  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<Report> GetAll()
  {
    throw new NotImplementedException();
  }

  public Report GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Report Update(Report data)
  {
    throw new NotImplementedException();
  }

  private Report _populateCreator(Report report, Profile profile)
  {
    report.Creator = profile;
    return report;
  }

  public List<Report> GetReportsByRestaurantId(int restaurantId)
  {
    string sql = @"
    SELECT
    report.*,
    account.*
    FROM reports report
    JOIN accounts account ON account.id = report.creatorId
    WHERE report.restaurantId = @restaurantId;";

    List<Report> reports = _db.Query<Report, Profile, Report>(sql, _populateCreator, new { restaurantId }).ToList();

    return reports;
  }
}