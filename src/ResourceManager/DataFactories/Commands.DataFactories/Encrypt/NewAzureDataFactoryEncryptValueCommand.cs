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

using System;
using System.Globalization;
using System.Management.Automation;
using System.Security;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsCommon.New, Constants.EncryptString), OutputType(typeof(string))]
    public class NewAzureDataFactoryEncryptValueCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 1, Mandatory = true, HelpMessage = "The value to encrypt.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 2, Mandatory = true, HelpMessage = "The value to encrypt.")]
        [ValidateNotNullOrEmpty]
        public SecureString Value { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 2, Mandatory = false, HelpMessage = "The gateway group name.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 3, Mandatory = false, HelpMessage = "The gateway group name.")]
        public string GatewayName { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByFactoryObject)
            {
                if (DataFactory == null)
                {
                    throw new PSArgumentNullException(string.Format(CultureInfo.InvariantCulture,
                        Resources.DataFactoryArgumentInvalid));
                }

                DataFactoryName = DataFactory.DataFactoryName;
                ResourceGroupName = DataFactory.ResourceGroupName;
            }

            string encryptedValue = String.Empty;

            if (String.IsNullOrWhiteSpace(GatewayName))
            {
                // Cloud encryption without Gateway
                encryptedValue = DataFactoryClient.CloudEncryptString(Value, ResourceGroupName, DataFactoryName);
            }
            else
            {
                // On-premises encryption with Gateway
                encryptedValue = DataFactoryClient.OnPremisesEncryptString(Value, ResourceGroupName, DataFactoryName, GatewayName);
            }
            
            WriteObject(encryptedValue);
        }
    }
}