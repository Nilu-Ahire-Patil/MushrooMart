<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHomeMaster.Master" AutoEventWireup="true" CodeBehind="Peg_Contact.aspx.cs" Inherits="MySiteNew.Peg_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <link href="Assests/CSS/MySiteBuy.css" rel="stylesheet" />--%>
    <link href="Assests/CSS/MySiteContact.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <a href="#" class="logo">MushrooMart</a>
        <ul>
            <li><a href="../Default.aspx">Home</a></li>
            <li><a href="../Peg_Products.aspx" class="active">Products</a></li>
            <li><a href="#">Team</a></li>
            <li><a href="#">Contact</a></li>
        </ul>
    </header>
    <div class="ConArea">
        <div class="BuyInfo">
            <div class="inputbox">
                <input type="text" required="required">
                <span>Username</span>
                <i></i>
            </div>
            <div class="inputbox">
                <input type="text" required="required">
                <span>Username</span>
                <i></i>
            </div>
            <div class="inputbox">
                <input type="text" required="required">
                <span>Username</span>
                <i></i>
            </div>

        </div>
        <div class="BuyInfo">
            <div class="inputbox">
                <input type="text" required="required">
                <span>Username</span>
                <i></i>
            </div>
            <div class="inputbox">
                <input type="text" required="required">
                <span>Username</span>
                <i></i>
            </div>
            <div class="inputbox">
                <input type="text" required="required">
                <span>Username</span>
                <i></i>
            </div>

        </div>
        <div class="btnSave">
            <input type="submit" class="BtnOrder" value="Order">
        </div>
    </div>

</asp:Content>
