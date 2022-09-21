namespace DAL.Entities
{
    public partial class Transaction
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public Category Category { get; set; }
        public double Amount { get; set; }
        public string? Comment { get; set; }
    }
        
}
