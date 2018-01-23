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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Profile.Common;
using System.Linq;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to log into an environment and download the subscriptions
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmAccount", DefaultParameterSetName = ContextNameParameterSet, SupportsShouldProcess=true)]
    [Alias("Logout-AzAccount", "Logout-AzureRmAccount")]
    [OutputType(typeof(PSAzureRmAccount))]
    public class RemoveAzureRMAccountCommand : AzureContextModificationCmdlet
    {
        private const string UserIdParameterSet = "UserId";
        private const string ServicePrincipalParameterSet = "ServicePrincipal";
        private const string InputObjectParametrSet= "AccountObject";
        private const string ContextParameterSet = "ContextObject";
        private const string ContextNameParameterSet = "ContextName";


        
        [Parameter(ParameterSetName = UserIdParameterSet, 
                    Mandatory = true, HelpMessage = "User name of the form user@contoso.org", Position = 0)]
        [ValidateNotNullOrEmpty]
        [Alias("Id", "UserId")]
        public  string Username { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSet,
                   Mandatory = true, HelpMessage = "ServicePrincipal id (globally unique id)")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN", "ServicePrincipal")]
        public string ApplicationId { get; set; }

        [Parameter(ParameterSetName = ServicePrincipalParameterSet,
                  Mandatory = true, HelpMessage = "Tenant id (globally unique id)")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        [Parameter(ParameterSetName = InputObjectParametrSet, 
                    Mandatory = true, ValueFromPipeline=true, Position = 0, HelpMessage = "Account")]
        [ValidateNotNull]
        public PSAzureRmAccount InputObject { get; set; }
        
        [Parameter(ParameterSetName = ContextParameterSet, 
                    Mandatory = true, HelpMessage = "Context", ValueFromPipeline =true, Position = 0)]
        [ValidateNotNull]
        public PSAzureContext AzureContext { get; set; }

        
        [Parameter(ParameterSetName = ContextNameParameterSet, 
                    Mandatory = false, HelpMessage = "Name of the context to log out of")]
        [ValidateNotNullOrEmpty]
        public string ContextName { get; set; }

        public override void ExecuteCmdlet()
        {
            IAzureAccount azureAccount = null;
            switch(ParameterSetName)
            {
                case UserIdParameterSet:
                    azureAccount = new AzureAccount { Id = Username, Type = AzureAccount.AccountType.User };
                    break;
                case ServicePrincipalParameterSet:
                    azureAccount = new AzureAccount { Id = ApplicationId, Type = AzureAccount.AccountType.ServicePrincipal };
                    azureAccount.SetTenants(TenantId);
                    break;
                case InputObjectParametrSet:
                    azureAccount = InputObject;
                    break;
                case ContextParameterSet:
                    azureAccount = AzureContext.Account;
                    break;
                case ContextNameParameterSet:
                    if (MyInvocation.BoundParameters.ContainsKey(nameof(ContextName)))
                    {
                        var profile = DefaultProfile as AzureRmProfile;
                        azureAccount = profile.Contexts[ContextName].Account;
                    }
                    else
                    {
                        azureAccount = DefaultContext?.Account;
                    }
                    break;
            }

            if (azureAccount == null || string.IsNullOrWhiteSpace(azureAccount.Id))
            {
                WriteExceptionError(new ArgumentException("Provide a valid account or context"));
            }
            else
            {

                if (ShouldProcess(string.Format("Log out principal '{0}'", azureAccount.Id), "log out"))
                {
                    if (GetContextModificationScope() == ContextModificationScope.CurrentUser)
                    {
                        AzureSession.Instance.AuthenticationFactory.RemoveUser(azureAccount, AzureSession.Instance.TokenCache);
                    }

                    if (AzureRmProfileProvider.Instance.Profile != null)
                    {

                        ModifyContext((localProfile, profileClient) =>
                       {
                           var matchingContexts = localProfile.Contexts?.Values?.Where((c) => c != null && c.Account != null && string.Equals(c.Account.Id, azureAccount.Id, StringComparison.CurrentCultureIgnoreCase));
                           foreach (var context in matchingContexts)
                           {
                               profileClient.TryRemoveContext(context);
                           }
                       });
                    }

                    WriteObject(new PSAzureRmAccount(azureAccount));
                }
            }
        }
    }
}
