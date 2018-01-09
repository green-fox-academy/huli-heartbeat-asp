using HeartBeat;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HeartBeatTest
{
    class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<SimpleContext>(options
                => options.UseSqlServer(@"Server=db;Database=kikurtadatbazis;MultipleActiveResultSets=true;User=sa;Password=V4t0l0c0;"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SimpleContext context)
        {
            context.Database.EnsureCreated();
            app.UseHeartBeat(context);
        }
    }
}