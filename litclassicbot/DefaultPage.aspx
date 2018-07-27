<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="litclassicbot.FirstWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LitClassic - сервис привлечения внимания к русской классической литературе</title>
    <link href="DefaultPageStyleSheet.css" rel="stylesheet" type="text/css"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" class="form" runat="server">
        <header>
            <div id="header-main">
                <div class="logo_column1">
                    <img class="logo_img" alt="" src="Content/header/main_logo.png" />
                    <h1 class="logo"> LITCLASSIC </h1>
                </div>
<%--                <div class="logo_column2">
                    <p class="logo_buttons">
                        <asp:Button ID="RandomParticalButton" runat="server" 
                            Text="Случайная &quot;частица&quot;" OnClick="RandomParticalButton_Click" 
                            BackColor="Black" BorderStyle="Solid" Font-Bold="False" Font-Italic="False" 
                            Font-Names="'PT Sans'" Font-Overline="False" Font-Size="Medium" 
                            Font-Strikeout="False" Font-Underline="False" ForeColor="White" 
                            Height="28px" BorderColor="Black" Width="160px" />
                        <asp:Button ID="RandomPoemParticalButton" runat="server" 
                            OnClick="RandomPoemParticalButton_Click" Text="Случайная стихотворная &quot;частица&quot;" 
                            BackColor="Black" BorderStyle="Solid" Font-Bold="False" Font-Names="'PT Sans'" 
                            Font-Size="Medium" ForeColor="White" Height="26px" BorderColor="Black" Width="260px" />
                        <asp:Button ID="RandomWordButton" runat="server" OnClick="RandomWordButton_Click" 
                            Text="Случайное слово из словаря В.И.Даля" BackColor="Black" BorderStyle="Solid" 
                            Font-Bold="False" Font-Names="'PT Sans'" Font-Size="Medium" ForeColor="White" 
                            Height="26px" BorderColor="Black" Width="285px" />
                    </p>
                </div>--%>
            </div>
            <div class="logo-links">
                <asp:LinkButton ID="LinkButtonAuthorization" runat="server" OnClick="LinkButtonAuthorization_Click">Авторизация</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonTelegramBot" runat="server" OnClick="LinkButtonTelegramBot_Click">Бот для Telegram</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonVKPublic" runat="server" OnClick="LinkButtonVKPublic_Click">Бот и сообщество ВКонтакте</asp:LinkButton> 
            </div>           
        </header>
        <div class="main">
            <div class="welcome-message">
                <p>
                    <asp:Label ID="LabelWelcome1" runat="server" Text="Добро пожаловать!"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="LabelWelcome2" runat="server" Text="В правом верхнем углу - 
                        все доступные функции."></asp:Label>
                </p>
                <p>
                    <asp:Label ID="LabelWelcome3" runat="server" Text="Пользуйтесь во благо!"></asp:Label>
                </p>
            </div>
            <div class="partical-line">
                <p>
                    <asp:Label ID="LabelParticalLine" runat="server" Text="Здесь будет текст произведения 
                        - &quot;частица&quot;." Visible="False" CssClass="partical-line"></asp:Label>
                </p>
            </div>
            <div class="poem-partical-line">
                <p>
                    <asp:Label ID="LabelPoemParticalLine" runat="server" Text="Здесь будет текст произведения 
                        - &quot;стихотворной частицы&quot;." Visible="False" CssClass="poem-partical-line"></asp:Label>
                </p>
            </div>
            <div class="word-name">
                <p>
                    <asp:Label ID="LabelWordName" runat="server" Text="Здесь будет слово из толкового 
                        словаря живого великорусского словаря." Visible="False" Font-Bold="True" 
                        Font-Italic="True" Font-Size="Larger"></asp:Label>
                </p>
                <hr />
            </div>
            <div class="partical-title">                                 
                <p>
                    <asp:Label ID="LabelParticalTitle" runat="server" Text="Здесь будет описание 
                        произведения и книги." ForeColor="Black" Visible="False" Font-Bold="True" 
                        Font-Italic="True"></asp:Label>              
                </p>
            </div>
            <div class="word-value">  
                <p> 
                    <asp:Label ID="LabelWordValue" runat="server" Text="Здесь будет значение слова 
                        из словаря В.И.Даля." Font-Size="Medium" ForeColor="Black" Visible="False"></asp:Label>
                </p>
            </div>
        </div>
        <div class="footer">
            <div class="footer-main">
                <div class="footer-buttons">
                    <div class="footer-button-partical">
                        <asp:ImageButton ID="ImageButtonPartical" runat="server" ImageUrl="Content/footer/partical_icon.png" 
                            BorderWidth="10px" Height="60px" AlternateText="Случайная &quot;частица&quot;" 
                            CssClass="image-button-partical" OnClick="ImageButtonPartical_Click" 
                            ToolTip="Случайная &quot;частица&quot;" />
                        <div class="footer-button-partical-text">
                            <p style="color: #FFFFFF; text-align: center; font-size: small; margin-top: -10px;">Случайная "частица"</p>
                        </div>
                    </div>
                    <div class="footer-button-poem-partical">
                        <asp:ImageButton ID="ImageButtonPoemPartical" runat="server" ImageUrl="Content/footer/poem_partical_icon.png" 
                            BorderWidth="10px" Height="60px" AlternateText="Случайная стихотворная &quot;частица&quot;" 
                            CssClass="image-button-poem-partical" OnClick="ImageButtonPoemPartical_Click" 
                            ToolTip="Случайная стихотворная &quot;частица&quot;" />
                        <div class="footer-button-poem-partical-text">
                            <p style="color: #FFFFFF; text-align: center; font-size: small; margin-top: -10px;">Случайная стихотворная "частица"</p>
                        </div>
                    </div>
                    <div class="footer-button-word">
                        <asp:ImageButton ID="ImageButtonWord" runat="server" ImageUrl="Content/footer/word_icon.png" 
                            BorderWidth="10px" Height="60px" AlternateText="Случайное слово из словаря В.И.Даля" 
                            CssClass="image-button-word" OnClick="ImageButtonWord_Click" 
                            ToolTip="Случайное слово из словаря В.И.Даля" />
                        <div class="footer-button-word-text">
                            <p style="color: #FFFFFF; text-align: center; font-size: small; margin-top: -10px;">Случайное слово из словаря В.И.Даля</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer-full">

            </div>
        </div>
    </form>
</body>
</html>
