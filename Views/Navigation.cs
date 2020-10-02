using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace JBPOS.Views
{
    public static class Navigation
    {
        public static MenuBar Create()
        {
            return new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_Sistema", new MenuItem [] {
                    new MenuItem ("_Salir", "", () => {
                        Application.RequestStop();
                   })
                }),
                new MenuBarItem ("_Productos", new MenuItem [] {
                    new MenuItem ("_Nuevo", "",() => Products.Create())
                }),

            });
        }
    }
}
