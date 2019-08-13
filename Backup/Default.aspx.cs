using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebDAL stor = new WebDAL();
            List<string> StoreName = new List<string>();

            StoreName= stor.ImportStoreName();

            for (int i=0;StoreName.Count>i;i++)
            {
            HyperLink DynLink = new HyperLink();
            
            DynLink.Text = "\n" +StoreName[i];
            DynLink.NavigateUrl = "~/TestPage.aspx";
            ListItem listItem = new ListItem(DynLink.Text);
            BulletedList1.Items.Add(listItem);
          
            }



        }
    }
}
