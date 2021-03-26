using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WordSearch.Repositories;
using WordSearch.Services;

namespace WordSearch
{
    public class StartUp
    {
        public IConfiguration configuration { get; }
        public StartUp(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        // Would normally configure endpoints for controllers,
        // Routing, Cors etc
        public void Configure() {}

        public void ConfigureServices(IServiceCollection services)
        {
            // Services
            services.AddScoped<IGridService, GridService>();
            services.AddScoped<ISearchService, SearchService>();

            // Repositories
            services.AddScoped<IGridDataAccess, GridDataAccess>();

            var sp = services.BuildServiceProvider();
            var gridService = sp.GetService<IGridService>();
            var searchService = sp.GetService<ISearchService>();

            // Wasnt sure how far I should go so configured services
            // to use some DI, in a proper webbApp, id avoid the below
            // and setup a Host Adapter
            Display d = new Display(gridService, searchService);
            d.Show();
        }
    }
}
