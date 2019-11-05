using System;
using System.Text.RegularExpressions;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;

namespace UiAutomationDemo.Model
{
    public class Calculator
    {
        public Calculator(AutomationBase automation)
        {
            app = Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            mainWindow = app.GetMainWindow(automation);
            mainWindow = automation.GetDesktop().FindFirstDescendant(cf => cf.ByName("Kalkulačka")).AsWindow(); ;
        }

        #region Private properties

        private readonly Application app;
        private readonly Window mainWindow;

        #endregion Private members

        #region Private methods

        private AutomationElement FindElement(string text)
        {
            var element = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(text));
            return element;
        }

        #endregion

        #region Public properties

        public Button Button0 => FindElement("num0Button").AsButton();
        public Button Button1 => FindElement("num1Button").AsButton();
        public Button Button2 => FindElement("num2Button").AsButton();
        public Button Button3 => FindElement("num3Button").AsButton();
        public Button Button4 => FindElement("num4Button").AsButton();
        public Button Button5 => FindElement("num5Button").AsButton();
        public Button Button6 => FindElement("num6Button").AsButton();
        public Button Button7 => FindElement("num7Button").AsButton();
        public Button Button8 => FindElement("num8Button").AsButton();
        public Button Button9 => FindElement("num9Button").AsButton();

        public Button ButtonPi => FindElement("piButton").AsButton();


        public Button ButtonAdd => FindElement("plusButton").AsButton();
        public Button ButtonMinus => FindElement("minusButton").AsButton();
        public Button ButtonMultiply => FindElement("multiplyButton").AsButton();
        public Button ButtonDivide => FindElement("divideButton").AsButton();
        public Button ButtonEquals => FindElement("equalButton").AsButton();

        public string Result
        {
            get
            {
                var resultElement = FindElement("CalculatorResults");
                var value = resultElement.Properties.Name;
                return Regex.Replace(value, "[^0-9]", string.Empty);
            }
        }

        public string Header
        {
            get
            {
                var headerElement = FindElement("Header").AsTextBox();
                var value = headerElement.Name;
                return Regex.Replace(value, "Režim kalkulačky", string.Empty);
            }
        }

        #endregion

        #region Public methods

        public void Close()
        {
            mainWindow.Close();
        }

        public void SwitchToStandard()
        {
            Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.KEY_1);
            Wait.UntilInputIsProcessed();
            app.WaitWhileBusy();
        }

        public void SwitchToScientific()
        {
            Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.KEY_2);
            Wait.UntilInputIsProcessed();
            app.WaitWhileBusy();
        }

        public void SwitchToProgrammers()
        {
            Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.KEY_3);
            Wait.UntilInputIsProcessed();
            app.WaitWhileBusy();
        }

        #endregion


    }
}
