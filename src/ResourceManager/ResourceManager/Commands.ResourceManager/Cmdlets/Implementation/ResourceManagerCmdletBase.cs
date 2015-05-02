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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using System.Runtime.ExceptionServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.RestClients;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Common.Authentication.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The base class for resource manager cmdlets.
    /// </summary>
    public abstract class ResourceManagerCmdletBase : AzurePSCmdlet
    {
        /// <summary>
        /// The cancellation source.
        /// </summary>
        private CancellationTokenSource cancellationSource;

        /// <summary>
        /// Gets the cancellation source.
        /// </summary>
        protected CancellationToken? CancellationToken
        {
            get
            {
                return this.cancellationSource == null ? null : (CancellationToken?)this.cancellationSource.Token;
            }
        }

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "When set, indicates the version of the resource provider API to use. If not specified, the API version is automatically determined as the latest available.")]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the switch that indicates if pre-release API version should be considered.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "When set, indicates that the cmdlet should use pre-release API versions when automatically determining which version to use.")]
        public SwitchParameter Pre { get; set; }

        /// <summary>
        /// The <c>BeginProcessing</c> method.
        /// </summary>
        protected override void BeginProcessing()
        {
            try
            {
                if (this.cancellationSource == null)
                {
                    this.cancellationSource = new CancellationTokenSource();
                }

                base.BeginProcessing();
                this.OnBeginProcessing();
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    throw;
                }

                var capturedException = ExceptionDispatchInfo.Capture(ex);
                this.HandleException(capturedException: capturedException);
            }
        }

        /// <summary>
        /// The <c>StopProcessing</c> method.
        /// </summary>
        protected override void StopProcessing()
        {
            try
            {
                if (this.cancellationSource != null && !this.cancellationSource.IsCancellationRequested)
                {
                    this.cancellationSource.Cancel();
                }

                this.OnStopProcessing();
                base.StopProcessing();
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    throw;
                }

                var capturedException = ExceptionDispatchInfo.Capture(ex);
                this.HandleException(capturedException: capturedException);
            }
            finally
            {
                this.DisposeOfCancellationSource();
            }
        }

        /// <summary>
        /// The <c>EndProcessing</c> method.
        /// </summary>
        protected override void EndProcessing()
        {
            try
            {
                this.OnEndProcessing();
                base.EndProcessing();
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    throw;
                }

                var capturedException = ExceptionDispatchInfo.Capture(ex);
                this.HandleException(capturedException: capturedException);
            }
            finally
            {
                this.DisposeOfCancellationSource();
            }
        }

        /// <summary>
        /// The <c>ProcessRecord</c> method.
        /// </summary>
        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                this.OnProcessRecord();
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    throw;
                }

                var capturedException = ExceptionDispatchInfo.Capture(ex);
                this.HandleException(capturedException: capturedException);
            }
        }

        /// <summary>
        /// When overridden, allows child classes to be called when the <c>ProcessRecord</c> method is invoked.
        /// </summary>
        protected virtual void OnProcessRecord()
        {
            // no-op
        }

        /// <summary>
        /// When overridden, allows child classes to be called when the <c>EndProcessing</c> method is invoked.
        /// </summary>
        protected virtual void OnEndProcessing()
        {
            // no-op
        }

        /// <summary>
        /// When overridden, allows child classes to be called when the <c>BeginProcessing</c> method is invoked.
        /// </summary>
        protected virtual void OnBeginProcessing()
        {
            // no-op
        }

        /// <summary>
        /// When overridden, allows child classes to be called when the <c>StopProcessing</c> method is invoked.
        /// </summary>
        protected virtual void OnStopProcessing()
        {
            // no-op
        }

        /// <summary>
        /// Determines the API version.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="pre">When specified, indicates if pre-release API versions should be considered.</param>
        protected Task<string> DetermineApiVersion(string resourceId, bool? pre = null)
        {
            return string.IsNullOrWhiteSpace(this.ApiVersion)
                ? ApiVersionHelper.DetermineApiVersion(
                    profile: this.Profile,
                    resourceId: resourceId,
                    cancellationToken: this.CancellationToken.Value,
                    pre: pre ?? this.Pre)
                : Task.FromResult(this.ApiVersion);
        }

        /// <summary>
        /// Determines the API version.
        /// </summary>
        /// <param name="providerNamespace">The provider namespace.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="pre">When specified, indicates if pre-release API versions should be considered.</param>
        protected Task<string> DetermineApiVersion(string providerNamespace, string resourceType, bool? pre = null)
        {
            return string.IsNullOrWhiteSpace(this.ApiVersion)
                ? ApiVersionHelper.DetermineApiVersion(
                    profile: this.Profile,
                    providerNamespace: providerNamespace,
                    resourceType: resourceType,
                    cancellationToken: this.CancellationToken.Value,
                    pre: pre ?? this.Pre)
                : Task.FromResult(this.ApiVersion);
        }

        /// <summary>
        /// Gets a new instance of the <see cref="ResourceManagerRestRestClient"/>.
        /// </summary>
        public ResourceManagerRestRestClient GetResourcesClient()
        {
            var endpoint = this.Profile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);

            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new ApplicationException(
                    "The endpoint for the Azure Resource Manager service is not set. Please report this issue via GitHub or contact Microsoft customer support.");
            }

            var endpointUri = new Uri(endpoint, UriKind.Absolute);

            return new ResourceManagerRestRestClient(
                endpointUri: endpointUri,
                httpClientHelper: HttpClientHelperFactory.Instance
                .CreateHttpClientHelper(
                        credentials: AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(this.Profile.Context),
                        headerValues: AzureSession.ClientFactory.UserAgents));
        }

        /// <summary>
        /// Writes a <see cref="JToken"/> object as a <see cref="PSObject"/>.
        /// </summary>
        protected void WriteObject(JToken result)
        {
            this.WriteObject(sendToPipeline: result.ToPsObject(), enumerateCollection: true);
        }

        /// <summary>
        /// Gets a new instance of the long running operation helper.
        /// </summary>
        /// <param name="activityName">The name of the action.</param>
        /// <param name="isResourceCreateOrUpdate">When set to true, indicates that the tracker will be used to track a resource creation request.</param>
        internal LongRunningOperationHelper GetLongRunningOperationTracker(string activityName, bool isResourceCreateOrUpdate)
        {
            return new LongRunningOperationHelper(
                activityName: activityName,
                resourcesClientFactory: () => this.GetResourcesClient(),
                writeProgressAction: progress => this.WriteProgress(progress),
                cancellationToken: this.CancellationToken.Value,
                isResourceCreateOrUpdate: isResourceCreateOrUpdate);
        }

        /// <summary>
        /// Disposes of the <see cref="CancellationTokenSource"/>.
        /// </summary>
        private void DisposeOfCancellationSource()
        {
            if (this.cancellationSource != null)
            {
                if (!this.cancellationSource.IsCancellationRequested)
                {
                    this.cancellationSource.Cancel();
                }

                this.cancellationSource.Dispose();
                this.cancellationSource = null;
            }
        }

        /// <summary>
        /// Provides specialized exception handling.
        /// </summary>
        /// <param name="capturedException">The captured exception</param>
        private void HandleException(ExceptionDispatchInfo capturedException)
        {
            try
            {
                var errorResponseException = capturedException.SourceException as ErrorResponseMessageException;
                if (errorResponseException != null)
                {
                    this.ThrowTerminatingError(errorResponseException.ToErrorRecord());
                }

                var aggregateException = capturedException.SourceException as AggregateException;
                if (aggregateException != null)
                {
                    if (aggregateException.InnerExceptions.CoalesceEnumerable().Any() &&
                        aggregateException.InnerExceptions.Count == 1)
                    {
                        errorResponseException = aggregateException.InnerExceptions.Single() as ErrorResponseMessageException;
                        if (errorResponseException != null)
                        {
                            this.ThrowTerminatingError(errorResponseException.ToErrorRecord());
                        }
                    }
                    else
                    {
                        throw aggregateException.Flatten();
                    }
                }

                capturedException.Throw();
            }
            finally
            {
                this.DisposeOfCancellationSource();
            }
        }
    }
}