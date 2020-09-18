
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests{
        // Red, Green, Refactor
        // 1- Fazer os testes falharem
        // 2- Fazer os testes passarem
        // 3- Refatorar o código
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid(){
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            
            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }


    }
}