using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities{

    public abstract class Payment : Entity{
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Address address, string payer, Document document, Email email)
        {
            //Pegar um novo Guid -> Transformar para String -> Retirar os "-" -> Pegar os 10 primeiros caracters -> Transformar para maiusculo
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Payer = payer;
            Document = document;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(0, Total, "Payment.Total","O total não pode ser zero")
                .IsGreaterOrEqualsThan(Total,TotalPaid, "Payment.Total","O valor pago é menor que o valor do pagamento")
            );
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Address Address { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
    }
    
}