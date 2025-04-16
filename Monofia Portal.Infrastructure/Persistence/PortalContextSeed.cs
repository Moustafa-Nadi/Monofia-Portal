using Menofia_Portal.Core.Entities;
using System.Text.Json;

namespace Monofia_Portal.Infrastructure.Persistence
{
    public static class PortalContextSeed
    {
        public static async Task SeedingAsync(PortalDbContext context)
        {
            if (!context.News.Any())
            {
                var newsData = File.ReadAllText("../Monofia Portal.Infrastructure/DataSeeding/newsData.json");
                var news = JsonSerializer.Deserialize<List<PortalNews>>(newsData);
                if (news is { Count: > 0 }) // Check If Types Is Not Null and Count > 0
                {
                    foreach (var item in news)
                    {
                        await context.Set<PortalNews>().AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }

            if (!context.NewsTranslation.Any())
            {
                var newsTransData = File.ReadAllText("../Monofia Portal.Infrastructure/DataSeeding/newsDataTrans.json");
                var newsTrans = JsonSerializer.Deserialize<List<NewsTranslation>>(newsTransData);
                if (newsTrans is { Count: > 0 }) // Check If Types Is Not Null and Count > 0
                {
                    foreach (var item in newsTrans)
                    {
                        await context.Set<NewsTranslation>().AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
