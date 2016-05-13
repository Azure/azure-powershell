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


using Microsoft.AzureStack.Management.StorageAdmin;
using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///          Get-RoleInstance [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [-RoleType] {enum} [[-InstanceId] {string}] [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminRoleInstance)]
    public sealed class GetAdminNodeRoleInstance : AdminCmdlet
    {
        /// <summary>
        /// farm identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
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
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, Position = 6)]
        [ValidateNotNull]
        public string InstanceId
        {
            get;
            set;
        }

        protected override void Execute()
        {
            object resultObject;
            if (string.IsNullOrEmpty(InstanceId))
            {
                switch (RoleType)
                {
                    case RoleType.AccountContainerserver:
                        resultObject = Client.AccountContainerServerInstances.List(ResourceGroupName, FarmName).RoleInstances.Select(_ => new AccountContainerRoleInstanceResponse(_));
                        break;
                    case RoleType.BlobFrontend:
                        resultObject = Client.BlobFrontendInstances.List(ResourceGroupName, FarmName).RoleInstances.Select(_ => new BlobFrontEndRoleInstanceResponse(_));
                        break;
                    case RoleType.TableFrontend:
                        resultObject = Client.TableFrontendInstances.List(ResourceGroupName, FarmName).RoleInstances.Select(_ => new TableFrontEndRoleInstanceResponse(_));
                        break;
                    case RoleType.BlobServer:
                        resultObject = Client.BlobServerInstances.List(ResourceGroupName, FarmName).RoleInstances.Select(_ => new BlobServerRoleInstanceResponse(_));
                        break;
                    case RoleType.TableServer:
                        resultObject = Client.TableServerInstances.List(ResourceGroupName, FarmName).RoleInstances.Select(_ => new TableServerRoleInstanceResponse(_));
                        break;
                    case RoleType.HealthMonitoringserver:
                        resultObject = Client.HealthMonitoringServerInstances.List(ResourceGroupName, FarmName).RoleInstances.Select(_ => new MonitoringServerRoleInstanceResponse(_));
                        break;
                    case RoleType.MetricsServer:
                        resultObject = Client.MetricsServerInstances.List(ResourceGroupName, FarmName).RoleInstances.Select(_ => new MetricsServerRoleInstanceResponse(_));
                        break;
                    case RoleType.TableMaster:
                        resultObject = Client.TableMasterInstances.List(ResourceGroupName, FarmName).RoleInstances.Select(_ => new TableMasterRoleInstanceResponse(_));
                        break;
                    default:
                        throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, Resources.InvalidRoleTypeErrorMessageFormat, RoleType));
                }
            }
            else
            {
                switch (RoleType)
                {
                    case RoleType.AccountContainerserver:
                        resultObject = new AccountContainerRoleInstanceResponse(Client.AccountContainerServerInstances.Get(ResourceGroupName, FarmName, InstanceId).RoleInstance);
                        break;
                    case RoleType.BlobFrontend:
                        resultObject = new BlobFrontEndRoleInstanceResponse(Client.BlobFrontendInstances.Get(ResourceGroupName, FarmName, InstanceId).RoleInstance);
                        break;
                    case RoleType.TableFrontend:
                        resultObject = new TableFrontEndRoleInstanceResponse(Client.TableFrontendInstances.Get(ResourceGroupName, FarmName, InstanceId).RoleInstance);
                        break;
                    case RoleType.BlobServer:
                        resultObject = new BlobServerRoleInstanceResponse(Client.BlobServerInstances.Get(ResourceGroupName, FarmName, InstanceId).RoleInstance);
                        break;
                    case RoleType.TableServer:
                        resultObject = new TableServerRoleInstanceResponse(Client.TableServerInstances.Get(ResourceGroupName, FarmName, InstanceId).RoleInstance);
                        break;
                    case RoleType.HealthMonitoringserver:
                        resultObject = new MonitoringServerRoleInstanceResponse(Client.HealthMonitoringServerInstances.Get(ResourceGroupName, FarmName, InstanceId).RoleInstance);
                        break;
                    case RoleType.MetricsServer:
                        resultObject = new MetricsServerRoleInstanceResponse(Client.MetricsServerInstances.Get(ResourceGroupName, FarmName, InstanceId).RoleInstance);
                        break;
                    case RoleType.TableMaster:
                        resultObject = new TableMasterRoleInstanceResponse(Client.TableMasterInstances.Get(ResourceGroupName, FarmName, InstanceId).RoleInstance);
                        break;
                    default:
                        throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, Resources.InvalidRoleTypeErrorMessageFormat, RoleType));
                }
            }
            WriteObject(resultObject, true);
        }
    }
}
