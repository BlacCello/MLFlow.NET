

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MLFlow.NET.Lib.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RunStatus
    {
        RUNNING,
        SCHEDULED,
        FINISHED,
        FAILED,
        KILLED,
    }
}
