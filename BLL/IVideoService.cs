using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IVideoService
    {
        //C
        void Add(Video video);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        int GetCount();
        //U
        Video Update(Video video);
        //D
        void Delete(int Id);
    }
}
