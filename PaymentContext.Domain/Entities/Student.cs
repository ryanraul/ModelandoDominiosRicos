using System;
using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities{
    public class Student{

        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

        }
        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription){
            // Se tiver uma assinatura ativa, cancela

            // Cancela todas as assinaturas, e coloca esta como principal
            foreach(var sub in Subscriptions){
                sub.Inactivate();
            }

            _subscriptions.Add(subscription);
        }
    }
}