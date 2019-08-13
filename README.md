# Online-Trading-System
Online Trading system This software is divided into two projects customer interface -a website that allows customers to make purchases through the website.  administrator user interface enables an administrator to upload products from the desktop.

Online Trading system
 This software is divided into two projects

customer interface -a website that allows customers to make purchases through the website. 
administrator user interface enables an administrator to upload products from the desktop.                                                                                                                                                                                       
web interface - intro

"source":"/Content/Common/videoplayer.xap","initParams":"deferredLoad=false,duration=0,m=https://i1.code.msdn.s-msft.com/online-trading-system-935a449d/image/file/131677/1/njk.wmv,autostart=false,autohide=true,showembed=true","background":"#00FFFFFF","minRuntimeVersion":"3.0.40624.0","enableHtmlAccess":"true","src":"https://i1.code.msdn.s-msft.com/online-trading-system-935a449d/image/file/131677/1/njk.wmv","id":"131677","name":"njk.wmv"

Web interface

In This website the customer can register and start to conduct purchases on the website,

On the opening page he have to choose the store that he wanted to visit,

there is a link to every store





but first the customer need to register/ login in order to start to make purchases.







as soon as the customer enter to the store link it Opens a page with all the stores products for sale.



This application was made by the use of technologies server side:

ASP.Net
Sql
To buy a product - mark a check in the checkbox And you can see the product thet you want to buy  in the right shopping list
In order to realize your purchase, click on the button "Buy Products".
to Cancel product from your shopping list, uncheck the mark in the checkbox.
Some of the products in the stores you can see a video about the product from YouTube .         Simple, double-click on the panel that leads to the panel turns and you can see the videoDouble-clicking again will return the panel to the previous state .


This application was made by the use of technologies client side:



html5
css3
Ajaxs
javascript
jqwery


view purchases:

To view purchases made in the past, just go to the page "View shopping" from the menu above .





___________________________________________________________________

Administrator interface -desktop appliction

"source":"/Content/Common/videoplayer.xap","initParams":"deferredLoad=false,duration=0,m=https://i1.code.msdn.s-msft.com/online-trading-system-935a449d/image/file/132258/1/onlinetrading.wmv,autostart=false,autohide=true,showembed=true","background":"#00FFFFFF","minRuntimeVersion":"3.0.40624.0","enableHtmlAccess":"true","src":"https://i1.code.msdn.s-msft.com/online-trading-system-935a449d/image/file/132258/1/onlinetrading.wmv","id":"132258","name":"onlinetrading.wmv" 

This application was made by the use of technologies :

WPF
SQL
This app allows the store owner to advertise his products on the site ,

You can open a store and update products exported to the database of the site

The products will be  update automatically in to the store page  And will be able be seen by the buyers 







Registered manager

To create a new store  the store owner have to register

just click on the link and fill your record and password



Log In

to enter to the store you have just created click on the link "log in"

and fill your name and password



Store Manager view

after you have just log in you can see the Administrator view 

When here you can:



update your products
View the products bought
view on the customer information


Insert New product 

to insert new product : click on the "Add item" button in the left menu 

and anew cyan panel will created 

Click on the bottom of the panel and insert the product image in the file maneger 

without any image ther  is not possible to upload product!

for Uploading Product details click on the "Product List" in the grey tab menu above



Remove product

to remove item from the store just click on the "Remove item" button and than press  

on the panel you want that will be removed or - click on the "Product List" and than  

Select the products with the mouse  and than press on the "Remove Item" button

the selected item will be deleted



Export Data

Once you've made any changes You must update the database for these changes will be valid

press on the "Export Data" button and all the changes you have made will take affect



SQLC#
Edit|Remove
USE [Online Trading System DB] 
GO 
/****** Object:  StoredProcedure [dbo].[InsertUpdate]    Script Date: 12/15/2014 12:38:16 ******/ 
SET ANSI_NULLS ON 
GO 
SET QUOTED_IDENTIFIER ON 
GO 
ALTER proc [dbo].[InsertUpdate] 
@storeid int, 
@id int, 
@prod nvarchar(50), 
@category nvarchar(50), 
@price numeric, 
@instock bit, 
@count real, 
@DateUpdate datetime, 
@description nvarchar(max), 
@Url nvarchar(max) 
as 
begin 
 
if exists( select [StoreId] from DBT where StoreId like @storeid) 
begin 
        if exists( select [ID] from DBT where ID like @ID ) 
        begin 
 
                print 'update' 
                update [DBT]  
 
                set 
                [ProductName]=@prod, 
                [Category]=@category, 
                [Price]=@price, 
                [Instock]=@instock, 
                [Count]=@count, 
                [DateUpdate]=@DateUpdate, 
                [Description]=@description, 
                [url]=@Url 
 
                where ID like @id and StoreId like @storeid 
                                 
             
 
        end 
 
        else if not exists( select [ID] from DBT where ID like @ID ) 
 
        begin 
         
            print 'insert' 
            insert into [DBT] (StoreId,ID,ProductName,Category,Price,Instock,[Count],DateUpdate, [Description],[url]) 
             
            values  
            ( 
            @storeid, 
            @id, 
            @prod,   
            @category,   
            @price,  
            @instock , 
            @count,   
            @DateUpdate, 
            @description,   
            @Url  
            ) 
                 
                 
        end 
  end 
   
   
  else  
  begin 
   
  print 'Shope not exist' 
  end 
 
 end 
 
 




Import Data

to import the product database: click on the " Import Data " button in the left menu



SQLC#
Edit|Remove
USE [Online Trading System DB] 
GO 
/****** Object:  StoredProcedure [dbo].[StoreDataById]    Script Date: 12/15/2014 12:44:28 ******/ 
SET ANSI_NULLS ON 
GO 
SET QUOTED_IDENTIFIER ON 
GO 
ALTER proc [dbo].[StoreDataById] 
 
@storeid int  
as 
begin 
 
select  
       StoreId, 
       StoreName, 
       ManegerName, 
       Market, 
       RegisterDate 
   
 
 
from [Shope] 
 
where StoreId like @storeid 
 
end
 




Product Sales

If you want to watch any of the products bought inyour store

click on "Product Sales" button from the left blue menu and than click on the "Product List"

from the grey tab menu above list of product will appers on the Gridview 

You can view in the list:



Customer who bought this product
Which product was purchased
On what date the product was purchased
When the client are registered to the site
and another information about the product that purchased

if you want to watch all your product list again - click on the "Import Data" button from the left menu. 



Log off

Return to the main Window by click on the " Main Window" button on the left  menu 



Your Site

You can view the page of your shop on site  And other additional stores 

By using the site manager browser :

click on the "Your Site" grey tab above and watch the Online Trading System web site 

from the Administrator interface. 

The browser is IE's browser so that some applications may not have been active such as watching  on

YouTube, Rotate the panel And the display will look different.





This software was created by Oren Berkovich 2014.

Email: orenber@hotmail.com
