namespace WebAPIApplication.Models
{
    // Basic model to put data extracted from the DB into
    public class Thing
    {
        public long id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
    }
}