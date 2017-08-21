using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using BE;
using BLL.Services;

namespace BLL
{
    public class BLLFacade
    {
        static void Main(string[] args)
        {
        }

        public IVideoService VideoService
        {
            get { return new VideoService(); }
        }


    }
}
