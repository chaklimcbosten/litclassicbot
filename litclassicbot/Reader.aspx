<%@ Page Title="Чтение книг. LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master" 
    AutoEventWireup="true" CodeBehind="Reader.aspx.cs" Inherits="litclassicbot.Reader" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">   
    <div class="main">
        <h1>Чтение книг</h1>
        <h2>Начатые книги</h2>
        <h2>Чтение</h2>
    </div>
</asp:Content>

<asp:Content ID="FooterContent" ContentPlaceHolderID="FooterContent" runat="server"> 
    <div class="footer-right-column-top">
        <p class="footer-right-text">Опции текущего раздела:</p>
    </div>
    <div class="footer-right-column-bottom">
<%--    <div class="footer-button">--%>
        <div class="footer-button-right">
            <asp:Button ID="ButtonReadNext" runat="server" Text="ЧИТАТЬ ДАЛЕЕ" 
                CssClass="button-read-next" />
        </div>
        <div class="footer-button-right">
            <asp:Button ID="ButtonReadPrevious" runat="server" Text="ЧИТАТЬ ПРЕДЫДУЩЕЕ" 
                CssClass="button-read-previous" />
        </div>       
<%--    </div>--%>
    </div>
</asp:Content>
