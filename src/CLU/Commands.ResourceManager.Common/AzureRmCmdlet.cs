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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Commands.ResourceManager.Common.Properties;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Reflection;
using System.Linq;
using System.Globalization;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    /// <summary>
    /// Represents base class for Resource Manager cmdlets
    /// </summary>
    public abstract class AzureRMCmdlet : AzurePSCmdlet
    {
        public const string ProfileVariable = "_azpsh_profile";

        /// <summary>
        /// Gets or sets the global profile for ARM cmdlets.
        /// </summary>
        public AzureRMProfile DefaultProfile { get; set; }

        /// <summary>
        /// Gets the current default context.
        /// </summary>
        protected override AzureContext DefaultContext
        {
            get
            {
                if (DefaultProfile == null || DefaultProfile.Context == null)
                {
                    throw new PSInvalidOperationException(Resources.ProfileCannotBeNull);
                }

                return DefaultProfile.Context;
            }
        }

        protected override void BeginProcessing()
        {
            // Deserialize session variables
            var sessionProfile = GetSessionVariableValue<PSAzureProfile>(AzurePowerShell.ProfileVariable, (PSAzureProfile)(new AzureRMProfile()));
            if (sessionProfile != null)
            {
                DefaultProfile = DefaultProfile?? sessionProfile;
            }
            base.BeginProcessing();
            //TODO:  Add back RP automatic registration
            //ClientFactory.AddHandler(new RPRegistrationDelegatingHandler(
            //               () => new ResourceManagementClient(
            //                   AuthenticationFactory.GetSubscriptionCloudCredentials(DefaultContext, AzureEnvironment.Endpoint.ResourceManager),
            //                   DefaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)),
            //               s => _debugMessages.Enqueue(s)));

        }

        protected override void EndProcessing()
        {
            SetSessionVariable(AzurePowerShell.ProfileVariable, ((PSAzureProfile)DefaultProfile));
            //ClientFactory.RemoveHandler(typeof(RPRegistrationDelegatingHandler));
            base.EndProcessing();
        }

        protected override bool IsTelemetryCollectionEnabled
        {
            get
            {
                return DefaultProfile.IsTelemetryCollectionEnabled == true;
            }
        }

        protected override void InitializeQosEvent()
        {
            var commandAlias = GetType().GetTypeInfo().GetCustomAttributes<CliCommandAliasAttribute>().First();
            QosEvent = new AzurePSQoSEvent()
            {
                CommandName = commandAlias != null ? "az " + commandAlias.CommandName : this.MyInvocation?.MyCommand?.Name,
                ModuleName = this.GetType().GetTypeInfo().Assembly.GetName().Name,
                ModuleVersion = this.GetType().GetTypeInfo().Assembly.GetName().Version.ToString(),
                ClientRequestId = this._clientRequestId,
                IsSuccess = true,
            };

            if (this.MyInvocation != null && this.MyInvocation.BoundParameters != null)
            {
                QosEvent.Parameters = string.Join(" ", 
                    this.MyInvocation.BoundParameters.Keys.Select(
                        s => string.Format(CultureInfo.InvariantCulture, "--{0} xxx", s.ToLowerInvariant())));
            }

            if (this.DefaultProfile?.Context?.Account?.Id != null)
            {
                QosEvent.Uid = MetricHelper.GenerateSha256HashString(
                    this.DefaultProfile.Context.Account.Id.ToString());
            }
            else
            {
                QosEvent.Uid = "defaultid";
            }

            var cluHost = this.Host as CLUHost;
            if (cluHost != null)
            {
                QosEvent.InputFromPipeline = cluHost.IsInputRedirected;
                QosEvent.OutputToPipeline = cluHost.IsOutputRedirected;
                QosEvent.HostVersion = cluHost.Version.ToString();
            }
        }
    }
}
