using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;
using NStack;
using System.Linq;
using JBPOS.Models;
using JBPOS.DataContext;

namespace JBPOS.Views
{
    public class EmployeeUpdate
	{
		public Window Win { get; set; }
		public JBPOS_DB_Context db { get; set; }
		public EmployeeUpdate(JBPOS_DB_Context _db) {
			db = _db;
		}
		public void Render(int _id)
        {
			var Win = new Window("Editando Empleado " + _id)
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill() - 1
			};

			var employee = db.Employees.Where(x => x.Id == _id).FirstOrDefault();

			var lblName = new Label(1, 1, "Name:");
			TextField txtName = new TextField(1, 2, 10, employee.Name.ToString());
			Win.Add(lblName, txtName);
			
			var lblPassword = new Label(1, 4, "Password:");
			TextField txtPassword = new TextField(1, 5, 10, employee.Password.ToString());

			Win.Add(lblPassword, txtPassword);

			var btnSave = new Button(40, 20, "Guardar", true);
			btnSave.Clicked += () =>
			{
                employee.Name = txtName.Text.ToString();
                employee.Password = txtPassword.Text.ToString();
                
				db.SaveChanges();

				Application.RequestStop();
			};

			Win.Add(btnSave);
			Application.Run(Win);
		}
	}
}

