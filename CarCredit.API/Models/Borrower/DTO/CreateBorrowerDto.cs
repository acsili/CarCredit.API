namespace CarCredit.API.Models.Borrower.DTO
{
    public class CreateBorrowerDto
    {
        public string FullName { get; set; } = string.Empty; 
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
        public int MonthlyIncome { get; set; }
    }
}
