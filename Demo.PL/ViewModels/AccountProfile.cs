using Demo.DAL.Entities;

namespace Demo.PL.ViewModels;
public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<RegisterViewModel, ApplicationUser>();
    }
}
