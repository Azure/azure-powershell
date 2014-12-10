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

using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// Get Microsoft Azure Service Diagnostics Extension.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureServiceDiagnosticsExtension"), OutputType(typeof(DiagnosticExtensionContext))]
    public class GetAzureServiceDiagnosticsExtensionCommand : BaseAzureServiceDiagnosticsExtensionCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, HelpMessage = "Service Name")]
        public override string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment Slot: Production (default) or Staging")]
        [ValidateSet(DeploymentSlotType.Production, DeploymentSlotType.Staging, IgnoreCase = true)]
        public override string Slot
        {
            get;
            set;
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            ValidateService();
            ValidateDeployment();
        }

        public void ExecuteCommand()
        {
            ValidateParameters();
            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.HostedServices.ListExtensions(this.ServiceName),
                (s, r) =>
                {
                    var extensionRoleList = (from dr in Deployment.Roles
                                             select new ExtensionRole(dr.RoleName)).ToList().Union(new ExtensionRole[] { new ExtensionRole() });

                    return from role in extensionRoleList
                           from extension in r.Extensions
                           where ExtensionManager.CheckNameSpaceType(extension, ProviderNamespace, ExtensionName)
                              && ExtensionManager.GetBuilder(Deployment.ExtensionConfiguration).Exist(role, extension.Id)
                           select new DiagnosticExtensionContext
                           {
                               OperationId = s.Id,
                               OperationDescription = CommandRuntime.ToString(),
                               OperationStatus = s.Status.ToString(),
                               Extension = extension.Type,
                               ProviderNameSpace = extension.ProviderNamespace,
                               Id = extension.Id,
                               Role = role,
                               StorageAccountName = GetPublicConfigValue(extension, StorageAccountElemStr),
                               WadCfg = GetPublicConfigValue(extension, WadCfgElemStr),
                               PublicConfiguration = GetPublicConfigValue(extension, "PublicConfig"),
                               Version = extension.Version
                           };
                });
        }

        protected override void OnProcessRecord()
        {
            ExecuteCommand();
        }
    }
}
