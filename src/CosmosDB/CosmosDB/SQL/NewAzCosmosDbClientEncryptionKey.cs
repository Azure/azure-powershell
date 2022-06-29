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
using Azure.Core;
using Azure.Core.Cryptography;
using Microsoft.Rest.Azure;
using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using ResourceIdentifier = Microsoft.Azure.Management.Internal.Resources.Utilities.Models.ResourceIdentifier;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDbClientEncryptionKey", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlClientEncryptionKeyGetResults))]
    public class NewAzCosmosDbClientEncryptionKey : AzureCosmosDBCmdletBase
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

        [Parameter(Mandatory = true, HelpMessage = Constants.ClientEncryptionKeyName)]
        [Alias(Constants.ClientEncryptionKeyNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.EncryptionAlgorithmName)]
        [ValidateNotNullOrEmpty]
        public string EncryptionAlgorithmName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = Constants.KeyWrapMetaData)]
        [ValidateNotNull]
        public PSSqlKeyWrapMetadata KeyWrapMetadata { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.KeyEncryptionKeyResolver)]
        [ValidateNotNull]
        public IKeyEncryptionKeyResolver KeyEncryptionKeyResolver { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlDatabaseGetResults SqlDatabaseObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(SqlDatabaseObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            KeyWrapMetadata encryptionKeyWrapMetadata;
            if (KeyWrapMetadata != null)
            {
                encryptionKeyWrapMetadata = PSSqlKeyWrapMetadata.ToSDKModel(KeyWrapMetadata);
            }
            else
            {
                throw new ArgumentException("KeyWrapMetadata cannot be null");
            }

            if(!string.Equals(EncryptionAlgorithmName, "AEAD_AES_256_CBC_HMAC_SHA256"))
            {
                throw new ArgumentException($"Invalid encryption algorithm '{EncryptionAlgorithmName}' passed. Please refer to https://aka.ms/CosmosClientEncryption for more details.");
            }

            if (!string.Equals(encryptionKeyWrapMetadata.Algorithm, "RSA-OAEP"))
            {
                throw new ArgumentException($"Invalid key wrap algorithm '{encryptionKeyWrapMetadata.Algorithm}' passed. Please refer to https://aka.ms/CosmosClientEncryption for more details.");
            }

            if (string.Equals(encryptionKeyWrapMetadata.Type, "AZURE_KEY_VAULT") && KeyEncryptionKeyResolver == null)
            {
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

            byte[] plainTextDataEncryptionKey = new byte[32];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(plainTextDataEncryptionKey);


            byte[] wrappedDataEncryptionKey = KeyEncryptionKeyResolver.Resolve(encryptionKeyWrapMetadata.Value)
                .WrapKey(encryptionKeyWrapMetadata.Algorithm, plainTextDataEncryptionKey);

            ClientEncryptionKeyResource clientEncryptionKeyResource = new ClientEncryptionKeyResource
            {
                Id = Name,
                EncryptionAlgorithm = EncryptionAlgorithmName,
                KeyWrapMetadata = encryptionKeyWrapMetadata,
                WrappedDataEncryptionKey = wrappedDataEncryptionKey
            };

            ClientEncryptionKeyCreateUpdateParameters clientEncryptionKeyCreateUpdateParameters = new ClientEncryptionKeyCreateUpdateParameters
            {
                Resource = clientEncryptionKeyResource
            };

            if (ShouldProcess(Name, "Creating a new CosmosDB Client Encryption Key"))
            {
                // FIXME : This requires a backend fix since its not honoring If-None-Match header with a *. This is required to prevent a race which might result in 
                // accidental replace of a key. This is a best effort approach to check for resource conflict.
                ClientEncryptionKeyGetResults readClientEncryptionKeyGetResults = null;
                try
                {
                    readClientEncryptionKeyGetResults = CosmosDBManagementClient.SqlResources.GetClientEncryptionKey(ResourceGroupName, AccountName, DatabaseName, Name);
                }
                catch (CloudException e)
                {
                    if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                    {
                        throw;
                    }
                }

                if (readClientEncryptionKeyGetResults != null)
                {
                    throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, Name));
                }

                ClientEncryptionKeyGetResults clientEncryptionKeyGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateClientEncryptionKeyWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, clientEncryptionKeyCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlClientEncryptionKeyGetResults(clientEncryptionKeyGetResults));
            }
        }
    }   

}
