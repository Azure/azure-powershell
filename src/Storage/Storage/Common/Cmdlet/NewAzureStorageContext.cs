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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.ServiceManagement.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet
{
    /// <summary>
    /// New storage context
    /// </summary>
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContext", DefaultParameterSetName = OAuthParameterSet), OutputType(typeof(AzureStorageContext))]
    public class NewAzureStorageContext : AzureDataCmdlet
    {
        /// <summary>
        /// Default resourceId for storage OAuth tokens
        /// </summary>
        public const string StorageOAuthEndpointResourceValue = "https://storage.azure.com";

        /// <summary>
        /// The extension key to use for the storage token audience value
        /// </summary>
        public const string StorageOAuthEndpointResourceKey = "StorageOAuthEndpointResourceId";

        /// <summary>
        /// Account name and key parameter set name
        /// </summary>
        private const string AccountNameKeyParameterSet = "AccountNameAndKey";

        /// <summary>
        /// Sas token parameter set name
        /// </summary>
        private const string SasTokenParameterSet = "SasToken";

        /// <summary>
        /// Sas token with azure environment parameter set name
        /// </summary>
        private const string SasTokenEnvironmentParameterSet = "SasTokenWithAzureEnvironment";

        /// <summary>
        /// Account name and key and azure environment parameter set name
        /// </summary>
        private const string AccountNameKeyEnvironmentParameterSet = "AccountNameAndKeyEnvironment";

        /// <summary>
        /// Connection string parameter set name
        /// </summary>
        private const string ConnectionStringParameterSet = "ConnectionString";

        /// <summary>
        /// Local development account parameter set name
        /// </summary>
        private const string LocalParameterSet = "LocalDevelopment";

        /// <summary>
        /// Anonymous storage account parameter set name
        /// </summary>
        private const string AnonymousParameterSet = "AnonymousAccount";

        /// <summary>
        /// OAuth storage account parameter set name
        /// </summary>
        private const string OAuthParameterSet = "OAuthAccount";

        /// <summary>
        /// OAuth storage account parameter set name
        /// </summary>
        private const string OAuthEnvironmentParameterSet = "OAuthAccountEnvironment";

        /// <summary>
        /// Anonymous storage account with azure environment parameter set name
        /// </summary>
        private const string AnonymousEnvironmentParameterSet = "AnonymousAccountEnvironment";

        /// <summary>
        /// Account name and key with Service Endpoint parameter set name
        /// </summary>
        private const string AccountNameKeyServiceEndpointParameterSet = "AccountNameAndKeyServiceEndpoint";

        /// <summary>
        /// Sas token with Service Endpoint parameter set name
        /// </summary>
        private const string SasTokenServiceEndpointParameterSet = "SasTokenServiceEndpoint";

        /// <summary>
        /// Anonymous storage account with Service Endpoint parameter set name
        /// </summary>
        private const string AnonymousServiceEndpointParameterSet = "AnonymousAccountServiceEndpoint";

        /// <summary>
        /// OAuth storage account with Service Endpoint parameter set name
        /// </summary>
        private const string OAuthServiceEndpointParameterSet = "OAuthAccountServiceEndpoint";

        private const string StorageAccountNameHelpMessage = "Azure Storage Account Name";
        [Parameter(Position = 0, HelpMessage = StorageAccountNameHelpMessage,
            Mandatory = true, ParameterSetName = AccountNameKeyParameterSet)]
        [Parameter(Position = 0, HelpMessage = StorageAccountNameHelpMessage,
            Mandatory = true, ParameterSetName = AccountNameKeyEnvironmentParameterSet)]
        [Parameter(Position = 0, HelpMessage = StorageAccountNameHelpMessage,
            Mandatory = true, ParameterSetName = AnonymousParameterSet)]
        [Parameter(Position = 0, HelpMessage = StorageAccountNameHelpMessage,
            Mandatory = true, ParameterSetName = AnonymousEnvironmentParameterSet)]
        [Parameter(Position = 0, HelpMessage = StorageAccountNameHelpMessage,
            Mandatory = true, ParameterSetName = SasTokenParameterSet)]
        [Parameter(Position = 0, HelpMessage = StorageAccountNameHelpMessage,
            Mandatory = true, ParameterSetName = SasTokenEnvironmentParameterSet)]
        [Parameter(Position = 0, HelpMessage = StorageAccountNameHelpMessage,
            Mandatory = true, ParameterSetName = OAuthParameterSet)]
        [Parameter(Position = 0, HelpMessage = StorageAccountNameHelpMessage,
            Mandatory = true, ParameterSetName = OAuthEnvironmentParameterSet)]
        [Parameter(Position = 0, HelpMessage = StorageAccountNameHelpMessage,
            Mandatory = true, ParameterSetName = AccountNameKeyServiceEndpointParameterSet)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        private const string StorageAccountKeyHelpMessage = "Azure Storage Account Key";
        [Parameter(Position = 1, HelpMessage = StorageAccountKeyHelpMessage,
            Mandatory = true, ParameterSetName = AccountNameKeyParameterSet)]
        [Parameter(Position = 1, HelpMessage = StorageAccountKeyHelpMessage,
            Mandatory = true, ParameterSetName = AccountNameKeyEnvironmentParameterSet)]
        [Parameter(Position = 1, HelpMessage = StorageAccountKeyHelpMessage,
            Mandatory = true, ParameterSetName = AccountNameKeyServiceEndpointParameterSet)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountKey { get; set; }

        private const string SasTokenHelpMessage = "Azure Storage SAS Token";
        [Parameter(HelpMessage = SasTokenHelpMessage,
            Mandatory = true, ParameterSetName = SasTokenParameterSet)]
        [Parameter(HelpMessage = SasTokenHelpMessage,
            Mandatory = true, ParameterSetName = SasTokenEnvironmentParameterSet)]
        [Parameter(HelpMessage = SasTokenHelpMessage,
            Mandatory = true, ParameterSetName = SasTokenServiceEndpointParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SasToken { get; set; }

        private const string ConnectionStringHelpMessage = "Azure Storage Connection String";
        [Parameter(HelpMessage = ConnectionStringHelpMessage,
            Mandatory = true, ParameterSetName = ConnectionStringParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ConnectionString { get; set; }

        private const string LocalHelpMessage = "Use local development storage account";
        [Parameter(HelpMessage = LocalHelpMessage,
            Mandatory = true, ParameterSetName = LocalParameterSet)]
        public SwitchParameter Local
        {
            get { return isLocalDevAccount; }
            set { isLocalDevAccount = value; }
        }

        private bool isLocalDevAccount;

        private const string AnonymousHelpMessage = "Use anonymous storage account";
        [Parameter(HelpMessage = AnonymousHelpMessage,
            Mandatory = true, ParameterSetName = AnonymousParameterSet)]
        [Parameter(HelpMessage = AnonymousHelpMessage,
            Mandatory = true, ParameterSetName = AnonymousEnvironmentParameterSet)]
        [Parameter(HelpMessage = AnonymousHelpMessage,
            Mandatory = true, ParameterSetName = AnonymousServiceEndpointParameterSet)]
        public SwitchParameter Anonymous
        {
            get { return isAnonymous; }
            set { isAnonymous = value; }
        }

        private bool isAnonymous;

        [Parameter(HelpMessage = "Use OAuth storage account", Mandatory = false, ParameterSetName = OAuthParameterSet)]
        [Parameter(HelpMessage = "Use OAuth storage account", Mandatory = false, ParameterSetName = OAuthEnvironmentParameterSet)]
        [Parameter(HelpMessage = "Use OAuth storage account", Mandatory = false, ParameterSetName = OAuthServiceEndpointParameterSet)]
        public SwitchParameter UseConnectedAccount
        {
            get { return isOAuth; }
            set { isOAuth = value; }
        }

        private bool isOAuth = true;

        private const string ProtocolHelpMessage = "Protocol specification (HTTP or HTTPS), default is HTTPS";
        [Parameter(HelpMessage = ProtocolHelpMessage,
            ParameterSetName = AccountNameKeyParameterSet)]
        [Parameter(HelpMessage = ProtocolHelpMessage,
            ParameterSetName = AccountNameKeyEnvironmentParameterSet)]
        [Parameter(HelpMessage = ProtocolHelpMessage,
            ParameterSetName = AnonymousParameterSet)]
        [Parameter(HelpMessage = ProtocolHelpMessage,
            ParameterSetName = AnonymousEnvironmentParameterSet)]
        [Parameter(HelpMessage = ProtocolHelpMessage,
            ParameterSetName = SasTokenParameterSet)]
        [Parameter(HelpMessage = ProtocolHelpMessage,
            ParameterSetName = OAuthParameterSet)]
        [Parameter(HelpMessage = ProtocolHelpMessage,
            ParameterSetName = OAuthEnvironmentParameterSet)]
        [ValidateSet(StorageNouns.HTTP, StorageNouns.HTTPS, IgnoreCase = true)]
        public string Protocol
        {
            get { return protocolType; }
            set { protocolType = value; }
        }

        private string protocolType = StorageNouns.HTTPS;

        private const string EndPointHelpMessage = "Azure storage endpoint";
        [Parameter(HelpMessage = EndPointHelpMessage, ParameterSetName = AccountNameKeyParameterSet)]
        [Parameter(HelpMessage = EndPointHelpMessage, ParameterSetName = AnonymousParameterSet)]
        [Parameter(HelpMessage = EndPointHelpMessage, ParameterSetName = SasTokenParameterSet)]
        [Parameter(HelpMessage = EndPointHelpMessage, ParameterSetName = OAuthParameterSet)]
        public string Endpoint
        {
            get { return storageEndpoint; }
            set { storageEndpoint = value; }
        }

        private string storageEndpoint = string.Empty;

        private const string AzureEnvironmentHelpMessage = "Azure environment name";
        [Alias("Name", "EnvironmentName")]
        [Parameter(HelpMessage = AzureEnvironmentHelpMessage, ParameterSetName = AccountNameKeyEnvironmentParameterSet,
            ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [Parameter(HelpMessage = AzureEnvironmentHelpMessage, ParameterSetName = AnonymousEnvironmentParameterSet,
            ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [Parameter(HelpMessage = AzureEnvironmentHelpMessage, ParameterSetName = SasTokenEnvironmentParameterSet, Mandatory = true)]
        [Parameter(HelpMessage = AzureEnvironmentHelpMessage, ParameterSetName = OAuthEnvironmentParameterSet, Mandatory = true)]
        public string Environment
        {
            get { return environmentName; }
            set { environmentName = value; }
        }

        private string environmentName = string.Empty;

        private const string BlobServiceEndPointHelpMessage = "Azure storage blob service endpoint";
        [Parameter(Mandatory = true, HelpMessage = BlobServiceEndPointHelpMessage, ParameterSetName = AccountNameKeyServiceEndpointParameterSet)]
        [Parameter(HelpMessage = BlobServiceEndPointHelpMessage, ParameterSetName = AnonymousServiceEndpointParameterSet)]
        [Parameter(HelpMessage = BlobServiceEndPointHelpMessage, ParameterSetName = SasTokenServiceEndpointParameterSet)]
        [Parameter(HelpMessage = BlobServiceEndPointHelpMessage, ParameterSetName = OAuthServiceEndpointParameterSet)]
        public string BlobEndpoint { get; set; }

        private const string FileServiceEndPointHelpMessage = "Azure storage file service endpoint";
        [Parameter(HelpMessage = FileServiceEndPointHelpMessage, ParameterSetName = AccountNameKeyServiceEndpointParameterSet)]
        [Parameter(HelpMessage = FileServiceEndPointHelpMessage, ParameterSetName = AnonymousServiceEndpointParameterSet)]
        [Parameter(HelpMessage = FileServiceEndPointHelpMessage, ParameterSetName = SasTokenServiceEndpointParameterSet)]
        [Parameter(HelpMessage = FileServiceEndPointHelpMessage, ParameterSetName = OAuthServiceEndpointParameterSet)]
        public string FileEndpoint { get; set; }

        private const string QueueServiceEndPointHelpMessage = "Azure storage queue service endpoint";
        [Parameter(HelpMessage = QueueServiceEndPointHelpMessage, ParameterSetName = AccountNameKeyServiceEndpointParameterSet)]
        [Parameter(HelpMessage = QueueServiceEndPointHelpMessage, ParameterSetName = AnonymousServiceEndpointParameterSet)]
        [Parameter(HelpMessage = QueueServiceEndPointHelpMessage, ParameterSetName = SasTokenServiceEndpointParameterSet)]
        [Parameter(HelpMessage = QueueServiceEndPointHelpMessage, ParameterSetName = OAuthServiceEndpointParameterSet)]
        public string QueueEndpoint { get; set; }

        private const string TableServiceEndPointHelpMessage = "Azure storage table service endpoint";
        [Parameter(HelpMessage = TableServiceEndPointHelpMessage, ParameterSetName = AccountNameKeyServiceEndpointParameterSet)]
        [Parameter(HelpMessage = TableServiceEndPointHelpMessage, ParameterSetName = AnonymousServiceEndpointParameterSet)]
        [Parameter(HelpMessage = TableServiceEndPointHelpMessage, ParameterSetName = SasTokenServiceEndpointParameterSet)]
        [Parameter(HelpMessage = TableServiceEndPointHelpMessage, ParameterSetName = OAuthServiceEndpointParameterSet)]
        public string TableEndpoint { get; set; }

        /// <summary>
        /// Get storage account by account name and account key
        /// </summary>
        /// <param name="accountName">Storage account name</param>
        /// <param name="accountKey">Storage account key</param>
        /// <param name="useHttps">Use https or not</param>
        /// <param name="storageEndpoint"></param>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountByNameAndKey(string accountName, string accountKey,
            bool useHttps, string storageEndpoint = "")
        {
            StorageCredentials credential = new StorageCredentials(GetRealAccountName(accountName), accountKey);
            return GetStorageAccountWithEndPoint(credential, accountName, useHttps, storageEndpoint);
        }

        /// <summary>
        /// Get storage account by account name and account key
        /// </summary>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountByNameAndKey(string accountName, string accountKey,
            string blobEndPoint, string queueEndPoint, string fileEndPoint, string tableEndPoint)
        {
            StorageCredentials credential = new StorageCredentials(GetRealAccountName(accountName), accountKey);
            return new CloudStorageAccount(credential,
                string.IsNullOrEmpty(blobEndPoint) ? null : new Uri(blobEndPoint),
                string.IsNullOrEmpty(queueEndPoint) ? null : new Uri(queueEndPoint),
                string.IsNullOrEmpty(tableEndPoint) ? null : new Uri(tableEndPoint),
                string.IsNullOrEmpty(fileEndPoint) ? null : new Uri(fileEndPoint));
        }

        /// <summary>
        /// Get storage account by account name and account key
        /// </summary>
        /// <param name="accountName">Storage account name</param>
        /// <param name="accountKey">Storage account key</param>
        /// <param name="useHttps">Use https or not</param>
        /// <param name="azureEnvironmentName">Azure environment name</param>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountByNameAndKeyFromAzureEnvironment(string accountName,
            string accountKey, bool useHttps, string azureEnvironmentName = "")
        {
            StorageCredentials credential = new StorageCredentials(GetRealAccountName(accountName), accountKey);
            return GetStorageAccountWithAzureEnvironment(credential, StorageAccountName, useHttps, azureEnvironmentName);
        }

        /// <summary>
        /// Get storage account by sastoken
        /// </summary>
        /// <param name="storageAccountName">Storage account name, it's used for build end point</param>
        /// <param name="sasToken">Sas token</param>
        /// <param name="useHttps">Use https or not</param>
        /// <param name="storageEndpoint"></param>
        /// <returns>a storage account</returns>
        internal CloudStorageAccount GetStorageAccountBySasToken(string storageAccountName, string sasToken,
            bool useHttps, string storageEndpoint = "")
        {
            StorageCredentials credential = new StorageCredentials(sasToken);
            return GetStorageAccountWithEndPoint(credential, storageAccountName, useHttps, storageEndpoint);
        }

        /// <summary>
        /// Get storage account by sastoken
        /// </summary>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountBySasToken(string sasToken,
            string blobEndPoint, string queueEndPoint, string fileEndPoint, string tableEndPoint)
        {
            StorageCredentials credential = new StorageCredentials(sasToken);
            return new CloudStorageAccount(credential,
                string.IsNullOrEmpty(blobEndPoint) ? null : new Uri(blobEndPoint),
                string.IsNullOrEmpty(queueEndPoint) ? null : new Uri(queueEndPoint),
                string.IsNullOrEmpty(tableEndPoint) ? null : new Uri(tableEndPoint),
                string.IsNullOrEmpty(fileEndPoint) ? null : new Uri(fileEndPoint));
        }

        internal CloudStorageAccount GetStorageAccountBySasTokenFromAzureEnvironment(string storageAccountName,
            string sasToken, bool useHttps, string azureEnvironmentName = "")
        {
            StorageCredentials credential = new StorageCredentials(sasToken);
            return GetStorageAccountWithAzureEnvironment(credential, StorageAccountName, useHttps, azureEnvironmentName);
        }

        /// <summary>
        /// Get storage account by connection string
        /// </summary>
        /// <param name="connectionString">Azure storage connection string</param>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountByConnectionString(string connectionString)
        {
            return CloudStorageAccount.Parse(connectionString);
        }

        /// <summary>
        /// Get local development storage account
        /// </summary>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetLocalDevelopmentStorageAccount()
        {
            return CloudStorageAccount.DevelopmentStorageAccount;
        }

        /// <summary>
        /// Get anonymous storage account
        /// </summary>
        /// <param name="storageAccountName">Storage account name, it's used for build end point</param>
        /// <param name="useHttps"></param>
        /// <param name="storageEndpoint"></param>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetAnonymousStorageAccount(string storageAccountName, bool useHttps, string storageEndpoint = "")
        {
            StorageCredentials credential = new StorageCredentials();
            return GetStorageAccountWithEndPoint(credential, storageAccountName, useHttps, storageEndpoint);
        }

        /// <summary>
        /// Get storage account by anonymous
        /// </summary>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetAnonymousStorageAccount(
            string blobEndPoint, string queueEndPoint, string fileEndPoint, string tableEndPoint)
        {
            StorageCredentials credential = new StorageCredentials();
            return new CloudStorageAccount(credential,
                string.IsNullOrEmpty(blobEndPoint) ? null : new Uri(blobEndPoint),
                string.IsNullOrEmpty(queueEndPoint) ? null : new Uri(queueEndPoint),
                string.IsNullOrEmpty(tableEndPoint) ? null : new Uri(tableEndPoint),
                string.IsNullOrEmpty(fileEndPoint) ? null : new Uri(fileEndPoint));
        }

        /// <summary>
        /// Get anonymous storage account
        /// </summary>
        /// <param name="storageAccountName">Storage account name, it's used for build end point</param>
        /// <param name="useHttps"></param>
        /// <param name="azureEnvironmentName"></param>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetAnonymousStorageAccountFromAzureEnvironment(string storageAccountName,
            bool useHttps, string azureEnvironmentName = "")
        {
            StorageCredentials credential = new StorageCredentials();
            return GetStorageAccountWithAzureEnvironment(credential, storageAccountName, useHttps, azureEnvironmentName);
        }

        /// <summary>
        /// Get OAuth storage account
        /// </summary>
        /// <param name="storageAccountName">Storage account name, it's used for build end point</param>
        /// <param name="useHttps"></param>
        /// <param name="storageEndpoint"></param>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountByOAuth(string storageAccountName, bool useHttps, string storageEndpoint = "")
        {
            IAccessToken accessToken = CreateOAuthToken();
            TokenCredential tokenCredential = new TokenCredential(GetTokenStrFromAccessToken(accessToken), GetTokenRenewer(accessToken), null, new TimeSpan(0, 1, 0));
            StorageCredentials credential = new StorageCredentials(tokenCredential);
            return GetStorageAccountWithEndPoint(credential, storageAccountName, useHttps, storageEndpoint);
        }

        /// <summary>
        /// Get storage account by OAuth
        /// </summary>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountByOAuth(
            string blobEndPoint, string queueEndPoint, string fileEndPoint, string tableEndPoint)
        {
            IAccessToken accessToken = CreateOAuthToken();
            TokenCredential tokenCredential = new TokenCredential(GetTokenStrFromAccessToken(accessToken), GetTokenRenewer(accessToken), null, new TimeSpan(0, 1, 0));
            StorageCredentials credential = new StorageCredentials(tokenCredential);
            return new CloudStorageAccount(credential,
                string.IsNullOrEmpty(blobEndPoint) ? null : new Uri(blobEndPoint),
                string.IsNullOrEmpty(queueEndPoint) ? null : new Uri(queueEndPoint),
                string.IsNullOrEmpty(tableEndPoint) ? null : new Uri(tableEndPoint),
                string.IsNullOrEmpty(fileEndPoint) ? null : new Uri(fileEndPoint));
        }

        /// <summary>
        /// Get OAuth storage account
        /// </summary>
        /// <param name="storageAccountName">Storage account name, it's used for build end point</param>
        /// <param name="useHttps"></param>
        /// <param name="azureEnvironmentName"></param>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountByOAuthFromAzureEnvironment(string storageAccountName, bool useHttps, string azureEnvironmentName = "")
        {
            IAccessToken accessToken = CreateOAuthToken();
            TokenCredential tokenCredential = new TokenCredential(GetTokenStrFromAccessToken(accessToken), GetTokenRenewer(accessToken), null, new TimeSpan(0, 1, 0));
            StorageCredentials credential = new StorageCredentials(tokenCredential);
            return GetStorageAccountWithAzureEnvironment(credential, storageAccountName, useHttps, azureEnvironmentName);
        }

        private RenewTokenFuncAsync GetTokenRenewer(IAccessToken accessToken)
        {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            RenewTokenFuncAsync renewer = async (Object state, CancellationToken cancellationToken) =>
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            {
                var tokenStr = GetTokenStrFromAccessToken(accessToken);
                return new NewTokenAndFrequency(tokenStr, new TimeSpan(0, 1, 0));
            };
            return renewer;
        }

        private IAzureEnvironment EnsureStorageOAuthAudienceSet(IAzureEnvironment environment)
        {
            if (environment != null)
            {
                if (!environment.IsPropertySet(StorageOAuthEndpointResourceKey))
                {
                    environment.SetProperty(StorageOAuthEndpointResourceKey, StorageOAuthEndpointResourceValue);
                }
            }

            return environment;
        }

        /// <summary>
        /// Create a OAuth Token
        /// </summary>
        /// <returns>the token</returns>
        private IAccessToken CreateOAuthToken()
        {
            if (DefaultContext == null || DefaultContext.Account == null)
            {
                throw new InvalidOperationException(Resources.ContextCannotBeNull);
            }

            IAccessToken accessToken = AzureSession.Instance.AuthenticationFactory.Authenticate(
               DefaultContext.Account,
               EnsureStorageOAuthAudienceSet(DefaultContext.Environment),
               DefaultContext.Tenant.Id,
               null,
               ShowDialog.Never,
               null,
               StorageOAuthEndpointResourceKey);
            return accessToken;
        }

        /// <summary>
        /// Get the token string from the accesstoken
        /// </summary>
        /// <param name="accessToken">the token</param>
        /// <returns>token string</returns>
        private string GetTokenStrFromAccessToken(IAccessToken accessToken)
        {
            var tokenStr = string.Empty;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                tokenStr = tokenValue;
            });
#if DEBUG
            WriteDebug(DateTime.Now.ToString() + ": token:" + tokenStr);
#endif
            return tokenStr;
        }

        /// <summary>
        /// Get storage account and use specific end point
        /// </summary>
        /// <param name="credential">Storage credential</param>
        /// <param name="storageAccountName">Storage account name, it's used for build end point</param>
        /// <param name="useHttps"></param>
        /// <param name="endPoint"></param>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountWithEndPoint(StorageCredentials credential,
            string storageAccountName, bool useHttps, string endPoint = "")
        {
            if (String.IsNullOrEmpty(storageAccountName))
            {
                throw new ArgumentException(String.Format(Resources.ObjectCannotBeNull, StorageNouns.StorageAccountName));
            }

            if (string.IsNullOrEmpty(endPoint))
            {
                return GetStorageAccountWithAzureEnvironment(credential, storageAccountName, useHttps);
            }

            string blobEndpoint = string.Empty;
            string tableEndpoint = string.Empty;
            string queueEndpoint = string.Empty;
            string fileEndpoint = string.Empty;
            string domain = endPoint.Trim();

            if (useHttps)
            {
                blobEndpoint = String.Format(Resources.HttpsBlobEndPointFormat, storageAccountName, domain);
                tableEndpoint = String.Format(Resources.HttpsTableEndPointFormat, storageAccountName, domain);
                queueEndpoint = String.Format(Resources.HttpsQueueEndPointFormat, storageAccountName, domain);
                fileEndpoint = String.Format(Resources.HttpsFileEndPointFormat, storageAccountName, domain);
            }
            else
            {
                blobEndpoint = String.Format(Resources.HttpBlobEndPointFormat, storageAccountName, domain);
                tableEndpoint = String.Format(Resources.HttpTableEndPointFormat, storageAccountName, domain);
                queueEndpoint = String.Format(Resources.HttpQueueEndPointFormat, storageAccountName, domain);
                fileEndpoint = String.Format(Resources.HttpFileEndPointFormat, storageAccountName, domain);
            }

            return new CloudStorageAccount(credential, new Uri(blobEndpoint), new Uri(queueEndpoint), new Uri(tableEndpoint), new Uri(fileEndpoint));
        }

        /// <summary>
        /// Get storage account and use specific azure environment
        /// </summary>
        /// <param name="credential">Storage credential</param>
        /// <param name="storageAccountName">Storage account name, it's used for build end point</param>
        /// <param name="useHttps">Use secure Http protocol</param>
        /// <param name="azureEnvironmentName">Environment name</param>
        /// <returns>A storage account</returns>
        internal CloudStorageAccount GetStorageAccountWithAzureEnvironment(StorageCredentials credential,
            string storageAccountName, bool useHttps, string azureEnvironmentName = "")
        {
            IAzureEnvironment azureEnvironment = null;
            var profile = SMProfile ?? RMProfile;
            if (null != profile)
            {
                if (profile.DefaultContext != null && profile.DefaultContext.Environment != null && string.IsNullOrEmpty(azureEnvironmentName))
                {
                    azureEnvironment = profile.DefaultContext.Environment;

                    if (null == azureEnvironment)
                    {
                        azureEnvironmentName = EnvironmentName.AzureCloud;
                    }
                }

                if (null == azureEnvironment)
                {
                    try
                    {
                        azureEnvironment = profile.Environments.FirstOrDefault((s) => string.Equals(s.Name, azureEnvironmentName, StringComparison.OrdinalIgnoreCase));
                        if (azureEnvironment == null)
                        {
                            azureEnvironment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
                        }
                    }
                    catch (ArgumentException e)
                    {
                        throw new ArgumentException(e.Message + " " + string.Format(CultureInfo.CurrentCulture, Resources.ValidEnvironmentName, EnvironmentName.AzureCloud, EnvironmentName.AzureChinaCloud));
                    }
                }

            }

            if (null != azureEnvironment)
            {
                try
                {
                    Uri blobEndPoint = azureEnvironment.GetStorageBlobEndpoint(storageAccountName, useHttps);
                    Uri queueEndPoint = azureEnvironment.GetStorageQueueEndpoint(storageAccountName, useHttps);
                    Uri tableEndPoint = azureEnvironment.GetStorageTableEndpoint(storageAccountName, useHttps);
                    Uri fileEndPoint = azureEnvironment.GetStorageFileEndpoint(storageAccountName, useHttps);

                    return new CloudStorageAccount(credential, blobEndPoint, queueEndPoint, tableEndPoint, fileEndPoint);
                }
                catch (ArgumentNullException)
                {
                    // the environment may not have value for StorageEndpointSuffix, in this case, we'll still use the default domain of "core.windows.net"
                }
            }

            return GetStorageAccountWithEndPoint(credential, storageAccountName, useHttps, Resources.DefaultDomain);
        }

        /// <summary>
        /// Get default end point domain
        /// </summary>
        /// <returns></returns>
        internal string GetDefaultEndPointDomain()
        {
            return Resources.DefaultStorageEndPointDomain;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            CloudStorageAccount account = null;
            bool useHttps = (StorageNouns.HTTPS.ToLower() == protocolType.ToLower());

            switch (ParameterSetName)
            {
                case AccountNameKeyParameterSet:
                    account = GetStorageAccountByNameAndKey(StorageAccountName, StorageAccountKey, useHttps, storageEndpoint);
                    break;
                case AccountNameKeyServiceEndpointParameterSet:
                    account = GetStorageAccountByNameAndKey(StorageAccountName, StorageAccountKey, this.BlobEndpoint, this.QueueEndpoint, this.FileEndpoint, this.TableEndpoint);
                    break;
                case AccountNameKeyEnvironmentParameterSet:
                    account = GetStorageAccountByNameAndKeyFromAzureEnvironment(StorageAccountName, StorageAccountKey,
                        useHttps, environmentName);
                    break;
                case SasTokenParameterSet:
                    account = GetStorageAccountBySasToken(StorageAccountName, SasToken, useHttps, storageEndpoint);
                    break;
                case SasTokenServiceEndpointParameterSet:
                    account = GetStorageAccountBySasToken(SasToken, this.BlobEndpoint, this.QueueEndpoint, this.FileEndpoint, this.TableEndpoint);
                    break;
                case SasTokenEnvironmentParameterSet:
                    account = GetStorageAccountBySasTokenFromAzureEnvironment(StorageAccountName, SasToken, useHttps, environmentName);
                    break;
                case ConnectionStringParameterSet:
                    account = GetStorageAccountByConnectionString(ConnectionString);
                    break;
                case LocalParameterSet:
                    account = GetLocalDevelopmentStorageAccount();
                    break;
                case AnonymousParameterSet:
                    account = GetAnonymousStorageAccount(StorageAccountName, useHttps, storageEndpoint);
                    break;
                case AnonymousServiceEndpointParameterSet:
                    account = GetAnonymousStorageAccount(this.BlobEndpoint, this.QueueEndpoint, this.FileEndpoint, this.TableEndpoint);
                    break;
                case AnonymousEnvironmentParameterSet:
                    account = GetAnonymousStorageAccountFromAzureEnvironment(StorageAccountName, useHttps, environmentName);
                    break;
                case OAuthParameterSet:
                    account = GetStorageAccountByOAuth(StorageAccountName, useHttps, storageEndpoint);
                    break;
                case OAuthServiceEndpointParameterSet:
                    account = GetStorageAccountByOAuth(this.BlobEndpoint, this.QueueEndpoint, this.FileEndpoint, this.TableEndpoint);
                    break;
                case OAuthEnvironmentParameterSet:
                    account = GetStorageAccountByOAuthFromAzureEnvironment(StorageAccountName, useHttps, environmentName);
                    break;
                default:
                    throw new ArgumentException(Resources.DefaultStorageCredentialsNotFound);
            }

            AzureStorageContext context = new AzureStorageContext(account, GetRealAccountName(StorageAccountName), DefaultContext, WriteDebug);

            WriteObject(context);
        }

        private static string GetRealAccountName(string inputAccountName)
        {
            if (inputAccountName != null)
            {
                // remove zone patition from the input account name, like input "myaccountname.z10", the real account name is "myaccountname"
                return inputAccountName.Split(new char[] { '.' })[0];
            }
            return null;
        }
    }
}
