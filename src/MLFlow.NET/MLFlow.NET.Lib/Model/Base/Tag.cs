using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Base
{
    public class RunTag
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}