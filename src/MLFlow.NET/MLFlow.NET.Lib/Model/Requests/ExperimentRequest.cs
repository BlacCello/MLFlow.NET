using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Model.Requests
{
    public class ExperimentRequest
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("artifact_location")]
        public string ArtifactLocation { get; private set; }

        public ExperimentRequest(string name, string artifactLocation = null)
        {
            this.Name = name;
            this.ArtifactLocation = artifactLocation;
        }
    }
}