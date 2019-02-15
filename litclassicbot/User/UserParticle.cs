using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Classes.User
{
    public class UserParticle:User
    {
        private int particleId;
        private Dictionary<string, bool> authors;
        private Dictionary<string, bool> themeTypes;

        public Dictionary<string, bool> Authors { get => authors; set => authors = value; }
        public Dictionary<string, bool> ThemeTypes { get => themeTypes; set => themeTypes = value; }
        public int ParticleId { get => particleId; set => particleId = value; }

        public void NewUserParticle()
        {
            
        }
        public void LoadUserParticle()
        {

        }
    }
}