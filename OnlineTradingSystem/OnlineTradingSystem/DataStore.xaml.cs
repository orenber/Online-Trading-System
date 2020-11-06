using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;




namespace OnlineTradingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Instance
        DA sqldata = new DA();
        string Imgeloc = "";
        private List<Product> products;
        private List<BL.Supplier> suppliers;
        private Store regis;
        private Canvas piCanv;
        private ImageBrush ib;
        List<Border> bord = new List<Border>();

        #endregion

        #region constructor
        public MainWindow(Store _ur)
        {
            InitializeComponent();
            regis = _ur;
            NameofStore.Text = regis.Storename;
        }
        public MainWindow()
        {
            InitializeComponent();

        } 
        #endregion

        //************************* Animation ***********************

        #region Window_Activate -Start animation

        private void Window_Activated(object sender, EventArgs e)
        {

            var winHigth = this.Height;
            var winWidth = this.Width;


            var top = Canvas.GetTop(image1);
            var left = Canvas.GetLeft(image1);

            Storyboard sb = new Storyboard();
            foreach (var ab in MoveTo(image1, left, top, winWidth - 300, 0))
                sb.Children.Add(ab);

            foreach (var ab in MoveTo(image1, 0, winWidth - 300, 3, 3))
            {
                ab.BeginTime = TimeSpan.FromSeconds(5);
                sb.Children.Add(ab);
            }

            (image1).BeginStoryboard(sb);




        }

        public static void MoveTo(Image target, double newX, double newY)
        {

            var top = Canvas.GetTop(target);
            var left = Canvas.GetLeft(target);
            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(top, newY - top, TimeSpan.FromSeconds(2));
            DoubleAnimation anim2 = new DoubleAnimation(left, newX - left, TimeSpan.FromSeconds(2));
            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
            trans.BeginAnimation(TranslateTransform.YProperty, anim2);

        }

        static IEnumerable<DoubleAnimation> MoveTo(Image target, double origX, double origY, double newX, double newY)
        {

            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;
            var a = new DoubleAnimation(origX, newY, TimeSpan.FromSeconds(2));
            Storyboard.SetTargetProperty(a, new PropertyPath("(Canvas.Top)"));
            var b = new DoubleAnimation(origY, newX, TimeSpan.FromSeconds(2));
            Storyboard.SetTargetProperty(b, new PropertyPath("(Canvas.Left)"));

            yield return a;
            yield return b;
        }

        #endregion

        //******************* Show your web Store **************

        #region Show Web Page

        private void MyWebrowser_Loaded(object sender, RoutedEventArgs e)
        {
            MyWebrowser.Navigate(new Uri("http://localhost:5085"));
        }

        #endregion

        //*******************  Main Window Store **************

        #region Window Loadaed

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*  products = LoadCollectionData();*/
            Import_data_Click(sender, e);

        }


        private void ShowAllTheImageProducts()
        {
            for (int i = 0; i < products.Count; i++)
            {

                Buid_border_Pic(i);

            };

        }
        #endregion

        #region Back To The Main Window
        private void BackMainWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Are you sure?

            this.Hide();
            Window1 super = new Window1();
            super.Show();

        } 
        #endregion
        
        #region Window Closed
        private void Window_Closed(object sender, EventArgs e)
        {

            Environment.Exit(0);
        } 
        #endregion

    }


}
