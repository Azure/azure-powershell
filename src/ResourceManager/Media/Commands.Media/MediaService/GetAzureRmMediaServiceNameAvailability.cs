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
using Microsoft.Azure.Commands.Media.Common;
using Microsoft.Azure.Commands.Media.Models;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;

namespace Microsoft.Azure.Commands.Media.MediaService
{
    /// <summary>
    /// Checks whether a Media Service name is available
    /// </summary>
    [Cmdlet(VerbsCommon.Get, MediaServiceNameAvailabilityStr), OutputType(typeof(PSCheckNameAvailabilityOutput))]
    public class GetAzureRmMediaServiceNameAvailability : AzureMediaServiceCmdletBase
    {
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The media service account name.")]
        [ValidateNotNullOrEmpty]
        [Alias("Name", "ResourceName")]
        public string AccountName;

        public override void ExecuteCmdlet()
        {
            var result = MediaServicesManagementClient.MediaService.CheckNameAvailabilty(new CheckNameAvailabilityInput
            {
                Name = AccountName,
                Type = MediaServicesType
            });
            WriteObject(result.ToPsCheckNameAvailabilityOutput(), true);
        }
    }
}
