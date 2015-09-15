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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.Compute;
using Hyak.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    public class IaaSDeploymentManagementCmdletBase : ServiceManagementBaseCmdlet
    {
        private static IList<string> TerminalStates = new List<string>
        {
            "FailedStartingVM",
            "ProvisioningFailed",
            "ProvisioningTimeout"
        };

        public IaaSDeploymentManagementCmdletBase()
        {
            CreatingNewDeployment = false;
        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ServiceName
        {
            get;
            set;
        }

        protected DeploymentGetResponse CurrentDeploymentNewSM { get; set; }

        protected OperationStatusResponse GetDeploymentOperationNewSM { get; set; }

        protected bool CreatingNewDeployment { get; set; }

        protected string GetDeploymentServiceName { get; set; }

        protected virtual void ExecuteCommand()
        {
            if (!string.IsNullOrEmpty(ServiceName))
            {
                InvokeInOperationContext(() =>
                {
                    try
                    {
                        CurrentDeploymentNewSM = this.ComputeClient.Deployments.GetBySlot(this.ServiceName, DeploymentSlot.Production);
                        GetDeploymentOperationNewSM = GetOperation(CurrentDeploymentNewSM.RequestId);
                        WriteVerboseWithTimestamp(Resources.GetDeploymentCompletedOperation);
                    }
                    catch (CloudException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                        else
                        {
                            WriteWarning(string.Format(CultureInfo.CurrentUICulture, Resources.NoDeploymentFoundInService, ServiceName));
                        }
                    }
                });
            }
        }

        protected override void ProcessRecord()
        {
            try
            {
                try
                {
                    HttpRestCallLogger.CurrentCmdlet = this;
                    base.ProcessRecord();
                    ExecuteCommand();
                }
                catch (CloudException ce)
                {
                    throw new ComputeCloudException(ce);
                }
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }

        protected void WaitForRoleToBoot(string roleName)
        {
            string currentInstanceStatus = null;
            Management.Compute.Models.RoleInstance durableRoleInstance;
            do
            {
                DeploymentGetResponse d = null;
                InvokeInOperationContext(() =>
                {
                    try
                    {
                        d = this.ComputeClient.Deployments.GetBySlot(ServiceName, DeploymentSlot.Production);
                    }
                    catch (CloudException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }
                });

                if (d == null)
                {
                    throw new ApplicationException(String.Format(Resources.CouldNotFindDeployment, ServiceName, Model.DeploymentSlotType.Production));
                }

                durableRoleInstance = d.RoleInstances == null || !d.RoleInstances.Any() ? null : d.RoleInstances.First(ri => ri.RoleName == roleName);

                if (currentInstanceStatus == null)
                {
                    this.WriteVerboseWithTimestamp(Resources.RoleInstanceStatus, durableRoleInstance.InstanceStatus);
                    currentInstanceStatus = durableRoleInstance.InstanceStatus;
                }

                if (currentInstanceStatus != durableRoleInstance.InstanceStatus)
                {
                    this.WriteVerboseWithTimestamp(Resources.RoleInstanceStatus, durableRoleInstance.InstanceStatus);
                    currentInstanceStatus = durableRoleInstance.InstanceStatus;
                }

                if(TerminalStates.FirstOrDefault(r => String.Compare(durableRoleInstance.InstanceStatus, r, true, CultureInfo.InvariantCulture) == 0) != null)
                {
                    var message = string.Format(Resources.VMCreationFailedWithVMStatus, durableRoleInstance.InstanceStatus);
                    throw new ApplicationException(message);
                }
                
                if(String.Compare(durableRoleInstance.InstanceStatus, Microsoft.WindowsAzure.Management.Compute.Models.RoleInstanceStatus.ReadyRole, true, CultureInfo.InvariantCulture) == 0)
                {
                    break;
                }
                
                //Once we move Tasks, we should remove Thread.Sleep
                Thread.Sleep(TimeSpan.FromSeconds(30));

            } while (true);
        }
    }
}