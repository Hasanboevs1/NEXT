using NEXT.Data.IRepositories;
using NEXT.Data.Repositories;
using NEXT.Service.IServices;
using NEXT.Service.Services;

namespace NEXT.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPostRepository<>), typeof(PostRepository<>));
            services.AddScoped<IPostService, PostService>();
        }
    }
}
