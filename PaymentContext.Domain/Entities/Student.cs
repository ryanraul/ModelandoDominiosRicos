using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities{
    public class Student{
        public Student(string firsName, string lastName, string document, string email)
        {
            FirsName = firsName;
            LastName = lastName;
            Document = document;
            Email = email;

            if(FirsName.Length == 0)
                throw new Exception("Nome Invalido");
        }

        public string FirsName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public List<Subscription> Subscriptions { get; private set; }
    }
}