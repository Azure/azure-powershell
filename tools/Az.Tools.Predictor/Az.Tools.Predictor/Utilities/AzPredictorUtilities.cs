// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry;
using System;
using System.Collections.Generic;
using System.Management.Automation.Subsystem.Prediction;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities
{
    /// <summary>
    /// A utility class for common methods
    /// </summary>
    internal static class AzPredictorUtilities
    {
        /// <summary>
        /// Requests preditions and collects telemetry event.
        /// </summary>
        /// <param name="azPredictorService">The service to send the request.</param>
        /// <param name="telemetryClient">The telemetry client to collect the data.</param>
        /// <param name="predictionClient">The client that initiate the telemetry event.</param>
        /// <param name="commands">A list of commands.</param>
        /// <param name="telemetryWaitTask">The task to wait before we collect the telemetry data.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public static async Task RequestPredictionAndCollectTelemetryAync(IAzPredictorService azPredictorService, ITelemetryClient telemetryClient, PredictionClient predictionClient, IEnumerable<string> commands, TaskCompletionSource telemetryWaitTask, CancellationToken cancellationToken)
        {
            var requestId = Guid.NewGuid().ToString();
            (bool, CommandLineSummary)? requestResult = default;
            Exception exception = null;

            try
            {
                requestResult = await azPredictorService.RequestPredictionsAsync(commands, requestId, cancellationToken);
            }
            catch (ServiceRequestException e)
            {
                requestResult = (e.IsRequestSent, e.PredictorSummary);
                exception = e.InnerException;
            }
            catch (Exception e) when (!(e is OperationCanceledException))
            {
                exception = e;
            }
            finally
            {
                if (telemetryWaitTask != null)
                {
                    await telemetryWaitTask.Task;
                }

                if (requestResult.HasValue)
                {
                    telemetryClient.RequestId = requestId;
                    telemetryClient.OnRequestPrediction(new RequestPredictionTelemetryData(predictionClient,
                                commands,
                                requestResult.Value.Item1,
                                exception,
                                requestResult.Value.Item2));
                }
            }
        }
    }
}
