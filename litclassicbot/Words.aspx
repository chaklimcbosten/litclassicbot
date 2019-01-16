<%@ Page Title="Толковый словарь живого великорусского языка В.И.Даля. LITCLASSIC" Language="C#"
    MasterPageFile="~/litclassic.Master" AutoEventWireup="true" CodeBehind="Words.aspx.cs" Inherits="litclassicbot.Words" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerWordsPage" runat="server"></asp:ScriptManager>
    <div class="main">
        <div class="main-panel">
            <h1>Толковый словарь живого, великорусского языка Владимира Ивановича Даля</h1>
            <h2>Слово</h2>
            <asp:UpdatePanel ID="UpdatePanelWord" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="LabelWordName" runat="server"></asp:Label>
                    <h2>Значение слова</h2>
                    <asp:Label ID="LabelWordValue" runat="server"></asp:Label>
                    <asp:Label ID="LabelSubtitleWordLinks" runat="server" Visible="False"><h2>Упомянутые в ссылках слова</h2></asp:Label>
                    <asp:Label ID="LabelWordLinks" runat="server" Visible="False"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="interactive-panel">
            <div class="nav-panel">
                <h4>Разделы сайта:</h4>
                <asp:UpdatePanel ID="UpdatePanelNotifications" runat="server">
                    <ContentTemplate>
                        <div class="buttons-nav-panel">
                            <div class="nav-button-wrapper">
                                <a class="nav-button" href="Particles.aspx">"ЧАСТИЦЫ"</a>
                                <div class="particles-notif">
                                    <asp:Label ID="LabelParticleNotification" runat="server" Text="1,2T"></asp:Label></div>
                            </div>
                            <div class="nav-button-wrapper">
                                <a class="nav-button-pressed" href="Words.aspx">СЛОВАРЬ</a>
                                <div class="words-notif">
                                    <asp:Label ID="LabelWordNotification" runat="server" Text="1,2T"></asp:Label></div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="options-panel">
                <h4>Опции раздела:</h4>
                <asp:Button ID="ButtonWordReload" runat="server" Text="ДРУГОЕ СЛОВО" CssClass="button-reload" OnClick="ButtonWordReload_Click" />
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="FooterContentAdaptive" ContentPlaceHolderID="FooterContentAdaptive" runat="server">
    <asp:ImageButton ID="ImageButtonWordReload" runat="server" ImageUrl="~/Content/icons/reload-icon.png"
        Height="24" Width="24" CssClass="image-button" OnClick="ButtonWordReload_Click" />
</asp:Content>
