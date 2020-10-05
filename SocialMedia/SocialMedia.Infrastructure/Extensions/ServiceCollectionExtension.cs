using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Interfaces.Output.Users;
using SocialMedia.Domain.Models.Custom;
using SocialMedia.Domain.Services.Posts;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia.Infrastructure.Repositories.Interfaces;
using SocialMedia.Infrastructure.Repositories.Posts;
using SocialMedia.Infrastructure.Repositories.Users;
using SocialMedia.Infrastructure.Services;

namespace SocialMedia.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialMediaContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("SocialMedia"))
           );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            //services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register Dependency
            services.AddTransient<IGetPostsInput, GetPostsService>();
            services.AddTransient<IGetPostsOutput, GetPostsRepository>();
            services.AddTransient<IGetPostInput, GetPostService>();
            services.AddTransient<IGetPostOutput, GetPostRepository>();
            services.AddTransient<ICreatePostInput, CreatePostService>();
            services.AddTransient<ICreatePostOutput, CreatePostRepository>();
            services.AddTransient<IUpdatePostInput, UpdatePostService>();
            services.AddTransient<IUpdatePostOutput, UpdatePostRepository>();
            services.AddTransient<IDeletePostInput, DeletePostService>();
            services.AddTransient<IDeletePostOutput, DeletePostRepository>();
            services.AddTransient<IGetPostsByUserOutput, GetPostsByUserRepository>();

            services.AddTransient<IGetUserOutput, GetUserRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

        /*public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Social Media API", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }*/
    }
}
