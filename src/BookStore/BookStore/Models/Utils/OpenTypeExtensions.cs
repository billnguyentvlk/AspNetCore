using System.Collections.Generic;
using Newtonsoft.Json;

namespace BookStore.Models.Utils
{
    public static class OpenTypeExtensions
    {
        private static readonly JsonSerializerSettings JSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        private static readonly JsonSerializerSettings JDeserializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All, MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
        };

        public static string SerializeToJsonStringWithTypeName(this IDictionary<string, object> dynamicProperties)
        {
            return dynamicProperties == null
                ? null
                : JsonConvert.SerializeObject(dynamicProperties, Formatting.None, JSerializerSettings);
        }

        public static IDictionary<string, object> DeserializeToDynamicProperties(this string jsonString)
        {
            return null == jsonString
                ? null
                : JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonString, JDeserializerSettings);
        }
    }
}