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
    public class EmployeesTable
	{
		public Window Win { get; set; }
		public JBPOS_DB_Context db { get; set; }
		public int ItemSelected { get; set; }
		public string State { get; set; }
		public List<ustring> items { get; set; }
		public EmployeesTable(JBPOS_DB_Context _db) {
			db = _db;
		}
		public void Render()
        {
 
			var Win = new Window("Empleados")
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill() - 1
			};
			State = "Employee";


			List<ustring> items = GetEmployeeList();


			View newView = new View();

			ustring header = 
                "   Id │" +
                "           Name          │" +
                "  Password  │" 
                ;
                
			var lbListView = new Label(header)
			{
				ColorScheme = Colors.TopLevel,
				X = 0,
				Y = 1,
				Width = Dim.Fill() - 1
			};

			var table = new ListView(items)
			{
				X = 0,
				Y = Pos.Bottom(lbListView) + 1,
				Height = Dim.Fill() - 2,
				Width = Dim.Fill()
			};

			table.SelectedItemChanged += (ListViewItemEventArgs e) => {
				var res = (ustring)table.Source.ToList()[table.SelectedItem];
				ItemSelected = Convert.ToInt32(res.Split("│")[0]);
			};

			table.KeyUp += (a) => {
				if (a.KeyEvent.KeyValue == 1048591 && State == "Employee") {
					State = "UPDATE_Employee";
					new EmployeeCreate(db).Render();
					table.SetSource(GetEmployeeList());
					State = "Employee";
				}
				if (a.KeyEvent.KeyValue == 1048593 && State == "Employee") {
					State = "UPDATE_Employee";
					new EmployeeUpdate(db).Render(ItemSelected);
					table.SetSource(GetEmployeeList());
					State = "Employee";
				}
				if (a.KeyEvent.KeyValue == 1048598 && State == "Employee") {
					State = "UPDATE_Employee";
					db.Employees
						.Remove(db
							.Employees
								.Where(x => x.Id == ItemSelected)
								.FirstOrDefault()
						);
					db.SaveChanges();
					table.SetSource(GetEmployeeList());
					State = "Employee";
				}
			};

			var lblBottom = new Label("F5 para agregar    "+ 
									  "F7 para editar    "+
									  "F12 para eliminar    "+
									  "Ctrl + Q para salir")
			{
				X = 0,
				Y = Pos.Bottom(table) + 1
			};

			Win.Add(lbListView, table, lblBottom);
			Application.Run(Win);
		}

		private List<ustring> GetEmployeeList()
		{
			List<ustring> res = new List<ustring>();
			var Employee = db.Employees.ToList();
			foreach (var item in Employee)
			{
				res.Add(" " +                         
                        ToNumber(item.Id) +
                        ToLongString(item.Name) +
                        ToSmallString(item.Password)  
                        
					   );
			}
			return res;

		}

		private string ToSmallString(string v)
		{
			return  (v + new String(' ', 12 - v.Length)).Substring(0,12) + "│"; 
		}

		private static object ToLongString(string v)
		{
			return  (v + new String(' ', 25 - v.Length)).Substring(0, 25) + "│"; 
		}

		private static string ToNumber(int number)
		{
			return new String(' ', 5 - number.ToString().Count()) + number + "│";
		}

		private static string ToMoney(float number)
		{
			return new String(' ', 7 - number.ToString().Count()) + number.ToString("0.00") + "│";
		}
	}
}

