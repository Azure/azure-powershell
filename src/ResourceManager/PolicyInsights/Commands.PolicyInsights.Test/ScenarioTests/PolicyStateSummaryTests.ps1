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
Get policy states summary at management group scope
#>
function Get-AzureRmPolicyStateSummary-ManagementGroupScope
{
    $managementGroupName = Get-TestManagementGroupName
	$from = Get-TestQueryIntervalStart

	$policyStateSummary = Get-AzureRmPolicyStateSummary -ManagementGroupName $managementGroupName -Top 10 -From $from
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at subscription scope
#>
function Get-AzureRmPolicyStateSummary-SubscriptionScope
{
	$from = Get-TestQueryIntervalStart

    $policyStateSummary = Get-AzureRmPolicyStateSummary -Top 10 -From $from
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at resource group scope
#>
function Get-AzureRmPolicyStateSummary-ResourceGroupScope
{
	$resourceGroupName = Get-TestResourceGroupName
	$from = Get-TestQueryIntervalStart

    $policyStateSummary = Get-AzureRmPolicyStateSummary -ResourceGroupName $resourceGroupName -Top 10 -From $from
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at resource scope
#>
function Get-AzureRmPolicyStateSummary-ResourceScope
{
	$resourceId = Get-TestResourceId
	$from = Get-TestQueryIntervalStart

    $policyStateSummary = Get-AzureRmPolicyStateSummary -ResourceId $resourceId -Top 10 -From $from
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at policy set definition scope
#>
function Get-AzureRmPolicyStateSummary-PolicySetDefinitionScope
{
	$policySetDefinitionName = Get-TestPolicySetDefinitionName

    $policyStateSummary = Get-AzureRmPolicyStateSummary -PolicySetDefinitionName $policySetDefinitionName -Top 10
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at policy definition scope
#>
function Get-AzureRmPolicyStateSummary-PolicyDefinitionScope
{
	$policyDefinitionName = Get-TestPolicyDefinitionName

    $policyStateSummary = Get-AzureRmPolicyStateSummary -PolicyDefinitionName $policyDefinitionName -Top 10
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at subscription level policy assignment scope
#>
function Get-AzureRmPolicyStateSummary-SubscriptionLevelPolicyAssignmentScope
{
	$policyAssignmentName = Get-TestPolicyAssignmentName

    $policyStateSummary = Get-AzureRmPolicyStateSummary -PolicyAssignmentName $policyAssignmentName -Top 10
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at resource group level policy assignment scope
#>
function Get-AzureRmPolicyStateSummary-ResourceGroupLevelPolicyAssignmentScope
{
	$resourceGroupName = Get-TestResourceGroupNameForPolicyAssignmentStates
	$policyAssignmentName = Get-TestPolicyAssignmentNameResourceGroupLevelStates

    $policyStateSummary = Get-AzureRmPolicyStateSummary -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
	Validate-PolicyStateSummary $policyStateSummary
}
