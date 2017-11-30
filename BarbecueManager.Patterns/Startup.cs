using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SimpleInjector;

namespace BarbecueManager.Patterns
{
    public static class Startup
    {
        public static void Configure(Container container)
        {
            // Configure the default settings for json seralization / deserialization
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                // Convert enum values always as strings
                Converters = new JsonConverter[] { new StringEnumConverter() { CamelCaseText = false } },
#if !DEBUG
                Formatting = Formatting.None,
                // Do not serialize null fields
                NullValueHandling = NullValueHandling.Ignore
#endif
            };
        }
    }
}
