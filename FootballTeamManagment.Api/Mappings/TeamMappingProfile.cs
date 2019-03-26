using AutoMapper;
using FootballTeamManagment.Api.Models;
using FootballTeamManagment.Core.Models;

namespace FootballTeamManagment.Api.Mappings
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<TeamView, Team>()
                .ForMember(t => t.FootballPlayers, opt => opt.Ignore())
                .ForMember(t => t.Id, opt => opt.Ignore());
            CreateMap<Team, TeamView>();
        }
    }
}
