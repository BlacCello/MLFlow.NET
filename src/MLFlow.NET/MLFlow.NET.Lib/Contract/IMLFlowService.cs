using System.Collections.Generic;
using System.Threading.Tasks;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Model.Requests;
using MLFlow.NET.Lib.Model.Responses.Experiment;
using MLFlow.NET.Lib.Model.Responses.Run;

namespace MLFlow.NET.Lib.Contract
{
    public interface IMLFlowService
    {
        Task<CreateResponse> CreateExperiment(ExperimentRequest request);

        Task<RunResponse> CreateRun(CreateRunRequest request);

        Task<RunResponse> UpdateRun(UpdateRunRequest request);

        Task<LogMetric> LogMetric(MetricRequest request);

        Task<LogParam> LogParameter(ParamRequest request);

        Task<LogBatch> LogBatch(BatchRequest request);

        Task<ListExperimentsResponse> ListExperiments(ViewType viewtype);
        Task<GetExperimentResponse> GetExperiment(string experiment_id);

        Task<CreateResponse> GetOrCreateExperiment(ExperimentRequest request);
    }
}