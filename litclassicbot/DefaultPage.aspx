<%@ Page Title="LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master"
    AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="litclassicbot._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerDefaultPage" runat="server"></asp:ScriptManager>
    <div class="main">
        <div class="main-panel">
            <h1>Главная страница</h1>
            <%--<h2>Навигация</h2>
            <div class="content-main-page">
                <p>В верхней части сайта - "шапке" - клавиши ссылок на страницы с иными частями проекта, размещённых на других ресурсах.</p>
                <p>В нижней части сайта - "подвале" - клавиши ссылок на страницы с основными функциями сайта.</p>
            </div>--%>
            <h2>О сайте</h2>
            <div class="content-main-page">
                <p>
                    Человеку всегда необходимо прикасаться к ясному, осознанному для него самого взгляду на жизнь. 
                    Необходимо не только иметь его, но и постоянно укреплять, уточнять, ища новые тонкости, уразумевая собственные заблуждения. 
                    Не интернет виноват в том, что времяпровождение в нём не вносит в жизнь ей необходимых, решительных качеств, двигающих к совершенству, 
                    но мы сами, не сумевшие по-иному наполнить его и через это окружить себя и время своё таким наполнением.
                </p>
                <p>
                    Фантазия всегда к чему-либо прикасается. Неминуемо предметом её становится или добро или зло. Первое лишь расправляет 
                    и направляет её к свету и свободе, второе - увлекает к рабским цепям дурных привычек и страстей. 
                    Фантазия предполагается эволюцией как главная 
                    определяющая человека, но лишь добровольно посвятившая себя добру фантазия приносит настоящие, ценные плоды. 
                    Как быть фантазии в современном, столь изощрённым на самые разные мелочи мире? На чём остановить её интерес 
                    во столь красочном, поглощающем внимание интернете? Моя "проба пера" - в интернете можно создать систему, 
                    которая бы точно и метко направляла фантазию ко всему верному, сливаясь при этом по своей комфортности 
                    и привлекательности с остальным виртуальным пространством.
                </p>
            </div>
            <h2>О "частицах"</h2>
            <div class="content-main-page">
                <p>
                    Вы словно открываете книгу на случайной странице. Неизвестная она для Вас и новая ли, читанная, но позабытая ли 
                    - её страница хоть чуть-чуть увлекает Вас. Нет задачи читать её всю, лишь страницу - развлечь себя. 
                    Не бегая от полки к полки, Вы перебираете одну за другой, открывая для себя новую, увлекаясь ненадолго. 
                    Какая будет следующая книга? На какой части она откроется? Неужели не правдоподобна ситуация, в которой именно в следующей "частице"
                    может ждать Вас то, что искренне понравится, но что скрыто было по неизвестным причинам от Вашего внимания до сей поры?
                </p>
                <p>
                    Восстанавливая упущения школьной программы, ценя дорогое, утекающее в дела время, здесь не нужно искать книги, знать, 
                    какие прочесть в первую очередь, т.к. всё - уже собрано и подготовлено. 
                    В книгах этих лица русской литературы и русской души, ревнители Правды, стойкие и трудолюбивые воины Отечества - 
                    Пушкин, Гоголь, Достоевский, Лермонтов, Гончаров, Державин, Аксаков, Жуковский, Ломоносов и другие - помогают вспомнить 
                    себя и свой труд, посвящённый не силе безначального искусства, но человеческому пути к более чистому и светлому состоянию.
                </p>
            </div>
            <%--        <h2>Статистика</h2>
                <div class="content-main-page"><asp:Label ID="LabelStatistics" runat="server" CssClass="label-statistics"></asp:Label></div>
            <h2>Благодарности</h2>
            <div class="content-main-page"></div>--%>
        </div>
        <div class="interactive-panel">
            <div class="nav-panel">
                <h4>Разделы сайта:</h4>
                <asp:UpdatePanel ID="UpdatePanelNotifications" runat="server">
                    <ContentTemplate>
                        <div class="buttons-nav-panel">
                            <div class="nav-button-wrapper">
                                <a class="nav-button" href="Particles.aspx">"ЧАСТИЦЫ"</a>
                                <div class="particles-notif"><asp:Label ID="LabelParticleNotification" runat="server" Text="1,2T"></asp:Label></div>
                            </div>
                            <div class="nav-button-wrapper">
                                <a class="nav-button" href="Words.aspx">СЛОВАРЬ</a>
                                <div class="words-notif"><asp:Label ID="LabelWordNotification" runat="server" Text="1,2T"></asp:Label></div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="options-panel">
                <asp:Label ID="LabelLastAction" runat="server" CssClass="last-actions">
                    <%--<h4>Последние действия</h4>--%>
                    <div class="last-actions-tip">
                        <h4>Кликните по чёрному блоку для перехода в соответствующий раздел сайта.</h4>
                    </div>
                    <div class="last-actions-links">
                        <asp:Label ID="LabelParticleColumn" runat="server" CssClass="last-action-particle">
                            <h4>Вы смотрели эту "частицу":</h4>
                            <asp:Label ID="LabelLastParticle" runat="server"></asp:Label>
                        </asp:Label>
                        <asp:Label ID="LabelWordColumn" runat="server" CssClass="last-action-word">
                            <h4>Вы смотрели это слово:</h4>
                            <asp:Label ID="LabelLastWord" runat="server"></asp:Label>
                        </asp:Label>
                    </div>
                </asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
