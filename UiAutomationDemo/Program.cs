using FlaUI.UIA3;
using FlaUI.Core.Input;
using FlaUI.Core;
using System;
using System.Threading;

namespace UiAutomationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = Application.Launch("notepad");
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                var menu = window.FindFirstDescendant(cf => cf.ByAutomationId("MenuBar")).AsMenu();
                menu.Items[0].Click();

                Thread.Sleep(2000);
                app.Close();
            }

        }
    }
}
