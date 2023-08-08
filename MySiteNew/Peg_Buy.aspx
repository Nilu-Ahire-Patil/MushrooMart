<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHomeMaster.Master" AutoEventWireup="true" CodeBehind="Peg_Buy.aspx.cs" Inherits="MySiteNew.Peg_Buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assests/CSS/MySiteBuy.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <a href="#" class="logo">logo</a>
        <ul>
            <li><a href="../Default.aspx">Home</a></li>
            <li><a href="../Peg_Products.aspx" class="active">Products</a></li>
            <li><a href="#">Team</a></li>
            <li><a href="../Peg_Contact.aspx">Contact</a></li>
            <li><a href="../Peg_About.aspx">About</a></li>
        </ul>
    </header>
    <!-- main content -->
    <div class="BuyArea">

        <div class="ProductPreview">
            <asp:Repeater ID="rep_buy_pro" runat="server">
                <ItemTemplate>
                    <div class="Product">
                        <img class="ProImage" src="../Images/Product/<%#Eval("image") %>" alt="<%#Eval("image") %>" />
                        <div class="ProName"><%#Eval("pro_name") %></div>
                        <div class="ProPrice"><%#Eval("price") %></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="Offerarea">
                <asp:Repeater ID="rep_offer" runat="server">
                    <ItemTemplate>
                        <div class="Offer">
                            <div class="Offervolume"><%#Eval("off_volume") %></div>
                            <div class="Offerprice"><%#Eval("off_price") %></div>
                            <asp:Button ID="OfferSelect1" runat="server" OnClick="OfferSelect_Click" CssClass="Offerselect" CommandName="BtnDis" CommandArgument='<%#Eval("off_id") %>' Text="Select" CausesValidation="True" UseSubmitBehavior="False" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>




        <div class="UserInfo">
            <div class="inputbox">
                <asp:TextBox ID="txt_name" CssClass="input" required="required" runat="server"></asp:TextBox>

                <span>Name</span>
                <i></i>
            </div>
            <div class="inputbox">
                <asp:TextBox ID="txt_contact" CssClass="input" required="required" runat="server"></asp:TextBox>

                <span>Contact</span>
                <i></i>
            </div>
            <div class="inputbox">
                 <asp:TextBox ID="txt_address" CssClass="input" required="required" runat="server"></asp:TextBox>
               
                <span>Address</span>
                <i></i>
            </div>

        </div>
        <div class="BuyInfo">
            <div class="inputboxselected">
                 <asp:TextBox ID="txt_amount" ReadOnly="true" CssClass="input" required="required" runat="server"></asp:TextBox>
                <span>Bill</span>
                <i></i>
            </div>
            <div class="inputbox">
                 <asp:TextBox ID="txt_" CssClass="input" required="required" runat="server"></asp:TextBox>
               
                <span>Username</span>
                <i></i>
            </div>
            <div class="inputbox">
                 <asp:TextBox ID="TextBox1" CssClass="input" required="required" runat="server"></asp:TextBox>
                <span>Username</span>
                <i></i>
            </div>

        </div>
        <div class="btnSave">
            <input type="submit" class="BtnOrder" value="Order">
        </div>
    </div>
</asp:Content>
