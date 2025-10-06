

namespace Demo.BLL.MappingProfiles;
internal class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        //CreateMap<Source, Destination>();
        CreateMap<EmployeeRequest, Employee>();
        CreateMap<EmployeeUpdateRequest, Employee>();

        CreateMap<Employee, EmployeeDetailsResponse>();
        CreateMap<Employee, EmployeeResponse>();

        CreateMap<EmployeeDetailsResponse, EmployeeUpdateRequest>();

        CreateMap<EmployeeUpdateRequest, EmployeeRequest>();

    }
}
