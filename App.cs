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

            var menu = Navigation.Create();
            var win = WelcomeScreen.Render();

            Application.Top.Add(menu, win);
            Application.Run();
        }
    }
}
