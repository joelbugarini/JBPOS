using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;
using JBPOS.Views;

namespace JBPOS
{
    public static class App
    {
        public static void Start()
        {            
            Application.Init();

            var menu = MainMenuBar.Create();
            var win = MainWindow.Create("JBPOS");

            Application.Top.Add(menu, win);
            Application.Run();
        }
    }
}
