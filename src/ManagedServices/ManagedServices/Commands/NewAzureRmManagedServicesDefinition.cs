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

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands
{
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.ManagedServices.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Management.Automation;

    [Cmdlet(
        VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "ManagedServicesDefinition",
        DefaultParameterSetName = DefaultParameterSet,
        SupportsShouldProcess = true), OutputType(typeof(PSRegistrationDefinition))]
    public class NewAzureRmManagedServicesDefinition : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByPlanParameterSet = "ByPlan";
        protected const string ByAuthorizationsParameterSet = "ByAuthorizations";

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The unique name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = false, HelpMessage = "The unique name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByAuthorizationsParameterSet, Mandatory = false, HelpMessage = "The unique name of the Registration Definition.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The display name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The display name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByAuthorizationsParameterSet, Mandatory = true, HelpMessage = "The display name of the Registration Definition.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Tenant Identifier.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Tenant Identifier.")]
        [Parameter(ParameterSetName = ByAuthorizationsParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Tenant Identifier.")]
        [ValidateNotNullOrEmpty]
        public string ManagedByTenantId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        [Parameter(ParameterSetName = ByAuthorizationsParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Principal Identifier.")]
        [ValidateNotNullOrEmpty]
        public string PrincipalId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The role definition identifier to grant permissions to principal identifier.")]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The authorization mapping list with principalId - roleDefinitionId.")]
        [Parameter(ParameterSetName = ByAuthorizationsParameterSet, Mandatory = true, HelpMessage = "The authorization mapping list with principalId - roleDefinitionId.")]
        [ValidateNotNull]
        public Authorization[] Authorizations { get; set; }

        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The name of the plan.")]
        [ValidateNotNullOrEmpty]
        public string PlanName { get; set; }

        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The name of the Publisher.")]
        [ValidateNotNullOrEmpty]
        public string PlanPublisher { get; set; }

        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The name of the Product.")]
        [ValidateNotNullOrEmpty]
        public string PlanProduct { get; set; }

        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The version number of the plan.")]
        [ValidateNotNullOrEmpty]
        public string PlanVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            var scope = this.GetDefaultScope();
            var definitionId = Guid.NewGuid().ToString();
            var managedByTenantId = string.Empty;

            if (this.IsParameterBound(x => x.Name))
            {
                if (!this.Name.IsGuid())
                {
                    throw new ApplicationException("Name must be a valid GUID.");
                }

                definitionId = (new Guid(this.Name)).ToString();
            }

            if (!this.ManagedByTenantId.IsGuid())
            {
                throw new ApplicationException("ManagedByTenantId must be a valid GUID.");
            }
            else
            {
                managedByTenantId = (new Guid(this.ManagedByTenantId)).ToString();
            }

            if (this.IsParameterBound(x => x.Authorizations) &&
                (this.IsParameterBound(x => x.PrincipalId) || this.IsParameterBound(x => x.RoleDefinitionId)))
            {
                throw new ApplicationException("Authorizations are supported when RoleDefinitionId and PrincipalId are null.");
            }

            if (!this.IsParameterBound(x => x.Authorizations) &&
                (!this.IsParameterBound(x => x.PrincipalId) || !this.IsParameterBound(x => x.RoleDefinitionId)))
            {
                throw new ApplicationException("Please provide RoleDefinitionId and PrincipalId parameters together or Authorizations parameter.");
            }

            if (this.Authorizations == null &&
                this.IsParameterBound(x => x.PrincipalId) &&
                this.IsParameterBound(x => x.RoleDefinitionId))
            {
                this.Authorizations = new Authorization[]
                {
                    new Authorization
                    {
                        RoleDefinitionId = this.RoleDefinitionId,
                        PrincipalId = this.PrincipalId
                    }
                };
            }

            Plan plan = null;
            if (this.IsParameterBound(x => x.PlanName) &&
                this.IsParameterBound(x => x.PlanPublisher) &&
                this.IsParameterBound(x => x.PlanProduct) &&
                this.IsParameterBound(x => x.PlanVersion))
            {
                plan = new Plan
                {
                    Name = this.PlanName,
                    Product = this.PlanProduct,
                    Publisher = this.PlanPublisher,
                    Version = this.PlanVersion
                };
            }

            ConfirmAction(MyInvocation.InvocationName,
            $"{scope}/providers/Microsoft.ManagedServices/registrationDefinitions/{definitionId}",
            () =>
            {
                var registrationDefinition = new RegistrationDefinition
                {
                    Plan = plan,
                    Properties = new RegistrationDefinitionProperties
                    {
                        Description = this.Description,
                        RegistrationDefinitionName = this.DisplayName,
                        ManagedByTenantId = managedByTenantId,
                        Authorizations = this.Authorizations
                    }
                };

                var result = this.PSManagedServicesClient.CreateOrUpdateRegistrationDefinition(
                    scope: scope,
                    registrationDefinition: registrationDefinition,
                    registratonDefinitionId: definitionId);

                WriteObject(new PSRegistrationDefinition(result), true);
            });
        }
    }
}