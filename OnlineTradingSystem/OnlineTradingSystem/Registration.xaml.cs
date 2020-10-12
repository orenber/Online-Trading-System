using System.Windows;


namespace OnlineTradingSystem
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        #region Register 
        public void Register_Click(object sender, RoutedEventArgs e)
        {
            Store regi = new Store()

            {
                Username = UserNameText_Edit.Text,
                Email = EmailText_Edit.Text,
                Password = passwordBoxText_Edit.Password,
             
                Marketname = MarketNameText_Edit.Text,
                Storename = StoreNameText_Edit.Text

            };

            DA dal = new DA();

            /* check if no one is register in the same name 
             * if the name is empty return ok 
             * if the name is already busy return false
            */
            bool ok = dal.RegistrationData(regi);

            if (ok == true)
            {

                this.Close();
            }

        }
        #endregion


        public void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
