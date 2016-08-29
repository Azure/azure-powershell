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

using Microsoft.Azure;
using Microsoft.AzureStack.Management.StorageAdmin;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///          Restart-RoleInstance [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [-RoleType] {enum} [-InstanceId] {string} [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Restart, Nouns.AdminRoleInstance, SupportsShouldProcess = true)]
    public sealed class RestartRoleInstance : AdminCmdlet
    {
        /// <summary>
        /// farm identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNullOrEmpty]
        public string FarmName
        {
            get;
            set;
        }

        /// <summary>
        /// name of role
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        public RoleType RoleType
        {
            get;
            set;
        }

        /// <summary>
        /// instance identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        [ValidateNotNullOrEmpty]
        public string InstanceId
        {
            get;
            set;
        }

        protected override void Execute()
        {
            if (ShouldProcess(
                    Resources.RestartRoleInstanceVerboseDescription.FormatInvariantCulture(InstanceId, RoleType),
                    Resources.RestartRoleInstanceVerboseWarning.FormatInvariantCulture(InstanceId, RoleType),
                    Resources.ShouldProcessCaption))
            {
                AzureOperationResponse response;
                switch (RoleType)
                {
                    case RoleType.AccountContainerserver:
                        response = Client.AccountContainerServerInstances.Restart(ResourceGroupName, FarmName, InstanceId);
                        break;
                    case RoleType.BlobFrontend:
                        response = Client.BlobFrontendInstances.Restart(ResourceGroupName, FarmName, InstanceId);
                        break;
                    case RoleType.TableFrontend:
                        response = Client.TableFrontendInstances.Restart(ResourceGroupName, FarmName, InstanceId);
                        break;
                    case RoleType.BlobServer:
                        response = Client.BlobServerInstances.Restart(ResourceGroupName, FarmName, InstanceId);
                        break;
                    case RoleType.TableServer:
                        response = Client.TableServerInstances.Restart(ResourceGroupName, FarmName, InstanceId);
                        break;
                    case RoleType.HealthMonitoringserver:
                        response = Client.HealthMonitoringServerInstances.Restart(ResourceGroupName, FarmName, InstanceId);
                        break;
                    case RoleType.MetricsServer:
                        response = Client.MetricsServerInstances.Restart(ResourceGroupName, FarmName, InstanceId);
                        break;
                    case RoleType.TableMaster:
                        response = Client.TableMasterInstances.Restart(ResourceGroupName, FarmName, InstanceId);
                        break;
                    default:
                        throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, Resources.InvalidRoleTypeErrorMessageFormat, RoleType));
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new AdminException(string.Format(CultureInfo.InvariantCulture, Resources.OperationFailedErrorMessage, response.StatusCode));
                }
            }
        }
    }
}
