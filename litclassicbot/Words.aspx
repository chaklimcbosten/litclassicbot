<%@ Page Title="Толковый словарь живого великорусского языка В.И.Даля. LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master" AutoEventWireup="true" CodeBehind="Words.aspx.cs" Inherits="litclassicbot.Words" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">   
    <div class="main">
        <h1>Толковый словарь живого, великорусского языка Владимира Ивановича Даля</h1>
        <h2>Слово</h2>
        <asp:Label ID="LabelWordName" runat="server"></asp:Label>
        <h2>Значение слова</h2>
        <asp:Label ID="LabelWordValue" runat="server"></asp:Label>
    </div>
</asp:Content>
