using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKPOSTerminal;
using WKPOSTerminal.Controllers;

namespace WKPOSTerminal.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            string result = controller.Get("ABCDABA");
            string result2 = controller.Get("CCCCCCC");
            string result3 = controller.Get("ABCD");

            // Assert
            Assert.AreEqual("13.25", result);
            Assert.AreEqual("6", result2);
            Assert.AreEqual("7.25", result3);
        }

       
    }
}
