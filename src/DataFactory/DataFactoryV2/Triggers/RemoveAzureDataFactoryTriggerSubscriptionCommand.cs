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

using Microsoft.Azure.Commands.DataFactoryV2.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2TriggerSubscription",
        DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureDataFactoryTriggerSubscriptionCommand : DataFactoryContextActionBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpTriggerName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.TriggerName)]
        public override string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByInputObject, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.HelpTriggerObject)]
        [ValidateNotNull]
        public PSTrigger InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.HelpPassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ByResourceId();
            ByInputObject(InputObject);

            if (ShouldProcess(Name, Constants.ActionDescriptionForRemoveEventSubscription))
            {
                DataFactoryClient.UnsubscribeFromTriggerEvents(ResourceGroupName, DataFactoryName, Name);
            }
            if (PassThru.IsPresent && PassThru.ToBool())
            {
                WriteObject(true);
            }
        }
    }
}
