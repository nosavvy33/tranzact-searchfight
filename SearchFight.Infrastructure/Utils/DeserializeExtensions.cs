using System.Text.Json;

namespace SearchFight.Infrastructure.Utils
{
    internal static class DeserializeExtensions
    {
        private static JsonSerializerOptions searchResultSerializerSettings = 
            new JsonSerializerOptions() 
            { 
                PropertyNameCaseInsensitive = true 
            };

        /// <summary>
        /// Deserialize search results with conditioned JsonSerializerOptions
        /// </summary>
        /// <typeparam name="T">Target object mapping</typeparam>
        /// <param name="jsonString">JSON value string</param>
        /// <returns>Target object full with JSON values</returns>
        internal static T DeserializeSearchResult<T>(this string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString, searchResultSerializerSettings);
        }
    }
}
