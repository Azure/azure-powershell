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

using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Common.Extensions.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

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
        public string Certificate { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = CredentialsParameterSet)]
        public PSCredential Credential { get; set; }
        
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = CertificateParameterSet)]
        public string Tenant { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = FileParameterSet)]
        public string Path { get; set; }
        
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
        }
    }
}
