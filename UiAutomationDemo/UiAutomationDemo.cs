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
            Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            var window = automation.GetDesktop().FindFirstDescendant(cf => cf.ByName("Kalkulačka"));
            calc = new Calculator(window);
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
