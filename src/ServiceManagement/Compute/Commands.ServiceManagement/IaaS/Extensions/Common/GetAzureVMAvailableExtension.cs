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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Get Microsoft Azure VM Extension Image.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        AzureVMAvailableExtensionCommandNoun,
        DefaultParameterSetName = ListLatestExtensionsParamSetName),
    OutputType(
        typeof(VirtualMachineExtensionImageContext))]
    public class GetAzureVMAvailableExtensionCommand : ServiceManagementBaseCmdlet
    {
        protected const string AzureVMAvailableExtensionCommandNoun = "AzureVMAvailableExtension";
        protected const string ListLatestExtensionsParamSetName = "ListLatestExtensions";
        protected const string ListAllVersionsParamSetName = "ListAllVersions";
        protected const string ListSingleVersionParamSetName = "ListSingleVersion";

        [Parameter(
            ParameterSetName = ListLatestExtensionsParamSetName,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Image Name.")]
        [Parameter(
            ParameterSetName = ListAllVersionsParamSetName,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Image Name.")]
        [Parameter(
            ParameterSetName = ListSingleVersionParamSetName,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Image Name.")]
        [ValidateNotNullOrEmpty]
        public string ExtensionName { get; set; }

        [Parameter(
            ParameterSetName = ListLatestExtensionsParamSetName,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Publisher.")]
        [Parameter(
            ParameterSetName = ListAllVersionsParamSetName,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Publisher.")]
        [Parameter(
            ParameterSetName = ListSingleVersionParamSetName,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Publisher.")]
        [ValidateNotNullOrEmpty]
        public string Publisher { get; set; }

        [Parameter(
            ParameterSetName = ListSingleVersionParamSetName,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(
            ParameterSetName = ListAllVersionsParamSetName,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify to list all versions of an extension.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllVersions { get; set; }

        public virtual void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();

            Func<VirtualMachineExtensionListResponse.ResourceExtension, bool> truePred = s => true;

            Func<string, Func<VirtualMachineExtensionListResponse.ResourceExtension, string>,
                 Func<VirtualMachineExtensionListResponse.ResourceExtension, bool>> predFunc =
                 (x, f) => string.IsNullOrEmpty(x) ? truePred : s => string.Equals(x, f(s), StringComparison.OrdinalIgnoreCase);

            var typePred = predFunc(this.ExtensionName, s => s.Name);
            var publisherPred = predFunc(this.Publisher, s => s.Publisher);
            var versionPred = predFunc(this.Version, s => s.Version);

            ExecuteClientActionNewSM(null,
                CommandRuntime.ToString(),
                () =>
                {
                    if (this.AllVersions.IsPresent || !string.IsNullOrEmpty(this.Version))
                    {
                        return this.ComputeClient.VirtualMachineExtensions.ListVersions(this.Publisher, this.ExtensionName);
                    }
                    else
                    {
                        return this.ComputeClient.VirtualMachineExtensions.List();
                    }
                },
                (op, response) => response.Where(typePred).Where(publisherPred).Where(versionPred).Select(
                     extension => ContextFactory<VirtualMachineExtensionListResponse.ResourceExtension, VirtualMachineExtensionImageContext>(extension, op)));
        }

        protected override void OnProcessRecord()
        {
            try
            {
                this.ExecuteCommand();
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }
    }
}
