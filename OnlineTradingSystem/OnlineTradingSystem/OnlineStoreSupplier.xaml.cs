
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace OnlineTradingSystem
{
    public partial class MainWindow : Window
    {

        private void Add_supplier_click(object sender, RoutedEventArgs e)
        {
            suppliers.Add(new BL.Supplier() {

            });
            dataGridSupplier.Items.Refresh();

        }

        #region Import supplier data

        private void Show_supplier()
        {
            suppliers = new List<BL.Supplier>();
            suppliers = sqldata.ImportSupplierData();
            dataGridSupplier.ItemsSource = suppliers;
            dataGridSupplier.Items.Refresh();

        }


        #endregion

        private void DataGrid_RowEditEnding_Supplier(object sender, DataGridRowEditEndingEventArgs e)
        {

     

        }

        private void DataGrid_Sorting_Supplier(object sender, DataGridSortingEventArgs e)
        {

        }

    }


}
