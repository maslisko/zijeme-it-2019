using FlaUI.UIA3;
using FlaUI.Core;
using FlaUI.Core.Capturing;
using UiAutomationDemo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UiAutomationDemo
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calc;
        private AutomationBase automation;
        private TestContext context;
        
        #region Test setup

        [TestInitialize]
        public void InitTest(TestContext testContext)
        {
            automation = new UIA3Automation();
            calc = new Calculator(automation);
            context = testContext;
        }

        #endregion

        #region Test cleanup

        [TestCleanup]
        public void Cleaup()
        {
            var image = Capture.Screen();
            // add cursor
            image.ApplyOverlays(new MouseOverlay(image));
            image.ToFile(Path.Combine(context.TestResultsDirectory, context.TestName, ".png"));

            calc.Close();
            automation.Dispose();
        }

        #endregion

        #region Tests

        [TestMethod]
        public void TestModeSwitching()
        {
            calc.SwitchToScientific();
            calc.SwitchToStandard();
            calc.SwitchToScientific();
            Assert.AreEqual("Vědecká", calc.Header);
        }

        [TestMethod]
        public void TestAddition()
        {
            calc.Button2.Click();
            calc.Button0.Click();
            calc.ButtonPlus.Click();
            calc.Button9.Click();
            calc.Button0.Click();
            calc.ButtonEquals.Click();

            Assert.AreEqual(calc.Result, "110", "Addition failed");
        }

        [TestMethod]
        public void TestSubtraction()
        {
            calc.Button1.Click();
            calc.Button0.Click();
            calc.ButtonDecimalSeparator.Click();
            calc.Button6.Click();
            calc.ButtonMinus.Click();
            calc.Button4.Click();
            calc.Button2.Click();
            calc.ButtonEquals.Click();

            Assert.AreEqual(calc.Result, "-31.4", "Subtraction failed");
        }

        [TestMethod]
        public void TestPiValue()
        {
            calc.ButtonPi.Click();

            Assert.AreEqual(calc.Result, "3.1415926535897932384626433832795", "Unexpected value of PI");
        }

        #endregion

    }
}
