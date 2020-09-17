using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects{
    public class Name : ValueObject{
        public Name(string firsName, string lastName)
        {
            FirsName = firsName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirsName,3,"Name.FirstName","Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName,3,"Name.LastName","Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirsName,40,"Name.FirstName","Nome deve conter no maximo 40 caracteres")
            );
        }

        public string FirsName { get; private set; }
        public string LastName { get; private set; }
    }
}