using MLFlow.NET.Lib.Model.Base;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Run
{
    public class RunData
    {
        [JsonProperty("metrics")]
        public Metric[] Metrics { get; set; }

        [JsonProperty("params")]
        public Param[] Params { get; set; }

        [JsonProperty("tags")]
        public RunTag[] Tags { get; set; }
    }
}