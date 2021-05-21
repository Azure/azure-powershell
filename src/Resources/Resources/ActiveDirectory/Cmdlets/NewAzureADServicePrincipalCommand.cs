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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Web;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Creates a new service principal.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ADServicePrincipal", DefaultParameterSetName = "SimpleParameterSet", SupportsShouldProcess = true)]
    [OutputType(typeof(PSADServicePrincipal), typeof(PSADServicePrincipalWrapper))]
    public class NewAzureADServicePrincipalCommand : ActiveDirectoryBaseCmdlet
    {
        private const string SimpleParameterSet = "SimpleParameterSet";

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
        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, HelpMessage = "The application id for which service principal is created.")]
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
        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, HelpMessage = "The display name for the service principal is derived from the IdentifierUris of created application.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

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
        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet,
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
        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet,
            HelpMessage = "The end date till which password or key is valid. Default value is one year after the start date.")]
        public DateTime EndDate { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, HelpMessage = "The scope that the service principal has permissions on. If a value for Role is provided, but " +
            "no value is provided for Scope, then Scope will default to the current subscription.")]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, HelpMessage = "The role that the service principal has over the scope. If a value for Scope is provided, but " +
            "no value is provided for Role, then Role will default to the 'Contributor' role.")]
        [PSArgumentCompleter("Reader", "Contributor", "Owner")]
        public string Role { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, HelpMessage = "If set, will skip creating the default role assignment for the service principal.")]
        public SwitchParameter SkipAssignment { get; set; }

        private AuthorizationClient _policiesClient;

        public AuthorizationClient PoliciesClient
        {
            get
            {
                if (this._policiesClient == null)
                {
                    this._policiesClient = new AuthorizationClient(DefaultContext);
                }

                return this._policiesClient;
            }

            set { this._policiesClient = value; }
        }

        public NewAzureADServicePrincipalCommand()
        {
            DateTime currentTime = DateTime.UtcNow;
            StartDate = currentTime;
        }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                //safe gauard for login status, check if DefaultContext not existed, PSInvalidOperationException will be thrown
                var CheckDefaultContext = DefaultContext;

                if (this.ParameterSetName == SimpleParameterSet)
                {
                    CreateSimpleServicePrincipal();
                    return;
                }

                if (!this.IsParameterBound(c => c.EndDate))
                {
                    WriteVerbose(Resources.Properties.Resources.DefaultEndDateUsed);
                    EndDate = StartDate.AddYears(1);
                }

                if (this.IsParameterBound(c => c.ApplicationObject))
                {
                    ApplicationId = ApplicationObject.ApplicationId;
                    DisplayName = ApplicationObject.DisplayName;
                }

                if (ApplicationId == Guid.Empty)
                {


                    // Create an application and get the applicationId
                    CreatePSApplicationParameters appParameters = new CreatePSApplicationParameters();

                    if(this.IsParameterBound(c => c.DisplayName) && !string.IsNullOrEmpty(DisplayName))
                    {
                        string uri = "http://" + HttpUtility.UrlEncode(DisplayName.Trim());
                        appParameters.IdentifierUris = new string[] { };
                        appParameters.DisplayName = DisplayName;
                    }

                    if (this.IsParameterBound(c => c.PasswordCredential))
                    {
                        appParameters.PasswordCredentials = PasswordCredential;
                    }
                    else if (this.IsParameterBound(c => c.CertValue))
                    {
                        appParameters.KeyCredentials = new PSADKeyCredential[]
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
                        appParameters.KeyCredentials = KeyCredential;
                    }

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

                if (ShouldProcess(target: createParameters.ApplicationId.ToString(), action: string.Format("Adding a new service principal to be associated with an application having AppId '{0}'", createParameters.ApplicationId)))
                {
                    var servicePrincipal = ActiveDirectoryClient.CreateServicePrincipal(createParameters);
                    WriteObject(servicePrincipal);
                }
            });
        }

        private void CreateSimpleServicePrincipal()
        {
            var subscriptionId = DefaultContext.Subscription?.Id;
            if (!this.IsParameterBound(c => c.StartDate))
            {
                DateTime currentTime = DateTime.UtcNow;
                StartDate = currentTime;
                WriteVerbose("No start date provided - using the current time as default.");
            }

            if (!this.IsParameterBound(c => c.EndDate))
            {
                EndDate = StartDate.AddYears(1);
                WriteVerbose(Resources.Properties.Resources.DefaultEndDateUsed);
            }

            if (!this.IsParameterBound(c => c.DisplayName))
            {
                DisplayName = "azure-powershell-" + StartDate.ToString("MM-dd-yyyy-HH-mm-ss");
                WriteVerbose(string.Format("No display name provided - using the default display name of '{0}'", DisplayName));
            }

            bool printPassword = false;
            bool printUseExistingSecret = true;

            // Handle credentials
            var Password = Guid.NewGuid().ToString().ConvertToSecureString();

            // Create an application and get the applicationId
            if (!this.IsParameterBound(c => c.ApplicationId))
            {
                printUseExistingSecret = false;
                CreatePSApplicationParameters appParameters = new CreatePSApplicationParameters
                {
                    DisplayName = DisplayName,
                    HomePage = "http://" + HttpUtility.UrlEncode(DisplayName.Trim()),
                    PasswordCredentials = new PSADPasswordCredential[]
                    {
                        new PSADPasswordCredential()
                        {
                            StartDate = StartDate,
                            EndDate = EndDate,
                            KeyId = Guid.NewGuid(),
                            Password = SecureStringExtensions.ConvertToString(Password)
                        }
                    }
                };

                if (ShouldProcess(target: appParameters.DisplayName, action: string.Format("Adding a new application for with display name '{0}'", appParameters.DisplayName)))
                {
                    var application = ActiveDirectoryClient.CreateApplication(appParameters);
                    ApplicationId = application.ApplicationId;
                    WriteVerbose(string.Format("No application id provided - created new AD application with application id '{0}'", ApplicationId));
                    printPassword = true;
                }
            }

            CreatePSServicePrincipalParameters createParameters = new CreatePSServicePrincipalParameters
            {
                ApplicationId = ApplicationId,
                AccountEnabled = true,
            };

            var shouldProcessMessage = string.Format("Adding a new service principal to be associated with an application " +
                                                      "having AppId '{0}' with no permissions.", createParameters.ApplicationId);

            if (!SkipRoleAssignment())
            {
                if (!this.IsParameterBound(c => c.Scope))
                {
                    Scope = string.Format("/subscriptions/{0}", subscriptionId);
                    WriteVerbose(string.Format("No scope provided - using the default scope '{0}'", Scope));
                }

                AuthorizationClient.ValidateScope(Scope, true);

                if (!this.IsParameterBound(c => c.Role))
                {
                    Role = "Contributor";
                    WriteVerbose(string.Format("No role provided - using the default role '{0}'", Role));
                }

                shouldProcessMessage = string.Format("Adding a new service principal to be associated with an application " +
                                                      "having AppId '{0}' with '{1}' role over scope '{2}'.", createParameters.ApplicationId, this.Role, this.Scope);
            }

            if (ShouldProcess(target: createParameters.ApplicationId.ToString(), action: shouldProcessMessage))
            {
                PSADServicePrincipalWrapper servicePrincipal = new PSADServicePrincipalWrapper(ActiveDirectoryClient.CreateServicePrincipal(createParameters));
                if(printPassword)
                {
                    servicePrincipal.Secret = Password;
                }
                else if(printUseExistingSecret)
                {
                    WriteVerbose(String.Format(ProjectResources.ServicePrincipalCreatedWithCredentials, ApplicationId));
                }
                WriteObject(servicePrincipal);
                if (SkipRoleAssignment())
                {
                    WriteVerbose("Skipping role assignment for the service principal.");
                    return;
                }

                WriteWarning(string.Format("Assigning role '{0}' over scope '{1}' to the new service principal.", this.Role, this.Scope));
                FilterRoleAssignmentsOptions parameters = new FilterRoleAssignmentsOptions()
                {
                    Scope = this.Scope,
                    RoleDefinitionName = this.Role,
                    ADObjectFilter = new ADObjectFilterOptions
                    {
                        SPN = servicePrincipal.ApplicationId.ToString(),
                        Id = servicePrincipal.Id.ToString()
                    },
                    ResourceIdentifier = new ResourceIdentifier()
                    {
                        Subscription = subscriptionId
                    },
                    CanDelegate = false
                };

                for (var i = 0; i < 6; i++)
                {
                    try
                    {
                        TestMockSupport.Delay(5000);
                        PoliciesClient.CreateRoleAssignment(parameters);
                        var ra = PoliciesClient.FilterRoleAssignments(parameters, subscriptionId);
                        if (ra != null)
                        {
                            WriteVerbose(string.Format("Role assignment with role '{0}' and scope '{1}' successfully created for the created service principal.", this.Role, this.Scope));
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        // Do nothing
                    }
                }
            }
        }

        private bool SkipRoleAssignment()
        {
            return this.IsParameterBound(c => c.SkipAssignment) || (!this.IsParameterBound(c => c.Role) && !this.IsParameterBound(c => c.Scope) && !HasSubscription());
        }

        private bool HasSubscription()
        {
            return DefaultContext.Subscription?.Id != null;
        }
    }
}
