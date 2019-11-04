using System;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Responses.Run
{
    public class UpdateRunRequest
    {
        [JsonProperty("run_id")]
        public string RunId { get; set; }
        [JsonProperty("end_time")]
        public long EndTime { get; set; }

        [JsonProperty("status")]
        public RunStatus Status { get; set; }
    }
}
