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
using System.Collections;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    /// <summary>
    /// Creates new Microsoft Azure profile.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureProfile"), OutputType(typeof(AzureSMProfile))]
    public class NewAzureProfileCommand : AzureSMCmdlet
    {
        internal const string CertificateParameterSet = "Certificate";
        internal const string CredentialsParameterSet = "Credentials";
        internal const string ServicePrincipalParameterSet = "ServicePrincipal";
        internal const string AccessTokenParameterSet = "Token";
        internal const string FileParameterSet = "File";
        internal const string PropertyBagParameterSet = "PropertyBag";
        internal const string EmptyParameterSet = "Empty";

        internal const string SubscriptionIdKey = "SubscriptionId";
        internal const string CertificateKey = "Certificate";
        internal const string UsernameKey = "Username";
        internal const string PasswordKey = "Password";
        internal const string SPNKey = "ServicePrincipal";
        internal const string TenantKey = "Tenant";
        internal const string AccountIdKey = "AccountId";
        internal const string TokenKey = "Token";
        internal const string EnvironmentKey = "Environment";
        internal const string StorageAccountKey = "StorageAccount";

        [Parameter(Mandatory = false, ParameterSetName = CertificateParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = CredentialsParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = EmptyParameterSet)]
        public AzureEnvironment Environment { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = CertificateParameterSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = CredentialsParameterSet)]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = CertificateParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = CredentialsParameterSet)]
        public string StorageAccount { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        public X509Certificate2 Certificate { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = CredentialsParameterSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ServicePrincipalParameterSet)]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = false, Position = 2, ParameterSetName = CredentialsParameterSet)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ServicePrincipalParameterSet)]
        [Alias("TenantId")]
        public string Tenant { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ServicePrincipalParameterSet)]
        public SwitchParameter ServicePrincipal { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = AccessTokenParameterSet)]
        public string AccessToken { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AccessTokenParameterSet)]
        public string AccountId { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = FileParameterSet)]
        public string Path { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = PropertyBagParameterSet)]
        public Hashtable Properties { get; set; }

        // do not use the Profile parameter for this cmdlet
        private new AzureSMProfile Profile { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AzureSMProfile AzureSMProfile;
            AzureProfileSettings settings;
            if (ParameterSetName == PropertyBagParameterSet)
            {
                AzureSMProfile = new AzureSMProfile();
                var actualParameterSet = ParseHashTableParameters(Properties, out settings);
                InitializeAzureProfile(AzureSMProfile, actualParameterSet, settings);
            }
            else if (ParameterSetName == FileParameterSet)
            {
                if (string.IsNullOrEmpty(Path) || !File.Exists(Path))
                {
                    throw new ArgumentException(Resources.InvalidNewProfilePath);
                }

                AzureSMProfile = new AzureSMProfile(Path);
            }
            else
            {
                AzureSMProfile = new AzureSMProfile();
                settings = AzureProfileSettings.Create(this);
                InitializeAzureProfile(AzureSMProfile, ParameterSetName, settings);
            }

            WriteObject(AzureSMProfile);
        }

        protected override void InitializeProfile()
        {
            // do not initialize the current profile for this cmdlet
        }

        private void InitializeAzureProfile(AzureSMProfile profile, string parameterSet, AzureProfileSettings settings)
        {
            var savedCache = AzureSession.TokenCache;
            AzureSession.TokenCache = TokenCache.DefaultShared;
            try
            {

                var profileClient = new ProfileClient(profile);
                if (settings.Environment == null)
                {
                    settings.Environment = AzureEnvironment.PublicEnvironments["AzureCloud"];
                }
                switch (parameterSet)
                {
                    case CertificateParameterSet:
                        profileClient.InitializeProfile(settings.Environment, new Guid(settings.SubscriptionId),
                            settings.Certificate,
                            settings.StorageAccount);
                        break;
                    case CredentialsParameterSet:
                        var userAccount = new AzureAccount
                        {
                            Id = settings.Credential.UserName,
                            Type = AzureAccount.AccountType.User
                        };
                        profileClient.InitializeProfile(settings.Environment, new Guid(settings.SubscriptionId),
                            userAccount,
                            settings.Credential.Password, settings.StorageAccount);
                        break;
                    case AccessTokenParameterSet:
                        profileClient.InitializeProfile(settings.Environment, new Guid(settings.SubscriptionId),
                            settings.AccessToken,
                            settings.AccountId, settings.StorageAccount);
                        break;
                    case ServicePrincipalParameterSet:
                        var servicePrincipalAccount = new AzureAccount
                        {
                            Id = settings.Credential.UserName,
                            Type = AzureAccount.AccountType.ServicePrincipal,
                        };
                        servicePrincipalAccount.SetOrAppendProperty(AzureAccount.Property.Tenants, settings.Tenant);
                        profileClient.InitializeProfile(settings.Environment, new Guid(settings.SubscriptionId),
                            servicePrincipalAccount,
                            settings.Credential.Password, settings.StorageAccount);
                        break;
                    case EmptyParameterSet:
                        if (!profile.Environments.ContainsKey(settings.Environment.Name))
                        {
                            profile.Environments.Add(settings.Environment.Name, settings.Environment);
                        }
                        break;
                }
            }
            finally
            {
                AzureSession.TokenCache = savedCache;
            }
        }

        private string ParseHashTableParameters(Hashtable propertyBag, out AzureProfileSettings settings)
        {
            settings = new AzureProfileSettings();
            string parametSetName = null;
            if (!propertyBag.ContainsKey(SubscriptionIdKey))
            {
                throw new ArgumentException(Resources.MissingSubscriptionInProfileProperties);
            }

            settings.SubscriptionId = (string)propertyBag[SubscriptionIdKey];
            if (propertyBag.ContainsKey(StorageAccountKey))
            {
                settings.StorageAccount = (string)propertyBag[StorageAccountKey];
            }

            if (propertyBag.ContainsKey(EnvironmentKey))
            {
                var environmentValue = (string)propertyBag[EnvironmentKey];
                if (AzureEnvironment.PublicEnvironments.ContainsKey(environmentValue))
                {
                    settings.Environment = AzureEnvironment.PublicEnvironments[environmentValue];
                }
            }

            if (propertyBag.ContainsKey(CertificateKey))
            {
                if (!propertyBag[CertificateKey].GetType().IsAssignableFrom(typeof(X509Certificate2)))
                {
                    throw new ArgumentException(Resources.MissingCertificateInProfileProperties);
                }

                settings.Certificate = (X509Certificate2)propertyBag[CertificateKey];
                parametSetName = CertificateParameterSet;
            }
            else if (propertyBag.ContainsKey(UsernameKey))
            {
                settings.Credential = CreatePsCredential((string)propertyBag[UsernameKey], propertyBag);
                if (propertyBag.ContainsKey(TenantKey))
                {
                    settings.Tenant = (string)propertyBag[TenantKey];
                }
                parametSetName = CredentialsParameterSet;
            }
            else if (propertyBag.ContainsKey(SPNKey) && propertyBag.ContainsKey(TenantKey))
            {
                settings.Credential = CreatePsCredential((string)propertyBag[SPNKey], propertyBag);
                if (propertyBag.ContainsKey(TenantKey))
                {
                    settings.Tenant = (string)propertyBag[TenantKey];
                }
                parametSetName = ServicePrincipalParameterSet;
            }
            else if (propertyBag.ContainsKey(AccountIdKey) && propertyBag.ContainsKey(TokenKey))
            {
                settings.AccountId = (string)propertyBag[AccountIdKey];
                settings.AccessToken = (string)propertyBag[TokenKey];
                parametSetName = AccessTokenParameterSet;
            }
            else
            {
                throw new ArgumentException(Resources.InvalidProfileProperties);
            }

            return parametSetName;
        }


        private PSCredential CreatePsCredential(string username, Hashtable propertyBag)
        {
            if (!propertyBag.ContainsKey(PasswordKey))
            {
                throw new ArgumentException(Resources.MissingPasswordInProfileProperties);
            }

            var password = new SecureString();
            foreach (var passwordchar in (string)propertyBag[PasswordKey])
            {
                password.AppendChar(passwordchar);
            }

            return new PSCredential(username, password);
        }
    }
}
