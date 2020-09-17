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

using Microsoft.Azure.Management.ManagedServices.Models;
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Extensions;
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands
{
    [WindowsAzure.Commands.Common.CustomAttributes.GenericBreakingChange(
        message: "New mandatory parameter 'DisplayName' will be added to represent a user-friendly name for a registration definition",
        deprecateByVersion: ManagedServicesUtility.UpcomingVersion,
        changeInEfectByDate: ManagedServicesUtility.UpcomingVersionReleaseDate)]
    [Cmdlet(
    VerbsCommon.New,
    Microsoft.Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedServicesDefinition",
    DefaultParameterSetName = DefaultParameterSet,
    SupportsShouldProcess = true), OutputType(typeof(PSRegistrationDefinition))]
    public class NewAzureRmManagedServicesDefinition : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByPlanParameterSet = "ByPlan";

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The name of the Registration Definition.")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Tenant Identifier.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Tenant Identifier.")]
        public string ManagedByTenantId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Principal Identifier.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Principal Identifier.")]
        public string PrincipalId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The Managed Service Provider's Role Identifier.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The Managed Service Provider's Role Identifier.")]
        public string RoleDefinitionId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        public string Description { get; set; }

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

        public Guid RegistrationDefinitionId { get; set; } = default(Guid);

        public override void ExecuteCmdlet()
        {
            var scope = this.GetDefaultScope();

            if (!this.ManagedByTenantId.IsGuid())
            {
                throw new ApplicationException("ManagedByTenantId must be a valid GUID.");
            }

            if (!this.PrincipalId.IsGuid())
            {
                throw new ApplicationException("PrincipalId must be a valid GUID.");
            }

            if (!this.RoleDefinitionId.IsGuid())
            {
                throw new ApplicationException("RoleDefinitionId must be a valid GUID.");
            }

            if (this.RegistrationDefinitionId == default(Guid))
            {
                this.RegistrationDefinitionId = Guid.NewGuid();
            }

            ConfirmAction(MyInvocation.InvocationName,
                $"{scope}/providers/Microsoft.ManagedServices/registrationDefinitions/{this.RegistrationDefinitionId}",
                () =>
                {
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

                    var registrationDefinition = new RegistrationDefinition
                    {
                        Plan = plan,
                        Properties = new RegistrationDefinitionProperties
                        {
                            Description = this.Description,
                            RegistrationDefinitionName = this.Name,
                            ManagedByTenantId = this.ManagedByTenantId,
                            Authorizations = new List<Authorization>
                                    {
                                            new Authorization
                                            {
                                                PrincipalId =this.PrincipalId,
                                                RoleDefinitionId =this.RoleDefinitionId
                                            }
                                    }
                        }
                    };

                    var result = this.PSManagedServicesClient.CreateOrUpdateRegistrationDefinition(
                        scope: scope,
                            registrationDefinition: registrationDefinition,
                            registratonDefinitionId: this.RegistrationDefinitionId);

                    WriteObject(new PSRegistrationDefinition(result), true);
                });
        }
    }
}
