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

# setup the Pester environment
. (Join-Path $PSScriptRoot 'Common.ps1') 'Get-AzPolicyState'


Describe 'Get-AzPolicyState' {

    BeforeAll {
        # set up commonly used variables
        $managementGroupName = $env.managementGroup
        $from = $env.fromDate
        $resourceGroupName = $env.firstRgName
        $resourceId = $env.testResourceId
        $policySetDefinitionName = $env.policySetDefName
        $policyDefinitionName = $env.auditPolicyDefName
    }

    It 'LatestManagementGroupScope' {
        $policyStates = Get-AzPolicyState -ManagementGroupName $managementGroupName -Top 10 -From $from
        Validate-PolicyStates $policyStates 10
    }

    It 'AllManagementGroupScope' {
        $policyStates = Get-AzPolicyState -All -ManagementGroupName $managementGroupName -Top 10 -From $from
        Validate-PolicyStates $policyStates 10
    }

    It 'ManagementGroupScope-Paging' {
        # Apply filters\selection to recude the session recording size
        $policyStates = Get-AzPolicyState -ManagementGroupName $managementGroupName -Top 1001 -From $from -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
        Assert-True { $policyStates.Count -eq 1001 }

        $policyStates = Get-AzPolicyState -ManagementGroupName $managementGroupName -From $from -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
        Assert-True { $policyStates.Count -ge 1001 }
    }

    It 'LatestSubscriptionScope' {
        $policyStates = Get-AzPolicyState -Top 10 -From $from
        Validate-PolicyStates $policyStates 10
    }

    It 'SubscriptionScope-Paging' {
        # Apply filters\selection to recude the session recording size
        $policyStates = Get-AzPolicyState -Top 1001 -From $from -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
        Assert-True { $policyStates.Count -eq 1001 }

        $policyStates = Get-AzPolicyState -From $from -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
        Assert-True { $policyStates.Count -ge 1001 }
    }

    It 'AllSubscriptionScope' {
        $policyStates = Get-AzPolicyState -All -Top 10 -From $from
        Validate-PolicyStates $policyStates 10
    }

    It 'LatestResourceGroupScope' {
        $policyStates = Get-AzPolicyState -ResourceGroupName $resourceGroupName -Top 10 -From $from
        Validate-PolicyStates $policyStates 10
    }

    It 'AllResourceGroupScope' {
        $policyStates = Get-AzPolicyState -All -ResourceGroupName $resourceGroupName -Top 10 -From $from
        Validate-PolicyStates $policyStates 10
    }

    It 'LatestResourceScope' {
        $policyStates = Get-AzPolicyState -ResourceId $resourceId -Top 10 -From $from
        Validate-PolicyStates $policyStates 10
    }

    It 'AllResourceScope' {
        $policyStates = Get-AzPolicyState -All -ResourceId $resourceId -Top 10 -From $from
        Validate-PolicyStates $policyStates 10
    }

    It 'LatestPolicySetDefinitionScope' {
        $policyStates = Get-AzPolicyState -PolicySetDefinitionName $policySetDefinitionName -Top 10
        Validate-PolicyStates $policyStates 10
    }

    It 'AllPolicySetDefinitionScope' {
        $policyStates = Get-AzPolicyState -All -PolicySetDefinitionName $policySetDefinitionName -Top 10
        Validate-PolicyStates $policyStates 10
    }

    It 'PolicySetDefinitionScope-Paging' {
        # Apply selection to recude session recording size
        $policyStates = Get-AzPolicyState -All -PolicySetDefinitionName $policySetDefinitionName -Top 1001 -Select "Timestamp"
        Assert-True { $policyStates.Count -eq 1001 }

        $policyStates = Get-AzPolicyState -All -PolicySetDefinitionName $policySetDefinitionName -Select "Timestamp"
        Assert-True { $policyStates.Count -ge 1001 }
    }

    It 'LatestPolicyDefinitionScope' {
        $policyStates = Get-AzPolicyState -PolicyDefinitionName $policyDefinitionName -Top 10
        Validate-PolicyStates $policyStates 10
    }

    It 'AllPolicyDefinitionScope' {
        $policyStates = Get-AzPolicyState -All -PolicyDefinitionName $policyDefinitionName -Top 10
        Validate-PolicyStates $policyStates 10
    }

    It 'PolicyDefinitionScope-Paging' {
        # Apply selection to recude session recording size
        $policyStates = Get-AzPolicyState -All -PolicyDefinitionName $policyDefinitionName -Top 1001 -Select "Timestamp"
        Assert-True { $policyStates.Count -eq 1001 }

        $policyStates = Get-AzPolicyState -All -PolicyDefinitionName $policyDefinitionName -Select "Timestamp"
        Assert-True { $policyStates.Count -ge 1001 }
    }

    It 'LatestSubscriptionLevelPolicyAssignmentScope' {
        $policyAssignmentName = $env.auditAssignmentNameSub

        $policyStates = Get-AzPolicyState -PolicyAssignmentName $policyAssignmentName -Top 10
        Validate-PolicyStates $policyStates 10
    }

    It 'AllSubscriptionLevelPolicyAssignmentScope' {
        $policyAssignmentName = $env.auditAssignmentNameSub

        $policyStates = Get-AzPolicyState -All -PolicyAssignmentName $policyAssignmentName -Top 10
        Validate-PolicyStates $policyStates 10
    }

    It 'PolicyAssignmentScope-Paging' {
        $policyAssignmentName = $env.auditAssignmentNameSub

        # Apply selection to reduce session recording size
        $policyStates = Get-AzPolicyState -All -PolicyAssignmentName $policyAssignmentName -Top 1001 -Select "Timestamp"
        Assert-True { $policyStates.Count -eq 1001 }

        $policyStates = Get-AzPolicyState -All -PolicyAssignmentName $policyAssignmentName -Select "Timestamp"
        Assert-True { $policyStates.Count -ge 1001 }
    }

    It 'LatestResourceGroupLevelPolicyAssignmentScope' {
        $policyAssignmentName = $env.auditAssignmentNameRg

        $policyStates = Get-AzPolicyState -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
        Validate-PolicyStates $policyStates 10
    }

    It 'AllResourceGroupLevelPolicyAssignmentScope' {
        $policyAssignmentName = $env.auditAssignmentNameRg

        $policyStates = Get-AzPolicyState -All -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
        Validate-PolicyStates $policyStates 10
    }

    It 'QueryResultsWithFrom' {
	      $policyStates = Get-AzPolicyState -From $from -Top 10
	      Validate-PolicyStates $policyStates 10
    }

    It 'QueryResultsWithTo' {
	      $to = $env.toDate

	      $policyStates = Get-AzPolicyState -To $to -Top 10
	      Validate-PolicyStates $policyStates 10
    }

    It 'QueryResultsWithTop' {
	      $policyStates = Get-AzPolicyState -Top 10
	      Validate-PolicyStates $policyStates 10
    }

    It 'QueryResultsWithOrderBy' {
	      $policyStates = Get-AzPolicyState -OrderBy "Timestamp asc, PolicyDefinitionAction, PolicyAssignmentId asc" -Top 10
	      Validate-PolicyStates $policyStates 10
    }

    It 'QueryResultsWithSelect' {
	      $policyStates = Get-AzPolicyState -Select "Timestamp, ResourceId, PolicyAssignmentId, PolicyDefinitionId, IsCompliant, SubscriptionId, PolicyDefinitionAction, ComplianceState" -Top 10
	      Validate-PolicyStates $policyStates 10
    }

    It 'QueryResultsWithFilter' {
	      $policyStates = Get-AzPolicyState -Filter "IsCompliant eq false and PolicyDefinitionAction eq 'audit'" -Top 10
	      Validate-PolicyStates $policyStates 10
    }

    It 'QueryResultsWithApply' {
	      $policyStates = Get-AzPolicyState -Apply "groupby((PolicyAssignmentId, PolicyDefinitionId, ResourceId))/groupby((PolicyAssignmentId, PolicyDefinitionId), aggregate(`$count as NumResources))" -Top 10
	      Foreach ($policyState in $policyStates) {
		        Assert-NotNull $policyState

		        Assert-Null $policyState.ResourceId
		        Assert-NotNullOrEmpty $policyState.PolicyAssignmentId
		        Assert-NotNullOrEmpty $policyState.PolicyDefinitionId

		        Assert-NotNull $policyState.AdditionalProperties
		        Assert-NotNull $policyState.AdditionalProperties["NumResources"]
	      }
    }

    It 'QueryResultsWithExpandPolicyEvaluationDetails' {
	      $policyStates = Get-AzPolicyState -ResourceId $resourceId -Expand "PolicyEvaluationDetails" -Top 10 -Filter "PolicyDefinitionAction eq 'modify'"
	      Validate-PolicyStates $policyStates 10 -expandPolicyEvaluationDetails
    }
}