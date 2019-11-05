using System.Collections.Generic;
using MLFlow.NET.Lib.Model.Base;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Requests
{
    public class BatchRequest
    {
        [JsonProperty("run_id")]
        public string RunId { get; private set; }
        [JsonProperty("params")]
        public IEnumerable<Param> Params { get; private set; }
        [JsonProperty("metrics")]
        public IEnumerable<Metric> Metrics { get; private set; }

        public BatchRequest(string runId, IEnumerable<Param> parameters, IEnumerable<Metric> metrics)
        {
            this.RunId = runId;
            this.Params = parameters;
            this.Metrics = metrics;
        }
    }
}