<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebApplication2.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        #TextArea1
        {
            height: 126px;
            width: 441px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    </form>
<asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
            
            
           <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderWidth="10px" 
            Height="220px" BackColor="#3366CC" BorderStyle="Outset" ForeColor="#99CCFF" 
            ScrollBars="Auto" style="margin-right: 682px; text-align: center;" 
            Width="163px">
          <asp:Label ID="Label1" runat="server" Text="Product Name"></asp:Label>
            
            
            <asp:Image ID="Image2" runat="server" Height="171px" 
                style="margin-left: 0px; margin-bottom: 0px;" />
            
            
            <asp:Label ID="Label3" runat="server" Text="Price :7656745" BorderStyle="Groove" 
                style="margin-left: 0px"></asp:Label>
            <asp:CheckBox ID="Buy" runat="server" />
        
            
           
            
        
            
 
        
            
           
            
        
            
           
        </asp:Panel>
    <div>
    
    </div>
    </body>
</html>
</asp:Content>