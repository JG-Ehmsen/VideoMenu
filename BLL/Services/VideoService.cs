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
        IVideoRepository repo;

        public VideoService(IVideoRepository repo)
        {
            this.repo = repo;
        }

        public void Add(Video video)
        {
            repo.Add(video);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public Video Get(int Id)
        {
            return repo.Get(Id);
        }

        public List<Video> GetAll()
        {
            return repo.GetAll();
        }

        public int GetCount()
        {
            return repo.GetCount();
        }

        public Video Update(Video video)
        {
            Video vid = Get(video.ID);
            if (vid != null)
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
