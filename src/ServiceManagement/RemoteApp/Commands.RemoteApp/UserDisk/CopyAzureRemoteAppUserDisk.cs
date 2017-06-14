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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Copy, "AzureRemoteAppUserDisk")]
    public class CopyAzureRemoteAppUserDisk : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp source collection name")]
        [ValidatePattern(NameValidatorString)]
        public string SourceCollectionName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp destination collection name")]
        [ValidatePattern(NameValidatorString)]
        public string DestinationCollectionName { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp user upn")]
        [ValidatePattern(UserPrincipalValdatorString)]
        public string UserUpn { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Overwrite existing user disk")]
        public SwitchParameter OverwriteExistingUserDisk { get; set; }

        public override void ExecuteCmdlet()
        {
            CallClient(() => Client.UserDisks.Copy(SourceCollectionName, DestinationCollectionName, UserUpn, OverwriteExistingUserDisk.IsPresent), Client.UserDisks);
        }
    }
}