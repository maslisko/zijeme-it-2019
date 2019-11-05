using FlaUI.UIA3;
using FlaUI.Core;
using UiAutomationDemo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UiAutomationDemo
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calc;
        private AutomationBase automation;
        
        #region Test setup

        [TestInitialize]
        public void InitTest()
        {
            automation = new UIA3Automation();
            calc = new Calculator(automation);
        }

        #endregion

        #region Test cleanup

        [TestCleanup]
        public void Cleaup()
        {
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
