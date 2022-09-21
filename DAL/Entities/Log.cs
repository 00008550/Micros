namespace DAL.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public Balance Balance { get; set; }
        public Transaction Transaction { get; set; }
        public double Previous { get; set; }
        public double Added { get; set; }
        public DateTime Time { get; set; }
    }
}
