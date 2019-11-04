using System;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Run
{
    public class CreateRunRequest
    {
        [JsonProperty("experiment_id")]
        public string ExperimentId { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        // Valid Tags are listed here: https://www.mlflow.org/docs/latest/tracking.html#system-tags
        [JsonProperty("tags")]
        public RunTag[] Tags { get; set; }
    }
}
