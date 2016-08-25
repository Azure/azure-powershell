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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsCommon.New, Constants.EncryptString, DefaultParameterSetName = ByFactoryName), OutputType(typeof(string))]
    public class NewAzureDataFactoryEncryptValueCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ByFactoryObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory object.")]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The data factory name.")]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 1, Mandatory = false, HelpMessage = "The value to encrypt.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 2, Mandatory = false, HelpMessage = "The value to encrypt.")]
        public SecureString Value { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 2, Mandatory = false, HelpMessage = "The gateway group name.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 3, Mandatory = false, HelpMessage = "The gateway group name.")]
        public string GatewayName { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 3, Mandatory = false, HelpMessage = "The windows authentication credential.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 4, Mandatory = false, HelpMessage = "The windows authentication credential.")]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 4, Mandatory = false,
            HelpMessage = "The linked service type.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 5, Mandatory = false,
            HelpMessage = "The linked service type.")]
        [ValidateSet("OnPremisesSqlLinkedService", "OnPremisesFileSystemLinkedService", "OnPremisesOracleLinkedService",
            "OnPremisesOdbcLinkedService", "OnPremisesPostgreSqlLinkedService", "OnPremisesTeradataLinkedService",
            "OnPremisesMySQLLinkedService", "OnPremisesDB2LinkedService", "OnPremisesSybaseLinkedService",
            "HdfsLinkedService",
            IgnoreCase = true)]
        public string Type { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 5, Mandatory = false, HelpMessage = "The non-credential value.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 6, Mandatory = false, HelpMessage = "The non-credential value.")]
        public string NonCredentialValue { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 6, Mandatory = false, HelpMessage = "The authentication type.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 7, Mandatory = false, HelpMessage = "The authentication type.")]
        [ValidateSet("Windows", "Basic", "Anonymous", IgnoreCase = true)]
        public string AuthenticationType { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 7, Mandatory = false, HelpMessage = "The server name.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 8, Mandatory = false, HelpMessage = "The server name.")]
        public string Server { get; set; }

        [Parameter(ParameterSetName = ByFactoryObject, Position = 8, Mandatory = false, HelpMessage = "The database name.")]
        [Parameter(ParameterSetName = ByFactoryName, Position = 9, Mandatory = false, HelpMessage = "The database name.")]
        public string Database { get; set; }

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
                WriteWarning("Cloud encryption has already been deprecated. Please run get-help new-azuredatafactoryencryptvalue to see other option of this command");
            }
            else
            {
                // On-premises encryption with Gateway
                encryptedValue = DataFactoryClient.OnPremisesEncryptString(Value, ResourceGroupName, DataFactoryName,
                    GatewayName, Credential, Type, NonCredentialValue, AuthenticationType, Server, Database);
            }

            WriteObject(encryptedValue);
        }
    }
}