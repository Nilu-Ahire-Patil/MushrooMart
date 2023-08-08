<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHomeMaster.Master" AutoEventWireup="true" CodeBehind="Peg_Products.aspx.cs" Inherits="MySiteNew.Peg_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assests/CSS/MySiteProduct.css" rel="stylesheet" />

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
    <div class="row">
        <asp:Repeater ID="rep_product" runat="server">
            <ItemTemplate>
                <div class="WorkArea">
                    <div class="Product">
                        <img class="ProImage" src="../Images/Product/<%#Eval("image") %>" alt="<%#Eval("image") %>" />
                        <div class="ProName"><%#Eval("pro_name") %></div>
                        <div class="ProPrice"><%#Eval("price") %></div>
                        <asp:Button ID="BtnPro" runat="server" OnClick="Button1_Click" CssClass="ProBuy" CommandName="BtnDis" CommandArgument='<%#Eval("id") %>' Text="Buy" CausesValidation="True" UseSubmitBehavior="False" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
