using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository; 
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validations
            command.Validate();
            if(command.Invalid){
                AddNotifications(command);
                return new CommandResult(false,"Não foi possivel realizar seu cadastro");
            }
                
            //Verificar se Documento ja esta cadastrado
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document","Este CPF já está em uso");

            //Verificar se E-mail ja esta cadastrado
            if(_repository.EmailExists(command.Email))
                AddNotification("Email","Este E-mail já esta em uso");

            //Gerar os VOs
            var name = new Name(command.FirstName,command.LastName);
            var document = new Document(command.Document,EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street,command.Number,command.Neighborhood,command.City,command.State,command.Country,command.ZipCode);
            
            
            //Gerar as Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            //Só muda a implementação do pagamento
            var payment = new BoletoPayment(
                command.BarCode, 
                command.BoletoNumber, 
                command.PaidDate, 
                command.ExpireDate, 
                command.Total, 
                command.TotalPaid, 
                address, 
                command.Payer, 
                new Document(command.PayerDocument ,command.PayerDocumentType),
                email
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Validacoes
            //Agrupar as Validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            
            //Checar notificações
            if(Invalid){
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            //Salvar as Informações
            _repository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailService.Send(student.Name.ToString(),student.Email.Address,"Bem vindo a plataforma","Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            //Fail Fast Validations
                
            //Verificar se Documento ja esta cadastrado
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document","Este CPF já está em uso");

            //Verificar se E-mail ja esta cadastrado
            if(_repository.EmailExists(command.Email))
                AddNotification("Email","Este E-mail já esta em uso");

            //Gerar os VOs
            var name = new Name(command.FirsName,command.LastName);
            var document = new Document(command.Document,EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street,command.Number,command.Neighborhood,command.City,command.State,command.Country,command.ZipCode);
            
            
            //Gerar as Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));

            //Só muda a implementação do pagamento
            var payment = new PayPalPayment(
                command.TransactionCode,
                command.PaidDate, 
                command.ExpireDate, 
                command.Total, 
                command.TotalPaid, 
                address, 
                command.Payer, 
                new Document(command.PayerDocument ,command.PayerDocumentType),
                email
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            
            //Agrupar as Validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            
            //Checar notificações
            if(Invalid){
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            //Salvar as Informações
            _repository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailService.Send(student.Name.ToString(),student.Email.Address,"Bem vindo a plataforma","Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            //Fail Fast Validations
                
            //Verificar se Documento ja esta cadastrado
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document","Este CPF já está em uso");

            //Verificar se E-mail ja esta cadastrado
            if(_repository.EmailExists(command.Email))
                AddNotification("Email","Este E-mail já esta em uso");

            //Gerar os VOs
            var name = new Name(command.FirsName,command.LastName);
            var document = new Document(command.Document,EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street,command.Number,command.Neighborhood,command.City,command.State,command.Country,command.ZipCode);
            
            
            //Gerar as Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));

            //Só muda a implementação do pagamento
            var payment = new CreditCardPayment(
                command.CardHolderName,
                command.CardNumber,
                command.LastTansactionNumber,
                command.PaidDate, 
                command.ExpireDate, 
                command.Total, 
                command.TotalPaid, 
                address, 
                command.Payer, 
                new Document(command.PayerDocument ,command.PayerDocumentType),
                email
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            
            //Agrupar as Validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            
            //Checar notificações
            if(Invalid){
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            //Salvar as Informações
            _repository.CreateSubscription(student);

            //Enviar E-mail de boas vindas
            _emailService.Send(student.Name.ToString(),student.Email.Address,"Bem vindo a plataforma","Sua assinatura foi criada");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}