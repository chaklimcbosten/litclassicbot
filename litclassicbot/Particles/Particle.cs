using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Classes
{
    public class Particle
    {
        private int id;
        private string body;
        private string title;

        public int Id { get => id; set => id = value; }
        public string Body { get => body; set => body = value; }
        public string Title { get => title; set => title = value; }
    }
}