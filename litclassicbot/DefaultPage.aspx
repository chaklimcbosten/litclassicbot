<%@ Page Title="LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="litclassicbot._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main">
        <h1><asp:Label ID="LabelSubtitleMain" runat="server" Text="Главная страница" 
            CssClass="label-subtitle-main"></asp:Label></h1>

        <h2><asp:Label ID="LabelSubtitleAboutSite" runat="server" Text="О сайте"
            CssClass="label-subtitle-about-site"></asp:Label></h2>
            
        <asp:Label ID="LabelAboutSite" runat="server" CssClass="label-about-site"></asp:Label>

        <h2><asp:Label ID="LabelSubtitlePartical" runat="server" Text="О частицах"
            CssClass="label-subtitle-partical"></asp:Label></h2>

        <asp:Label ID="LabelPartical" runat="server" CssClass="label-partical"></asp:Label>

        <h2><asp:Label ID="LabelSubtitleNavigation" runat="server" Text="Навигация" 
            CssClass="label-subtitle-navigation"></asp:Label></h2>

        <asp:Label ID="LabelNavigation" runat="server" CssClass="label-navigation"></asp:Label>

        <h2><asp:Label ID="LabelSubtitleStatistics" runat="server" Text="Статистика" 
            CssClass="label-subtitle-statistics"></asp:Label></h2>
            
        <asp:Label ID="LabelStatistics" runat="server" CssClass="label-statistics"></asp:Label>

        <h2><asp:Label ID="LabelSubtitleGratitudes" runat="server" Text="Благодарности" 
            CssClass="label-subtitle-gratitudes"></asp:Label></h2>

        <asp:Label ID="LabelGratitudes" runat="server" CssClass="label-gratitudes"></asp:Label>



        <asp:Label ID="LabelToCopy" runat="server" Visible="False"></asp:Label>

        <div class="image-button-copy-to-clipboard">
            <button id="btn" data-clipboard-target="label-partical-line"> </button>

            <%--<script src="Scripts/clipboard.min.js"></script>--%>
            <script>
                var copyText = document.getElementById('.label-partical-line');

                copyText.select();

                document.execCommand("copy");
                //var LabelToCopy = document.getElementById("label-to-copy");
                //var clipboard = new ClipboardJS(LabelToCopy);
                //clipboard.on('success', function (e) {
                //    console.log(e);
                //});
                //clipboard.on('error', function (e) {
                //    console.log(e);
                //});
            </script>
        </div>
    </div>
</asp:Content>
