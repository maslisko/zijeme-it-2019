using FlaUI.UIA3;
using FlaUI.Core.Input;
using FlaUI.Core;
using System;
using UiAutomationDemo.Model;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UiAutomationDemo
{
    [TestClass]
    class UiAutomationDemo
    {
        private Calculator calc;
        private AutomationBase automation;

        [TestInitialize]
        public void InitTest()
        {
            automation = new UIA3Automation();
            calc = new Calculator(automation);
        }

        [TestCleanup]
        public void Cleaup()
        {
            calc.Close();
            automation.Dispose();
        }


        [TestMethod]
        public void TestPiValue()
        {
            
        }


    }
}
