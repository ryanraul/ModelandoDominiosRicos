using System;

namespace PaymentContext.Domain.Entities{

    public abstract class Payment{
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string address, string payer, string document, string email)
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
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Address { get; private set; }
        public string Payer { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
    }
    
}