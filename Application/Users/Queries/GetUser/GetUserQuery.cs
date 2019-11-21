using CleanArchitecture.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture. Application.Users.Queries.GetUser
{
    public class GetUserQuery : IGetUserQuery
    {
        private IUserRepository userRepository;
        public GetUserQuery(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }
        public UserModel Execute(string name)
        {
            UserModel user = this.userRepository.GetAll().Where(s => s.Name == name).Select(p=>new UserModel { 
            Id = p.Id,
            Name = p.Name
            }).FirstOrDefault();
            return user;
        }
    }
}
