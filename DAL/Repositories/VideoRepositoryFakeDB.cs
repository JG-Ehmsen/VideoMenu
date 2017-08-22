using System;
using System.Collections.Generic;
using System.Text;
using BE;
using System.Linq;

namespace DAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        private static List<Video> Videos = new List<Video>();
        private static int ID = 1;

        public void Add(Video video)
        {
            Videos.Add(new Video()
            {
                Title = video.Title,
                Author = video.Author,
                Genre = video.Genre,
                ID = ID++
            });
        }

        public void Delete(int Id)
        {
            Video vid = Get(Id);
            if (vid != null)
            {
                Videos.Remove(vid);
            }
            else
            {
                Console.WriteLine("Somethings' wrong!");
            }
        }

        public Video Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.ID == Id);
        }

        public List<Video> GetAll()
        {
            return Videos;
        }

        public int GetCount()
        {
            return Videos.Count();
        }
    }
}
