using MLFlow.NET.Lib.Model.Base;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Requests
{
    public class CreateRunRequest
    {
        [JsonProperty("experiment_id")]
        public string ExperimentId { get; private set; }

        [JsonProperty("start_time")]
        public long StartTime { get; private set; }

        // Valid Tags are listed here: https://www.mlflow.org/docs/latest/tracking.html#system-tags
        [JsonProperty("tags")]
        public RunTag[] Tags { get; private set; }

        public CreateRunRequest(string experimentId, long startTime, RunTag[] tags)
        {
            this.ExperimentId = experimentId;
            this.StartTime = startTime;
            this.Tags = tags;
        }
    }
}
