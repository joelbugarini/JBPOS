using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;
using NStack;
using System.Linq;

namespace JBPOS.Views
{
    public static class MainScreen
    {
        public static Window Render()
        {
            var Win = new Window("Punto de venta")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 1
            };

            Label message = new Label(1, 1, "Sistema de punto de venta desarrollado por joel bugarini");

            Win.Add(message);

            return Win;
        }

	}
}
