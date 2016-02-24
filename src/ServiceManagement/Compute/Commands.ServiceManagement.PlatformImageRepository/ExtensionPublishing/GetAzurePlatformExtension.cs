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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// Get Microsoft Azure Publisher Extensions.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        AzurePlatformExtensionCommandNoun),
    OutputType(
        typeof(ExtensionImageContext))]
    public class GetAzureServiceAvailableExtensionCommand : ServiceManagementBaseCmdlet
    {
        protected const string AzurePlatformExtensionCommandNoun = "AzurePlatformExtension";

        public void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();
            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () =>
                {
                    var op = this.ComputeClient.HostedServices.ListPublisherExtensions();
                    return op;
                },
                (op, response) => response.Select(
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
