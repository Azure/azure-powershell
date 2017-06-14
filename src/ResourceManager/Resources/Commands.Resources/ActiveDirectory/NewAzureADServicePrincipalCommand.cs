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

using Microsoft.Azure.Commands.ActiveDirectory.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using System;
using System.Management.Automation;

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

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordCredential,
            HelpMessage = "The collection of password credentials associated with the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPasswordCredential,
            HelpMessage = "The collection of password credentials associated with the application.")]
        public PSADPasswordCredential[] PasswordCredentials { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyCredential,
            HelpMessage = "The collection of key credentials associated with the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyCredential,
            HelpMessage = "The collection of key credentials associated with the application.")]
        public PSADKeyCredential[] KeyCredentials { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPasswordPlain,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The base64 encoded cert value for the key credentials associated with the application that will be valid for one year by default.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyPlain,
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
        public DateTime StartDate { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithPasswordPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyPlain,
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

                switch (ParameterSetName)
                {
                    case ParameterSet.ApplicationWithPasswordPlain:
                    case ParameterSet.DisplayNameWithPasswordPlain:
                        createParameters.PasswordCredentials = new PSADPasswordCredential[]
                        {
                        new PSADPasswordCredential
                        {
                            StartDate = StartDate,
                            EndDate = EndDate,
                            KeyId = Guid.NewGuid(),
                            Password = Password
                        }
                        };
                        break;

                    case ParameterSet.ApplicationWithPasswordCredential:
                    case ParameterSet.DisplayNameWithPasswordCredential:
                        createParameters.PasswordCredentials = PasswordCredentials;
                        break;

                    case ParameterSet.ApplicationWithKeyPlain:
                    case ParameterSet.DisplayNameWithKeyPlain:
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
                        break;

                    case ParameterSet.ApplicationWithKeyCredential:
                    case ParameterSet.DisplayNameWithKeyCredential:
                        createParameters.KeyCredentials = KeyCredentials;
                        break;
                }

                if (ShouldProcess(target: createParameters.ApplicationId.ToString(), action: string.Format("Adding a new service principal to be associated with an application having AppId '{0}'", createParameters.ApplicationId)))
                {
                    WriteObject(ActiveDirectoryClient.CreateServicePrincipal(createParameters));
                }
            });
        }
    }
}