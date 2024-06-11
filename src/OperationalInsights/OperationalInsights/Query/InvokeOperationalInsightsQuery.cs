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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.OperationalInsights;
using Microsoft.Rest;
using System;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Threading;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.OperationalInsights.Query
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsQuery", DefaultParameterSetName = ParamSetNameByWorkspaceId),OutputType(typeof(PSQueryResponse))]
    public class InvokeOperationalInsightsQuery : ResourceManager.Common.AzureRmLongRunningCmdlet
    {
        private const string ParamSetNameByWorkspaceId = "ByWorkspaceId";
        private const string ParamSetNameByWorkspaceObject = "ByWorkspaceObject";
        private readonly double _timeoutBufferInSeconds = 30;

        [Parameter(Mandatory = true, ParameterSetName = ParamSetNameByWorkspaceId, HelpMessage = "The workspace ID.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParamSetNameByWorkspaceObject, HelpMessage = "The workspace", ValueFromPipeline = true)]
        public PSWorkspace Workspace { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The query to execute.")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The timespan to bound the query by.")]
        public TimeSpan? Timespan { get; set; } = null;

        [Parameter(Mandatory = false, HelpMessage = "Puts an upper bound on the amount of time the server will spend processing the query. See: https://learn.microsoft.com/azure/azure-monitor/logs/api/timeouts")]
        [ValidateRange(1, int.MaxValue)]
        public int? Wait { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified, rendering information for metric queries will be included in the response.")]
        public SwitchParameter IncludeRender { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified, query statistics will be included in the response.")]
        public SwitchParameter IncludeStatistics { get; set; }

        private OperationalInsightsDataClient _operationalInsightsDataClient;

        internal OperationalInsightsDataClient OperationalInsightsDataClient
        {
            get
            {
                if (this._operationalInsightsDataClient == null)
                {
                    ServiceClientCredentials clientCredentials = null;
                    if (ParameterSetName == ParamSetNameByWorkspaceId && WorkspaceId == "DEMO_WORKSPACE")
                    {
                        clientCredentials = new ApiKeyClientCredentials("DEMO_KEY");
                    }
                    else
                    {
                        clientCredentials = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(DefaultContext, AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint);
                    }

                    this._operationalInsightsDataClient =
                        AzureSession.Instance.ClientFactory.CreateCustomArmClient<OperationalInsightsDataClient>(clientCredentials);
                    ConfigureTimeoutForClient();

                    this._operationalInsightsDataClient.Preferences.IncludeRender = IncludeRender.IsPresent;
                    this._operationalInsightsDataClient.Preferences.IncludeStatistics = IncludeStatistics.IsPresent;
                    this._operationalInsightsDataClient.NameHeader = "LogAnalyticsPSClient";

                    Uri targetUri = null;
                    DefaultContext.Environment.TryGetEndpointUrl(
                        AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint, out targetUri);
                    if (targetUri == null)
                    {
                        throw new Exception("Operational Insights is not supported in this Azure Environment");
                    }

                    this._operationalInsightsDataClient.BaseUri = targetUri;

                    if (targetUri.AbsoluteUri.Contains("localhost"))
                    {
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    }
                }

                return this._operationalInsightsDataClient;
            }
            set
            {
                this._operationalInsightsDataClient = value;
            }
        }

        private void ConfigureTimeoutForClient()
        {
            if (this.IsParameterBound(c => c.Wait) && Wait != null)
            {
                _operationalInsightsDataClient.HttpClient.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(Wait)).Add(TimeSpan.FromSeconds(_timeoutBufferInSeconds));
            }
        }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParamSetNameByWorkspaceId)
            {
                OperationalInsightsDataClient.WorkspaceId = WorkspaceId;
            }
            else if (ParameterSetName == ParamSetNameByWorkspaceObject)
            {
                // This seems like a weird mapping, but rest assurured, CustomerId is what we want here
                OperationalInsightsDataClient.WorkspaceId = Workspace.CustomerId.ToString();
            }

            if (Wait.HasValue)
            {
                OperationalInsightsDataClient.Preferences.Wait = Wait.Value;
            }

            WriteObject(PSQueryResponse.Create(OperationalInsightsDataClient.Query(Query, Timespan)));
        }
    }
}
