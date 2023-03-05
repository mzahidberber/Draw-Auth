using AuthServer.Core.DTOs;
using AuthServer.Core.Model;
using AutoMapper;

namespace AuthServer.Business
{
    internal class DTOMapper:Profile
    {
        public DTOMapper()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
