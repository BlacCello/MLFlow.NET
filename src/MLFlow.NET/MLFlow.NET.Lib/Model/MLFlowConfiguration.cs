using System;
using System.Collections.Generic;
using System.Text;

namespace MLFlow.NET.Lib.Model
{
    public class MLFlowConfiguration
    {
        public string MlFlowServerBaseUrl { get; set; }
        public bool MLFlowServerAuthentication { get; set; }
        public string MLFLowServerUser { get; set; }
        public string MLFlowServerPassword { get; set; }
        public string APIBase { get; set; }
        public int Retries { get; set; }
        public int RetryTimeoutMillis { get; set; }
    }
}
