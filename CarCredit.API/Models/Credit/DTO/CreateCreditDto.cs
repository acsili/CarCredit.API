﻿namespace CarCredit.API.Models.Credit.DTO
{
    public class CreateCreditDto
    {
        public int CreditTerm { get; set; }
        public float InterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        public double InitialFee { get; set; }
        public int BorrowerId { get; set; }
        public int CarId { get; set; }
    }
}
