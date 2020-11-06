
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace OnlineTradingSystem
{
    public partial class MainWindow : Window
    {

        private void add_supplier_click(object sender, RoutedEventArgs e)
        {
            suppliers.Add(new BL.Supplier() {

            });
            dataGridSupplier.Items.Refresh();

        }

        #region Import supplier data

        private void show_supplier()
        {
            suppliers = new List<BL.Supplier>();
            suppliers = sqldata.ImportSupplierData();
            dataGridSupplier.ItemsSource = suppliers;
            dataGridSupplier.Items.Refresh();

        }


        #endregion

        private void dataGrid_RowEditEnding_Supplier(object sender, DataGridRowEditEndingEventArgs e)
        {
            
            int indx = dataGridSupplier.SelectedIndex;
            int columnName = dataGridSupplier.CurrentColumn.DisplayIndex;
            string haeder= dataGridSupplier.CurrentColumn.Header.ToString();

        }

        private void dataGrid_Sorting_Supplier(object sender, DataGridSortingEventArgs e)
        {

        }

    }


}
