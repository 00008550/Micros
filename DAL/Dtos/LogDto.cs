namespace DAL.Dtos
{
    public class LogDto
    {
        public Guid Id { get; set; }
        public string PreviousBalance { get; set; }
        public string AddedAmount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
