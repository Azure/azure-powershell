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

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Azure.Commands.Attestation.Properties;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    /// <summary>
    /// Thrown when the attestation service returned a successful response that could not be read, for example because
    /// the connection closed while the response was being received.
    /// </summary>
    internal class UnreadableServiceResponseException : InvalidOperationException
    {
        public UnreadableServiceResponseException(Exception innerException)
            : base(Resources.UnreadableServiceResponse, innerException)
        {
        }
    }

    /// <summary>
    /// Stops Azure.Core from sending a request again when reading a successful response fails. Azure.Core retries
    /// such failures, which are IOExceptions or timeouts, but for a write the service has already applied the change.
    /// Added to the pipeline after the retry policy and before the policy that reads the response.
    /// </summary>
    internal sealed class NoRetryAfterSuccessfulResponsePolicy : HttpPipelinePolicy
    {
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            try
            {
                ProcessNext(message, pipeline);
            }
            catch (Exception ex) when (HasSuccessfulResponse(message))
            {
                throw new UnreadableServiceResponseException(ex);
            }
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            try
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            catch (Exception ex) when (HasSuccessfulResponse(message))
            {
                throw new UnreadableServiceResponseException(ex);
            }
        }

        private static bool HasSuccessfulResponse(HttpMessage message) => message.HasResponse && !message.Response.IsError;
    }
}
