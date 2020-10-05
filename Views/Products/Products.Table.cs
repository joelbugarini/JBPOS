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
    public class ProductsTable
	{
		public Window Win { get; set; }
		public JBPOS_DB_Context db { get; set; }
		public int StockItemSelected { get; set; }
		public string State { get; set; }
		public List<ustring> items { get; set; }
		public ProductsTable(JBPOS_DB_Context _db) {
			db = _db;
		}
		public void Render()
        {
 
			var Win = new Window("Productos")
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill() - 1
			};
			State = "PRODUCTS";


			List<ustring> items = GetListAsTableString();


			View newView = new View();

			ustring header = " STOCK#│        DESCRIPCION       │ PRECIO.R │ PRECIO.V │MODEL│ PACK│";
			// ListView
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
				StockItemSelected = Convert.ToInt32(res.Split("│")[0]);
			};

			table.KeyUp += (a) => {
				if (a.KeyEvent.KeyValue == 1048591 && State == "PRODUCTS") {
					State = "UPDATE_PRODUCT";
					new ProductCreate(db).Render();
					table.SetSource(GetListAsTableString());
					State = "PRODUCTS";
				}
				if (a.KeyEvent.KeyValue == 1048593 && State == "PRODUCTS") {
					State = "UPDATE_PRODUCT";
					new ProductUpdate(db).Render(StockItemSelected);
					table.SetSource(GetListAsTableString());
					State = "PRODUCTS";
				}
				if (a.KeyEvent.KeyValue == 1048598 && State == "PRODUCTS") {
					State = "UPDATE_PRODUCT";
					db.Products
						.Remove(db
							.Products
								.Where(x => x.StockNumber == StockItemSelected)
								.FirstOrDefault()
						);
					db.SaveChanges();
					table.SetSource(GetListAsTableString());
					State = "PRODUCTS";
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

		private List<ustring> GetListAsTableString()
		{
			List<ustring> res = new List<ustring>();
			var products = db.Products.ToList();
			foreach (var item in products)
			{
				res.Add(" " + item.StockNumber + "│ " +
					  ToLongString(item.Description) + 
					    ToMoney(item.RegularPrice) + 
					    ToMoney(item.SalePrice) + 
					    ToNumber(item.Model) + 
					    ToNumber(item.Pack)  
					   );
			}
			return res;

		}

		private static object ToLongString(string v)
		{
			return  (v + new String(' ', 25 - v.Length)).Substring(0, 25) + "│"; 
		}

		private static string ToNumber(int number)
		{
			return new String(' ', 5 - number.ToString().Count()) + number + "│";
		}

		private static string ToMoney(float salePrice)
		{
			return new String(' ', 7 - salePrice.ToString().Count()) + salePrice.ToString("0.00") + "│";
		}
	}
}
