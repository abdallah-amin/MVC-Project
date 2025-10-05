namespace Demo.BLL.MappingProfiles;
public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<DepartmentRequest, Department>();
        CreateMap<DepartmentUpdateRequest, Department>();

        CreateMap<Department, DepartmentDetailsResponse>();
        CreateMap<Department, DepartmentResponse>();

        CreateMap<DepartmentDetailsResponse, DepartmentUpdateRequest>();

    }

}
