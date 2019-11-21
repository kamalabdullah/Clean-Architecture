using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Infrastructure.Network
{
    public interface IWebClientWrapper
    {
        void Post(string address, string json);
    }
}
