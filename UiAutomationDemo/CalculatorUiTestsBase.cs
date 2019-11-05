using FlaUI.UIA3;
using FlaUI.Core;
using FlaUI.Core.Capturing;
using UiAutomationDemo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UiAutomationDemo
{
    public class CalculatorUiTestsBase
    {
        private AutomationBase automation;
        protected Calculator calc;

        public TestContext TestContext { get; set; }

        #region Test setup

        [TestInitialize]
        public void InitTest()
        {
            automation = new UIA3Automation();
            calc = new Calculator(automation);
            calc.SwitchToStandard();
        }

        #endregion

        #region Test cleanup

        [TestCleanup]
        public void Cleaup()
        {
            var image = Capture.Screen();
            // add cursor to bitmap
            image.ApplyOverlays(new MouseOverlay(image));
            image.ToFile(Path.Combine(TestContext.TestResultsDirectory, TestContext.TestName + ".png"));

            calc.Close();
            automation.Dispose();
        }

        #endregion
    }
}
