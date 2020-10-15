using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Configuration;

namespace OnlineTradingSystem
{
    public partial class MainWindow : Window
    {

        #region Add Product

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab = tabsTopControl.SelectedItem as TabItem;
            switch (tab.Name)
            {
                case "Product_List":
                    add_product_click(sender, e);
                    break;
                case "Supplier_List":
                    add_supplier_click(sender, e);

                    break;

            }
           
            // Add item to the data tabel
           
        }

        #endregion




        private void add_product_click(object sender, RoutedEventArgs e)
        {

            if (products.Count == 0)
            {

                products.Add(new Product());
            }
            else
            {
                 products = products[products.Count - 1].AddList(products, numbersID);
            }
            dataGrid1.Items.Refresh();

            Product proud = products[products.Count - 1];
            craete_canvas_product(sender, e);

        }

        private void add_supplier_click(object sender, RoutedEventArgs e)
        {
            suppliers.Add(new BL.Supplier() {

            });
            dataGridSupplier.Items.Refresh();


        }


        private void craete_canvas_product(object sender, RoutedEventArgs e)
        {


            Grid gridborder = new Grid()
            {
                Width = 80,
                Height = 150

            };


            piCanv = new Canvas()
            {
                Name = "c" + products[products.Count - 1].ID.ToString(),
                ToolTip = "Click here to add Image",
                Width = 75,
                Height = 120,
                Margin = new Thickness(1, 40, 1, 1),
                Background = new SolidColorBrush(Colors.LightCyan),

            };



            Label labelproduct = new Label()
            {
                Content = products[products.Count - 1].ID + "\n " + products[products.Count - 1].ProductName
            };



            bord.Add(new Border()
            {
                Name = "b" + products[products.Count - 1].ID.ToString(),
                Width = 100,
                Height = 200,
                CornerRadius = new CornerRadius(15),
                BorderThickness = new Thickness(5, 10, 15, 20),
                Margin = new Thickness(15, 5, 5, 5),
                BorderBrush = Brushes.SlateBlue,
                Child = gridborder,
                Style = Resources["borderStyle"] as Style


            });


            bord[bord.Count - 1].MouseRightButtonDown += RemoveItem_Click;

            piCanv.MouseLeftButtonDown += piCanv_MouseLeftButtonDown;

            gridborder.Children.Add(piCanv);
            gridborder.Children.Add(labelproduct);

            Warp.Children.Add(bord[bord.Count - 1]);


        }

        private void dataGrid_RowEditEnding_Supplier(object sender, DataGridRowEditEndingEventArgs e)
        {
            
            int indx = dataGridSupplier.SelectedIndex;
            int columnName = dataGridSupplier.CurrentColumn.DisplayIndex;
            string haeder= dataGridSupplier.CurrentColumn.Header.ToString();
            dataGridSupplier.CurrentCell.Item


        }


    }





}
