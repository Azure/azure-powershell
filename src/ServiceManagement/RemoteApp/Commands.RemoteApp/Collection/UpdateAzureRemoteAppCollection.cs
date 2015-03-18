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

using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Commands.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsData.Update, "AzureRemoteAppCollection", SupportsShouldProcess = true), OutputType(typeof(TrackingResult))]

    public class UpdateAzureRemoteAppCollection : RdsCmdlet
    {
        [Parameter (Mandatory = true,
                    Position = 0,
                    HelpMessage = "RemoteApp collection name")]
        [ValidatePattern (NameValidatorString)]
        public string CollectionName { get; set; }


        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the RemoteApp template image."
        )]
        public string ImageName { get; set; }

        public override void ExecuteCmdlet()
        {
            CollectionCreationDetails details = null;
            OperationResultWithTrackingId response = null;
            Collection collection = null;

            collection = FindCollection(CollectionName);

            if (collection != null)
            {
                details = new CollectionCreationDetails()
                {
                    Name = CollectionName,
                    TemplateImageName = ImageName,
                    PlanName = collection.PlanName
                };

                if (ShouldProcess(CollectionName, Commands_RemoteApp.UpdateCollection))
                {
                    response = CallClient(() => Client.Collections.Set(CollectionName, false, false, details), Client.Collections);
                }

                if (response != null)
                {
                    WriteTrackingId(response);
                }
            }
        }
    }
}
