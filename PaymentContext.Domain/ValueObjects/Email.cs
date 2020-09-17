using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects{
    public class Email : ValueObject{
        public Email(string address)
        {
            Address = address;

            //Esse cotrato requer que o email seja valido (Design By Contracts)
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email.Address","E-mail invalido")
            );
        }

        public string Address { get; private set; }
    }
}