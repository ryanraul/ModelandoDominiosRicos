using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities{
    public class CreditCardPayment : Payment{
        public CreditCardPayment(
            string cardHolderName, 
            string cardNumber, 
            string lastTansactionNumber, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid, 
            Address address, 
            string payer, 
            Document document, 
            Email email):base(
                paidDate, 
                expireDate, 
                total, 
                totalPaid, 
                address, 
                payer, 
                document, 
                email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTansactionNumber = lastTansactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTansactionNumber { get; private set; }
    }
}