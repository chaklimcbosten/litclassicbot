using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Models.Word
{
    public class Word
    {
        private int id;
        private string title;
        private string body;
        private bool random;

        public Word(int id)
        {
            Id = id;
        }

        public Word(bool random)
        {
            Random = random;
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Body { get => body; set => body = value; }
        public bool Random { get => random; set => random = value; }
    }
}