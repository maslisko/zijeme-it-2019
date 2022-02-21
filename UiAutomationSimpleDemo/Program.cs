using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.UIA3;
using FlaUI.Core;



namespace UiAutomationSimpleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            using (var automation = new UIA3Automation())
            {
                var window = automation.GetDesktop().FindFirstDescendant(cf => cf.ByName("Calculator"));
                // var window = app.GetMainWindow(automation);
                window.SetForeground();
                var buttonPi = window.FindFirstDescendant(cf => cf.ByAutomationId("piButton2"));
                buttonPi.Click();

                var resultBox = window.FindFirstDescendant(cf => cf.ByAutomationId("CalculatorResults"));
                var result = resultBox.Name;
                result = result.Replace("Zobrazuje se ", string.Empty);

                Console.WriteLine(result);
                Console.ReadKey();

                app.Close();
            }
        }
    }
}
