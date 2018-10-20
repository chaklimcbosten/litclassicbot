<%@ Page Title="Частицы. LITCLASSIC" Language="C#" MasterPageFile="~/litclassic.Master" AutoEventWireup="true" CodeBehind="Particles.aspx.cs" Inherits="litclassicbot.Particles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManagerParticlePage" runat="server"></asp:ScriptManager>

    <div class="main">
        <h1>Случайная "частица"</h1>
        <h2>Настройки получения "частиц"</h2>
        <div class="particle-settings">
            <asp:UpdatePanel ID="UpdatePanelParticleSettings" runat="server" UpdateMode="Conditional">
                 <Contenttemplate>
                     <asp:CheckBox ID="CheckBoxThemeType0" runat="server" 
                         Text="Основные произведения" OnCheckedChanged="CheckBoxThemeType0_CheckedChanged" 
                         ClientIDMode="Static"/>
                    <asp:CheckBox ID="CheckBoxThemeType1" runat="server" 
                        Text="Прочие произведения, заметки, письма и пр." OnCheckedChanged="CheckBoxThemeType1_CheckedChanged" 
                        ClientIDMode="Static"/>
                    <asp:CheckBox ID="CheckBoxThemeType2" runat="server" 
                        Text="Примечания, приложения, комментарии и пр." OnCheckedChanged="CheckBoxThemeType2_CheckedChanged" 
                        ClientIDMode="Static"/>
                 </Contenttemplate>
            </asp:UpdatePanel>

            
            <input id="Checkbox1" type="checkbox" />
            <input id="Checkbox2" type="checkbox" />
            <input id="Checkbox3" type="checkbox" />

        </div>
        <asp:UpdatePanel ID="UpdatePanelParticle" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <h2>Текст "частицы"</h2>
                <asp:Label ID="LabelParticleLine" runat="server"></asp:Label>
                <asp:Label ID="LabelPoemParticleLine" runat="server"></asp:Label>
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
            <asp:Button ID="ButtonParticleReload" runat="server" Text="ОБНОВИТЬ" CssClass="button-reload" 
                OnClick="ButtonParticleReload_Click" />
        </div>
        <div class="footer-button-right">           
            <a class="button-read-next" href="Reader.aspx">ЧИТАТЬ</a>
        </div>
        <div class="footer-button-right">           
            <asp:Button ID="ButtonParticleSave" runat="server" Text="СОХРАНИТЬ" 
                CssClass="button-particle-save" />
        </div> 
        <div class="footer-button-right">           
            <asp:Button ID="ButtonParticleReport" runat="server" Text="ОШИБКА!" 
                CssClass="button-report" />
        </div>  
    </div>   
</asp:Content>


