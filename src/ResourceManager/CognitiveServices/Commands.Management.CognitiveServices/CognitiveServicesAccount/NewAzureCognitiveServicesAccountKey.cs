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

using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Regnerate Cognitive Services Account Key (Key1 or Key2)
    /// </summary>
    [Cmdlet(VerbsCommon.New, CognitiveServicesAccountKeyNounStr), OutputType(typeof(string))]
    public class NewAzureCognitiveServicesAccountKeyCommand : CognitiveServicesAccountBaseCmdlet
    {
        private const KeyNameEnum Key1 = KeyNameEnum.Key1;

        private const KeyNameEnum Key2 = KeyNameEnum.Key2;

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Key.")]
        public KeyNameEnum KeyName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var keys = this.CognitiveServicesClient.CognitiveServicesAccounts.RegenerateKey(
                this.ResourceGroupName,
                this.Name,
                this.KeyName);

            WriteObject(keys);
        }
    }
}
