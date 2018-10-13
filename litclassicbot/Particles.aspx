<%@ Page Title="Частицы. LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master" AutoEventWireup="true" CodeBehind="Particles.aspx.cs" Inherits="Particles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    <div class="main">
        <h1>Случайная "частица"</h1>
        <h2>Настройки получения "частиц"</h2>
        <div class="particle-settings">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Основные произведения" Checked="True" />
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Прочие произведения, заметки, письма и пр." />
            <asp:CheckBox ID="CheckBox3" runat="server" Text="Примечания, приложения, комментарии и пр." />
            <%--    <div class="footer">
            <div class="footer-main">
                <div class="footer-buttons">
                    <div class="footer-buttons-left-column">
                        <div class="footer-button">
                            <a class="button-partical" href="Particals.aspx">"ЧАСТИЦЫ"</a>
                        </div>
                        <div class="footer-button">                  
                            <a class="button-word" href="Words.aspx">СЛОВАРЬ В.И.ДАЛЯ</a>
                        </div>
                        <div class="footer-button">                  
                            <a class="button-proverb" href="Proverbs.aspx">ПОСЛОВИЦЫ</a>
                        </div>
                    </div>
                    <div class="footer-buttons-right-column">                     
                        <div class="footer-button">           
                            <asp:Button ID="ButtonParticalReport" runat="server" Text="СООБЩИТЬ ОБ ОШИБКЕ" 
                                CssClass="button-report" />
                        </div>
                        <div class="footer-button">           
                            <a class="button-read-next" href="Proverbs.aspx">ЧИТАТЬ ДАЛЕЕ</a>
                        </div>
                        <div class="footer-button">           
                            <a class="button-reload" href="Particals.aspx">ОБНОВИТЬ</a>
                        </div>
                    </div>                   
                </div>
                <div class="footer-images-buttons">
                    <div class="image-button-partical">
                        <a href="Particals.aspx"><img src="Content/footer/partical-icon.png" height="24" width="24"/></a>
                    </div>
                    <div class="image-button-word">
                        <a href="Words.aspx"><img src="Content/footer/word-icon.png" height="24" width="24"/></a>
                    </div>           
                </div>
            </div>
         </div>  --%>
        </div>
        <h2>Текст "частицы"</h2>
        <asp:Label ID="ParticleLine" runat="server"></asp:Label>
        <asp:Label ID="LabelPoemParticleLine" runat="server"></asp:Label>
        <h2>Сведения о "частице"</h2>
        <asp:Label ID="LabelParticleTitle" runat="server"></asp:Label>
        <%--    <div class="footer">
            <div class="footer-main">
                <div class="footer-buttons">
                    <div class="footer-buttons-left-column">
                        <div class="footer-button">
                            <a class="button-partical" href="Particals.aspx">"ЧАСТИЦЫ"</a>
                        </div>
                        <div class="footer-button">                  
                            <a class="button-word" href="Words.aspx">СЛОВАРЬ В.И.ДАЛЯ</a>
                        </div>
                        <div class="footer-button">                  
                            <a class="button-proverb" href="Proverbs.aspx">ПОСЛОВИЦЫ</a>
                        </div>
                    </div>
                    <div class="footer-buttons-right-column">                     
                        <div class="footer-button">           
                            <asp:Button ID="ButtonParticalReport" runat="server" Text="СООБЩИТЬ ОБ ОШИБКЕ" 
                                CssClass="button-report" />
                        </div>
                        <div class="footer-button">           
                            <a class="button-read-next" href="Proverbs.aspx">ЧИТАТЬ ДАЛЕЕ</a>
                        </div>
                        <div class="footer-button">           
                            <a class="button-reload" href="Particals.aspx">ОБНОВИТЬ</a>
                        </div>
                    </div>                   
                </div>
                <div class="footer-images-buttons">
                    <div class="image-button-partical">
                        <a href="Particals.aspx"><img src="Content/footer/partical-icon.png" height="24" width="24"/></a>
                    </div>
                    <div class="image-button-word">
                        <a href="Words.aspx"><img src="Content/footer/word-icon.png" height="24" width="24"/></a>
                    </div>           
                </div>
            </div>
         </div>  --%>
        <h2>Копировать, сохранить, поделиться "частицей"</h2>
        <h2>О процессе формирования "частиц"</h2>
    </div>  
<%--    <div class="footer">
            <div class="footer-main">
                <div class="footer-buttons">
                    <div class="footer-buttons-left-column">
                        <div class="footer-button">
                            <a class="button-partical" href="Particals.aspx">"ЧАСТИЦЫ"</a>
                        </div>
                        <div class="footer-button">                  
                            <a class="button-word" href="Words.aspx">СЛОВАРЬ В.И.ДАЛЯ</a>
                        </div>
                        <div class="footer-button">                  
                            <a class="button-proverb" href="Proverbs.aspx">ПОСЛОВИЦЫ</a>
                        </div>
                    </div>
                    <div class="footer-buttons-right-column">                     
                        <div class="footer-button">           
                            <asp:Button ID="ButtonParticalReport" runat="server" Text="СООБЩИТЬ ОБ ОШИБКЕ" 
                                CssClass="button-report" />
                        </div>
                        <div class="footer-button">           
                            <a class="button-read-next" href="Proverbs.aspx">ЧИТАТЬ ДАЛЕЕ</a>
                        </div>
                        <div class="footer-button">           
                            <a class="button-reload" href="Particals.aspx">ОБНОВИТЬ</a>
                        </div>
                    </div>                   
                </div>
                <div class="footer-images-buttons">
                    <div class="image-button-partical">
                        <a href="Particals.aspx"><img src="Content/footer/partical-icon.png" height="24" width="24"/></a>
                    </div>
                    <div class="image-button-word">
                        <a href="Words.aspx"><img src="Content/footer/word-icon.png" height="24" width="24"/></a>
                    </div>           
                </div>
            </div>
         </div>  --%>  
</asp:Content>

<asp:Content ID="FooterContent" ContentPlaceHolderID="FooterContent" runat="server"> 
    <div class="footer-button-right">           
        <a class="button-reload" href="Particles.aspx">ОБНОВИТЬ</a>
    </div>
    <div class="footer-button-right">           
        <a class="button-read-next" href="Reader.aspx">ЧИТАТЬ ДАЛЕЕ</a>
    </div>
    <div class="footer-button-right">           
        <asp:Button ID="ButtonParticleSave" runat="server" Text="СОХРАНИТЬ" 
            CssClass="button-particle-save" />
    </div> 
    <div class="footer-button-right">           
        <asp:Button ID="ButtonParticleReport" runat="server" Text="СООБЩИТЬ ОБ ОШИБКЕ" 
            CssClass="button-report" />
    </div>  
</asp:Content>

