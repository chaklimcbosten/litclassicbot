using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Classes.User
{
    public class UserParticle:User
    {
        private int particleId;
        private Dictionary<string, bool> particleAuthors;
        private Dictionary<string, bool> particleThemeTypes;

        public int GetParticleId()
        {
            return particleId;
        }
        public bool GetAuthor(string author)
        {
            return particleAuthors[author];
        }
        public Dictionary<string, bool> GetAuthors()
        {
            return particleAuthors;
        }
    }
}