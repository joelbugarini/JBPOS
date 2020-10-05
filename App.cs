using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;
using JBPOS.Views;
using JBPOS.DataContext;

namespace JBPOS
{
    public static class App
    {
        public static JBPOS_DB_Context db = new JBPOS_DB_Context();
        public static void Start()
        {            
            Application.Init();

            MenuBar menu = new Navigation(db).Render();
            var win = MainScreen.Render();

            Application.Top.Add(menu, win);
            Application.Run();
        }
    }
}
