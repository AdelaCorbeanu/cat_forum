using cat_forum.Helpers.Seeders;
using cat_forum.Repositories.PostRepository;
using cat_forum.Services.Posts;

namespace cat_forum.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostRepository>();

            return services;
        }

        public static IServiceCollection AddServices (this IServiceCollection services)
        {
            services.AddTransient<IPostService, PostService>();

            return services;
        }

        public static IServiceCollection AddSeeders (this IServiceCollection services)
        {
            services.AddTransient<PostsSeeder>();

            return services;
        }

    }
}
