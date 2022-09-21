namespace DAL.Entities
{
    public class Balance
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
