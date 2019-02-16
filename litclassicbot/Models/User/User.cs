using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Models.User
{
    public class User
    {
        private string id;
        private UserParticle userParticle;
        private UserWord userWord;

        public string Id { get => id; set => id = value; }
        public UserParticle UserParticle { get => userParticle; set => userParticle = value; }
        public UserWord UserWord { get => userWord; set => userWord = value; }

        // возвращение всех настроек
        // обновление/присваивание настроек
    }
}