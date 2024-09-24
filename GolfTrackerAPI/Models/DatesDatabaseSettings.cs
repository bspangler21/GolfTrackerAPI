namespace GolfTrackerAPI.Models
{
    /// <summary>
    /// Represents the settings for the golfer database.
    /// </summary>
    public class DatesDatabaseSettings
    {
        /// <summary>
        /// Gets or sets the connection string for the database.
        /// </summary>
        public string ConnectionString { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        public string DatabaseName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the golfers collection in the database.
        /// </summary>
        public string DatesCollectionName { get; set; } = null!;
    }
}
