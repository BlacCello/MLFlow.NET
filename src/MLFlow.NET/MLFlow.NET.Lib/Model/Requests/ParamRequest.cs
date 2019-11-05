using MLFlow.NET.Lib.Model.Base;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Requests
{
    public class ParamRequest : Param
    {
        [JsonProperty("run_id")]
        public string RunId { get; set; }
    }
}