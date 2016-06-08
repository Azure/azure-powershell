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

using Hyak.Common;
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using System.Globalization;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsCommon.New, Constants.Gateway, DefaultParameterSetName = ByFactoryName), OutputType(typeof(PSDataFactoryGateway))]
    public class NewAzureDataFactoryGatewayCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
    HelpMessage = "The data factory gateway name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description to update.")]
        public string Description { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByFactoryObject)
            {
                if (DataFactory == null)
                {
                    throw new PSArgumentNullException(string.Format(CultureInfo.InvariantCulture, Resources.DataFactoryArgumentInvalid));
                }

                DataFactoryName = DataFactory.DataFactoryName;
                ResourceGroupName = DataFactory.ResourceGroupName;
            }

            PSDataFactoryGateway gateway = null;
            try
            {
                gateway = DataFactoryClient.GetGateway(ResourceGroupName, DataFactoryName, Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != HttpStatusCode.NotFound) throw;
            }

            if (gateway != null)
            {
                throw new PSInvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.DataFactoryGatewayExists, Name, DataFactoryName));
            }

            var request = new PSDataFactoryGateway
            {
                Name = Name,
                Description = Description
            };

            PSDataFactoryGateway response = DataFactoryClient.CreateOrUpdateGateway(ResourceGroupName, DataFactoryName, request);
            WriteObject(response);
        }
    }
}
