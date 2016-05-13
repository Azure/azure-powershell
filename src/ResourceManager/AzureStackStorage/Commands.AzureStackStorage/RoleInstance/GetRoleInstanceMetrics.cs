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
using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminRoleInstanceMetric)]
    public sealed class GetRoleInstanceMetrics : AdminMetricCmdlet
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
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 6)]
        [ValidateNotNull]
        public string InstanceId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        protected override MetricsResult GetMetricsResult(string filter)
        {
            MetricsResult resultObject;
            switch (RoleType)
            {
                case RoleType.AccountContainerserver:
                    resultObject = Client.AccountContainerServerInstances.GetMetrics(ResourceGroupName, FarmName, InstanceId, filter);
                    break;
                case RoleType.BlobFrontend:
                    resultObject = Client.BlobFrontendInstances.GetMetrics(ResourceGroupName, FarmName, InstanceId, filter);
                    break;
                case RoleType.TableFrontend:
                    resultObject = Client.TableFrontendInstances.GetMetrics(ResourceGroupName, FarmName, InstanceId, filter);
                    break;
                case RoleType.BlobServer:
                    resultObject = Client.BlobServerInstances.GetMetrics(ResourceGroupName, FarmName, InstanceId, filter);
                    break;
                case RoleType.TableServer:
                    resultObject = Client.TableServerInstances.GetMetrics(ResourceGroupName, FarmName, InstanceId, filter);
                    break;
                case RoleType.HealthMonitoringserver:
                    resultObject = Client.HealthMonitoringServerInstances.GetMetrics(ResourceGroupName, FarmName, InstanceId, filter);
                    break;
                case RoleType.MetricsServer:
                    resultObject = Client.MetricsServerInstances.GetMetrics(ResourceGroupName, FarmName, InstanceId, filter);
                    break;
                case RoleType.TableMaster:
                    resultObject = Client.TableMasterInstances.GetMetrics(ResourceGroupName, FarmName, InstanceId, filter);
                    break;
                default:
                    throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, Resources.InvalidRoleTypeErrorMessageFormat, RoleType));
            }
            return resultObject;
        }
    }
}