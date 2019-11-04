using System.Threading.Tasks;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Model.Responses.Experiment;
using MLFlow.NET.Lib.Model.Responses.Run;

namespace MLFlow.NET.Lib.Contract
{
    public interface IMLFlowService
    {
        Task<CreateResponse> CreateExperiment(string name,
            string artifact_location = null);

        Task<RunResponse> CreateRun(CreateRunRequest request);

        Task<RunResponse> UpdateRun(UpdateRunRequest request);

        Task<LogMetric> LogMetric(string run_id,
            string key, double value, long? timeStamp = null);

        Task<LogMetric> LogMetric(string run_id,
            string key, double value, int step, long? timeStamp = null);

        Task<LogParam> LogParameter(string run_id,
            string key, string value);

        Task<ListExperimentsResponse> ListExperiments(ViewType viewtype);
        Task<GetExperimentResponse> GetExperiment(string experiment_id);

        Task<CreateResponse> GetOrCreateExperiment(
            string name,
            string artifact_location = null);
    }
}