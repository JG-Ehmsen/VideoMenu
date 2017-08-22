using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using System.Linq;

namespace BLL.Services
{
    class VideoService : IVideoService
    {
        public void Add(Video video)
        {
            FakeDB.Videos.Add(new Video()
            {
                Title = video.Title,
                Author = video.Author,
                Genre = video.Genre,
                ID = FakeDB.ID++


            });
        }

        public void Delete(int Id)
        {
            Video vid = Get(Id);
            if (vid != null)
            {
                FakeDB.Videos.Remove(vid);
            }
            else
            {
                Console.WriteLine("Somethings' wrong!");
            }
        }

        public Video Get(int Id)
        {
            return FakeDB.Videos.FirstOrDefault(x => x.ID == Id);
        }

        public List<Video> GetAll()
        {
            return FakeDB.Videos;
        }

        public int GetCount()
        {
            return FakeDB.Videos.Count();
        }

        public Video Update(Video video)
        {
            Video vid = Get(video.ID);
            if(vid != null)
            {
                vid.Title = video.Title;
                vid.Author = video.Author;
                vid.Genre = video.Genre;
                return vid;
            }
            else
            {
                return null;
            }

            
        }
    }
}
