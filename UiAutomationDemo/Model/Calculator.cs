using System;
using System.Text.RegularExpressions;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;

namespace UiAutomationDemo.Model
{
    public class Calculator
    {
        public Calculator(AutomationElement mainWindow)
        {
            this.mainWindow = mainWindow;
        }


        #region Private properties

        private readonly AutomationElement mainWindow;

        #endregion Private members


        #region public properties

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


        public Button ButtonAdd => FindElement("plusButton").AsButton();
        public Button ButtonEquals => FindElement("equalButton").AsButton();

        public string Result
        {
            get
            {
                var resultElement = FindElement("CalculatorResults");
                var value = resultElement.Properties.Name;
                return Regex.Replace(value, "[^0-9]", String.Empty);
            }
        }

        #endregion



        private AutomationElement FindElement(string text)
        {
            var element = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(text));
            return element;
        }

    }
}
