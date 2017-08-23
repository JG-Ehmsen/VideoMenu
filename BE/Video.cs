using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return "#" + this.ID + " - " + this.Title + " by " + Author + " - " + this.Genre;
        }
    }
}
