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
using Microsoft.Azure.Commands.KeyVault.Models;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Text;
using System.Xml;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet( VerbsCommon.Set, CmdletNoun.AzureKeyVaultManagedStorageSasDefinition,
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri,
        DefaultParameterSetName = ParameterSetRawSas )]
    [OutputType( typeof( ManagedStorageSasDefinition ) )]
    public partial class SetAzureKeyVaultManagedStorageSasDefinition : KeyVaultCmdletBase
    {
        private const string ParameterSetRawSas = "RawSas";

        [Parameter( Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter( Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key Vault managed storage account name. Cmdlet constructs the FQDN of a managed storage account name from vault name, currently " +
                          "selected environment and manged storage account name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.StorageAccountName )]
        public string AccountName { get; set; }

        [Parameter( Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage sas definition name. Cmdlet constructs the FQDN of a storage sas definition from vault name, currently " +
                          "selected environment, storage account name and sas definition name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.SasDefinitionName )]
        public string Name { get; set; }

        [Parameter( Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Sas definition parameters that will be used to create the sas token.",
            ParameterSetName = ParameterSetRawSas )]
        [Obsolete("-Parameter will be removed and replaced by -TemplateUri and -SasType in May 2018")]
        [ValidateNotNull]
        public Hashtable Parameter { get; set; }

        [Parameter( Mandatory = false,
            HelpMessage = "Disables the use of sas definition for generation of sas token." )]
        public SwitchParameter Disable { get; set; }

        [Parameter( Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable representing tags of sas definition." )]
        [Alias( Constants.TagsAlias )]
        public Hashtable Tag { get; set; }

        #region Common SAS Arguments

        private const string TargetStorageVersionHelpMessage = "Specifies the signed storage service version to use to authenticate requests made with the SAS token.";
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetAdhocAccountSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetAdhocServiceBlobSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetAdhocServiceContainerSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetAdhocServiceFileSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetAdhocServiceShareSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetAdhocServiceQueueSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceBlobSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceContainerSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceFileSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceShareSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceQueueSas )]
        [Parameter( HelpMessage = TargetStorageVersionHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceTableSas )]
        [ValidateNotNullOrEmpty]
        public string TargetStorageVersion
        {
            get { return _targetStorageVersion; }
            set { _targetStorageVersion = value; }
        }
        private string _targetStorageVersion = "2016-05-31";  // default version

        private static class SharedAccessProtocols
        {
            public const string HttpsOnly = "HttpsOnly";
            public const string HttpsOrHttp = "HttpsOrHttp";
        }

        private const string ProtocolHelpMessage = "Protocol can be used in the request with the SAS token. Possbile values include 'HttpsOnly','HttpsOrHttp'";
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetAdhocAccountSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetAdhocServiceBlobSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetAdhocServiceContainerSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetAdhocServiceFileSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetAdhocServiceShareSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetAdhocServiceQueueSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceBlobSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceContainerSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceFileSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceShareSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceQueueSas )]
        [Parameter( HelpMessage = ProtocolHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceTableSas )]
        [ValidateNotNull]
        [ValidateSet( SharedAccessProtocols.HttpsOnly, SharedAccessProtocols.HttpsOrHttp )]
        public string Protocol { get; set; }

        // ReSharper disable once InconsistentNaming
        private const string IPAddressOrRangeHelpMessage = "IP, or IP range ACL (access control list) of the request that would be accepted by Azure Storage. E.g. '168.1.5.65' or '168.1.5.60-168.1.5.70'";
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetAdhocAccountSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetAdhocServiceBlobSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetAdhocServiceContainerSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetAdhocServiceFileSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetAdhocServiceShareSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetAdhocServiceQueueSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceBlobSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceContainerSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceFileSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceShareSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceQueueSas )]
        [Parameter( HelpMessage = IPAddressOrRangeHelpMessage, ParameterSetName = ParameterSetStoredPolicyServiceTableSas )]
        [ValidateNotNullOrEmpty]
        // ReSharper disable once InconsistentNaming
        public string IPAddressOrRange { get; set; }

        private const string ValidityPeriodHelpMessage = "Validity period that will get used to set the expiry time of sas token from the time it gets generated";
        [Parameter( Mandatory = true, HelpMessage = ValidityPeriodHelpMessage, ParameterSetName = ParameterSetAdhocAccountSas )]
        [Parameter( Mandatory = true, HelpMessage = ValidityPeriodHelpMessage, ParameterSetName = ParameterSetAdhocServiceBlobSas )]
        [Parameter( Mandatory = true, HelpMessage = ValidityPeriodHelpMessage, ParameterSetName = ParameterSetAdhocServiceContainerSas )]
        [Parameter( Mandatory = true, HelpMessage = ValidityPeriodHelpMessage, ParameterSetName = ParameterSetAdhocServiceShareSas )]
        [Parameter( Mandatory = true, HelpMessage = ValidityPeriodHelpMessage, ParameterSetName = ParameterSetAdhocServiceFileSas )]
        [Parameter( Mandatory = true, HelpMessage = ValidityPeriodHelpMessage, ParameterSetName = ParameterSetAdhocServiceQueueSas )]
        [Parameter( Mandatory = true, HelpMessage = ValidityPeriodHelpMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [ValidateNotNull]
        public TimeSpan? ValidityPeriod { get; set; }

        private const string PermissionsMessage = "Permissions. Possible values include 'Add','Create','Delete','List','Process','Query','Read','Update','Write'";
        [Parameter( Mandatory = true, HelpMessage = PermissionsMessage, ParameterSetName = ParameterSetAdhocAccountSas )]
        [Parameter( Mandatory = true, HelpMessage = PermissionsMessage, ParameterSetName = ParameterSetAdhocServiceBlobSas )]
        [Parameter( Mandatory = true, HelpMessage = PermissionsMessage, ParameterSetName = ParameterSetAdhocServiceContainerSas )]
        [Parameter( Mandatory = true, HelpMessage = PermissionsMessage, ParameterSetName = ParameterSetAdhocServiceFileSas )]
        [Parameter( Mandatory = true, HelpMessage = PermissionsMessage, ParameterSetName = ParameterSetAdhocServiceShareSas )]
        [Parameter( Mandatory = true, HelpMessage = PermissionsMessage, ParameterSetName = ParameterSetAdhocServiceQueueSas )]
        [Parameter( Mandatory = true, HelpMessage = PermissionsMessage, ParameterSetName = ParameterSetAdhocServiceTableSas )]
        [ValidateSet( SasPermissions.Add, SasPermissions.Create, SasPermissions.Delete, SasPermissions.List, SasPermissions.Process, SasPermissions.Read, SasPermissions.Query, SasPermissions.Update, SasPermissions.Write )]
        [ValidateNotNull]
        public string[] Permission { get; set; }

        protected KeyValuePair<string, string>? TargetStorageVersionParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( TargetStorageVersion ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.SignedVersion, TargetStorageVersion );
            }
        }

        protected KeyValuePair<string, string>? ProtocolParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( Protocol ) ) return null;

                if ( Protocol.Equals( SharedAccessProtocols.HttpsOnly, StringComparison.OrdinalIgnoreCase ) )
                    return new KeyValuePair<string, string>( SasDefinitionParameterConstants.SignedProtocols, "https" );
                if ( Protocol.Equals( SharedAccessProtocols.HttpsOrHttp, StringComparison.OrdinalIgnoreCase ) )
                    return new KeyValuePair<string, string>( SasDefinitionParameterConstants.SignedProtocols, "https,http" );
                throw new ArgumentOutOfRangeException();
            }
        }

        // ReSharper disable once InconsistentNaming
        protected KeyValuePair<string, string>? IPAddressOrRangeParameter
        {
            get
            {
                if ( string.IsNullOrWhiteSpace( IPAddressOrRange ) ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.SignedIp, IPAddressOrRange );
            }
        }

        protected KeyValuePair<string, string>? ValidityPeriodParameter
        {
            get
            {
                if ( ValidityPeriod == null ) return null;
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.ValidityPeriod, XmlConvert.ToString( ValidityPeriod.Value ) );
            }
        }

        protected void AddIfNotNull( KeyValuePair<string, string>? keyVaultPair, IDictionary<string, string> targetDictionary )
        {
            if ( keyVaultPair != null ) targetDictionary.Add( keyVaultPair.Value.Key, keyVaultPair.Value.Value );
        }

        private static class SasPermissions
        {
            public const string Read = "Read";
            public const string Write = "Write";
            public const string Delete = "Delete";
            public const string List = "List";
            public const string Add = "Add";
            public const string Create = "Create";
            public const string Update = "Update";
            public const string Process = "Process";
            public const string Query = "Query";
        }

        private KeyValuePair<string, string>? PermissionParameter
        {
            get
            {
                if ( Permission == null || Permission.Length == 0 ) return null;

                var builder = new StringBuilder();

                var permissionsSet = new HashSet<string>( Permission, StringComparer.OrdinalIgnoreCase );

                if ( ParameterSetName.Equals( ParameterSetAdhocAccountSas ) )
                {
                    //order is important here
                    if ( permissionsSet.Contains( SasPermissions.Read ) ) builder.Append( "r" );
                    if ( permissionsSet.Contains( SasPermissions.Write ) ) builder.Append( "w" );
                    if ( permissionsSet.Contains( SasPermissions.Delete ) ) builder.Append( "d" );
                    if ( permissionsSet.Contains( SasPermissions.List ) ) builder.Append( "l" );
                    if ( permissionsSet.Contains( SasPermissions.Add ) ) builder.Append( "a" );
                    if ( permissionsSet.Contains( SasPermissions.Create ) ) builder.Append( "c" );
                    if ( permissionsSet.Contains( SasPermissions.Update ) ) builder.Append( "u" );
                    if ( permissionsSet.Contains( SasPermissions.Process ) ) builder.Append( "p" );

                    // query is not allowed with account sas
                    if ( permissionsSet.Contains( SasPermissions.Query ) )
                        throw new ArgumentException( string.Format( CultureInfo.InvariantCulture,
                            Properties.Resources.InvalidSasPermission, SasPermissions.Query ) );
                }
                else
                {
                    //order is important here
                    if ( permissionsSet.Contains( SasPermissions.Query ) ) builder.Append( "r" );
                    if ( permissionsSet.Contains( SasPermissions.Read ) ) builder.Append( "r" );
                    if ( permissionsSet.Contains( SasPermissions.Add ) ) builder.Append( "a" );
                    if ( permissionsSet.Contains( SasPermissions.Create ) ) builder.Append( "c" );
                    if ( permissionsSet.Contains( SasPermissions.Write ) ) builder.Append( "w" );
                    if ( permissionsSet.Contains( SasPermissions.Update ) ) builder.Append( "u" );
                    if ( permissionsSet.Contains( SasPermissions.Delete ) ) builder.Append( "d" );
                    if ( permissionsSet.Contains( SasPermissions.List ) ) builder.Append( "l" );
                    if ( permissionsSet.Contains( SasPermissions.Process ) ) builder.Append( "p" );
                }
                return new KeyValuePair<string, string>( SasDefinitionParameterConstants.SignedPermissions, builder.ToString() );
            }
        }
        #endregion

        private IDictionary<string, string> GetParameters()
        {
            switch ( ParameterSetName )
            {
                case ParameterSetRawSas:
                {
                    var dictionary = new Dictionary<string, string>();
#pragma warning disable CS0618
                    foreach ( DictionaryEntry p in Parameter )
#pragma warning restore CS0618
                    {
                        if ( p.Key == null || string.IsNullOrEmpty( p.Key.ToString() ) )
                            throw new ArgumentException( "An invalid parameter was specified." );
                        dictionary[p.Key.ToString()] = ( p.Value == null ) ? string.Empty : p.Value.ToString();
                    }
                    return dictionary;
                }
                case ParameterSetAdhocAccountSas:
                return GetParameters( SasDefinitionParameterConstants.AccountSasTypeValue, null, null );
                case ParameterSetAdhocServiceContainerSas:
                case ParameterSetStoredPolicyServiceContainerSas:
                return GetParameters( SasDefinitionParameterConstants.ServiceSasTypeValue, SasDefinitionParameterConstants.ServiceSasTypeBlobValue, "c" );
                case ParameterSetAdhocServiceBlobSas:
                case ParameterSetStoredPolicyServiceBlobSas:
                return GetParameters( SasDefinitionParameterConstants.ServiceSasTypeValue, SasDefinitionParameterConstants.ServiceSasTypeBlobValue, "b" );
                case ParameterSetAdhocServiceShareSas:
                case ParameterSetStoredPolicyServiceShareSas:
                return GetParameters( SasDefinitionParameterConstants.ServiceSasTypeValue, SasDefinitionParameterConstants.ServiceSasTypeFileValue, "s" );
                case ParameterSetAdhocServiceFileSas:
                case ParameterSetStoredPolicyServiceFileSas:
                return GetParameters( SasDefinitionParameterConstants.ServiceSasTypeValue, SasDefinitionParameterConstants.ServiceSasTypeFileValue, "f" );
                case ParameterSetAdhocServiceTableSas:
                case ParameterSetStoredPolicyServiceTableSas:
                    return GetParameters( SasDefinitionParameterConstants.ServiceSasTypeValue, SasDefinitionParameterConstants.ServiceSasTypeTableValue, null );
                case ParameterSetAdhocServiceQueueSas:
                case ParameterSetStoredPolicyServiceQueueSas:
                    return GetParameters( SasDefinitionParameterConstants.ServiceSasTypeValue, SasDefinitionParameterConstants.ServiceSasTypeQueueValue, null );
                default:
                    throw new InvalidOperationException( string.Format( CultureInfo.InvariantCulture, "Invalid parameter set {0}", ParameterSetName ) );
            }
        }

        private IDictionary<string, string> GetParameters( string sasType, string serviceSasType, string resourceType )
        {
            var parameters = new Dictionary<string, string>();
            AddIfNotNull( new KeyValuePair<string, string>( SasDefinitionParameterConstants.SasType, sasType ), parameters );
            AddIfNotNull( string.IsNullOrWhiteSpace( serviceSasType ) ? (KeyValuePair<string, string>?) null : new KeyValuePair<string, string>( SasDefinitionParameterConstants.ServiceSasType, serviceSasType ), parameters );
            AddIfNotNull( TargetStorageVersionParameter, parameters );
            AddIfNotNull( ProtocolParameter, parameters );
            AddIfNotNull( IPAddressOrRangeParameter, parameters );
            AddIfNotNull( ValidityPeriodParameter, parameters );
            AddIfNotNull( ServicesParameter, parameters );
            AddIfNotNull( ResourceTypeParameter, parameters );
            AddIfNotNull( string.IsNullOrWhiteSpace( resourceType ) ? (KeyValuePair<string, string>?) null : new KeyValuePair<string, string>( SasDefinitionParameterConstants.SignedResourceTypes, resourceType ), parameters );
            AddIfNotNull( PermissionParameter, parameters );
            AddIfNotNull( ApiVersionParameter, parameters );
            AddIfNotNull( BlobParameter, parameters );
            AddIfNotNull( ContainerParameter, parameters );
            AddIfNotNull( PathParameter, parameters );
            AddIfNotNull( ShareParameter, parameters );
            AddIfNotNull( QueueParameter, parameters );
            AddIfNotNull( TableParameter, parameters );
            AddIfNotNull( PolicyParamater, parameters );
            AddIfNotNull( SharedAccessBlobHeaderCacheControlParameter, parameters );
            AddIfNotNull( SharedAccessBlobHeaderContentDispositionParameter, parameters );
            AddIfNotNull( SharedAccessBlobHeaderContentEncodingParameter, parameters );
            AddIfNotNull( SharedAccessBlobHeaderContentLanguageParameter, parameters );
            AddIfNotNull( SharedAccessBlobHeaderContentTypeParameter, parameters );
            AddIfNotNull( StartPartitionKeyParameter, parameters );
            AddIfNotNull( EndPartitionKeyParameter, parameters );
            AddIfNotNull( StartRowKeyParameter, parameters );
            AddIfNotNull( EndRowKeyParameter, parameters );
            return parameters;
        }

        public override void ExecuteCmdlet()
        {
            if ( ShouldProcess( Name, Properties.Resources.SetManagedStorageSasDefinition ) )
            {
                var sasDefinition = DataServiceClient.SetManagedStorageSasDefinition( VaultName,
                    AccountName,
                    Name,
                    GetParameters(),
                    new ManagedStorageSasDefinitionAttributes( !Disable.IsPresent ),
                    Tag );

                WriteObject( sasDefinition );
            }
        }
    }
}
