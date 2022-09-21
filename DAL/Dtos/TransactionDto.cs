namespace DAL.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string? Comment { get; set; }
    }
}
