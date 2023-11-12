using CarCredit.API.Interfaces;

namespace CarCredit.API.Models.Credit.Entity
{
    public class Credit : IEntity
    {
        public int Id { get; set; }
        public int CreditTerm { get; set; }
        public float InterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        public double InitialFee { get; set; }
        public int BorrowerId { get; set; }
        public int CarId { get; set; }
        public Borrower.Entity.Borrower Borrower { get; set; }
        public Car.Entity.Car Car { get; set; }
    }
}
