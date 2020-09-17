using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests{
    [TestClass]
    public class DocumentTests{
        // Red, Green, Refactor
        // 1- Fazer os testes falharem
        // 2- Fazer os testes passarem
        // 3- Refatorar o código
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid(){
            var doc = new Document("123",EDocumentType.CNPJ);
            //Garanta que é verdadeiro que meu doc é Invalido
            Assert.IsTrue(doc.Invalid);   
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid(){
            var doc = new Document("29927868000113",EDocumentType.CNPJ);
            //Garanta que é verdadeiro que meu doc é Valido
            Assert.IsTrue(doc.Valid);     
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid(){
            var doc = new Document("123",EDocumentType.CPF);
            //Garanta que é verdadeiro que meu doc é Invalido
            Assert.IsTrue(doc.Invalid);   
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("43562360096")]
        [DataRow("75894807034")]
        [DataRow("33291022092")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf){
            var doc = new Document(cpf,EDocumentType.CPF);
            //Garanta que é verdadeiro que meu doc é Invalido
            Assert.IsTrue(doc.Valid);   
        }


    }
}