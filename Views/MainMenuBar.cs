using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace JBPOS.Views
{
    public static class MainMenuBar
    {
        public static MenuBar Create()
        {
            return new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_Quit", "", () => {
                        Application.RequestStop();
                    })
                }),
            });
        }
    }
}
