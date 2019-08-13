<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server"  ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Online Tradin System!
    </h2>
 <p>
     Select a store from which you want to buy!</p>
    <p>
        &nbsp;<asp:Panel ID="Panel1" runat="server" Height="210px" Width="247px">
        <asp:BulletedList ID="BulletedList1" runat="server" Height="202px" 
            style="margin-left: 37px" DisplayMode="HyperLink">
           
        </asp:BulletedList>
        </asp:Panel>
      
    </p>
   
 
 
   
</asp:Content>
