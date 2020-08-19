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
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Extensions;
using Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Commands
{
    [Cmdlet(
        VerbsCommon.Remove,
        Microsoft.Azure.Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedServicesAssignment",
        DefaultParameterSetName = DefaultParameterSet,
        SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureRmManagedServcicesAssignment : ManagedServicesCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string ByResourceIdParameterSet = "ByResourceId";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        [Parameter(Position = 0, ParameterSetName = DefaultParameterSet, Mandatory = false, HelpMessage = "The scope where the registration assignment should be created.")]
        [ScopeCompleter]
        public string Scope { get; set; }

        [CmdletParameterBreakingChange(
            nameOfParameterChanging: "Id",
            deprecateByVersion: ManagedServicesUtility.UpcomingVersion,
            changeInEfectByDate: ManagedServicesUtility.UpcomingVersionReleaseDate,
            ReplaceMentCmdletParameterName = "Name")]
        [Parameter(ParameterSetName = DefaultParameterSet, Mandatory = true, HelpMessage = "The registration assignment Id.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [CmdletParameterBreakingChange(
            nameOfParameterChanging: "ResourceId",
            deprecateByVersion: ManagedServicesUtility.UpcomingVersion,
            changeInEfectByDate: ManagedServicesUtility.UpcomingVersionReleaseDate,
            ChangeDescription = ManagedServicesUtility.DeprecatedParameterDescription)]
        [Parameter(ParameterSetName = ByResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified rsource id of the registration assignment.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The registration assignment object.", ParameterSetName = ByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSRegistrationAssignment InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            string scope = null;
            string assignmentId = null;

            if (this.IsParameterBound(x => x.Id))
            {
                assignmentId = this.Id;
                scope = this.Scope ?? this.GetDefaultScope();
            }
            else if (this.IsParameterBound(x => x.InputObject))
            {
                assignmentId = this.InputObject.Id.GetResourceName();
                if (!ManagedServicesUtility.TryParseAssignmentScopeFromResourceId(this.InputObject.Id, out scope))
                {
                    throw new ApplicationException($"Unable to parse the scope from [{this.InputObject.Id}]");
                }
            }
            else if (this.IsParameterBound(x => x.ResourceId))
            {
                assignmentId = this.ResourceId.GetResourceName();
                if (!ManagedServicesUtility.TryParseAssignmentScopeFromResourceId(this.ResourceId, out scope))
                {
                    throw new ApplicationException($"Unable to parse the scope from [{this.ResourceId}]");
                }
            }

            ConfirmAction(MyInvocation.InvocationName,
                $"/{scope}/providers/Microsoft.ManagedServices/registrationAssignments/{assignmentId}",
                () =>
                {
                    this.PSManagedServicesClient.RemoveRegistrationAssignment(
                        scope: scope,
                        registrationAssignmentId: assignmentId);
                });
        }
    }
}
