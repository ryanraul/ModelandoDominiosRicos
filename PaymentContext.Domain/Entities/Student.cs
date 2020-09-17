using System;
using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities{
    public class Student : Entity{

        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email, Guid id) : base (id)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }
        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
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