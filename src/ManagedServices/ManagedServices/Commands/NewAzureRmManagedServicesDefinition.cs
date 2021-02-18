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

<<<<<<< HEAD
using Microsoft.Azure.Management.ManagedServices.Models;
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands
{
    [Cmdlet(
    VerbsCommon.New,
    Microsoft.Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedServicesDefinition",
    DefaultParameterSetName = DefaultParameterSet,
    SupportsShouldProcess = true), OutputType(typeof(PSRegistrationDefinition))]
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    public class NewAzureRmManagedServicesDefinition : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByPlanParameterSet = "ByPlan";
<<<<<<< HEAD

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The name of the Registration Definition.")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The Managedby Tenant Identifier.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The Managedby Tenant Identifier.")]
        public string ManagedByTenantId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The Managedby Principal Identifier.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The Managedby Principal Identifier.")]
        public string PrincipalId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The Managed Service Providers's Role Identifier.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The Managed Service Providers's Role Identifier.")]
        public string RoleDefinitionId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        public string Description { get; set; }
=======
        protected const string ByAuthorizationParameterSet = "ByAuthorization";

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The unique name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = false, HelpMessage = "The unique name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByAuthorizationParameterSet, Mandatory = false, HelpMessage = "The unique name of the Registration Definition.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The display name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The display name of the Registration Definition.")]
        [Parameter(ParameterSetName = ByAuthorizationParameterSet, Mandatory = true, HelpMessage = "The display name of the Registration Definition.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Tenant Identifier.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Tenant Identifier.")]
        [Parameter(ParameterSetName = ByAuthorizationParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Tenant Identifier.")]
        [ValidateNotNullOrEmpty]
        public string ManagedByTenantId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        [Parameter(ParameterSetName = ByAuthorizationParameterSet, Mandatory = false, HelpMessage = "The description of the Registration Definition.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The ManagedBy Principal Identifier.")]
        [ValidateNotNullOrEmpty]
        public string PrincipalId { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The role definition identifier to grant permissions to principal identifier.")]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(ParameterSetName = ByPlanParameterSet, Mandatory = true, HelpMessage = "The authorization mapping list with principalId - roleDefinitionId.")]
        [Parameter(ParameterSetName = ByAuthorizationParameterSet, Mandatory = true, HelpMessage = "The authorization mapping list with principalId - roleDefinitionId.")]
        [ValidateNotNull]
        public Authorization[] Authorization { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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

<<<<<<< HEAD
        public Guid RegistrationDefinitionId { get; set; } = default(Guid);

        public override void ExecuteCmdlet()
        {
            var scope = this.GetDefaultScope();
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            if (!this.ManagedByTenantId.IsGuid())
            {
                throw new ApplicationException("ManagedByTenantId must be a valid GUID.");
            }
<<<<<<< HEAD

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
=======
            else
            {
                managedByTenantId = (new Guid(this.ManagedByTenantId)).ToString();
            }

            if (this.IsParameterBound(x => x.Authorization) &&
                (this.IsParameterBound(x => x.PrincipalId) || this.IsParameterBound(x => x.RoleDefinitionId)))
            {
                throw new ApplicationException("Authorization parameter is supported only when RoleDefinitionId and PrincipalId are null.");
            }

            if (!this.IsParameterBound(x => x.Authorization) &&
                (!this.IsParameterBound(x => x.PrincipalId) || !this.IsParameterBound(x => x.RoleDefinitionId)))
            {
                throw new ApplicationException("Please provide RoleDefinitionId and PrincipalId parameters together or Authorization parameter.");
            }

            if (this.Authorization == null &&
                this.IsParameterBound(x => x.PrincipalId) &&
                this.IsParameterBound(x => x.RoleDefinitionId))
            {
                this.Authorization = new Authorization[]
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
                        Authorizations = this.Authorization
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
