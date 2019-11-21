using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces.Infrastructure
{
    public interface IInventoryService
    {
        void NotifySaleOcurred(int productId, int quantity);
    }
}
