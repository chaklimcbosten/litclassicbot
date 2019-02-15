using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Classes
{
    public class Word
    {
        private int id;
        private string word;
        private string body;

        public int Id { get => id; set => id = value; }
        public string Word { get => word; set => word = value; }
        public string Body { get => body; set => body = value; }
    }
}