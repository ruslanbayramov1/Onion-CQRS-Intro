using Microsoft.Extensions.Configuration;

namespace OnionAPI.Persistence.Helpers;

public class ConfigurationHelper
{
    public static string? GetConnectionString(string sectionName)
    {
        ConfigurationManager configurationManager = new();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/OnionAPI.API"));
        configurationManager.AddJsonFile("appsettings.Development.json");

        return configurationManager.GetConnectionString(sectionName);
    }
}
