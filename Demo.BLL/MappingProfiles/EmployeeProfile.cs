

namespace Demo.BLL.MappingProfiles;
internal class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        //CreateMap<Source, Destination>();
        CreateMap<EmployeeRequest, Employee>();
        CreateMap<EmployeeUpdateRequest, Employee>();

        CreateMap<Employee, EmployeeDetailsResponse>()
            .ForMember(d => d.Department,
            o => o.MapFrom(s => s.Department.Name))
            .ForMember(e => e.ImageName,
            o => o.MapFrom(s => s.Image))
            .ForMember(e => e.Image, opt => opt.Ignore());
        ;
        CreateMap<Employee, EmployeeResponse>()
            .ForMember(d => d.Department,
            o => o.MapFrom(s => s.Department.Name));
        ;

        CreateMap<EmployeeDetailsResponse, EmployeeUpdateRequest>();

        CreateMap<EmployeeUpdateRequest, EmployeeRequest>();

    }
}
