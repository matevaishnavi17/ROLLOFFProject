using AutoMapper;
using domainmodel=RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Models.DTO;

namespace RollOff_Test4API.Profiles
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            //ReverseMap() is used in case if we want to map DTO to the Domain Model
            CreateMap<domainmodel.Employee, GetEmployee>()
                .ReverseMap();
            CreateMap<domainmodel.Employee, GetEmployeeByID>()
                .ReverseMap();
            CreateMap<domainmodel.User, UserDTO>().ReverseMap();
            CreateMap<domainmodel.Login, LoginDTO>().ReverseMap();
            CreateMap<domainmodel.FeedbackForm, FeedbackFormDTO>().ReverseMap();
        }
    }
}
