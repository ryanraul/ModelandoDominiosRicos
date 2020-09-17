using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects{
    public class Name : ValueObject{
        public Name(string firsName, string lastName)
        {
            FirsName = firsName;
            LastName = lastName;

            if(string.IsNullOrEmpty(FirsName))
                AddNotification("Name.FirstName","Nome invalido");
        }

        public string FirsName { get; private set; }
        public string LastName { get; private set; }
    }
}