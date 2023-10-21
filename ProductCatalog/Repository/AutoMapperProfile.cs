using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProductCatalog.ViewModel;

namespace ProductCatalog.Repository
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterAcountVm, IdentityUser>();

        }
    }
}
