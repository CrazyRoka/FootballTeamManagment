using AutoMapper;
using FootballTeamManagment.Api.Models;
using FootballTeamManagment.Core.Models;

namespace FootballTeamManagment.Api.Mappings
{
    public class FootballPlayerMappingProfile : Profile
    {
        public FootballPlayerMappingProfile()
        {
            CreateMap<FootballPlayer, FootballPlayerView>();
            CreateMap<FootballPlayerView, FootballPlayer>()
                .ForMember(p => p.Team, opt => opt.Ignore())
                .ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}
