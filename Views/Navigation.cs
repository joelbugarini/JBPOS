using JBPOS.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace JBPOS.Views
{
    public class Navigation
    {
        public JBPOS_DB_Context db { get; set; }
        public Navigation(JBPOS_DB_Context _db) {
            db = _db; 
        }
        public MenuBar Render()
        {
            return new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_Sistema", new MenuItem [] {
                    new MenuItem ("_Salir", "", () => {
                        Application.RequestStop();
                   })
                }),
                new MenuBarItem ("_Productos", new MenuItem [] {
                    new MenuItem ("_Nuevo", "",() => new ProductCreate(db).Render()),
                    new MenuItem ("_Inventario", "",() => new ProductsTable(db).Render())
                }),
                new MenuBarItem ("_Empleados", new MenuItem [] {
                    new MenuItem ("_Nuevo", "",() => new EmployeeCreate(db).Render()),
                    new MenuItem ("_Listado", "",() => new EmployeesTable(db).Render())
                }),

            });
        }
    }
}
