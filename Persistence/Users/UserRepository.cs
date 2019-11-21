using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Persistence.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistence.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}
