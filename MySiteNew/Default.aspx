<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHomeMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MySiteNew.Peg_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <a href="#" class="logo">MushrooMart</a>
        <ul>
            <li><a href="../Default.aspx" class="active">Home</a></li>
            <li><a href="../Peg_Products.aspx">Products</a></li>
            <li><a href="#">Team</a></li>
            <li><a href="../Peg_Contact.aspx">Contact</a></li>
        </ul>
    </header>
    <div class="content">
        <h2>Comming Soon...</h2>
        <p>Soon....</p>
        <a href="../Peg_Products.aspx">Buy now</a>
    </div>
    <div class="imgBx">
        <img src="../Images/Home/home_mushroom.png" alt="design">
    </div>
</asp:Content>
