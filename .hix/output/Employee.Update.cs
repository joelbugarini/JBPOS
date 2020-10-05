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
			var Win = new Window("Editando Employee" + _id)
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill() - 1
			};

			var product = db.Products.Where(x => x.Id == _id).FirstOrDefault();
            
            var lblId = new Label(1, 1, "Id:");
			TextField txtId = new TextField(1, 2, 10, product.Id.ToString());
			Win.Add(lblId, txtId);var lblName = new Label(1, 1, "Name:");
			TextField txtName = new TextField(1, 2, 10, product.Name.ToString());
			Win.Add(lblName, txtName);var lblPassword = new Label(1, 1, "Password:");
			TextField txtPassword = new TextField(1, 2, 10, product.Password.ToString());
			Win.Add(lblPassword, txtPassword);

			var btnSave = new Button(40, 20, "Guardar", true);
			btnSave.Clicked += () =>
			{
                product.Id = Convert.ToInt32(txtId.Text);
                product.Name = txtName.Text;
                product.Password = txtPassword.Text;
                
                
				db.SaveChanges();

				Application.RequestStop();
			};

			Win.Add(btnSave);
			Application.Run(Win);
		}
	}
}

