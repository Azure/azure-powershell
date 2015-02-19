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
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    /// <summary>
    /// Creates new Microsoft Azure profile.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureProfile"), OutputType(typeof(AzureProfile))]
    public class NewAzureProfileCommand : AzurePSCmdlet
    {
        private const string CertificateParameterSet = "Certificate";
        private const string CredentialsParameterSet = "Credentials";
        private const string ServicePrincipalParameterSet = "ServicePrincipal";
        private const string AccessTokenParameterSet = "Token";
        private const string FileParameterSet = "File";
        private const string PropertyBagParameterSet = "PropertyBag";

        private const string SubscriptionIdKey = "SubscriptionId";
        private const string CertificateKey = "Certificate";
        private const string UsernameKey = "Username";
        private const string PasswordKey = "Password";
        private const string SPNKey = "ServicePrincipal";
        private const string TenantKey = "Tenant";
        private const string AccountIdKey = "AccountId";
        private const string TokenKey = "Token";
        private const string EnvironmentKey = "Environment";
        private const string StorageAccountKey = "StorageAccount";


        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        public AzureEnvironment Environment { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ServicePrincipalParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = AccessTokenParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        public string StorageAccount { get; set; }
        
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        public X509Certificate2 Certificate { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ServicePrincipalParameterSet)]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ServicePrincipalParameterSet)]
        public string Tenant { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ServicePrincipalParameterSet)]
        public SwitchParameter ServicePrincipal { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = AccessTokenParameterSet)]
        public string AccessToken { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = AccessTokenParameterSet)]
        public string AccountId { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = FileParameterSet)]
        public string Path { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName=PropertyBagParameterSet)]
        public Hashtable Properties { get; set; }
        
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AzureProfile azureProfile = new AzureProfile();
            AzureProfileSettings settings;
            if (ParameterSetName == PropertyBagParameterSet)
            {
                var actualParameterSet = ParseHashTableParameters(Properties, out settings);
                InitializeAzureProfile(azureProfile, actualParameterSet, settings);
            }
            else if (ParameterSetName == FileParameterSet)
            {
                
            }
            else
            {
                settings = AzureProfileSettings.Create(this);
                InitializeAzureProfile(azureProfile, ParameterSetName, settings);
            }

            WriteObject(azureProfile);
        }

        private void InitializeAzureProfile(AzureProfile profile, string parameterSet, AzureProfileSettings settings)
        {
            var profileClient = new ProfileClient(profile);
            if (settings.Environment == null)
            {
                settings.Environment = AzureEnvironment.PublicEnvironments["AzureCloud"];
            }
            switch (parameterSet)
            {
                case CertificateParameterSet:
                    profileClient.InitializeProfile(settings.Environment, new Guid(settings.SubscriptionId), settings.Certificate, 
                        settings.StorageAccount);
                    break;
                case CredentialsParameterSet:
                    var userAccount = new AzureAccount
                    {
                        Id = settings.Credential.UserName,
                        Type = AzureAccount.AccountType.User
                    };
                    profileClient.InitializeProfile(settings.Environment, new Guid(settings.SubscriptionId), userAccount, 
                        settings.Credential.Password, settings.StorageAccount);
                    break;
                case AccessTokenParameterSet:
                    profileClient.InitializeProfile(settings.Environment, new Guid(settings.SubscriptionId), settings.AccessToken, 
                        settings.AccountId, settings.StorageAccount);
                    break;
                case ServicePrincipalParameterSet:
                    var servicePrincipalAccount = new AzureAccount
                    {
                        Id = settings.Credential.UserName,
                        Type = AzureAccount.AccountType.ServicePrincipal
                    };
                    profileClient.InitializeProfile(settings.Environment, new Guid(settings.SubscriptionId), servicePrincipalAccount,
                        settings.Credential.Password, settings.StorageAccount);
                    break;
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

            if (propertyBag.ContainsKey(StorageAccountKey))
            {
                settings.StorageAccount = (string) propertyBag[StorageAccountKey];
            }

            if (propertyBag.ContainsKey(EnvironmentKey))
            {
                var environmentValue = (string) propertyBag[EnvironmentKey];
                if (AzureEnvironment.PublicEnvironments.ContainsKey(environmentValue))
                {
                    settings.Environment = AzureEnvironment.PublicEnvironments[environmentValue];
                }
            }

            if (propertyBag.ContainsKey(CertificateKey))
            {
                if (!propertyBag[CertificateKey].GetType().IsAssignableFrom(typeof (X509Certificate2)))
                {
                    throw new ArgumentException(Resources.MissingCertificateInProfileProperties);
                }

                settings.Certificate = (X509Certificate2) propertyBag[CertificateKey];
                parametSetName = CertificateParameterSet;
            }
            else if (propertyBag.ContainsKey(UsernameKey))
            {
                settings.Credential = CreatePsCredential((string) propertyBag[UsernameKey], propertyBag);
                if (propertyBag.ContainsKey(TenantKey))
                {
                    settings.Tenant = (string) propertyBag[TenantKey];
                }
                parametSetName = CredentialsParameterSet;
            }
            else if (propertyBag.ContainsKey(SPNKey) && propertyBag.ContainsKey(TenantKey))
            {
                settings.Credential = CreatePsCredential((string) propertyBag[SPNKey], propertyBag);
                if (propertyBag.ContainsKey(TenantKey))
                {
                    settings.Tenant = (string) propertyBag[TenantKey];
                }
                parametSetName = ServicePrincipalParameterSet;
            }
            else if (propertyBag.ContainsKey(AccountIdKey) && propertyBag.ContainsKey(TokenKey))
            {
                settings.AccountId = (string) propertyBag[AccountIdKey];
                settings.AccessToken = (string) propertyBag[TokenKey];
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
                foreach (var passwordchar in (string) propertyBag[PasswordKey])
                {
                    password.AppendChar(passwordchar);
                }

                return new PSCredential((string) propertyBag[UsernameKey], password);
        }
    }
}
