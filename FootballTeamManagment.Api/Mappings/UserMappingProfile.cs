using AutoMapper;
using FootballTeamManagment.Api.Models;
using FootballTeamManagment.Core.Models;

namespace FootballTeamManagment.Api.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserView, User>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForMember(u => u.UserRoles, opt => opt.Ignore());
            CreateMap<User, UserView>();
        }
    }
}
