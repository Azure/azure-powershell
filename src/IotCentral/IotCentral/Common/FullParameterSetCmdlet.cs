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

using Microsoft.Azure.Commands.IotCentral.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.IotCentral.Common
{
    public abstract class IotCentralFullParameterSetCmdlet : IotCentralBaseCmdlet
    {
        /// <summary>
        /// Iot Central Application ResourceId
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Iot Central Application Resource Id.",
            ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Iot Central Application Input Object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Iot Central Application Input Object.",
            ParameterSetName = InputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSIotCentralApp InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet as a job in the background.")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Uses the applicable parameter group to set the Name and ResouceName for the current execution.
        /// </summary>
        protected void SetNameAndResourceGroup()
        {
            switch (ParameterSetName)
            {
                case InteractiveIotCentralParameterSet:
                    break;
                case InputObjectParameterSet:
                    this.ResourceGroupName = this.InputObject.ResourceGroupName;
                    this.Name = this.InputObject.Name;
                    break;
                case ResourceIdParameterSet:
                    var identifier = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = identifier.ResourceGroupName;
                    this.Name = identifier.ResourceName;
                    break;
                default:
                    throw new PSArgumentException("BadParameterSetName");
            }
        }
    }
}
