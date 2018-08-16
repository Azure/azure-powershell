﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryGatewayAuthKey", DefaultParameterSetName = ByFactoryName, SupportsShouldProcess = true), OutputType(typeof(PSDataFactoryGatewayAuthKey))]
    public class NewAzureDataFactoryGatewayAuthKeyCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The data factory object.")]
        [Alias("DataFactory")]
        [ValidateNotNull]
        public PSDataFactory InputObject { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory gateway name.")]
        [ValidateNotNullOrEmpty]
        public string GatewayName { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of gateway auth key to be regenerated, either 'key1' or 'key2'.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("key1", "key2", IgnoreCase = true)]
        public string KeyName { get; set; }
        
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByFactoryObject)
            {
                DataFactoryName = InputObject.DataFactoryName;
                ResourceGroupName = InputObject.ResourceGroupName;
            }

            NewDataFactoryGatewayAuthKeyParameters param = new NewDataFactoryGatewayAuthKeyParameters()
            {
                KeyName = KeyName
            };

            if (ShouldProcess(this.DataFactoryName, "New Data Factory Gateway Auth Key"))
            {
                PSDataFactoryGatewayAuthKey gatewayKey = DataFactoryClient.RegenerateGatewayAuthKey(ResourceGroupName, DataFactoryName, GatewayName, param);
                WriteObject(gatewayKey);
            }

        }
    }
}
