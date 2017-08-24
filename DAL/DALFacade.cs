using DAL.Repositories;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository { get { return new VideoRepositoryEFMemory(new Context.InMemoryContext()); } }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMem();
            }
            }
    }
}
