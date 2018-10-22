<%@ Page Title="Частицы. LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master" 
    AutoEventWireup="true" CodeBehind="Particles.aspx.cs" Inherits="litclassicbot.Particles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerParticlesPage" runat="server"></asp:ScriptManager>
    <div class="main">
        <h1>Случайная "частица"</h1>
        <h2>Настройки получения "частиц"</h2>
        <asp:UpdatePanel ID="UpdatePanelParticleSettings" runat="server" UpdateMode="Conditional">
            <Contenttemplate>
                <div class="particle-settings">
                     <div class ="particle-settings-theme-types-column">
                         <div class="particle-settings-checkboxes-text">
                            <h3>Настройки тем "частиц"</h3>
                         </div>
                         <div class="particle-settings-checkboxes-theme-types">
                             <div class="checkbox-span">
                                <asp:CheckBox ID="CheckBoxThemeType0" runat="server" 
                                    Text="Основные произведения" 
                                    OnCheckedChanged="CheckBoxThemeType0_CheckedChanged" 
                                    ClientIDMode="Static"/>
                            </div>
                            <div class="checkbox-span">
                                <asp:CheckBox ID="CheckBoxThemeType1" runat="server" 
                                    Text="Прочие произведения, заметки, письма и пр." 
                                    OnCheckedChanged="CheckBoxThemeType1_CheckedChanged" 
                                    ClientIDMode="Static"/>
                            </div>
                            <div class="checkbox-span">
                                <asp:CheckBox ID="CheckBoxThemeType2" runat="server" 
                                    Text="Примечания, приложения, комментарии и пр." 
                                    OnCheckedChanged="CheckBoxThemeType2_CheckedChanged" 
                                    ClientIDMode="Static"/>
                            </div>   
                         </div>                                          
                     </div>
                     <div class="particle-settings-authors-numbers-column">
                         <div class="particle-settings-checkboxes-text">
                             <h3>Настройки авторов "частиц"</h3>
                         </div>
                         <div class="particle-settings-checkboxes-authors-numbers">
                             <div class="particle-settings-authors-numbers-checkboxes-group">
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor0" runat="server" ClientIDMode="Static" 
                                        Text="Фёдор Михайлович Достоевский" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor1" runat="server" ClientIDMode="Static" 
                                        Text="Александр Сергеевич Пушкин" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor2" runat="server" ClientIDMode="Static" 
                                        Text="Николай Васильевич Гоголь" />
                                </div>
                            </div>
                            <div class="particle-settings-authors-numbers-checkboxes-group">
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor3" runat="server" ClientIDMode="Static" 
                                        Text="Василий Андреевич Жуковский" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor4" runat="server" ClientIDMode="Static" 
                                        Text="Иван Андреевич Крылов" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor5" runat="server" ClientIDMode="Static" 
                                        Text="Михаил Юрьевич Лермонтов" />
                                </div>
                            </div>
                            <div class="particle-settings-authors-numbers-checkboxes-group">
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor6" runat="server" ClientIDMode="Static" 
                                        Text="Алексей Николаевич Толстой" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor7" runat="server" ClientIDMode="Static" 
                                        Text="Фёдор Иванович Тютчев" />
                                </div>
                                <div class="checkbox-span">
                                    <asp:CheckBox ID="CheckBoxAuthor8" runat="server" ClientIDMode="Static" 
                                        Text="Михаил Васильевич Ломоносов" />
                                </div>                    
                            </div>                        
                         </div>
                     </div>
                </div>
                <div class="button">
                    <asp:Button ID="ButtonHideParticleSettings" runat="server" Text="СКРЫТЬ НАСТРОЙКИ" 
                        CssClass="button-hide-particle-settings" />
                </div>
            </Contenttemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanelParticle" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <h2>Текст "частицы"</h2>
                <asp:Label ID="LabelParticleLine" runat="server"></asp:Label>
                <h2>Сведения о "частице"</h2>
                <asp:Label ID="LabelParticleTitle" runat="server"></asp:Label>
                <h2>Копировать, сохранить, поделиться "частицей"</h2>
            </ContentTemplate>
        </asp:UpdatePanel>
        <h2>О процессе формирования "частиц"</h2>
    </div>  
</asp:Content>

<asp:Content ID="FooterContent" ContentPlaceHolderID="FooterContent" runat="server"> 
    <div class="footer-right-column-top">
        <p class="footer-right-text">Опции текущего раздела:</p>
    </div>
    <div class="footer-right-column-bottom">
        <div class="footer-button-right">           
            <asp:Button ID="ButtonParticleReload" runat="server" Text="ОБНОВИТЬ" 
                CssClass="button-footer-right-column" OnClick="ButtonParticleReload_Click" />
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
        </div>  
    </div>   
</asp:Content>


