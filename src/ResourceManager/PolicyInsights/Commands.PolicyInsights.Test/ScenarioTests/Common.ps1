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
	"azgovtest4"
}

<#
.SYNOPSIS
Gets test resource group group name
#>
function Get-TestResourceGroupName
{
	"bulenttestrg"
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
	"12b58873-e0f8-4b95-936c-86cbe7c9d697"
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
	"45ab2ab7898d45ebb3087573"
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
	"bulenttestrg"
}

<#
.SYNOPSIS
Gets test policy assignment name (resource group level) (for state tests)
#>
function Get-TestPolicyAssignmentNameResourceGroupLevelStates
{
	"f4d1645d-9180-4968-99df-17234d0f7019"
}

<#
.SYNOPSIS
Gets test query interval start
#>
function Get-TestQueryIntervalStart
{
	"2018-03-31 00:00:00Z"
}

<#
.SYNOPSIS
Gets test query interval end
#>
function Get-TestQueryIntervalEnd
{
	"2018-05-30 00:00:00Z"
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
	param([System.Collections.Generic.List`1[[Microsoft.Azure.Commands.PolicyInsights.Models.PolicyState]]]$policyStates, [int]$count)

    Assert-True { $count -ge $policyStates.Count }
    Assert-True { $policyStates.Count -gt 0 }
	Foreach($policyState in $policyStates)
	{
		Validate-PolicyState $policyState
	}
}

<#
.SYNOPSIS
Validates a policy state
#>
function Validate-PolicyState
{
	param([Microsoft.Azure.Commands.PolicyInsights.Models.PolicyState]$policyState)

	Assert-NotNull $policyState

    Assert-NotNull $policyState.Timestamp
    Assert-NotNullOrEmpty $policyState.ResourceId
    Assert-NotNullOrEmpty $policyState.PolicyAssignmentId
    Assert-NotNullOrEmpty $policyState.PolicyDefinitionId
    Assert-NotNull $policyState.IsCompliant
    Assert-NotNullOrEmpty $policyState.SubscriptionId
    Assert-NotNullOrEmpty $policyState.PolicyDefinitionAction
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
    Assert-True { $policyStateSummary.PolicyAssignments.Count -le $policyStateSummary.Results.NonCompliantPolicies } 
    Assert-True { $policyStateSummary.PolicyAssignments.Count -gt 0 } 

	Foreach($policyAssignmentSummary in $policyStateSummary.PolicyAssignments)
	{
		Assert-NotNull $policyAssignmentSummary

		Assert-NotNullOrEmpty $policyAssignmentSummary.PolicyAssignmentId

        Assert-NotNull $policyAssignmentSummary.Results
		Assert-NotNull $policyAssignmentSummary.Results.NonCompliantResources
		Assert-NotNull $policyAssignmentSummary.Results.NonCompliantPolicies

        Assert-NotNull $policyAssignmentSummary.PolicyDefinitions
        Assert-True { $policyAssignmentSummary.PolicyDefinitions.Count -eq $policyAssignmentSummary.Results.NonCompliantPolicies }
        Assert-True { $policyAssignmentSummary.PolicyDefinitions.Count -gt 0 }

        if ($policyAssignmentSummary.Results.NonCompliantPolicies -gt 1)
        {
            Assert-NotNullOrEmpty $policyAssignmentSummary.PolicySetDefinitionId
        }

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

<#
.SYNOPSIS
Validates a string is not null or empty
#>
function Assert-NotNullOrEmpty
{
	param([string]$value)

	Assert-False { [string]::IsNullOrEmpty($value) }
}
