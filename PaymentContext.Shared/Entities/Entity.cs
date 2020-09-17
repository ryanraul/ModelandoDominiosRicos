using System;
using Flunt.Notifications;

namespace PaymentContext.Shared.Entities{
    public abstract class Entity : Notifiable{
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}