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
Get policy events at management group scope
#>
function Get-AzureRmPolicyEvent-ManagementGroupScope
{
<<<<<<< HEAD
	$managementGroupName = Get-TestManagementGroupName
	$from = Get-TestQueryIntervalStart

    $policyEvents = Get-AzPolicyEvent -ManagementGroupName $managementGroupName -Top 10 -From $from
	Validate-PolicyEvents $policyEvents 10
=======
   $managementGroupName = Get-TestManagementGroupName
   $from = Get-TestQueryIntervalStart

   $policyEvents = Get-AzPolicyEvent -ManagementGroupName $managementGroupName -Top 10 -From $from
   Validate-PolicyEvents $policyEvents 10
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

<#
.SYNOPSIS
Get policy events at subscription scope
#>
function Get-AzureRmPolicyEvent-SubscriptionScope
{
<<<<<<< HEAD
	$from = Get-TestQueryIntervalStart

    $policyEvents = Get-AzPolicyEvent -Top 10 -From $from
	Validate-PolicyEvents $policyEvents 10
=======
   $from = Get-TestQueryIntervalStart

   $policyEvents = Get-AzPolicyEvent -Top 10 -From $from
   Validate-PolicyEvents $policyEvents 10
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

<#
.SYNOPSIS
Get policy events at resource group scope
#>
function Get-AzureRmPolicyEvent-ResourceGroupScope
{
<<<<<<< HEAD
	$resourceGroupName = Get-TestResourceGroupName
	$from = Get-TestQueryIntervalStart

    $policyEvents = Get-AzPolicyEvent -ResourceGroupName $resourceGroupName -Top 10 -From $from
	Validate-PolicyEvents $policyEvents 10
=======
   $resourceGroupName = Get-TestResourceGroupName
   $from = Get-TestQueryIntervalStart

   $policyEvents = Get-AzPolicyEvent -ResourceGroupName $resourceGroupName -Top 10 -From $from
   Validate-PolicyEvents $policyEvents 10
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

<#
.SYNOPSIS
Get policy events at resource scope
#>
function Get-AzureRmPolicyEvent-ResourceScope
{
<<<<<<< HEAD
	$resourceId = Get-TestResourceId
	$from = Get-TestQueryIntervalStart

    $policyEvents = Get-AzPolicyEvent -ResourceId $resourceId -Top 10 -From $from
	Validate-PolicyEvents $policyEvents 10
=======
   $resourceId = Get-TestResourceId
   $from = Get-TestQueryIntervalStart

   $policyEvents = Get-AzPolicyEvent -ResourceId $resourceId -Top 10 -From $from
   Validate-PolicyEvents $policyEvents 10
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

<#
.SYNOPSIS
Get policy events at policy set definition scope
#>
function Get-AzureRmPolicyEvent-PolicySetDefinitionScope
{
<<<<<<< HEAD
	$policySetDefinitionName = Get-TestPolicySetDefinitionName
	$from = Get-TestQueryIntervalStart

    $policyEvents = Get-AzPolicyEvent -PolicySetDefinitionName $policySetDefinitionName -Top 10 -From $from
	Validate-PolicyEvents $policyEvents 10
=======
   $policySetDefinitionName = Get-TestPolicySetDefinitionName
   $from = Get-TestQueryIntervalStart

   $policyEvents = Get-AzPolicyEvent -PolicySetDefinitionName $policySetDefinitionName -Top 10 -From $from
   Validate-PolicyEvents $policyEvents 10
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

<#
.SYNOPSIS
Get policy events at policy definition scope
#>
function Get-AzureRmPolicyEvent-PolicyDefinitionScope
{
<<<<<<< HEAD
	$policyDefinitionName = Get-TestPolicyDefinitionName

    $policyEvents = Get-AzPolicyEvent -PolicyDefinitionName $policyDefinitionName -Top 10
	Validate-PolicyEvents $policyEvents 10
=======
   $policyDefinitionName = Get-TestPolicyDefinitionNameForEvents

   $policyEvents = Get-AzPolicyEvent -PolicyDefinitionName $policyDefinitionName -Top 10
   Validate-PolicyEvents $policyEvents 10
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

<#
.SYNOPSIS
Get policy events at subscription level policy assignment scope
#>
function Get-AzureRmPolicyEvent-SubscriptionLevelPolicyAssignmentScope
{
<<<<<<< HEAD
	$policyAssignmentName = Get-TestPolicyAssignmentName
	$from = Get-TestQueryIntervalStart

    $policyEvents = Get-AzPolicyEvent -PolicyAssignmentName $policyAssignmentName -Top 10 -From $from
	Validate-PolicyEvents $policyEvents 10
=======
   $policyAssignmentName = Get-TestPolicyAssignmentName
   $from = Get-TestQueryIntervalStart

   $policyEvents = Get-AzPolicyEvent -PolicyAssignmentName $policyAssignmentName -Top 10 -From $from
   Validate-PolicyEvents $policyEvents 10
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

<#
.SYNOPSIS
Get policy events at resource group level policy assignment scope
#>
function Get-AzureRmPolicyEvent-ResourceGroupLevelPolicyAssignmentScope
{
<<<<<<< HEAD
	$resourceGroupName = Get-TestResourceGroupNameForPolicyAssignmentEvents
	$policyAssignmentName = Get-TestPolicyAssignmentNameResourceGroupLevelEvents

    $policyEvents = Get-AzPolicyEvent -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
	Validate-PolicyEvents $policyEvents 10
=======
   $resourceGroupName = Get-TestResourceGroupNameForPolicyAssignmentEvents
   $policyAssignmentName = Get-TestPolicyAssignmentNameResourceGroupLevelEvents

   $policyEvents = Get-AzPolicyEvent -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
   Validate-PolicyEvents $policyEvents 10
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}
