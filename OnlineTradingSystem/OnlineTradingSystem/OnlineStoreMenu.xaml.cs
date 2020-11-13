using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace OnlineTradingSystem
{
    public partial class MainWindow : Window
    {

        List<Int32> numbersID;
        DA dal = new DA();
        DataTable dt;

        #region Add Item

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

        #region Exsport Data Table To Sql Server

        private void Export_data_Click(object sender, RoutedEventArgs e)
        {
            sqldata.ExportSqlData(products, regis);
            Export_data.Click += new RoutedEventHandler(Window_Activated);
        }


        #endregion

        #region Import Data table To GrideData
        

        private void Import_data_Click(object sender, RoutedEventArgs e)
        {
 
            numbersID = new List<Int32>();
            sqldata.ImportStoreName();
            numbersID = sqldata.ImportListNumberId();
            Warp.Children.Clear();

            show_product();
            show_supplier();

        }

        #endregion

        #region Remove Product

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (RemoveItem.IsChecked == true)
            {

                Border item = sender as Border;

                try
                {

                    Warp.Children.Remove(item);
                    int index = dataGridProduct.SelectedIndex;
                    var indx = dataGridProduct.SelectedItems;
                    if (indx.Count == 0)
                    {

                        string bordName = item.Name;
                        int num = Convert.ToInt32(bordName.Remove(0, 1));
                        Product pid = products.Where<Product>(X => X.ID == num).Single<Product>();
                        index = products.IndexOf(pid);
                        products.RemoveRange(index, 1);

                    }
                    else if (indx.Count != 0)
                    {
                        products.RemoveRange(index, indx.Count);
                        bord.RemoveRange(index, indx.Count);
                        Warp.Children.RemoveRange(index, indx.Count);
                    }
                }

                catch
                {
                    return;
                }

                finally
                { 
                    dataGridProduct.Items.Refresh();
                }

            }


        }

        #endregion

        #region Enter new Colume


        public static class Prompt
        {
            public static string ShowDialog()
            {
                System.Windows.Forms.Form prompt = new System.Windows.Forms.Form();
                prompt.Width = 200;
                prompt.Height = 150;
                prompt.Left = 0;
                prompt.Text = "New Column";
                System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label() { Left = 50, Top = 20, Text = "Enter new Colume" };
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 100 };
                System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "Ok", Left = 90, Width = 50, Top = 70 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.ShowDialog();
                return textBox.Text;
            }
        }


        #endregion

        #region Product Sales Click
        private void Product_Sales_Click(object sender, RoutedEventArgs e)
        {      
            dt = new DataTable();
            dt = dal.Product_Sales_by_Store_Id(regis);
            dataGridProduct.ItemsSource = dt.AsDataView();

        }
        #endregion

        #region Show Custumer List

        private void Custumer_List_click(object sender, RoutedEventArgs e)
        {
            
            dt = new DataTable();
            dt = dal.Customer_List_By_Store_Id(regis);
            dataGridProduct.ItemsSource = dt.AsDataView();

        }

        #endregion


    }
}
