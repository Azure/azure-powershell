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

using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Maps.Properties;
using Microsoft.Azure.Management.Maps;
using Microsoft.Azure.Commands.Maps.Models;

namespace Microsoft.Azure.Commands.Maps.MapsAccount
{
    /// <summary>
    /// Delete a Maps Account
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, MapsAccountNounStr, DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureMapsAccount : MapsAccountBaseCmdlet
    {
        protected const string NameParameterSet = "NameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Maps Account Name.")]
        [Alias(MapsAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "Maps Account piped from Get-AzureRmMapsAccount.",
            ValueFromPipeline = true)]
        public PSMapsAccount InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Maps Account ResourceId.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Return whether the specified account was successfully deleted or not.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                string rgName = null;
                string name = null;

                switch (ParameterSetName)
                {
                    case InputObjectParameterSet:
                    {
                        rgName = InputObject.ResourceGroupName;
                        name = InputObject.AccountName;
                        break;
                    }
                    case NameParameterSet:
                    {
                        rgName = this.ResourceGroupName;
                        name = this.Name;
                        break;
                    }
                    case ResourceIdParameterSet:
                    {
                        ValidateAndExtractName(this.ResourceId, out rgName, out name);
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(rgName)
                    && !string.IsNullOrEmpty(name)
                    && ShouldProcess(name, string.Format(CultureInfo.CurrentCulture, Resources.RemoveAccount_ProcessMessage, name)))
                {
                    this.MapsClient.Accounts.Delete(rgName, name);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                }
            });
        }
    }
}
