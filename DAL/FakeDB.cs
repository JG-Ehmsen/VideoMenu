using System;
using System.Collections.Generic;
using BE;

namespace DAL
{
    public class FakeDB
    {
        static void Main(string[] args)
        {
        }

        public static List<Video> Videos = new List<Video>();
        public static int ID = 0;

        public FakeDB()
        {
            GenerateVideos(20);
        }

        private void GenerateVideos(int count)
        {
            String[] Authors = { "Billy Bob", "MacMoe", "SuperCoolDUde99", "Danny the Dude", "Me", "RealPerson", "KimK", "Someone Else" };

            String[] Genres = { "Random", "Funny", "Sad", "Gaming", "Music", "Hobbies", "DYI" };

            Random rnd = new Random();


            for (int i = 1; i < count; i++)
            {
                Video vid = new Video();

                vid.Title = "Video " + i;

                int r = rnd.Next(Authors.Length);
                vid.Author = Authors[r];

                r = rnd.Next(Genres.Length);
                vid.Genre = Genres[r];
                vid.ID = ID++;


                Videos.Add(vid);
            }
        }
    }
}
