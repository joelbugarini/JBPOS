using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;
using NStack;
using System.Linq;
using JBPOS.Controllers;

namespace JBPOS.Views
{
    public static class MainWindow
    {
        public static Window Create(string text)
        {
            var Win = new Window(text)
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 1
            };

            var products = new ProductsController().GetProducts();

			var stockNumbers = products.Select(x => (ustring)x.StockNumber.ToString()).ToList();
			var descriptions = products.Select(x => (ustring)x.Description).ToList();
			var regularPrices = products.Select(x => (ustring)string.Format("{0:c}", x.RegularPrice)).ToList();
			var salePrices = products.Select(x => (ustring)string.Format("{0:c}", x.SalePrice)).ToList();



			// ListView
			var lbListView = new Label ("Productos") {
				ColorScheme = Colors.TopLevel,
				X = 0,
				Width = Dim.Fill ()
			};

			var listStockNumbers = new ListView(stockNumbers)
			{
				X = 0,
				Y = Pos.Bottom(lbListView) + 1,
				Height = Dim.Fill(2),
				Width = Dim.Percent(10)
			};

			var listview = new ListView (descriptions) {
				X = Pos.Percent(10),
				Y = Pos.Bottom (lbListView) + 1,
				Height = Dim.Fill(2),
				Width = Dim.Percent (30)
			};

			var listviewRegularPrice = new ListView(regularPrices)
			{
				X = Pos.Percent(40),
				Y = Pos.Bottom(lbListView) + 1,
				Height = Dim.Fill(2),
				Width = Dim.Percent(20)
			};

			var listviewSalePrice = new ListView(salePrices)
			{
				X = Pos.Percent(60),
				Y = Pos.Bottom(lbListView) + 1,
				Height = Dim.Fill(2),
				Width = Dim.Percent(20)
			};

			Win.Add (lbListView, listStockNumbers, listview, listviewRegularPrice, listviewSalePrice);

            return Win;
        }
    }
}
