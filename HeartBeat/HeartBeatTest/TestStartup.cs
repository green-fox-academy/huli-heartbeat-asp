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
                => options.UseInMemoryDatabase("testdatabase"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SimpleContext context)
        {
            app.UseHeartBeat(context);
        }
    }
}