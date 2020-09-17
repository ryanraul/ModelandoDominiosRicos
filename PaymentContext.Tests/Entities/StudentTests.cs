using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests{
    [TestClass]
    public class StudentTest{
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTest(){
            _name = new Name("Bruce","Wayne");
            _document = new Document("67919214394",EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1","123","bairro 1","Gotham","SP","BR","13400000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription(){
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, "Wayne Corp", _document, _email); 

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment(){

            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription(){
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, "Wayne Corp", _document, _email); 
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }


    }
}