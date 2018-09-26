<%@ Page Title="Толковый словарь живого великорусского языка В.И.Даля. LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master" AutoEventWireup="true" CodeBehind="Words.aspx.cs" Inherits="litclassicbot.Words" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">   
    <div class="main">
        <h1>Толковый словарь живого, великорусского языка Владимира Ивановича Даля</h1>
        <h2>Слово</h2>
        <asp:Label ID="LabelWordName" runat="server"></asp:Label>
        <h2>Значение слова</h2>
        <asp:Label ID="LabelWordValue" runat="server"></asp:Label>
        <asp:Label ID="LabelWordLinks" runat="server" Visible="False"><h2>Упомянутые в ссылках слова</h2></asp:Label>
    </div>
<%--    <div class="footer">
            <div class="footer-main">
                <div class="footer-buttons">
                    <div class="footer-button">
                        <a class="button-partical" href="Particals.aspx">"ЧАСТИЦЫ"</a>
                    </div>
                    <div class="footer-button">                  
                        <a class="button-word" href="Words.aspx">СЛОВАРЬ В.И.ДАЛЯ</a>
                    </div>
                    <div class="footer-button">                  
                        <a class="button-proverb" href="Proverbs.aspx">ПОСЛОВИЦЫ</a>
                    </div>
                </div>
                <div class="footer-images-buttons">
                    <div class="image-button-partical">
                        <a href="Particals.aspx"><img src="Content/footer/partical-icon.png" height="24" width="24"/></a>
                    </div>
                    <div class="image-button-word">
                        <a href="Words.aspx"><img src="Content/footer/word-icon.png" height="24" width="24"/></a>
                    </div>           
                </div>
            </div>
         </div>--%>    
</asp:Content>

<asp:Content ID="FooterContent" ContentPlaceHolderID="FooterContent" runat="server"> 
    <div class="footer-button-right">           
        <a class="button-reload" href="Words.aspx">ОБНОВИТЬ</a>
    </div>
</asp:Content>
