using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using BE;

namespace BLL
{
    public class BLLFacade
    {
        static void Main(string[] args)
        {
        }

        UOW UOW = new UOW();

        public void addVideo(Video video)
        {
            UOW.addVideo(video);
        }

        public List<Video> getVideos()
        {
            return UOW.getVideos();
        }

        public void removeVideo(Video video)
        {
            UOW.removeVideo(video);
        }

    }
}
