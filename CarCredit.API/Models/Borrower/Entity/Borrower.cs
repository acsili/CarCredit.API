using CarCredit.API.Interfaces;

namespace CarCredit.API.Models.Borrower.Entity
{
    public class Borrower : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int MonthlyIncome { get; set; }
        public List<Credit.Entity.Credit> Credits { get; set; } = new();
    }
}
