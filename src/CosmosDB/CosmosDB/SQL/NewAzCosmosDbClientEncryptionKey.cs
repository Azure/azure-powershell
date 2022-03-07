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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Azure.Core;
using Azure.Core.Cryptography;
using Microsoft.Rest.Azure;
using System.Security.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDbClientEncryptionKey", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlClientEncryptionKeyGetResults), typeof(ConflictingResourceException))]
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
        [ValidateNotNullOrEmpty]
        public string ClientEncryptionKeyName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.EncryptionAlgorithmName)]
        [ValidateNotNullOrEmpty]
        public string EncryptionAlgorithmName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = Constants.KeyWrapMetaData)]
        [ValidateNotNullOrEmpty]
        public PSSqlKeyWrapMetadata KeyWrapMetadata { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.IKeyEncryptionKeyResolver)]
        [ValidateNotNullOrEmpty]
        public IKeyEncryptionKeyResolver IKeyEncryptionKeyResolver { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlDatabaseGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
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

            ClientEncryptionKeyGetResults readClientEncryptionKeyGetResults = null;
            try
            {
                readClientEncryptionKeyGetResults = CosmosDBManagementClient.SqlResources.GetClientEncryptionKey(ResourceGroupName, AccountName, DatabaseName, ClientEncryptionKeyName);
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
                //throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, ClientEncryptionKeyName));
            }
            
            if (string.Equals(encryptionKeyWrapMetadata.Type, "AZURE_KEY_VAULT"))
            {
                if (IKeyEncryptionKeyResolver != null)
                {
                    throw new ArgumentException("EncryptionKeyStoreProvider cannot be set if IsAzureKeyVaultKeyStoreProvider is set to true");
                }

                // get the token credential for key vault audience.
                TokenCredential tokenCredential = new CosmosDBSessionCredential(DefaultContext, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);

                IKeyEncryptionKeyResolver = new KeyResolver(tokenCredential);
            }
            else
            {
                if (IKeyEncryptionKeyResolver == null)
                {
                    throw new ArgumentException("IKeyEncryptionKeyResolver cannot be null.");
                }
            }

            byte[] plainTextDataEncryptionKey = new byte[32];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(plainTextDataEncryptionKey);


            byte[] wrappedDataEncryptionKey = IKeyEncryptionKeyResolver.Resolve(encryptionKeyWrapMetadata.Value)
            .WrapKey(encryptionKeyWrapMetadata.Algorithm, plainTextDataEncryptionKey);

            ClientEncryptionKeyResource clientEncryptionKeyResource = new ClientEncryptionKeyResource
            {
                Id = ClientEncryptionKeyName,
                EncryptionAlgorithm = EncryptionAlgorithmName,
                KeyWrapMetadata = encryptionKeyWrapMetadata,
                WrappedDataEncryptionKey = wrappedDataEncryptionKey
            };

            ClientEncryptionKeyCreateUpdateParameters clientEncryptionKeyCreateUpdateParameters = new ClientEncryptionKeyCreateUpdateParameters
            {
                Resource = clientEncryptionKeyResource
            };

            if (ShouldProcess(ClientEncryptionKeyName, "Creating a new CosmosDB Client Encryption Key"))
            {
                ClientEncryptionKeyGetResults clientEncryptionKeyGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateClientEncryptionKeyWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, ClientEncryptionKeyName, clientEncryptionKeyCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlClientEncryptionKeyGetResults(clientEncryptionKeyGetResults));
            }

            return;
        }
    }   

}
