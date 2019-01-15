<%@ Page Title="Частицы. LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master" 
    AutoEventWireup="true" CodeBehind="Particles.aspx.cs" Inherits="litclassicbot.Particles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerParticlesPage" runat="server"></asp:ScriptManager>
    <div class="main">      
        <div class="main-panel">  
            <h1>Случайная "частица"</h1>    
        <asp:UpdatePanel ID="UpdatePanelParticle" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <h2>Текст "частицы"</h2>
                <asp:Label ID="LabelParticleLine" runat="server"></asp:Label>
                <h2>Сведения о "частице"</h2>
                <asp:Label ID="LabelParticleTitle" runat="server"></asp:Label>
                <%--<h2>Копировать, сохранить, поделиться "частицей"</h2>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--<h2>О процессе формирования "частиц"</h2>--%>
        </div>
        <div class="interactive-panel">
        <div class="nav-panel">
            <h4>Разделы сайта:</h4>
                <div class="nav-button-wrapper"><a class="nav-button-active" href="Particles.aspx">"ЧАСТИЦЫ"</a></div>            
                <div class="nav-button-wrapper"><a class="nav-button" href="Words.aspx">СЛОВАРЬ</a></div>
        </div>
        <div class="options-panel">
            <h4>Опции раздела:</h4>
                    <asp:UpdatePanel ID="UpdatePanelParticleSettings" runat="server" UpdateMode="Conditional">
            <Contenttemplate>
                <h4>Настройки получения "частиц"</h4>
                <div class="particle-settings">
                     <div class ="particle-settings-theme-types-column">
                         <div class="particle-settings-checkboxes-text">
                            <h4>Содержание "частиц"</h4>
                         </div>
                         <div class="particle-settings-checkboxes-theme-types">
                             <div class="checkbox-span">
                                <asp:CheckBox ID="CheckBoxThemeType0" runat="server" 
                                    Text="Основные произведения" 
                                    OnCheckedChanged="CheckBoxThemeType0_CheckedChanged" 
                                    ClientIDMode="Static" Checked="True" Font-Size="Smaller" />
                            </div>
                            <div class="checkbox-span">
                                <asp:CheckBox ID="CheckBoxThemeType1" runat="server" 
                                    Text="Прочие произведения, заметки, письма и пр." 
                                    OnCheckedChanged="CheckBoxThemeType1_CheckedChanged" 
                                    ClientIDMode="Static" Font-Size="Smaller" />
                            </div>
                            <div class="checkbox-span">
                                <asp:CheckBox ID="CheckBoxThemeType2" runat="server" 
                                    Text="Примечания, приложения, комментарии и пр." 
                                    OnCheckedChanged="CheckBoxThemeType2_CheckedChanged" 
                                    ClientIDMode="Static" Font-Size="Smaller" />
                            </div>   
                         </div>                                          
                     </div>
                     <div class="particle-settings-authors-numbers-column">
                         <div class="particle-settings-checkboxes-text">
                             <h4>Авторы "частиц"</h4>
                         </div>
                         <div class="particle-settings-checkboxes-authors-numbers">
                             <div class="particle-settings-authors-numbers-checkboxes-group">
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor0" runat="server" ClientIDMode="Static" 
                                        Text="Фёдор Михайлович Достоевский" Checked="True" Font-Size="Smaller" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor1" runat="server" ClientIDMode="Static" 
                                        Text="Александр Сергеевич Пушкин" Checked="True" Font-Size="Smaller" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor2" runat="server" ClientIDMode="Static" 
                                        Text="Николай Васильевич Гоголь" Checked="True" Font-Size="Smaller" />
                                </div>
                            </div>
                            <div class="particle-settings-authors-numbers-checkboxes-group">
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor3" runat="server" ClientIDMode="Static" 
                                        Text="Василий Андреевич Жуковский" Checked="True" Font-Size="Smaller" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor4" runat="server" ClientIDMode="Static" 
                                        Text="Иван Андреевич Крылов" Checked="True" Font-Size="Smaller" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor5" runat="server" ClientIDMode="Static" 
                                        Text="Михаил Юрьевич Лермонтов" Checked="True" Font-Size="Smaller" />
                                </div>
                            </div>
                            <div class="particle-settings-authors-numbers-checkboxes-group">
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor6" runat="server" ClientIDMode="Static" 
                                        Text="Фёдор Иванович Тютчев" Checked="True" Font-Size="Smaller" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor7" runat="server" ClientIDMode="Static" 
                                        Text="Алексей Константинович Толстой" Checked="True" Font-Size="Smaller" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor8" runat="server" ClientIDMode="Static" 
                                        Text="Михаил Васильевич Ломоносов" Checked="True" Font-Size="Smaller" />
                                </div>                    
                            </div>                        
                         </div>
                     </div>
                </div>
            </Contenttemplate>
        </asp:UpdatePanel>
                        <div class="footer-button-right">           
            <asp:Button ID="ButtonParticleReload" runat="server" Text="НОВАЯ &#34;ЧАСТИЦА&#34;"
                CssClass="button-footer-right-column" OnClick="ButtonParticleReload_Click" />
            </div>
        </div>
    </div>
    </div>
</asp:Content>

<asp:Content ID="FooterContent" ContentPlaceHolderID="FooterContent" runat="server"> 
    <div class="footer-right-column-top">
        <p class="footer-right-text">Опции текущего раздела:</p>
    </div>
    <div class="footer-right-column-bottom">
<%--        <div class="footer-button-right">           
            <asp:Button ID="ButtonParticleReload" runat="server" Text="ОБНОВИТЬ" 
                CssClass="button-footer-right-column" OnClick="ButtonParticleReload_Click" />
        </div>--%>
<%--        <div class="footer-button-right">           
            <asp:Button ID="ButtonParticleSettingsFooter" runat="server" Text="НАСТРОЙКИ" 
                CssClass="button-footer-right-column" OnClick="ButtonParticleSettings_Click" />
        </div>
        <div class="footer-button-right">           
            <a class="button-footer-right-column" href="Reader.aspx">ЧИТАТЬ</a>
        </div>
        <div class="footer-button-right">           
            <asp:Button ID="ButtonParticleSave" runat="server" Text="СОХРАНИТЬ" 
                CssClass="button-footer-right-column" />
        </div> 
        <div class="footer-button-right">           
            <asp:Button ID="ButtonParticleReport" runat="server" Text="ОШИБКА!" 
                CssClass="button-footer-right-column" />
        </div> --%> 
    </div>   
</asp:Content>

<asp:Content ID="FooterContentAdaptive" ContentPlaceHolderID="FooterContentAdaptive" runat="server">
<%--    <asp:ImageButton ID="ImageButtonParticleSettings" runat="server" 
        ImageUrl="~/Content/icons/particle-settings-icon.png" Height="24" Width="24" CssClass="image-button" 
        OnClick="ButtonParticleSettings_Click" />--%>
    <asp:ImageButton ID="ImageButtonParticleReload" runat="server" 
        ImageUrl="~/Content/icons/reload-icon.png" Height="24" Width="24" CssClass="image-button" 
        OnClick="ButtonParticleReload_Click" />    
</asp:Content>



