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
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Data.Encryption.AzureKeyVaultProvider;
using Microsoft.Data.Encryption.Cryptography;
using Azure.Core;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Azure.Identity;

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

        [Parameter(Mandatory = false, HelpMessage = Constants.ClientEncryptionKeyName)]
        [ValidateNotNullOrEmpty]
        public string ClientEncryptionKeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EncryptionAlgorithmName)]
        [ValidateNotNullOrEmpty]
        public string EncryptionAlgorithmName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.WrappedDataEncryptionKey)]
        [ValidateNotNullOrEmpty]
        public byte[] WrappedDataEncryptionKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true,  HelpMessage = Constants.KeyWrapMetaData)]
        [ValidateNotNullOrEmpty]
        public PSSqlKeyWrapMetadata KeyWrapMetadata { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IsAzureKeyVaultKeyStoreProvider)]
        [ValidateNotNullOrEmpty]
        public bool IsAzureKeyVaultKeyStoreProvider { get; set; } = true;

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.IsAzureKeyVaultKeyStoreProvider)]
        [ValidateNotNullOrEmpty]
        public EncryptionKeyStoreProvider EncryptionKeyStoreProvider { get; set; }

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
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, ClientEncryptionKeyName));
            }

            byte[] wrappedDataEncryptionKey = WrappedDataEncryptionKey;
            if (wrappedDataEncryptionKey == null || wrappedDataEncryptionKey.Length == 0)
            {
                KeyEncryptionKey keyEncryptionKey;
                if (IsAzureKeyVaultKeyStoreProvider)
                {
                    if (EncryptionKeyStoreProvider != null)
                    {
                        throw new ArgumentException("EncryptionKeyStoreProvider cannot be set if IsAzureKeyVaultKeyStoreProvider is set to true");
                    }

                    // get the token credential for key vault audience.
                    TokenCredential tokenCredential = new CosmosDBSessionCredential(DefaultContext, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);

                    AzureKeyVaultKeyStoreProvider azureKeyVaultKeyStoreProvider = new AzureKeyVaultKeyStoreProvider(tokenCredential);

                    keyEncryptionKey = KeyEncryptionKey.GetOrCreate(
                        encryptionKeyWrapMetadata.Name,
                        encryptionKeyWrapMetadata.Value,
                        azureKeyVaultKeyStoreProvider);
                }
                else
                {
                    if (EncryptionKeyStoreProvider == null)
                    {
                        throw new ArgumentException("EncryptionKeyStoreProvider cannot be null if IsAzureKeyVaultKeyStoreProvider is set to false");
                    }

                    keyEncryptionKey = KeyEncryptionKey.GetOrCreate(
                        encryptionKeyWrapMetadata.Name,
                        encryptionKeyWrapMetadata.Value,
                        EncryptionKeyStoreProvider);
                }

                ProtectedDataEncryptionKey protectedDataEncryptionKey = new ProtectedDataEncryptionKey(
                        ClientEncryptionKeyName,
                        keyEncryptionKey);

                wrappedDataEncryptionKey = protectedDataEncryptionKey.EncryptedValue;
            }

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
