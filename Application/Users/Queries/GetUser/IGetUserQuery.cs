using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Application.Users.Queries.GetUser
{
    public interface IGetUserQuery
    {
        UserModel Execute(string Name);
    }
}
