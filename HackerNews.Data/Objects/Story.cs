using System;

namespace HackerNews.Data
{
    public class Story
    {
        //enable this if we want to display user data (to be retrieved)
        //public User User { get; set; }

        public string By { get; set; }

        public int Descendants { get; set; }

        public int Id { get; set; }

        public int[] Kids { get; set; }

        public int Score { get; set; }

        public long Time { get; set; }

        public DateTime Date
        {
            get
            {
                return DateTimeOffset.FromUnixTimeSeconds(Time).DateTime;
            }
        }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public Boolean Deleted { get; set; }

        public string Text { get; set; }

        public Boolean Dead { get; set; }

        public int Parent { get; set; }

        public string Poll { get; set; }

        public int[] Parts { get; set; }
    }
}
