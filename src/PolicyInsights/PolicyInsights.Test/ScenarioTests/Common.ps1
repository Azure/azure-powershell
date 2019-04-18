# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Gets test management group name
#>
function Get-TestManagementGroupName
{
   "azgovtest5"
}

<#
.SYNOPSIS
Gets test resource group group name
#>
function Get-TestResourceGroupName
{
   "jilimpolicytest2"
}

<#
.SYNOPSIS
Gets test resource id
#>
function Get-TestResourceId
{
   "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/govintpolicyrp/providers/microsoft.network/trafficmanagerprofiles/gov-int-policy-rp"
}

<#
.SYNOPSIS
Gets test policy set definition name
#>
function Get-TestPolicySetDefinitionName
{
   "875cf75e-49c3-47f8-ab8d-89ba3d2311a0"
}

<#
.SYNOPSIS
Gets test policy definition name
#>
function Get-TestPolicyDefinitionName
{
   "24813039-7534-408a-9842-eb99f45721b1"
}

<#
.SYNOPSIS
Gets test policy assignment name
#>
function Get-TestPolicyAssignmentName
{
   "f54e881207924ca8b2e39f6a"
}

<#
.SYNOPSIS
Gets test resource group group name for resource group level policy assignment (for event tests)
#>
function Get-TestResourceGroupNameForPolicyAssignmentEvents
{
   "jilimpolicytest2"
}

<#
.SYNOPSIS
Gets test policy assignment name (resource group level) (for event tests)
#>
function Get-TestPolicyAssignmentNameResourceGroupLevelEvents
{
   "e9860612d8ec4a469f59af06"
}

<#
.SYNOPSIS
Gets test resource group group name for resource group level policy assignment (for state tests)
#>
function Get-TestResourceGroupNameForPolicyAssignmentStates
{
   "jilimpolicytest2"
}

<#
.SYNOPSIS
Gets test policy assignment name (resource group level) (for state tests)
#>
function Get-TestPolicyAssignmentNameResourceGroupLevelStates
{
   "e9860612d8ec4a469f59af06"
}

<#
.SYNOPSIS
Gets test query interval start
#>
function Get-TestQueryIntervalStart
{
   "2019-01-20 00:00:00Z"
}

<#
.SYNOPSIS
Gets test query interval end
#>
function Get-TestQueryIntervalEnd
{
   "2019-04-15 00:00:00Z"
}

<#
.SYNOPSIS
Gets the policy assignment used in remediation tests at subscription level and below
#>
function Get-TestRemediationSubscriptionPolicyAssignmentId
{
   "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
}

<#
.SYNOPSIS
Gets the policy assignment used in remediation tests at management group scope
#>
function Get-TestRemediationMgPolicyAssignmentId
{
   "/providers/Microsoft.Management/managementGroups/PolicyUIMG/providers/Microsoft.Authorization/policyAssignments/326b090398a649e3858e3f23"
}

<#
.SYNOPSIS
Validates a list of policy events
#>
function Validate-PolicyEvents
{
   param([System.Collections.Generic.List`1[[Microsoft.Azure.Commands.PolicyInsights.Models.PolicyEvent]]]$policyEvents, [int]$count)

   Assert-True { $count -ge $policyEvents.Count }
   Assert-True { $policyEvents.Count -gt 0 }
   Foreach($policyEvent in $policyEvents)
   {
      Validate-PolicyEvent $policyEvent
   }
}

<#
.SYNOPSIS
Validates a policy event
#>
function Validate-PolicyEvent
{
   param([Microsoft.Azure.Commands.PolicyInsights.Models.PolicyEvent]$policyEvent)

   Assert-NotNull $policyEvent

   Assert-NotNull $policyEvent.Timestamp
   Assert-NotNullOrEmpty $policyEvent.ResourceId
   Assert-NotNullOrEmpty $policyEvent.PolicyAssignmentId
   Assert-NotNullOrEmpty $policyEvent.PolicyDefinitionId
   Assert-NotNull $policyEvent.IsCompliant
   Assert-NotNullOrEmpty $policyEvent.SubscriptionId
   Assert-NotNullOrEmpty $policyEvent.PolicyDefinitionAction
   Assert-NotNullOrEmpty $policyEvent.TenantId
   Assert-NotNullOrEmpty $policyEvent.PrincipalOid
}

<#
.SYNOPSIS
Validates a list of policy states
#>
function Validate-PolicyStates
{
   param(
      [System.Collections.Generic.List`1[[Microsoft.Azure.Commands.PolicyInsights.Models.PolicyState]]]$policyStates,
	  [int]$count,
	  [switch]$expandPolicyEvaluationDetails = $false)

   Assert-True { $count -ge $policyStates.Count }
   Assert-True { $policyStates.Count -gt 0 }
   Foreach($policyState in $policyStates)
   {
      Validate-PolicyState $policyState -expandPolicyEvaluationDetails:$expandPolicyEvaluationDetails
   }
}

<#
.SYNOPSIS
Validates a policy state
#>
function Validate-PolicyState
{
   param(
      [Microsoft.Azure.Commands.PolicyInsights.Models.PolicyState]$policyState,
	  [switch]$expandPolicyEvaluationDetails = $false)

   Assert-NotNull $policyState

   Assert-NotNull $policyState.Timestamp
   Assert-NotNullOrEmpty $policyState.ResourceId
   Assert-NotNullOrEmpty $policyState.PolicyAssignmentId
   Assert-NotNullOrEmpty $policyState.PolicyDefinitionId
   Assert-NotNull $policyState.IsCompliant
   Assert-NotNullOrEmpty $policyState.SubscriptionId
   Assert-NotNullOrEmpty $policyState.PolicyDefinitionAction
   Assert-NotNullOrEmpty $policyState.ComplianceState

   if ($expandPolicyEvaluationDetails -and $policyState.ComplianceState -eq "NonCompliant")
   {
      Assert-NotNull $policyState.PolicyEvaluationDetails
   }
   else
   {
      Assert-Null $policyState.PolicyEvaluationDetails
   }
}

<#
.SYNOPSIS
Validates a policy state summary
#>
function Validate-PolicyStateSummary
{
   param([Microsoft.Azure.Commands.PolicyInsights.Models.PolicyStateSummary]$policyStateSummary)

   Assert-NotNull $policyStateSummary

   Assert-NotNull $policyStateSummary.Results
   Assert-NotNull $policyStateSummary.Results.NonCompliantResources
   Assert-NotNull $policyStateSummary.Results.NonCompliantPolicies

   Assert-NotNull $policyStateSummary.PolicyAssignments
   Assert-True { $policyStateSummary.PolicyAssignments.Count -gt 0 } 

   Foreach($policyAssignmentSummary in $policyStateSummary.PolicyAssignments)
   {
      Assert-NotNull $policyAssignmentSummary

      Assert-NotNullOrEmpty $policyAssignmentSummary.PolicyAssignmentId

      Assert-NotNull $policyAssignmentSummary.Results
      Assert-NotNull $policyAssignmentSummary.Results.NonCompliantResources
      Assert-NotNull $policyAssignmentSummary.Results.NonCompliantPolicies

      Assert-NotNull $policyAssignmentSummary.PolicyDefinitions
      if ($policyAssignmentSummary.PolicyDefinitions.Count -gt 0)
	  {
		  Assert-True { ($policyAssignmentSummary.PolicyDefinitions | Where-Object { $_.Results.NonCompliantResources -gt 0 }).Count -eq $policyAssignmentSummary.Results.NonCompliantPolicies }

		  Foreach($policyDefinitionSummary in $policyAssignmentSummary.PolicyDefinitions)
		  {
			 Assert-NotNull $policyDefinitionSummary

			 Assert-NotNullOrEmpty $policyDefinitionSummary.PolicyDefinitionId
			 Assert-NotNullOrEmpty $policyDefinitionSummary.Effect

			 Assert-NotNull $policyDefinitionSummary.Results
			 Assert-NotNull $policyDefinitionSummary.Results.NonCompliantResources
			 Assert-Null $policyDefinitionSummary.Results.NonCompliantPolicies
		  }
	  }
   }
}

<#
.SYNOPSIS
Validates a remediation
#>
function Validate-Remediation
{
   param([Microsoft.Azure.Commands.PolicyInsights.Models.Remediation.PSRemediation]$remediation)

   Assert-NotNull $remediation

   Assert-NotNull $remediation.CreatedOn
   Assert-NotNull $remediation.LastUpdatedOn
   Assert-True { $remediation.Id -like "*/providers/microsoft.policyinsights/remediations/*" }
   Assert-AreEqual "Microsoft.PolicyInsights/remediations" $remediation.Type
   Assert-NotNullOrEmpty $remediation.Name
   Assert-NotNullOrEmpty $remediation.PolicyAssignmentId
   Assert-NotNullOrEmpty $remediation.ProvisioningState
   Assert-NotNull $remediation.DeploymentSummary
}

<#
.SYNOPSIS
Validates a remediation deployment
#>
function Validate-RemediationDeployment
{
   param([Microsoft.Azure.Commands.PolicyInsights.Models.Remediation.PSRemediationDeployment]$deployment)

   Assert-NotNull $deployment

   Assert-NotNull $deployment.CreatedOn
   Assert-NotNull $deployment.LastUpdatedOn
   Assert-True { $deployment.RemediatedResourceId -like "/subscriptions/*/providers/*" }
   Assert-NotNullOrEmpty $deployment.Status
   Assert-NotNullOrEmpty $deployment.ResourceLocation
}

<#
.SYNOPSIS
Validates a string is not null or empty
#>
function Assert-NotNullOrEmpty
{
   param([string]$value)

   Assert-False { [string]::IsNullOrEmpty($value) }
}
