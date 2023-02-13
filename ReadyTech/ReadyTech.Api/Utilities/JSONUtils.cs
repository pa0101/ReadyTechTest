using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ReadyTech.Api.Utilities
{
    public static class JSONUtils
    {
        public static string SerializeObjectToJSON(object value) =>
            JsonConvert.SerializeObject(value, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
    }
}
