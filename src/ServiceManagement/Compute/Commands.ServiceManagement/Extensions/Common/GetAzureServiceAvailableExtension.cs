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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// Get Microsoft Azure Service Extension.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        AzureServiceAvailableExtensionCommandNoun,
        DefaultParameterSetName = ListLatestExtensionsParamSetName),
    OutputType(
        typeof(ExtensionImageContext))]
    public class GetAzureServiceAvailableExtensionCommand : ServiceManagementBaseCmdlet
    {
        protected const string AzureServiceAvailableExtensionCommandNoun = "AzureServiceAvailableExtension";
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
        public string ExtensionName
        {
            get;
            set;
        }

        [Parameter(
            ParameterSetName = ListLatestExtensionsParamSetName,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Provider Namespace.")]
        [Parameter(
            ParameterSetName = ListAllVersionsParamSetName,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Provider Namespace.")]
        [Parameter(
            ParameterSetName = ListSingleVersionParamSetName,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Provider Namespace.")]
        [ValidateNotNullOrEmpty]
        public string ProviderNamespace
        {
            get;
            set;
        }

        [Parameter(
            ParameterSetName = ListSingleVersionParamSetName,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Extension Version.")]
        [ValidateNotNullOrEmpty]
        public string Version
        {
            get;
            set;
        }

        [Parameter(
            ParameterSetName = ListAllVersionsParamSetName,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify to list all versions of an extension.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllVersions
        {
            get;
            set;
        }

        public void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();

            var truePred = (Func<ExtensionImage, bool>)(s => true);

            Func<string, Func<ExtensionImage, string>,
                 Func<ExtensionImage, bool>> predFunc =
                 (x, f) => string.IsNullOrEmpty(x) ? truePred : s => string.Equals(x, f(s), StringComparison.OrdinalIgnoreCase);

            var typePred = predFunc(this.ExtensionName, s => s.Type);
            var nameSpacePred = predFunc(this.ProviderNamespace, s => s.ProviderNameSpace);
            var versionPred = predFunc(this.Version, s => s.Version);

            ExecuteClientActionNewSM(null,
                CommandRuntime.ToString(),
                () =>
                {
                    if (AllVersions.IsPresent || !string.IsNullOrEmpty(this.Version))
                    {
                        return this.ComputeClient.HostedServices.ListExtensionVersions(this.ProviderNamespace, this.ExtensionName);
                    }
                    else
                    {
                        return this.ComputeClient.HostedServices.ListAvailableExtensions();
                    }
                },
                (op, response) => response.Where(typePred).Where(nameSpacePred).Where(versionPred).Select(
                     extension => ContextFactory<ExtensionImage, ExtensionImageContext>(extension, op)));
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
