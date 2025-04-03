using Authentification.JWT.DAL.Entities;
using Authentification.JWT.Service;
using AutoMapper;

namespace Authentification.JWT.WebAPI
{
    // Créer un profil de mappage
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
