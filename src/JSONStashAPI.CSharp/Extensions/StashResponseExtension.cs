using JSONStashAPI.CSharp.Models;
using Newtonsoft.Json;

namespace JSONStashAPI.CSharp.Extensions
{
    public static class StashResponseExtension
    {
        /// <summary>
        /// Converts the specified string containing the representation of a object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParseData<T>(this StashResponse response, out T result)
        {
            bool canDeserialize = true;
            
            JsonSerializerSettings settings = new()
            {
                Error = (sender, args) => { canDeserialize = false; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            };

            result = JsonConvert.DeserializeObject<T>(response.Data, settings);
            
            return canDeserialize;
        }
    }
}
