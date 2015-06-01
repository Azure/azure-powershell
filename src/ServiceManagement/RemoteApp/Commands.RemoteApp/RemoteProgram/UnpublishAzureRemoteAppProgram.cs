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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.RemoteApp;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsData.Unpublish, "AzureRemoteAppProgram", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High), OutputType(typeof(PublishingOperationResult))]
    public class UnpublishAzureRemoteAppProgram : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = false,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Aliases of the programs to unpublish")]
        [ValidateNotNullOrEmpty()]
        public string[] Alias { get; set; }

        public override void ExecuteCmdlet()
        {
            UnpublishApplicationsResult result = null;

            AliasesListParameter appAlias = new AliasesListParameter()
            {
                AliasesList = new List<string>(Alias)
            };

            if (appAlias.AliasesList.Count == 0)
            {
                if (ShouldProcess(Commands_RemoteApp.UnpublishProgramConfirmationDescription, 
                    Commands_RemoteApp.GenericAreYouSureQuestion, 
                    Commands_RemoteApp.UnpublishProgramCaptionMessage))
                {
                    result = CallClient(() => Client.Publishing.UnpublishAll(CollectionName), Client.Publishing);
                }
            }
            else
            {
                appAlias.AliasesList = new List<string>(Alias);
                result = CallClient(() => Client.Publishing.Unpublish(CollectionName, appAlias), Client.Publishing);
            }

            if (result != null && result.ResultList != null)
            {
                WriteObject(result.ResultList, true);
            }
        }
    }
}
