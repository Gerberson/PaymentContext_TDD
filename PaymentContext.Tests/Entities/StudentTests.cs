using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        //[TestMethod]
        public void AdicionarAssinatura()
            {
               Name name = new Name("Gerberson", "Dias");
               foreach (var not in name.Notifications)
               {
                   
               }
            }
        
        
    }
}