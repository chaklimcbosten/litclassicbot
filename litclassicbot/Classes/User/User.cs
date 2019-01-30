using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Classes.User
{
    public class User
    {
        private int webId;
        private UserParticle userParticle;
        private UserWord userWord;

        public UserParticle GetUserParticle()
        {
            return userParticle;
        }
        public UserWord GetUserWord()
        {
            return userWord;
        }

        public void SetWebId(int newWebId)
        {
            webId = newWebId;
        }

        private void GetUserSettings()
        {
            // запрос настроек по webId
            // получение настроек и их запись в User, UserParticle и UserWord
        }

        // возвращение всех настроек
        // обновление/присваивание настроек
    }
}