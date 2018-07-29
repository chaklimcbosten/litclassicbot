<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="litclassicbot.FirstWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LitClassic - сервис привлечения внимания к русской классической литературе</title>
    <link href="DefaultPageStyleSheet.css" rel="stylesheet" type="text/css"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <%--<link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500&amp;subset=cyrillic-ext" rel="stylesheet">--%>  
    <link href="https://fonts.googleapis.com/css?family=Roboto:300&amp;subset=cyrillic-ext" rel="stylesheet"> 
</head>
<body>
    <form class="form1" runat="server">


        
        <header>
            <div class="header-main">
                <img class="logo_img" src="Content/header/main_logo.png" />
                <h1 class="logo"> LITCLASSIC </h1>
            </div>
            <div class="logo-links">
                <asp:LinkButton ID="LinkButtonAuthorization" runat="server" OnClick="LinkButtonAuthorization_Click" 
                    CssClass="link-button-authorization">АВТОРИЗАЦИЯ</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonTelegramBot" runat="server" OnClick="LinkButtonTelegramBot_Click" 
                    CssClass="link-button-telegram-bot">БОТ ДЛЯ TELEGRAM</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonVKPublic" runat="server" OnClick="LinkButtonVKPublic_Click" 
                    CssClass="link-button-vk-bot">СООБЩЕСТВО ВКОНТАКТЕ</asp:LinkButton> 
            </div>           
        </header>



        <div class="main">
            <asp:Label ID="LabelSubtitleMain" runat="server" Text="Главная страница" 
                CssClass="label-subtitle-main"></asp:Label>

            <asp:Label ID="LabelWelcome1" runat="server" Text="Добро пожаловать!"></asp:Label>
            <asp:Label ID="LabelWelcome2" runat="server" Text="В правом верхнем углу - 
                все доступные функции."></asp:Label>
            <asp:Label ID="LabelWelcome3" runat="server" Text="Пользуйтесь во благо!"></asp:Label>

            <asp:Label ID="LabelSubtitleParticalLine" runat="server" Text="О сайте" 
                CssClass="label-subtitle-partical-line"></asp:Label>

            <asp:Label ID="LabelParticalLine" runat="server" Text="Здесь будет текст произведения 
                - &quot;частица&quot;." Visible="False"></asp:Label>
            <asp:Label ID="LabelPoemParticalLine" runat="server" Text="Здесь будет текст произведения 
                - &quot;стихотворной частицы&quot;." Visible="False"></asp:Label>
            <asp:Label ID="LabelWordName" runat="server" Text="Здесь будет слово из толкового 
                словаря живого великорусского языка В.И.Даля." Visible="False"></asp:Label>

            <asp:Label ID="LabelSubtitleParticalTitle" runat="server" Text="О создателях" 
                CssClass="label-subtitle-partical-title"></asp:Label>

            <asp:Label ID="LabelParticalTitle" runat="server" Text="Здесь будет описание 
                произведения и книги." Visible="False"></asp:Label>              
            <asp:Label ID="LabelWordValue" runat="server" Text="Здесь будет значение слова 
                из словаря В.И.Даля." Visible="False"></asp:Label>
        </div>



        <div class="footer">
            <div class="footer-main">
                <div class="footer-buttons">
                    <div class="footer-button-partical">
                        <%--<asp:ImageButton ID="ImageButtonPartical" runat="server" ImageUrl="Content/footer/partical_icon.png" 
                            AlternateText="Случайная &quot;частица&quot;" CssClass="image-button-partical" 
                            OnClick="ImageButtonPartical_Click" ToolTip="Случайная &quot;частица&quot;" BorderWidth="10px" />
                        <div class="footer-button-partical-text">
                            <p style="color: black; text-align: center; font-size: small; margin-top: -10px;">Случайная "частица"</p>
                        </div>--%>
                        <asp:Button ID="ButtonPartical" runat="server" Text="СЛУЧАЙНАЯ &quot;ЧАСТИЦА&quot;" 
                            OnClick="ButtonPartical_Click" CssClass="button-partical" />
                    </div>
                    <div class="footer-button-poem-partical">
                        <%--<asp:ImageButton ID="ImageButtonPoemPartical" runat="server" ImageUrl="Content/footer/poem_partical_icon.png" 
                            BorderWidth="10px" AlternateText="Случайная стихотворная &quot;частица&quot;" 
                            CssClass="image-button-poem-partical" OnClick="ImageButtonPoemPartical_Click" 
                            ToolTip="Случайная стихотворная &quot;частица&quot;" />
                        <div class="footer-button-poem-partical-text">
                            <p style="color: black; text-align: center; font-size: small; margin-top: -10px;">Случайная стихотворная "частица"</p>
                        </div>--%>
                        <asp:Button ID="ButtonPoemPartical" runat="server" Text="СЛУЧАЙНАЯ СТИХОТВОРНАЯ &quot;ЧАСТИЦА&quot;" 
                            OnClick="ButtonPoemPartical_Click" CssClass="button-poem-partical" />
                    </div>
                    <div class="footer-button-word">
                        <%--<asp:ImageButton ID="ImageButtonWord" runat="server" ImageUrl="Content/footer/word_icon.png" 
                            BorderWidth="10px" AlternateText="Случайное слово из словаря В.И.Даля" 
                            CssClass="image-button-word" OnClick="ImageButtonWord_Click" 
                            ToolTip="Случайное слово из словаря В.И.Даля" />
                        <div class="footer-button-word-text">
                            <p style="color: black; text-align: center; font-size: small; margin-top: -10px;">Случайное слово из словаря В.И.Даля</p>
                        </div>--%>
                        <asp:Button ID="ButtonWord" runat="server" Text="СЛУЧАЙНОЕ СЛОВО ИЗ СЛОВАРЯ В.И.ДАЛЯ" 
                            OnClick="ButtonWord_Click" CssClass="button-word" />
                    </div>
                </div>
            </div>
            <div class="footer-full">

            </div>
        </div>
    </form>
</body>
</html>
