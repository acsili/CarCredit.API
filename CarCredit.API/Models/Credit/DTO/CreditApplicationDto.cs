namespace CarCredit.API.Models.Credit.DTO
{
    public class CreditApplicationDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Model { get; set; }
        public long Price { get; set; }
        public int CreditTerm { get; set; }
        public double MonthlyPayment { get; set; }
    }
}
