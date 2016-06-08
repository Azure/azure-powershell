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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsData.Update, "AzureRemoteAppCollection", SupportsShouldProcess = true), OutputType(typeof(TrackingResult))]

    public class UpdateAzureRemoteAppCollection : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the RemoteApp template image."
        )]
        public string ImageName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the subnet to move the collection into."
        )]
        public string SubnetName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Log off users immediately after the update has successfully completed")]
        public SwitchParameter ForceLogoffWhenUpdateComplete { get; set; }

        public override void ExecuteCmdlet()
        {
            CollectionUpdateDetails details = null;
            OperationResultWithTrackingId response = null;
            Collection collection = null;

            collection = FindCollection(CollectionName);
            if (collection == null)
            {
                return;
            }

            details = new CollectionUpdateDetails()
            {
                TemplateImageName = ImageName,
                WaitBeforeShutdownInMinutes = ForceLogoffWhenUpdateComplete ? -1 : 0,
                SubnetName = string.IsNullOrEmpty(SubnetName) ? null : SubnetName
            };

            if (ShouldProcess(CollectionName, Commands_RemoteApp.UpdateCollection))
            {
                response = CallClient(() => Client.Collections.Set(CollectionName, true, false, details), Client.Collections);
            }

            if (response != null)
            {
                WriteTrackingId(response);
            }
        }
    }
}
