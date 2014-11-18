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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing
{
    /// <summary>
    /// Create a New Extension Endpoint Config Set.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        AzurePlatformExtensionEndpointConfigSetCommandNoun),
    OutputType(
        typeof(ExtensionEndpointConfigSet))]
    public class NewAzurePlatformExtensionEndpointConfigSetCommand : PSCmdlet
    {
        protected const string AzurePlatformExtensionEndpointConfigSetCommandNoun = "AzurePlatformExtensionEndpointConfigSet";

        protected override void ProcessRecord()
        {
            WriteObject(new ExtensionEndpointConfigSet());
        }
    }
}
