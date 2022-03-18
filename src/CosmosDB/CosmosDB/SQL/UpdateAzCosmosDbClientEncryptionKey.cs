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
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Azure.Core;
using Azure.Core.Cryptography;
using Microsoft.Rest.Azure;
using Azure.Security.KeyVault.Keys.Cryptography;
using ResourceIdentifier = Microsoft.Azure.Management.Internal.Resources.Utilities.Models.ResourceIdentifier;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDbClientEncryptionKey", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlClientEncryptionKeyGetResults))]
    public class UpdateAzCosmosDbClientEncryptionKey : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.ClientEncryptionKeyName)]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ClientEncryptionKeyName)]
        [Alias(Constants.ClientEncryptionKeyNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = Constants.KeyWrapMetaData)]
        [ValidateNotNull]
        public PSSqlKeyWrapMetadata KeyWrapMetadata { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.KeyEncryptionKeyResolver)]
        [ValidateNotNull]
        public IKeyEncryptionKeyResolver KeyEncryptionKeyResolver { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlDatabaseGetResults SqlDatabaseObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.ClientEncryptionKeyObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlClientEncryptionKeyGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(SqlDatabaseObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }            
            else if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = ResourceIdentifierExtensions.GetSqlDatabaseName(resourceIdentifier);
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
                Name = InputObject.Name;
            }

            KeyWrapMetadata newEncryptionKeyWrapMetadata;
            if (KeyWrapMetadata != null)
            {
                newEncryptionKeyWrapMetadata = PSSqlKeyWrapMetadata.ToSDKModel(KeyWrapMetadata);
            }
            else
            {
                throw new ArgumentException("KeyWrapMetadata cannot be null");
            }

            ClientEncryptionKeyGetResults readClientEncryptionKeyGetResults = null;
            try
            {
                readClientEncryptionKeyGetResults = CosmosDBManagementClient.SqlResources.GetClientEncryptionKey(ResourceGroupName, AccountName, DatabaseName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFound, Name), innerException: e);
                }
            }

            ClientEncryptionKeyResource clientEncryptionKeyResource = UpdateAzCosmosDbClientEncryptionKey.PopulateSqlClientEncryptionKeyResource(readClientEncryptionKeyGetResults.Resource);

            if (!string.Equals(newEncryptionKeyWrapMetadata.Algorithm, "RSA-OAEP"))
            {
                throw new ArgumentException($"Invalid key wrap algorithm '{newEncryptionKeyWrapMetadata.Algorithm}' passed. Please refer to https://aka.ms/CosmosClientEncryption for more details.");
            }

            byte[] rewrappedKey;

            if (string.Equals(clientEncryptionKeyResource.KeyWrapMetadata.Type, "AZURE_KEY_VAULT") && KeyEncryptionKeyResolver == null)
            {
                if (!string.Equals(newEncryptionKeyWrapMetadata.Type, "AZURE_KEY_VAULT"))
                {
                    throw new ArgumentException("KeyEncryptionKeyResolver type cannot be changed during rewrap operations. Please refer to https://aka.ms/CosmosClientEncryption for more details.");
                }

                // get the token credential for key vault audience.
                TokenCredential tokenCredential = new CosmosDBSessionCredential(DefaultContext, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);

                KeyEncryptionKeyResolver = new KeyResolver(tokenCredential);                
            }
            else
            {
                if (KeyEncryptionKeyResolver == null)
                {
                    throw new ArgumentException("KeyEncryptionKeyResolver cannot be null.");
                }
            }

            byte[] unwrappedKey = KeyEncryptionKeyResolver.Resolve(clientEncryptionKeyResource.KeyWrapMetadata.Value)
                    .UnwrapKey(clientEncryptionKeyResource.KeyWrapMetadata.Algorithm, clientEncryptionKeyResource.WrappedDataEncryptionKey);

            rewrappedKey = KeyEncryptionKeyResolver.Resolve(newEncryptionKeyWrapMetadata.Value)
                .WrapKey(newEncryptionKeyWrapMetadata.Algorithm, unwrappedKey);

            clientEncryptionKeyResource = new ClientEncryptionKeyResource
            {
                Id = Name,
                EncryptionAlgorithm = clientEncryptionKeyResource.EncryptionAlgorithm,
                KeyWrapMetadata = newEncryptionKeyWrapMetadata,
                WrappedDataEncryptionKey = rewrappedKey
            };

            ClientEncryptionKeyCreateUpdateParameters clientEncryptionKeyCreateUpdateParameters = new ClientEncryptionKeyCreateUpdateParameters
            {
                Resource = clientEncryptionKeyResource
            };

            if (ShouldProcess(Name, "Updating an existing CosmosDB Client Encryption Key"))
            {
                ClientEncryptionKeyGetResults clientEncryptionKeyGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateClientEncryptionKeyWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, clientEncryptionKeyCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlClientEncryptionKeyGetResults(clientEncryptionKeyGetResults));
            }
        }

        private static ClientEncryptionKeyResource PopulateSqlClientEncryptionKeyResource(ClientEncryptionKeyGetPropertiesResource clientEncryptionKeyGetPropertiesResource)
        {
            return new ClientEncryptionKeyResource
            {
                EncryptionAlgorithm = clientEncryptionKeyGetPropertiesResource.EncryptionAlgorithm,
                Id = clientEncryptionKeyGetPropertiesResource.Id,
                WrappedDataEncryptionKey = clientEncryptionKeyGetPropertiesResource.WrappedDataEncryptionKey,
                KeyWrapMetadata = clientEncryptionKeyGetPropertiesResource.KeyWrapMetadata                
            };
        }
    }
}
