using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleRenderer.Tests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void IsNotNullTest()
        {
            var result = MainRenderer.Financial.GenerateBoletoHtml(999);

            Assert.IsNotNull(result);
        }
    }
}
