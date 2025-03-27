using System.Net.Security;
using NUnit.Framework;
 
namespace TemplateEngine.Tests
{
    public class TempleEngineTests
    {
        [SetUp]
        public void Setup()
        {
        }
 
        [TestCase("Vaishnavi", "L", "Hello Shubham Prakash")]
        [TestCase("Hrishi","L", "Hello Mayank Kumar")]
 
 
        public void ShouldEvaluateForSingleVariable(string value1, string value2, string expectedValue)
        {
            //Arrange
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.setTempalate("Hello {firstName} {secondName}");
            templateEngine.setVariable("firstName", value1);
            templateEngine.setVariable("secondName", value2);
 
            //ACT
            string result = templateEngine.Evaluate();
 
            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}
