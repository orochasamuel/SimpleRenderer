using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleRenderer.Core;

namespace SimpleRenderer.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void IsNotNullTest()
        {
            var result = MainRenderer.Financial.GenerateBoletoHtml(999);

            Assert.IsNotNull(result);
        }
    }
}
