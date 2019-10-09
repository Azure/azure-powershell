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
using System.Net;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2DataFlow", DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    [OutputType(typeof(bool))]
    public class RemoveAzureDataFactoryDataFlowCommand : DataFactoryContextActionBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowName)]
        [Alias(Constants.DataFlowName)]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByInputObject, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.HelpDataFlow)]
        [ValidateNotNull]
        public PSDataFlow InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ByInputObject(InputObject);
            ByResourceId();

            ConfirmAction(
                    Force.IsPresent,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.DataFlowConfirmationMessage,
                        Name,
                        DataFactoryName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.DataFlowRemoving,
                        Name,
                        DataFactoryName),
                    Name,
                    ExecuteDelete);
        }

        private void ExecuteDelete()
        {
            HttpStatusCode response = DataFactoryClient.DeleteDataFlow(ResourceGroupName, DataFactoryName, Name);

            if (response == HttpStatusCode.NoContent)
            {
                WriteWarning(string.Format(CultureInfo.InvariantCulture, Resources.DataFlowNotFound, Name, DataFactoryName));
            }

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
