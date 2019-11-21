using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
