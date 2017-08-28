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
        DALFacade facade;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public void Add(Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                uow.VideoRepository.Add(video);
                uow.Complete();
            }
        }

        public void AddVideos(List<Video> videos)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var item in videos)
                {
                    uow.VideoRepository.Add(item);
                }
                uow.Complete();
            }
        }

        public void Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                uow.VideoRepository.Delete(Id);
                uow.Complete();
            }
        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Get(Id);
            }
        }

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll();
            }
        }

        public int GetCount()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetCount();
            }
        }

        public Video Update(Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                Video vid = uow.VideoRepository.Get(video.ID);
                if (vid != null)
                {
                    uow.VideoRepository.Get(video.ID).Author = video.Author;
                    uow.VideoRepository.Get(video.ID).Title = video.Title;
                    uow.VideoRepository.Get(video.ID).Genre = video.Genre;
                    uow.Complete();
                    return vid;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Video> Filter(String filter)
        {
            List<Video> filteredVideos = new List<Video>();

            foreach (var i in GetAll())
            {
                if (i.ToString().ToLower().Contains(filter))
                {
                    filteredVideos.Add(i);
                }
            }

            return filteredVideos;
        }
    }
}
