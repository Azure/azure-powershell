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
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///          Update-RoleInstance [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [-RoleType] {enum} [[-InstanceId] {string}] [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsData.Update, Nouns.AdminRoleInstance, SupportsShouldProcess = true)]
    public sealed class RoleInstanceSettingsPullNow : AdminCmdlet
    {
        /// <summary>
        /// farm identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        /// name of role
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        public RoleType RoleType { get; set; }

        /// <summary>
        /// instance identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 6)]
        [ValidateNotNull]
        public string InstanceId { get; set; }


        protected override void Execute()
        {
            if (ShouldProcess(
                Resources.UpdateRoleInstanceSettingDescription.FormatInvariantCulture(InstanceId, RoleType),
                Resources.UpdateRoleInstanceSettingWarning.FormatInvariantCulture(InstanceId, RoleType),
                Resources.ShouldProcessCaption))
            {
                object resultObject;

                switch (RoleType)
                {
                    case RoleType.AccountContainerserver:
                        resultObject = Client.AccountContainerServerInstances.SettingsPullNow(ResourceGroupName,
                            FarmName, InstanceId);
                        break;
                    case RoleType.BlobFrontend:
                        resultObject = Client.BlobFrontendInstances.SettingsPullNow(ResourceGroupName, FarmName,
                            InstanceId);
                        break;
                    case RoleType.TableFrontend:
                        resultObject = Client.TableFrontendInstances.SettingsPullNow(ResourceGroupName, FarmName,
                            InstanceId);
                        break;
                    case RoleType.BlobServer:
                        resultObject = Client.BlobServerInstances.SettingsPullNow(ResourceGroupName, FarmName,
                            InstanceId);
                        break;
                    case RoleType.TableServer:
                        resultObject = Client.TableServerInstances.SettingsPullNow(ResourceGroupName, FarmName,
                            InstanceId);
                        break;
                    case RoleType.HealthMonitoringserver:
                        resultObject = Client.HealthMonitoringServerInstances.SettingsPullNow(ResourceGroupName,
                            FarmName, InstanceId);
                        break;
                    case RoleType.MetricsServer:
                        resultObject = Client.MetricsServerInstances.SettingsPullNow(ResourceGroupName, FarmName,
                            InstanceId);
                        break;
                    case RoleType.TableMaster:
                        resultObject = Client.TableMasterInstances.SettingsPullNow(ResourceGroupName, FarmName,
                            InstanceId);
                        break;
                    default:
                        throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                            Resources.InvalidRoleTypeErrorMessageFormat, RoleType));
                }
                WriteObject(resultObject, true);
            }
        }
    }
}
