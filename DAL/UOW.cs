using BE;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UOW
    {

        FakeDB DB = new FakeDB();

        public void addVideo(Video video)
        {
            video.ID = DB.AssignID();
            DB.addVideo(video);
        }

        public List<Video> getVideos()
        {
            return DB.getVideos();
        }

        public void removeVideo(Video video)
        {
            DB.removeVideo(video);
        }


    }
}
