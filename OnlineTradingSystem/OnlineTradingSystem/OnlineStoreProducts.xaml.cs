using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
 

namespace OnlineTradingSystem
{
    public partial class MainWindow : Window
    {
        // ********* Product ************
        #region Creat Product List


        private List<Product> LoadCollectionData()
        {
            products = new List<Product>();
            products.Add(new Product());
            return products;
        }

        #endregion

        private void Add_product_click(object sender, RoutedEventArgs e)
        {

            if (products.Count == 0)
            {
                products.Add(new Product());
            }
            else
            {
                products = products[products.Count - 1].AddList(products, numbersID);
            }


            dataGridProduct.Items.Refresh();

            Product proud = products[products.Count - 1];
            Craete_canvas_product(sender, e);

        }
        // ******************************
        #region Open File image
        private void Open_Image()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog()
            {
                Title = "Select Photos",
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif",
                CheckFileExists = true,
                CheckPathExists = true
            };

            Stream myStream = null;



            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Imgeloc = openFileDialog1.FileName.ToString();
                            string file = openFileDialog1.FileName;
                            ib = new ImageBrush() { 
                            ImageSource = new BitmapImage(new Uri(file, UriKind.Relative)) 
                                };
                            piCanv.Background = ib;
                            piCanv.Children.Clear();

                            FileStream fs = new FileStream(Imgeloc, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);

                            //check wher is the picture location
                            string CanvasName = piCanv.Name;
                            int num = Convert.ToInt32(CanvasName.Remove(0, 1));
                            Product pid = products.Where<Product>(X => X.ID == num).Single<Product>();
                            int index = products.IndexOf(pid);
                            ///////////////////////////////

                            products[index].Img = br.ReadBytes((int)fs.Length);
                            Saveimg(products, index);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        //********************** canvas ******************

        #region Canvas Events

        private void Mycanvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            piCanv = sender as Canvas;
            Open_Image();
        }

        #endregion

        private void PiCanv_MouseLeftButtonDown(object sender, EventArgs e)
        {

            piCanv = sender as Canvas;

            Open_Image();

        }


        #endregion

        #region  Save Image To Sql 
        private void Saveimg(List<Product> products, int index)
        {

            //FileStream fs = new FileStream(Imgeloc[Imgeloc.Count], FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs);
            //products[products.Count].img = br.ReadBytes((int)fs.Length);

            DA sqlCom = new DA();
            sqlCom.SaveImageToSql(products, index);


        }
        #endregion

        #region Creat Border List

        private List<Border> GiveMeBorde()
        {
            bord = new List<Border>();
            return bord;

        }
        #endregion

        private void Show_product()
        {
            products = new List<Product>();

            products = sqldata.ImportSqlData(regis);
            ShowAllTheImageProducts();

            dataGridProduct.ItemsSource = products;
            dataGridProduct.Items.Refresh();

        }

        private void Craete_canvas_product(object sender, RoutedEventArgs e)
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

            piCanv.MouseLeftButtonDown += PiCanv_MouseLeftButtonDown;

            gridborder.Children.Add(piCanv);
            gridborder.Children.Add(labelproduct);

            Warp.Children.Add(bord[bord.Count - 1]);


        }

        #region Save image in the canvas
        private void Buid_border_Pic(int i)
        {

            Grid gridborder = new Grid()
            {
                Width = 80,
                Height = 150

            };


            piCanv = new Canvas()
            {
                Name = "c" + products[i].ID.ToString(),
                ToolTip = "Click here to add Image",
                Width = 75,
                Height = 120,
                Margin = new Thickness(1, 40, 1, 1),


                Background = new SolidColorBrush(Colors.LightCyan)

            };

            if (products[i].Img != null)
            {

                byte[] imageBytes = products[i].Img;

                MemoryStream stream = new MemoryStream(imageBytes);
                stream.Write(imageBytes, 0, imageBytes.Length);
                stream.Position = 0;
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                BitmapImage BitObj = new BitmapImage();
                BitObj.BeginInit();

                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                BitObj.StreamSource = ms;
                BitObj.EndInit();

                ib = new ImageBrush() { 
                ImageSource = BitObj
                };
                piCanv.Background = ib;
            }










            Label labelproduct = new Label()
            {
                Content = products[i].ID + "\n " + products[i].ProductName
            };




            bord.Add(new Border()
            {
                Name = "m" + products[i].ID.ToString(),
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

            piCanv.MouseLeftButtonDown += PiCanv_MouseLeftButtonDown;

            gridborder.Children.Add(piCanv);
            gridborder.Children.Add(labelproduct);

            Warp.Children.Add(bord[bord.Count - 1]);






        }
        #endregion

        //*********************** data Grid ***************
        #region Data Grid Events


        private void Addcolum_Click(object sender, RoutedEventArgs e)
        {
            string ColumeName = Prompt.ShowDialog();

            if (string.IsNullOrWhiteSpace(ColumeName) == false)
            {
                dynamic product = new Product();
                DataGridTextColumn textColumn = new DataGridTextColumn()
                {
                Header = ColumeName
                };
              

                // textColumn.Binding = new Binding("FirstName");
                dataGridProduct.Columns.Add(textColumn);

            }
        }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridProduct.Items.Refresh();
        }

        private void DataGrid1_Sorting(object sender, DataGridSortingEventArgs e)
        {

            //var b = dataGrid1.ItemsSource;

            //List<Product> product = (List<Product>)b;


        }

        #endregion

        private void DataGrid1_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var indx = dataGridProduct.SelectedIndex;
            products[indx].DateUpdate = DateTime.Now;

        }

        private void DataGrid_RowEditEnding_Product(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void DataGrid_Sorting_Product(object sender, DataGridSortingEventArgs e)
        {

        }
       
        //************ Refrese Events *********** 

        #region Refrese Grid

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {

            dataGridProduct.Items.Refresh();


        }
        #endregion

        #region Refrase Table

        private void RefraseTable()
        {

            dataGridProduct.Items.Refresh();

        }
        #endregion



    }
}
