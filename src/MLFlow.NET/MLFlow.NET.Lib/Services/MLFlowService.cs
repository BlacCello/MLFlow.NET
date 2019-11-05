using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MLFlow.NET.Lib.Contract;
using MLFlow.NET.Lib.Helpers;
using MLFlow.NET.Lib.Model;
using MLFlow.NET.Lib.Model.Requests;
using MLFlow.NET.Lib.Model.Responses.Experiment;
using MLFlow.NET.Lib.Model.Responses.Run;
using Newtonsoft.Json;

namespace MLFlow.NET.Lib.Services
{
    public class MLFlowService : IMLFlowService
    {
        private readonly IOptions<MLFlowConfiguration> _config;
        private readonly IHttpService _httpService;

        public MLFlowService(IOptions<MLFlowConfiguration> config,
            IHttpService httpService)
        {
            _config = config;
            _httpService = httpService;
        }
        public async Task<CreateResponse> CreateExperiment(ExperimentRequest request)
        {
            var response = await _httpService.Post<CreateResponse, ExperimentRequest>(
                _getPath(MLFlowAPI.Experiments.BasePath, MLFlowAPI.Experiments.Create),
                request);
            return response;
        }

        public async Task<CreateResponse> GetOrCreateExperiment(ExperimentRequest request)
        {

            var experiments = await ListExperiments(ViewType.ALL);

            var existing = experiments.Experiments.FirstOrDefault(_ => _.Name.ToLower() == request.Name.ToLower());

            if (existing != null)
            {
                return new CreateResponse()
                {
                    ExperimentId = existing.ExperimentId
                };
            }

            return await CreateExperiment(request);
        }

        public async Task<RunResponse> CreateRun(CreateRunRequest request)
        {
            var response = await _httpService.Post<RunResponse, CreateRunRequest>(_getPath(MLFlowAPI.Runs.BasePath, MLFlowAPI.Runs.Create), request);
            return response;
        }

        public async Task<RunResponse> UpdateRun(UpdateRunRequest request)
        {
            var response = await _httpService.Post<RunResponse, UpdateRunRequest>(_getPath(MLFlowAPI.Runs.BasePath, MLFlowAPI.Runs.Update), request);
            return response;
        }

        public async Task<ListExperimentsResponse> ListExperiments(ViewType viewtype)
        {
            var response = await _httpService.Get<ListExperimentsResponse, Object>(
                _getPath(MLFlowAPI.Experiments.BasePath, MLFlowAPI.Experiments.List),
                new { viewtype = viewtype.ToString() });

            return response;
        }

        public async Task<GetExperimentResponse> GetExperiment(string experiment_id)
        {
            var response = await _httpService.Get<GetExperimentResponse, Object>(
                _getPath(MLFlowAPI.Experiments.BasePath, MLFlowAPI.Experiments.Get),
                new { experiment_id });

            return response;
        }

        public async Task<LogMetric> LogMetric(MetricRequest request)
        {
            if (!request.TimeStamp.HasValue)
            {
                request.TimeStamp = UnixDateTimeHelpers.GetCurrentTimestampMilliseconds();
            }

            var response = await _httpService.Post<LogMetric, MetricRequest>(
                _getPath(MLFlowAPI.Runs.BasePath,
                    MLFlowAPI.Runs.LogMetric),
                    request);

            return response;
        }

        public async Task<LogParam> LogParameter(ParamRequest request)
        {
            var response = await _httpService.Post<LogParam, ParamRequest>(
                _getPath(MLFlowAPI.Runs.BasePath,
                    MLFlowAPI.Runs.LogParam),
                    request);

            return response;
        }

        public async Task<LogBatch> LogBatch(BatchRequest request)
        {
            if (request.Metrics.Any(m => !m.TimeStamp.HasValue)) {
                throw new ArgumentException("You need to assign a timestamp for every metric you are using in the batch request.");
            }
            var response = await _httpService.Post<LogBatch, BatchRequest>(
                _getPath(MLFlowAPI.Runs.BasePath,
                    MLFlowAPI.Runs.LogBatch),
                    request);

            return response;
        }

        private string _getPath(string basePart, string method)
        {
            return $"{basePart}/{method}";
        }
    }
}
