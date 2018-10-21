<%@ Page Title="Пословицы и поговорки, собранные В.И.Далем. LITCLASSIC" Language="C#" 
    MasterPageFile="~/litclassic.Master" AutoEventWireup="true" CodeBehind="Proverbs.aspx.cs" 
    Inherits="litclassicbot.Proverbs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">   
    <div class="main">
        <h1>Пословицы, собранные Владимиром Ивановичем Далем</h1>
        <h2>Пословица</h2>
    </div>
</asp:Content>

<asp:Content ID="FooterContent" ContentPlaceHolderID="FooterContent" runat="server"> 
    <div class="footer-right-column-top">
        <p class="footer-right-text">Опции текущего раздела:</p>
    </div>
    <div class="footer-right-column-bottom">
        <div class="footer-button-right">           
            <a class="button-reload" href="Proverbs.aspx">ОБНОВИТЬ</a>
        </div>
    </div>
</asp:Content>
