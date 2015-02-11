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
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
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
        private const string AccessTokenParameterSet = "Token";
        private const string FileParameterSet = "File";

        [Parameter(Mandatory = false, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        [Parameter(Mandatory = false, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        public AzureEnvironment Environment { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        public string StorageAccount { get; set; }
        
        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        public X509Certificate2 Certificate { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = true, Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        public string Tenant { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = AccessTokenParameterSet)]
        public string AccessToken { get; set; }

        [Parameter(Mandatory = true, Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = AccessTokenParameterSet)]
        public string AccountId { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = FileParameterSet)]
        public string Path { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
        
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AzureProfile azureProfile = new AzureProfile();
            ProfileClient profileClient = new ProfileClient(azureProfile);
            if (Environment == null)
            {
                Environment = AzureEnvironment.PublicEnvironments["AzureCloud"];
            }

            switch (ParameterSetName)
            {
                case CertificateParameterSet:
                    profileClient.InitializeProfile(Environment, new Guid(SubscriptionId), Certificate, 
                        StorageAccount);
                    break;
                case CredentialsParameterSet:
                    AzureAccount userAccount = new AzureAccount
                    {
                        Id = Credential.UserName
                    };
                    profileClient.InitializeProfile(Environment, new Guid(SubscriptionId), userAccount, 
                        Credential.Password, StorageAccount);
                    break;
                case AccessTokenParameterSet:
                    AzureAccount tokenAccount = new AzureAccount
                    {
                        Id = AccountId,
                        Type = AzureAccount.AccountType.User
                    };
                    profileClient.InitializeProfile(Environment, new Guid(SubscriptionId), tokenAccount, 
                        Credential.Password, StorageAccount);
                    break;
            }

            if (PassThru)
            {
                WriteObject(azureProfile);
            }
        }
    }
}
