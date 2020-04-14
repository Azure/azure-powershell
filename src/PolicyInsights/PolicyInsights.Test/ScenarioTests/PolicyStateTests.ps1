﻿# ----------------------------------------------------------------------------------
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
Get latest policy states at management group scope
#>
function Get-AzureRmPolicyState-LatestManagementGroupScope
{
	$managementGroupName = Get-TestManagementGroupName
	$from = Get-TestQueryIntervalStart

    $policyStates = Get-AzPolicyState -ManagementGroupName $managementGroupName -Top 10 -From $from
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at management group scope
#>
function Get-AzureRmPolicyState-AllManagementGroupScope
{
	$managementGroupName = Get-TestManagementGroupName
	$from = Get-TestQueryIntervalStart

    $policyStates = Get-AzPolicyState -All -ManagementGroupName $managementGroupName -Top 10 -From $from
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at subscription scope
#>
function Get-AzureRmPolicyState-LatestSubscriptionScope
{
	$from = Get-TestQueryIntervalStart

    $policyStates = Get-AzPolicyState -Top 10 -From $from
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at subscription scope
#>
function Get-AzureRmPolicyState-AllSubscriptionScope
{
	$from = Get-TestQueryIntervalStart

    $policyStates = Get-AzPolicyState -All -Top 10 -From $from
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at resource group scope
#>
function Get-AzureRmPolicyState-LatestResourceGroupScope
{
	$resourceGroupName = Get-TestResourceGroupName
	$from = Get-TestQueryIntervalStart

    $policyStates = Get-AzPolicyState -ResourceGroupName $resourceGroupName -Top 10 -From $from
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at resource group scope
#>
function Get-AzureRmPolicyState-AllResourceGroupScope
{
	$resourceGroupName = Get-TestResourceGroupName
	$from = Get-TestQueryIntervalStart

    $policyStates = Get-AzPolicyState -All -ResourceGroupName $resourceGroupName -Top 10 -From $from
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at resource scope
#>
function Get-AzureRmPolicyState-LatestResourceScope
{
	$resourceId = Get-TestResourceId
	$from = Get-TestQueryIntervalStart

    $policyStates = Get-AzPolicyState -ResourceId $resourceId -Top 10 -From $from
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at resource scope
#>
function Get-AzureRmPolicyState-AllResourceScope
{
	$resourceId = Get-TestResourceId
	$from = Get-TestQueryIntervalStart

    $policyStates = Get-AzPolicyState -All -ResourceId $resourceId -Top 10 -From $from
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at policy set definition scope
#>
function Get-AzureRmPolicyState-LatestPolicySetDefinitionScope
{
	$policySetDefinitionName = Get-TestPolicySetDefinitionName

    $policyStates = Get-AzPolicyState -PolicySetDefinitionName $policySetDefinitionName -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at policy set definition scope
#>
function Get-AzureRmPolicyState-AllPolicySetDefinitionScope
{
	$policySetDefinitionName = Get-TestPolicySetDefinitionName

    $policyStates = Get-AzPolicyState -All -PolicySetDefinitionName $policySetDefinitionName -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at policy definition scope
#>
function Get-AzureRmPolicyState-LatestPolicyDefinitionScope
{
	$policyDefinitionName = Get-TestPolicyDefinitionName

    $policyStates = Get-AzPolicyState -PolicyDefinitionName $policyDefinitionName -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at policy definition scope
#>
function Get-AzureRmPolicyState-AllPolicyDefinitionScope
{
	$policyDefinitionName = Get-TestPolicyDefinitionName

    $policyStates = Get-AzPolicyState -All -PolicyDefinitionName $policyDefinitionName -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at subscription level policy assignment scope
#>
function Get-AzureRmPolicyState-LatestSubscriptionLevelPolicyAssignmentScope
{
	$policyAssignmentName = Get-TestPolicyAssignmentName

    $policyStates = Get-AzPolicyState -PolicyAssignmentName $policyAssignmentName -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at subscription level policy assignment scope
#>
function Get-AzureRmPolicyState-AllSubscriptionLevelPolicyAssignmentScope
{
	$policyAssignmentName = Get-TestPolicyAssignmentName

    $policyStates = Get-AzPolicyState -All -PolicyAssignmentName $policyAssignmentName -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at resource group level policy assignment scope
#>
function Get-AzureRmPolicyState-LatestResourceGroupLevelPolicyAssignmentScope
{
	$resourceGroupName = Get-TestResourceGroupNameForPolicyAssignmentStates
	$policyAssignmentName = Get-TestPolicyAssignmentNameResourceGroupLevelStates

    $policyStates = Get-AzPolicyState -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at resource group level policy assignment scope
#>
function Get-AzureRmPolicyState-AllResourceGroupLevelPolicyAssignmentScope
{
	$resourceGroupName = Get-TestResourceGroupNameForPolicyAssignmentStates
	$policyAssignmentName = Get-TestPolicyAssignmentNameResourceGroupLevelStates

    $policyStates = Get-AzPolicyState -All -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Trigger a policy compliance scan at subscription scope
#>
function Start-AzPolicyComplianceScan-SubscriptionScope
{
    Assert-True { Start-AzPolicyComplianceScan -PassThru }
}

<#
.SYNOPSIS
Trigger a policy compliance scan at subscription scope
#>
function Start-AzPolicyComplianceScan-SubscriptionScope-AsJob
{
    $job = Start-AzPolicyComplianceScan -PassThru -AsJob
    $job | Wait-Job
    Assert-AreEqual "Completed" $job.State
    Assert-True { $job | Receive-Job }
}

<#
.SYNOPSIS
Trigger a policy compliance scan at resource group scope
#>
function Start-AzPolicyComplianceScan-ResourceGroupScope
{
    $resourceGroupName = Get-TestResourceGroupNameForPolicyAssignmentStates
    Assert-True { Start-AzPolicyComplianceScan -ResourceGroupName $resourceGroupName -PassThru }
}
