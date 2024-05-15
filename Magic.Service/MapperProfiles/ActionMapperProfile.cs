using AutoMapper;

namespace Magic.Service.MapperProfiles;

public class ActionMapperProfile : Profile
{
    public ActionMapperProfile()
    {
        /*CreateMap<Action, ActionResponse>()
            .ForMember(d => d.Run, s => s.Ignore())
            .ForMember(d => d.Description, s => s.MapFrom(a
                => a.Description.Replace("\"\"", "\"")))
            .ForMember(d => d.Test, s => s.Ignore())
            .ReverseMap();*/
    }
}