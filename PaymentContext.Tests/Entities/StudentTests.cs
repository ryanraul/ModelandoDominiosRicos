using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests{
    [TestClass]
    public class StudentTest{
        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription(){
            var name = new Name("Bruce","Wayne");
            var document = new Document("67919214394",EDocumentType.CPF);
            var email = new Email("batman@dc.com");
            var address = new Address("Rua 1","123","bairro 1","Gotham","SP","BR","13400000");
            var student = new Student(name, document, email);
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, address, "Wayne Corp", document, email); 

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            student.AddSubscription(subscription);

            Assert.IsTrue(student.Invalid);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment(){
            var name = new Name("Bruce","Wayne");
            var document = new Document("67919214394",EDocumentType.CPF);
            var email = new Email("batman@dc.com");
            var student = new Student(name, document, email);
            
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription(){
            Assert.Fail();
        }


    }
}