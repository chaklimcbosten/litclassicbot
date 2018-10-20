<%@ Page Title="Толковый словарь живого великорусского языка В.И.Даля. LITCLASSIC" 
    Language="C#" MasterPageFile="~/litclassic.Master" AutoEventWireup="true" 
    CodeBehind="Words.aspx.cs" Inherits="litclassicbot.Words" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">   
    <asp:ScriptManager ID="ScriptManagerWordsPage" runat="server"></asp:ScriptManager>
    <div class="main">
        <h1>Толковый словарь живого, великорусского языка Владимира Ивановича Даля</h1>
        <h2>Слово</h2>
        <asp:UpdatePanel ID="UpdatePanelWord" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="LabelWordName" runat="server"></asp:Label>
                <h2>Значение слова</h2>
                <asp:Label ID="LabelWordValue" runat="server"></asp:Label>
                <asp:Label ID="LabelWordLinks" runat="server" Visible="False">
                    <h2>Упомянутые в ссылках слова</h2></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>
</asp:Content>

<asp:Content ID="FooterContent" ContentPlaceHolderID="FooterContent" runat="server"> 
    <div class="footer-button-right">           
        <asp:Button ID="ButtonWordReload" runat="server" Text="ОБНОВИТЬ" CssClass="button-reload" 
                OnClick="ButtonWordReload_Click" />
    </div>
</asp:Content>
