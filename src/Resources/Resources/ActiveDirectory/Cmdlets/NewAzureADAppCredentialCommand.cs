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

using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Security;
using System.Text;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Creates a new AD application Credential.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ADAppCredential", DefaultParameterSetName = ParameterSet.ApplicationObjectIdWithPassword, SupportsShouldProcess = true), OutputType(typeof(PSADCredential))]
    public class NewAzureADAppCredentialCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithCertValue, HelpMessage = "The application object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithPassword, HelpMessage = "The application object id.")]
        [ValidateNotNullOrEmpty]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithCertValue, HelpMessage = "The application id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithPassword, HelpMessage = "The application id.")]
        [ValidateNotNullOrEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPassword, HelpMessage = "The display name of the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithCertValue, HelpMessage = "The display name of the application.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObjectWithCertValue, HelpMessage = "The application object.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObjectWithPassword, HelpMessage = "The application object.")]
        [ValidateNotNullOrEmpty]
        public PSADApplication ApplicationObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithPassword,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithPassword,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.ApplicationObjectWithPassword,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DisplayNameWithPassword,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [ValidateNotNullOrEmpty]
        public SecureString Password { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithCertValue,
            HelpMessage = "The base64 encoded value for the AsymmetricX509Cert associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithCertValue,
            HelpMessage = "The base64 encoded value for the AsymmetricX509Cert associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.ApplicationObjectWithCertValue,
            HelpMessage = "The base64 encoded value for the AsymmetricX509Cert associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DisplayNameWithCertValue,
            HelpMessage = "The base64 encoded value for the AsymmetricX509Cert associated with the application that will be valid for one year by default.")]
        [ValidateNotNullOrEmpty]
        public string CertValue { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        public DateTime StartDate { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The end date till which password or key is valid. Default value is one year after the start date.")]
        public DateTime EndDate { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Custom Key Identifier")]
        public String CustomKeyIdentifier { get; set; }

        public Guid KeyId { get; set; } = default(Guid);

        public NewAzureADAppCredentialCommand()
        {
            DateTime currentTime = DateTime.UtcNow;
            StartDate = currentTime;
        }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                
                if (!this.IsParameterBound(c => c.EndDate))
                {
                    WriteVerbose(Resources.Properties.Resources.DefaultEndDateUsed);
                    EndDate = StartDate.AddYears(1);
                }

                if (this.IsParameterBound(c => c.ApplicationObject))
                {
                    ObjectId = ApplicationObject.ObjectId;
                }
                else if (this.IsParameterBound(c => c.ApplicationId))
                {
                    ObjectId = ActiveDirectoryClient.GetAppObjectIdFromApplicationId(ApplicationId);
                }
                else if (this.IsParameterBound(c => c.DisplayName))
                {
                    ObjectId = ActiveDirectoryClient.GetAppObjectIdFromDisplayName(DisplayName);
                }

                if (Password != null && Password.Length > 0)
                {
                    string decodedPassword = SecureStringExtensions.ConvertToString(Password);
                    // Create object for password credential
                    var passwordCredential = new PasswordCredential()
                    {
                        EndDate = EndDate,
                        StartDate = StartDate,
                        KeyId = KeyId == default(Guid) ? Guid.NewGuid().ToString() : KeyId.ToString(),
                        Value = decodedPassword
                    };
                    if(!String.IsNullOrEmpty(CustomKeyIdentifier))
                    {
                        passwordCredential.CustomKeyIdentifier = Encoding.UTF8.GetBytes(CustomKeyIdentifier);
                    }
                    if (ShouldProcess(target: ObjectId, action: string.Format("Adding a new password to application with objectId {0}", ObjectId)))
                    {
                        WriteObject(ActiveDirectoryClient.CreateAppPasswordCredential(ObjectId, passwordCredential));
                    }
                }
                else if (CertValue != null)
                {
                    // Create object for key credential
                    var keyCredential = new KeyCredential()
                    {
                        EndDate = EndDate,
                        StartDate = StartDate,
                        KeyId = KeyId == default(Guid) ? Guid.NewGuid().ToString() : KeyId.ToString(),
                        Value = CertValue,
                        Type = "AsymmetricX509Cert",
                        Usage = "Verify",
                        CustomKeyIdentifier = CustomKeyIdentifier
                    };
                    if (ShouldProcess(target: ObjectId, action: string.Format("Adding a new certificate to application with objectId {0}", ObjectId)))
                    {
                        WriteObject(ActiveDirectoryClient.CreateAppKeyCredential(ObjectId, keyCredential));
                    }
                }
                else
                {
                    throw new InvalidOperationException("No valid keyCredential or passwordCredential to update!!");
                }
            });
        }
    }
}
