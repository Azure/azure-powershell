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

using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Creates a new AD servicePrincipal Credential.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ADSpCredential", DefaultParameterSetName = ParameterSet.SpObjectIdWithPassword, SupportsShouldProcess = true)]
    [OutputType(typeof(PSADCredential), typeof(PSADCredentialWrapper))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ADServicePrincipalCredential")]
    public class NewAzureADSpCredentialCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpObjectIdWithCertValue, HelpMessage = "The servicePrincipal object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpObjectIdWithPassword, HelpMessage = "The servicePrincipal object id.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServicePrincipalObjectId")]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithCertValue, HelpMessage = "The servicePrincipal name.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithPassword, HelpMessage = "The servicePrincipal name.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ServicePrincipalObjectWithCertValue, HelpMessage = "The service principal object.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ServicePrincipalObjectWithPassword, HelpMessage = "The service principal object.")]
        [ValidateNotNullOrEmpty]
        public PSADServicePrincipal ServicePrincipalObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpObjectIdWithCertValue,
            HelpMessage = "The base64 encoded value for the AsymmetricX509Cert associated with the servicePrincipal that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithCertValue,
            HelpMessage = "The base64 encoded value for the AsymmetricX509Cert associated with the servicePrincipal that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.ServicePrincipalObjectWithCertValue,
            HelpMessage = "The base64 encoded value for the AsymmetricX509Cert associated with the servicePrincipal that will be valid for one year by default.")]
        [ValidateNotNullOrEmpty]
        public string CertValue { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        public DateTime StartDate { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The end date till which password or key is valid. Default value is one year after the start date.")]
        public DateTime EndDate { get; set; }
    
        public Guid KeyId { get; set; } = default(Guid);

        public NewAzureADSpCredentialCommand()
        {
            DateTime currentTime = DateTime.UtcNow;
            StartDate = currentTime;
        }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.EndDate == null)
                {
                    WriteVerbose(Resources.Properties.Resources.DefaultEndDateUsed);
                    EndDate = StartDate.AddYears(1);
                }

                if (this.IsParameterBound(c => c.ServicePrincipalObject))
                {
                    ObjectId = ServicePrincipalObject.Id;
                }

                if (this.IsParameterBound(c => c.ServicePrincipalName))
                {
                    ObjectId = ActiveDirectoryClient.GetObjectIdFromSPN(ServicePrincipalName);
                }

                if (this.IsParameterBound(c => c.CertValue))
                {
                    // Create object for key credential
                    var keyCredential = new KeyCredential()
                    {
                        EndDate = EndDate,
                        StartDate = StartDate,
                        KeyId = KeyId == default(Guid) ? Guid.NewGuid().ToString() : KeyId.ToString(),
                        Value = CertValue,
                        Type = "AsymmetricX509Cert",
                        Usage = "Verify"
                    };

                    if (ShouldProcess(target: ObjectId, action: string.Format("Adding a new caertificate to service principal with objectId {0}", ObjectId)))
                    {
                        WriteObject(ActiveDirectoryClient.CreateSpKeyCredential(ObjectId, keyCredential));
                    }
                }
                else
                {
                    // If no credentials provided, set the password to a randomly generated GUID
                    var Password = Guid.NewGuid().ToString().ConvertToSecureString();

                    string decodedPassword = SecureStringExtensions.ConvertToString(Password);

                    var passwordCredential = new PasswordCredential()
                    {
                        EndDate = EndDate,
                        StartDate = StartDate,
                        KeyId = KeyId == default(Guid) ? Guid.NewGuid().ToString() : KeyId.ToString(),
                        Value = decodedPassword
                    };
                    if (ShouldProcess(target: ObjectId, action: string.Format("Adding a new password to service principal with objectId {0}", ObjectId)))
                    {
                        var spCred = new PSADCredentialWrapper(ActiveDirectoryClient.CreateSpPasswordCredential(ObjectId, passwordCredential));
                        spCred.Secret = Password;
                        WriteObject(spCred);
                    }
                }
            });
        }
    }
}
