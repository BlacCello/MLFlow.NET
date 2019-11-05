using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Base
{
    public class Metric
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
        [JsonProperty("step")]
        public long Step { get; set; }
        [JsonProperty("timestamp")]
        public long? TimeStamp { get; set; }
    }
}