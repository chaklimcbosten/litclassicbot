<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="litclassicbot.FirstWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LitClassic - сервис привлечения внимания к русской классической литературе</title>
    <link href="DefaultPageStyleSheet.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" class="form" runat="server">
        <header>
            <div class="logo_column1">
                <img class="logo_img" alt="" src="Content/main_logo.png" />
                <h1 class="logo"> LITCLASSIC </h1>
            </div>
            <div class="logo_column2">
                <p class="logo_buttons">
                    <asp:Button ID="RandomParticalButton" runat="server" Text="Случайная &quot;частица&quot;" OnClick="RandomParticalButton_Click" BackColor="Black" BorderStyle="Solid" Font-Bold="False" Font-Italic="False" Font-Names="'PT Sans'" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="33px" BorderColor="Black" Width="100%" />
                    <asp:Button ID="RandomPoemParticalButton" runat="server" OnClick="RandomPoemParticalButton_Click" Text="Случайная стихотворная &quot;частица&quot;" BackColor="Black" BorderStyle="Solid" Font-Bold="False" Font-Names="'PT Sans'" Font-Size="Small" ForeColor="White" Height="34px" BorderColor="Black" Width="100%" />
                    <asp:Button ID="RandomWordButton" runat="server" OnClick="RandomWordButton_Click" Text="Случайное слово из словаря В.И.Даля" BackColor="Black" BorderStyle="Solid" Font-Bold="False" Font-Names="'PT Sans'" Font-Size="Small" ForeColor="White" Height="33px" BorderColor="Black" Width="100%" />
                </p>
            </div>
        </header>
        <div class="main">
            <div class="welcome-message">
                <p>
                    <asp:Label ID="LabelWelcome" runat="server" Text="Добро пожаловать!<br>В заголовке сайта слева - все доступные функции. Пользуйтесь во благо!"></asp:Label>
                </p>
            </div>
            <div class="line">
                <p>
                    <asp:Label ID="LabelParticalLine" runat="server" Text="Здесь будет текст произведения - &quot;частица&quot;." Visible="False"></asp:Label>
                    <asp:Label ID="LabelWordName" runat="server" Text="Здесь будет слово из толкового словаря живого великорусского словаря." Visible="False" Font-Bold="True" Font-Italic="True"></asp:Label>
                </p>
            </div>
            <div class="title">                                 
                <p>
                    <asp:Label ID="LabelParticalTitle" runat="server" Text="Здесь будет описание произведения и книги." Font-Size="Medium" ForeColor="Black" Font-Bold="True" Font-Italic="True" Visible="False"></asp:Label>
                    <asp:Label ID="LabelWordValue" runat="server" Text="Здесь будет значение слова из словаря В.И.Даля." Font-Size="Medium" ForeColor="Black" Visible="False"></asp:Label>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
