using NUnit.Framework;

namespace WebAutomationProject
{
    public class Tests
    {

        [Test]
        [TestCaseSource(typeof(BaseClass.Base), "Browser")]
        public void Navigate_To_Storefront()
        {
            
        }
    }
}