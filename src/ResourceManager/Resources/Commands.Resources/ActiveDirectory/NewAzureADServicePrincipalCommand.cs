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

using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Creates a new service principal.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmADServicePrincipal", DefaultParameterSetName = ParameterSet.ApplicationWithoutCredential, SupportsShouldProcess = true), OutputType(typeof(PSADServicePrincipal))]
    public class NewAzureADServicePrincipalCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithoutCredential,
            HelpMessage = "The application id for which service principal is created.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The application id for which service principal is created.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordCredential,
            HelpMessage = "The application id for which service principal is created.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The application id for which service principal is created.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyCredential,
            HelpMessage = "The application id for which service principal is created.")]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithoutCredential,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPasswordPlain,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPasswordCredential,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyPlain,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyCredential,
            HelpMessage = "The display name for the application.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObjectWithoutCredential,
            HelpMessage = "The object representing the application for which the service principal is created.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObjectWithPasswordPlain,
            HelpMessage = "The object representing the application for which the service principal is created.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObjectWithPasswordCredential,
            HelpMessage = "The object representing the application for which the service principal is created.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObjectWithKeyPlain,
            HelpMessage = "The object representing the application for which the service principal is created.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObjectWithKeyCredential,
            HelpMessage = "The object representing the application for which the service principal is created.")]
        public PSADApplication ApplicationObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordCredential,
            HelpMessage = "The collection of password credentials associated with the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPasswordCredential,
            HelpMessage = "The collection of password credentials associated with the application.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.ApplicationObjectWithPasswordCredential,
            HelpMessage = "The collection of password credentials associated with the application.")]
        [Alias("PasswordCredentials")]
        public PSADPasswordCredential[] PasswordCredential { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyCredential,
            HelpMessage = "The collection of key credentials associated with the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyCredential,
            HelpMessage = "The collection of key credentials associated with the application.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.ApplicationObjectWithKeyCredential,
            HelpMessage = "The collection of key credentials associated with the application.")]
        [Alias("KeyCredentials")]
        public PSADKeyCredential[] KeyCredential { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPasswordPlain,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.ApplicationObjectWithPasswordPlain,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [ValidateNotNullOrEmpty]
        public SecureString Password { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The base64 encoded cert value for the key credentials associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyPlain,
            HelpMessage = "The base64 encoded cert value for the key credentials associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.ApplicationObjectWithKeyPlain,
            HelpMessage = "The base64 encoded cert value for the key credentials associated with the application that will be valid for one year by default.")]
        [ValidateNotNullOrEmpty]
        public string CertValue { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPasswordPlain,
            HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyPlain,
            HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ApplicationObjectWithPasswordPlain,
            HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ApplicationObjectWithKeyPlain,
            HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        public DateTime StartDate { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPasswordPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ApplicationObjectWithPasswordPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ApplicationObjectWithKeyPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        public DateTime EndDate { get; set; }

        public NewAzureADServicePrincipalCommand()
        {
            DateTime currentTime = DateTime.UtcNow;
            StartDate = currentTime;
            EndDate = currentTime.AddYears(1);
        }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.ApplicationObject))
                {
                    ApplicationId = ApplicationObject.ApplicationId;
                    DisplayName = ApplicationObject.DisplayName;
                }

                if (ApplicationId == Guid.Empty)
                {
                    string uri = "http://" + DisplayName.Trim().Replace(' ', '_');

                    // Create an application and get the applicationId
                    CreatePSApplicationParameters appParameters = new CreatePSApplicationParameters
                    {
                        DisplayName = DisplayName,
                        IdentifierUris = new[] { uri },
                        HomePage = uri
                    };

                    if (ShouldProcess(target: appParameters.DisplayName, action: string.Format("Adding a new application for with display name '{0}'", appParameters.DisplayName)))
                    {
                        var application = ActiveDirectoryClient.CreateApplication(appParameters);
                        ApplicationId = application.ApplicationId;
                    }
                }

                CreatePSServicePrincipalParameters createParameters = new CreatePSServicePrincipalParameters
                {
                    ApplicationId = ApplicationId,
                    AccountEnabled = true
                };

                if (this.IsParameterBound(c => c.Password))
                {
                    string decodedPassword = SecureStringExtensions.ConvertToString(Password);
                    createParameters.PasswordCredentials = new PSADPasswordCredential[]
                        {
                            new PSADPasswordCredential
                            {
                                StartDate = StartDate,
                                EndDate = EndDate,
                                KeyId = Guid.NewGuid(),
                                Password = decodedPassword
                            }
                        };
                }
                else if (this.IsParameterBound(c => c.PasswordCredential))
                {
                    createParameters.PasswordCredentials = PasswordCredential;
                }
                else if (this.IsParameterBound(c => c.CertValue))
                {
                    createParameters.KeyCredentials = new PSADKeyCredential[]
                        {
                            new PSADKeyCredential
                            {
                                StartDate = StartDate,
                                EndDate = EndDate,
                                KeyId = Guid.NewGuid(),
                                CertValue = CertValue
                            }
                        };
                }
                else if (this.IsParameterBound(c => c.KeyCredential))
                {
                    createParameters.KeyCredentials = KeyCredential;
                }

                if (ShouldProcess(target: createParameters.ApplicationId.ToString(), action: string.Format("Adding a new service principal to be associated with an application having AppId '{0}'", createParameters.ApplicationId)))
                {
                    WriteObject(ActiveDirectoryClient.CreateServicePrincipal(createParameters));
                }
            });
        }
    }
}