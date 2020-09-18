using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests{
    [TestClass]
    public class SubscriptionHandlerTests{
        // Red, Green, Refactor
        // 1- Fazer os testes falharem
        // 2- Fazer os testes passarem
        // 3- Refatorar o código
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists(){
             var handler = new SubscriptionHandler(new FakeStudentRepository(),new FakeEmailService());
             var command = new CreateBoletoSubscriptionCommand();

             command.FirstName= "Bruce";
             command.LastName= "Wayne";
             command.Document= "99999999999";
             command.Email= "raul@email.com2";
             command.BarCode= "123456789";

             command.BoletoNumber= "1234567";
             command.PaymentNumber= "123121";

             command.PaidDate= DateTime.Now;
             command.ExpireDate= DateTime.Now.AddMonths(1);
             command.Total= 60;
             command.TotalPaid= 60;
            
             command.Payer= "Wayne Corp";
             command.PayerDocument= "12345678911";
             command.PayerDocumentType= EDocumentType.CPF;
             command.PayerEmail= "batman@dc.com"; 
             command.Street= "asdad";
             command.Number= "awd";
             command.Neighborhood= "sada";
             command.City= "asdas";
             command.State= "as";
             command.Country= "as";
             command.ZipCode= "12345678";

             handler.Handle(command);
             Assert.AreEqual(false, handler.Valid);
        }



    }
}