using System;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Requests
{
    public class UpdateRunRequest
    {
        [JsonProperty("run_id")]
        public string RunId { get; private set; }
        [JsonProperty("end_time")]
        public long EndTime { get; private set; }

        [JsonProperty("status")]
        public RunStatus Status { get; private set; }

        public UpdateRunRequest(string runId, long endTime, RunStatus status)
        {
            this.RunId = runId;
            this.EndTime = endTime;
            this.Status = status;
        }
    }
}
