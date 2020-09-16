using System;

namespace PaymentContext.Domain.Entities{
    public class PayPalPayment : Payment{
        public PayPalPayment(string transactionCode, 
        DateTime paidDate,
        DateTime expireDate, 
        decimal total, 
        decimal totalPaid, 
        string address, 
        string payer, string document, string email):base(paidDate, expireDate, total, totalPaid, address, payer, document, email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; set; }
    }
}