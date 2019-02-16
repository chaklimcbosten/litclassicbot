using litclassicbot.Controllers.DataControllers;

namespace litclassicbot.Models.Particle
{
    public class Particle
    {
        private int id;
        private string body;
        private string title;
        private bool random;

        public Particle(int id)
        {
            Id = id;

            ConnectParticle connect = new ConnectParticle();
        }

        public Particle(bool random)
        {
            Random = random;
        }

        public int Id { get => id; set => id = value; }
        public string Body { get => body; set => body = value; }
        public string Title { get => title; set => title = value; }
        public bool Random { get => random; set => random = value; }
        
    }
}