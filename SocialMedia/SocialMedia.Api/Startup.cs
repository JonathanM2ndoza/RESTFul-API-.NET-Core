using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMedia.Domain.Interfaces.Input.Posts;
using SocialMedia.Domain.Interfaces.Output.Posts;
using SocialMedia.Domain.Services.Posts;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Repositories.Posts;

namespace SocialMedia.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register connection to BD
            services.AddDbContext<SocialMediaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SocialMedia")));

            // Register Dependency
            services.AddTransient<IGetPostsInput, GetPostsService>();
            services.AddTransient<IGetPostsOutput, GetPostsRepository>();
            services.AddTransient<IGetPostInput, GetPostService>();
            services.AddTransient<IGetPostOutput, GetPostRepository>();
            services.AddTransient<ICreatePostInput, CreatePostService>();
            services.AddTransient<ICreatePostOutput, CreatePostRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
