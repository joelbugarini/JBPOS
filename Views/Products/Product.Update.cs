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
    public class ProductUpdate
	{
		public Window Win { get; set; }
		public JBPOS_DB_Context db { get; set; }
		public ProductUpdate(JBPOS_DB_Context _db) {
			db = _db;
		}
		public void Render(int _stock)
        {
			var Win = new Window("Editando Producto " + _stock)
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill() - 1
			};

			var product = db.Products.Where(x => x.StockNumber == _stock).FirstOrDefault();

			var lblStockNumber = new Label(1, 1, "StockNumber:");
			TextField txtStockNumber = new TextField(1, 2, 10, product.StockNumber.ToString());
			Win.Add(lblStockNumber, txtStockNumber);

			var lblDescription = new Label(1, 4, "Description:");
			TextField txtDescription = new TextField(1, 5, 25, product.Description);
			Win.Add(lblDescription, txtDescription);


			var lblRegularPrice = new Label(1, 7, "RegularPrice:");
			TextField txtRegularPrice = new TextField(1, 8, 10, product.RegularPrice.ToString());
			Win.Add(lblRegularPrice, txtRegularPrice);


			var lblSalePrice = new Label(1, 10, "SalePrice:");
			TextField txtSalePrice = new TextField(1, 11, 10, product.SalePrice.ToString());
			Win.Add(lblSalePrice, txtSalePrice);


			var lblNoSold = new Label(1, 13, "NoSold:");
			TextField txtNoSold = new TextField(1, 14, 10, product.NoSold.ToString());
			Win.Add(lblNoSold, txtNoSold);


			var lblValueSold = new Label(40, 1, "ValueSold:");
			TextField txtValueSold = new TextField(40, 2, 10, product.ValueSold.ToString());
			Win.Add(lblValueSold, txtValueSold);


			var lblInventory = new Label(40, 4, "Inventory:");
			TextField txtInventory = new TextField(40, 5, 10, product.Inventory.ToString());
			Win.Add(lblInventory, txtInventory);


			var lblCost = new Label(40, 7, "Cost:");
			TextField txtCost = new TextField(40, 8, 10, product.Cost.ToString());
			Win.Add(lblCost, txtCost);


			var lblModel = new Label(40, 10, "Model:");
			TextField txtModel = new TextField(40, 11, 10, product.Model.ToString());
			Win.Add(lblModel, txtModel);


			var lblPack = new Label(40, 13, "Pack:");
			TextField txtPack = new TextField(40, 14, 10, product.Pack.ToString());
			Win.Add(lblPack, txtPack);


			var lblVendorStockNumber = new Label(40, 16, "VendorStockNumber:");
			TextField txtVendorStockNumber = new TextField(40, 17, 10, product.VendorStockNumber.ToString());
			Win.Add(lblVendorStockNumber, txtVendorStockNumber);

			var btnSave = new Button(40, 20, "Guardar", true);
			btnSave.Clicked += () =>
			{
				product.StockNumber = Convert.ToInt32(txtStockNumber.Text);
				product.Description = txtDescription.Text.ToString();
				product.RegularPrice = Convert.ToInt32(txtRegularPrice.Text);
				product.SalePrice = Convert.ToInt32(txtSalePrice.Text);
				product.NoSold = Convert.ToInt32(txtNoSold.Text);
				product.ValueSold = Convert.ToInt32(txtValueSold.Text);
				product.Inventory = Convert.ToInt32(txtInventory.Text);
				product.Cost = Convert.ToInt32(txtCost.Text);
				product.Model = Convert.ToInt32(txtModel.Text);
				product.Pack = Convert.ToInt32(txtPack.Text);
				product.VendorStockNumber = txtVendorStockNumber.Text.ToString();

				db.SaveChanges();

				Application.RequestStop();
			};

			Win.Add(btnSave);
			Application.Run(Win);
		}
	}
} 