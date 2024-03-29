using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests ()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("22233344456", EDocumentType.CPF);
            _email = new Email("hello@gmail.com");
            _address = new Address("Rua Pompilio", "223", "Zezé", "Jacareí", "SP", "Brasil", "22123321");
            _student = new Student(_name , _document, _email);
            _subscription = new Subscription(null);
        }
        

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscrition()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Solutions",_document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        public void ShouldReturnErrorWhenActiveSubscritionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }


        [TestMethod]
        public void ShouldReturnSuccessWhenNoActiveSubscrition()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Solutions",_document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
        
    }
}