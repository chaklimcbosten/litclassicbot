<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="litclassicbot.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ошибка... LITCLASSIC</title>
    <link href="Content/CSS/ErrorPageStyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:300&amp;subset=cyrillic-ext" rel="stylesheet" />
    <link rel="apple-touch-icon" href="Content/icons/fav-apple-icon.png" />
    <link rel="icon" type="image/png" href="Content/icons/favicon.png" />
</head>
<body>
    <form id="form1" class="form1" runat="server">
        <div class="error-page-top">
            <a href="~/" runat="server">
                <img class="logo_img" src="Content/header/main-logo-png-v3.png" /></a>
            <a href="~/" class="logo">LITCLASSIC </a>
        </div>
        <div class="error-page-bottom">
            <h1>В веб-приложении возникла ошибка... </h1>
            <h2>Надеемся, всё скоро вернётся в строй! </h2>
        </div>
    </form>
</body>
</html>
