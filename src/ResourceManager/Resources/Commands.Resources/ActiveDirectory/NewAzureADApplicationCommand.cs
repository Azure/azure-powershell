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
    /// Creates a new AD application.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmADApplication", DefaultParameterSetName = ParameterSet.ApplicationWithoutCredential, SupportsShouldProcess = true), OutputType(typeof(PSADApplication))]
    public class NewAzureADApplicationCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithoutCredential,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordCredential,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyCredential,
            HelpMessage = "The display name for the application.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithoutCredential,
            HelpMessage = "The URIs that identify the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The URIs that identify the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordCredential,
            HelpMessage = "The URIs that identify the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The URIs that identify the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyCredential,
            HelpMessage = "The URIs that identify the application.")]
        [ValidateNotNullOrEmpty]
        public string[] IdentifierUris { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithoutCredential,
            HelpMessage = "The URL to the applicationâ€™s homepage.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The URL to the applicationâ€™s homepage.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordCredential,
            HelpMessage = "The URL to the applicationâ€™s homepage.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The URL to the applicationâ€™s homepage.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyCredential,
            HelpMessage = "The URL to the applicationâ€™s homepage.")]
        [ValidateNotNullOrEmpty]
        public string HomePage { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithoutCredential,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordCredential,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyCredential,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        [ValidateNotNullOrEmpty]
        public string[] ReplyUrls { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithoutCredential,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordCredential,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyCredential,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        public bool AvailableToOtherTenants { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordCredential,
            HelpMessage = "The collection of password credentials associated with the application.")]
        public PSADPasswordCredential[] PasswordCredentials { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyCredential,
            HelpMessage = "The collection of key credentials associated with the application.")]
        public PSADKeyCredential[] KeyCredentials { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The value for the password credential associated with the application that will be valid for one year by default.")]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The base64 encoded cert value for the key credentials associated with the application that will be valid for one year by default.")]
        [ValidateNotNullOrEmpty]
        public string CertValue { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The start date after which password or key would be valid. Default value is current time.")]
        public DateTime StartDate { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithPasswordPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationWithKeyPlain,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after current time.")]
        public DateTime EndDate { get; set; }

        public NewAzureADApplicationCommand()
        {
            DateTime currentTime = DateTime.UtcNow;
            StartDate = currentTime;
            EndDate = currentTime.AddYears(1);
        }

        public override void ExecuteCmdlet()
        {
            CreatePSApplicationParameters createParameters = new CreatePSApplicationParameters
            {
                DisplayName = DisplayName,
                HomePage = HomePage,
                IdentifierUris = IdentifierUris,
                ReplyUrls = ReplyUrls,
                AvailableToOtherTenants = AvailableToOtherTenants
            };

            switch (ParameterSetName)
            {
                case ParameterSet.ApplicationWithPasswordPlain:
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
                    createParameters.PasswordCredentials = PasswordCredentials;
                    break;

                case ParameterSet.ApplicationWithKeyPlain:
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
                    createParameters.KeyCredentials = KeyCredentials;
                    break;
            }

            ExecutionBlock(() =>
            {
                if (ShouldProcess(target: createParameters.DisplayName, action: string.Format("Adding a new application with display name '{0}'", createParameters.DisplayName)))
                {
                    WriteObject(ActiveDirectoryClient.CreateApplication(createParameters));
                }
            });
        }
    }
}