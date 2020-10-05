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
    public class EmployeeCreate
	{
		public Window Win { get; set; }
		public JBPOS_DB_Context db { get; set; }
		public EmployeeCreate(JBPOS_DB_Context _db) {
			db = _db;
		}
		public void Render()
        {
			var Win = new Window("Agregando Employee")
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill() - 1
			};

			var Employee = new Employee(); 
            
            var lblId = new Label(1, 1, "Id:");
			TextField txtId = new TextField(1, 2, 10, "");
			Win.Add(lblId, txtId);var lblName = new Label(1, 1, "Name:");
			TextField txtName = new TextField(1, 2, 10, "");
			Win.Add(lblName, txtName);var lblPassword = new Label(1, 1, "Password:");
			TextField txtPassword = new TextField(1, 2, 10, "");
			Win.Add(lblPassword, txtPassword);

			var btnSave = new Button(40, 20, "Guardar", true);
			btnSave.Clicked += () =>
			{
                Employee.Id = Convert.ToInt32(txtId.Text);
                Employee.Name = txtName.Text;
                Employee.Password = txtPassword.Text;
                
                
				db.Employees.Add(Employee);
				db.SaveChanges();

				Application.RequestStop();
			};

			Win.Add(btnSave);
			Application.Run(Win);
		}
	}
}

