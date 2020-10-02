using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;
using NStack;
using System.Linq;
using JBPOS.Controllers;
using JBPOS.Models;

namespace JBPOS.Views
{
    public static class Products
	{
		public static Window Win { get; set; }
		public static void Create()
        {

			var Win = new Window("Press Ctrl-Q to exit")
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill() - 1
			};

			var products = new ProductsController().GetProducts();

			List<ustring> descriptions = GetListAsTableString(products);


			View newView = new View();

			// ListView
			var lbListView = new Label("Productos")
			{
				ColorScheme = Colors.TopLevel,
				X = 0,
				Width = Dim.Fill()
			};

			var listDisplay = new ListView(descriptions)
			{
				X = 0,
				Y = Pos.Bottom(lbListView) + 1,
				Height = Dim.Fill(2),
				Width = Dim.Fill()
			};


			Win.Add(lbListView, listDisplay);
			Application.Run(Win);
		}

		private static List<ustring> GetListAsTableString(List<Product> products)
		{
			List<ustring> res = new List<ustring>();
			foreach (var item in products)
			{
				res.Add(item.StockNumber + "│" +
					   (item.Description + "                       ").Substring(0, 25) + "│" +
					    ToMoney(item.RegularPrice) + 
					    ToMoney(item.SalePrice) + 

						item.SalePrice.ToString("    0.00")

					   );
			}
			return res;

		}

		private static string ToMoney(float salePrice)
		{
			return new String(' ', Convert.ToInt32(6 - (salePrice / 100)));
			
		}
	}
}
