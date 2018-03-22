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
Validates a list of policy events
#>
function Validate-PolicyEvents
{
	param([System.Collections.Generic.List`1[[Microsoft.Azure.Commands.PolicyInsights.Models.PolicyEvent]]]$policyEvents, [int]$count)

    Assert-AreEqual $count $policyEvents.Count
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

    Assert-AreEqual $count $policyStates.Count
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
    Assert-AreEqual $policyStateSummary.PolicyAssignments.Count $policyStateSummary.Results.NonCompliantPolicies

	Foreach($policyAssignmentSummary in $policyStateSummary.PolicyAssignments)
	{
		Assert-NotNull $policyAssignmentSummary

		Assert-NotNullOrEmpty $policyAssignmentSummary.PolicyAssignmentId

        Assert-NotNull $policyAssignmentSummary.Results
		Assert-NotNull $policyAssignmentSummary.Results.NonCompliantResources
		Assert-NotNull $policyAssignmentSummary.Results.NonCompliantPolicies

        Assert-NotNull $policyAssignmentSummary.PolicyDefinitions
        Assert-AreEqual $policyAssignmentSummary.PolicyDefinitions.Count $policyAssignmentSummary.Results.NonCompliantPolicies

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

    Assert-NotNull $value
	Assert-AreNotEqual $value ""
}
