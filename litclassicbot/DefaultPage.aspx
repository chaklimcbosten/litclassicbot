<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="litclassicbot.FirstWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LITCLASSIC - сервис привлечения внимания к русской классической литературе</title>
    <link href="DefaultPageStyleSheet.css" rel="stylesheet" type="text/css"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:300&amp;subset=cyrillic-ext" rel="stylesheet" /> 
</head>
<body>
    <form class="form1" runat="server">
--%>

        
<%@ Page Title="LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="litclassicbot._Default" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">





        <div class="main">
            <h1><asp:Label ID="LabelSubtitleMain" runat="server" Text="Главная страница" 
                CssClass="label-subtitle-main"></asp:Label></h1>

            <p><asp:Label ID="LabelSubtitleParticalLine" runat="server" 
                CssClass="label-subtitle-partical-line" Visible="False"></asp:Label></p>

            <h2><asp:Label ID="LabelSubtitleAboutSite" runat="server" Text="О сайте"
                CssClass="label-subtitle-about-site"></asp:Label></h2>
            
            <asp:Label ID="LabelAboutSite" runat="server" CssClass="label-about-site"></asp:Label>

            <h2><asp:Label ID="LabelSubtitlePartical" runat="server" Text="О частицах"
                CssClass="label-subtitle-partical"></asp:Label></h2>

            <asp:Label ID="LabelPartical" runat="server" CssClass="label-partical"></asp:Label>

            <asp:Label ID="LabelParticalLine" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LabelPoemParticalLine" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LabelWordName" runat="server" Visible="False"></asp:Label>

            <h2><asp:Label ID="LabelSubtitleNavigation" runat="server" Text="Навигация" 
                CssClass="label-subtitle-navigation"></asp:Label></h2>

            <asp:Label ID="LabelNavigation" runat="server" CssClass="label-navigation"></asp:Label>

            <p><asp:Label ID="LabelSubtitleParticalTitle" runat="server" 
                CssClass="label-subtitle-partical-title" Visible="False"></asp:Label></p>

            <asp:Label ID="LabelParticalTitle" runat="server" Text="Здесь будет описание 
                произведения и книги." Visible="False"></asp:Label>              
            <asp:Label ID="LabelWordValue" runat="server" Text="Здесь будет значение слова 
                из словаря В.И.Даля." Visible="False"></asp:Label>

            <h2><asp:Label ID="LabelSubtitleStatistics" runat="server" Text="Статистика" 
                CssClass="label-subtitle-statistics"></asp:Label></h2>
            
            <asp:Label ID="LabelStatistics" runat="server" CssClass="label-statistics"></asp:Label>

            <h2><asp:Label ID="LabelSubtitleGratitudes" runat="server" Text="Благодарности" 
                CssClass="label-subtitle-gratitudes"></asp:Label></h2>

            <asp:Label ID="LabelGratitudes" runat="server" CssClass="label-gratitudes"></asp:Label>



            <asp:Label ID="LabelToCopy" runat="server" Visible="False"></asp:Label>

            <div class="image-button-copy-to-clipboard">
                <button id="btn" data-clipboard-target="label-partical-line"> </button>

                <script src="Scripts/clipboard.min.js"></script>
                <script>
                    var LabelToCopy = document.getElementById("label-to-copy");
                    var clipboard = new ClipboardJS(LabelToCopy);
                    clipboard.on('success', function (e) {
                        console.log(e);
                    });
                    clipboard.on('error', function (e) {
                        console.log(e);
                    });
                </script>

<%--                <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButtonCopyToClipboard_Click" 
                    ImageUrl="Content/icons/copy-to-clipboard-icon.png" Height="24" />--%>
            </div>
        </div>


        <div class="footer">
            <div class="footer-main">
                <div class="footer-buttons">
                    <div class="footer-button-partical">
                        <asp:Button ID="ButtonPartical" runat="server" Text="СЛУЧАЙНАЯ &quot;ЧАСТИЦА&quot;" 
                            OnClick="ButtonPartical_Click" CssClass="button-partical" />
                    </div>
                    <div class="footer-button-poem-partical">                       
                        <asp:Button ID="ButtonPoemPartical" runat="server" Text="СЛУЧАЙНАЯ СТИХОТВОРНАЯ &quot;ЧАСТИЦА&quot;" 
                            OnClick="ButtonPoemPartical_Click" CssClass="button-poem-partical" />
                    </div>
                    <div class="footer-button-word">                  
                        <asp:Button ID="ButtonWord" runat="server" Text="СЛУЧАЙНОЕ СЛОВО ИЗ СЛОВАРЯ В.И.ДАЛЯ" 
                            OnClick="ButtonWord_Click" CssClass="button-word" />
                    </div>
                </div>
                <div class="footer-images-buttons">
                    <div class="image-button-partical">
                        <asp:ImageButton ID="ImageButtonPartical" runat="server" OnClick="ImageButtonPartical_Click"
                            ImageUrl="Content/footer/partical-icon.png" Height="24px"/>
                    </div>
                    <div class="image-button-poem-partical">
                        <asp:ImageButton ID="ImageButtonPoemPartical" runat="server" OnClick="ImageButtonPoemPartical_Click"
                            ImageUrl="Content/footer/poem-partical-icon.png" Height="24px"/>
                    </div>
                    <div class="image-button-word">
                        <asp:ImageButton ID="ImageButtonWord" runat="server" OnClick="ImageButtonWord_Click" 
                            ImageUrl="Content/footer/word-icon.png" Height="24px" />
                    </div>           
                </div>
            </div>
            <div class="footer-full">

            </div>
        </div>
        

    </asp:Content>
<%--    </form>
</body>
</html>--%>
