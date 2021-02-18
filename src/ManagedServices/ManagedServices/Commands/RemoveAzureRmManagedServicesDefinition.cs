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
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Extensions;
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands
{
    [Cmdlet(
    VerbsCommon.Remove,
    Microsoft.Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedServicesDefinition",
    DefaultParameterSetName = DefaultParameterSet,
    SupportsShouldProcess = true), OutputType(typeof(void))]

=======
namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands
{
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Management.Automation;

    [Cmdlet(
        VerbsCommon.Remove,
        AzureRMConstants.AzureRMPrefix + "ManagedServicesDefinition",
        DefaultParameterSetName = DefaultParameterSet,
        SupportsShouldProcess = true), OutputType(typeof(bool))]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    public class RemoveAzureRmManagedServicesDefinition : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByInputObjectParameterSet = "ByInputObject";
<<<<<<< HEAD
        protected const string ByResourceIdParameterSet = "ByResourceId";

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The registration definition identifier.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The full qualified resource id of registration definition.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
=======

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The scope where the registration definition created.")]
        [ValidateNotNullOrEmpty]
        [ScopeCompleter]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The unique name of the Registration Definition.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        [Parameter(ParameterSetName = ByInputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The registration definition object.")]
        [ValidateNotNull]
        public PSRegistrationDefinition InputObject { get; set; }

<<<<<<< HEAD
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope = null;
            string definitionId = null;
            if (this.IsParameterBound(x => x.Id))
            {
                scope = this.GetDefaultScope();
                definitionId = this.Id;
            }
            else if (this.IsParameterBound(x => x.InputObject))
            {
                definitionId = this.InputObject.Id.GetResourceName();
                if(!ManagedServicesUtility.TryParseDefinitionScopeFromResourceId(this.InputObject.Id, out scope))
                {
                    throw new ApplicationException($"Unable to parse the scope from [{this.InputObject.Id}]");
                }
            }
            else if (this.IsParameterBound(x => x.ResourceId))
            {
                definitionId = this.ResourceId.GetResourceName();
                if (!ManagedServicesUtility.TryParseDefinitionScopeFromResourceId(this.ResourceId, out scope))
                {
                    throw new ApplicationException($"Unable to parse the scope from [{this.ResourceId}]");
                }
            }

            ConfirmAction(MyInvocation.InvocationName,
                $"/{scope}/providers/Microsoft.ManagedServices/registrationDefinitions{definitionId}",
=======
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope = this.GetDefaultScope();
            string definitionId = null;

            if (this.IsParameterBound(x => x.Name))
            {
                if (!this.Name.IsGuid())
                {
                    throw new ApplicationException("Name must be a valid GUID.");
                }

                definitionId = (new Guid(this.Name)).ToString();
            }

            if (this.IsParameterBound(x => x.Scope))
            {
                scope = this.Scope;
            }

            if (this.IsParameterBound(x => x.InputObject))
            {
                if (!ManagedServicesUtility.TryParseDefinitionScopeFromResourceId(this.InputObject.Id, out scope) &&
                    string.IsNullOrWhiteSpace(scope))
                {
                    throw new ApplicationException($"Unable to parse the scope from [{this.InputObject.Id}]");
                }

                if (string.IsNullOrWhiteSpace(this.InputObject.Name) || !this.InputObject.Name.IsGuid())
                {
                    throw new ApplicationException("Invalid registration definition name provided in input object.");
                }

                definitionId = this.InputObject.Name;
            }

            ConfirmAction(MyInvocation.InvocationName,
                $"/{scope}/providers/Microsoft.ManagedServices/registrationDefinitions/{definitionId}",
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                () =>
                {
                    this.PSManagedServicesClient.RemoveRegistrationDefinition(
                        scope: scope,
                        registrationDefinitionId: definitionId);
<<<<<<< HEAD
                });
        }
    }
}
=======

                    if (this.PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
