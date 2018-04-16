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
    $policyEvents = Get-AzureRmPolicyEvent -ManagementGroupName "AzGovTest1" -Top 5
	Validate-PolicyEvents $policyEvents 5
}

<#
.SYNOPSIS
Get policy events at subscription scope
#>
function Get-AzureRmPolicyEvent-SubscriptionScope
{
    $policyEvents = Get-AzureRmPolicyEvent -Top 5
	Validate-PolicyEvents $policyEvents 5
}

<#
.SYNOPSIS
Get policy events at resource group scope
#>
function Get-AzureRmPolicyEvent-ResourceGroupScope
{
    $policyEvents = Get-AzureRmPolicyEvent -ResourceGroupName defaultresourcegroup-eus -Top 5
	Validate-PolicyEvents $policyEvents 5
}

<#
.SYNOPSIS
Get policy events at resource scope
#>
function Get-AzureRmPolicyEvent-ResourceScope
{
    $policyEvents = Get-AzureRmPolicyEvent -ResourceId "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/defaultresourcegroup-eus/providers/microsoft.operationalinsights/workspaces/defaultworkspace-d0610b27-9663-4c05-89f8-5b4be01e86a5-eus/linkedServices/Security"
	Validate-PolicyEvents $policyEvents 7
}

<#
.SYNOPSIS
Get policy events at policy set definition scope
#>
function Get-AzureRmPolicyEvent-PolicySetDefinitionScope
{
    $policyEvents = Get-AzureRmPolicyEvent -PolicySetDefinitionName a03db67e-a286-43c3-9098-b2da83d361ad -Top 5
	Validate-PolicyEvents $policyEvents 5
}

<#
.SYNOPSIS
Get policy events at policy definition scope
#>
function Get-AzureRmPolicyEvent-PolicyDefinitionScope
{
    $policyEvents = Get-AzureRmPolicyEvent -PolicyDefinitionName c8b79b49-a579-4045-984e-1b249ab8b474 -Top 5
	Validate-PolicyEvents $policyEvents 5
}

<#
.SYNOPSIS
Get policy events at subscription level policy assignment scope
#>
function Get-AzureRmPolicyEvent-SubscriptionLevelPolicyAssignmentScope
{
    $policyEvents = Get-AzureRmPolicyEvent -PolicyAssignmentName e46af646ebdb461dba708e01 -Top 5
	Validate-PolicyEvents $policyEvents 5
}

<#
.SYNOPSIS
Get policy events at resource group level policy assignment scope
#>
function Get-AzureRmPolicyEvent-ResourceGroupLevelPolicyAssignmentScope
{
    $policyEvents = Get-AzureRmPolicyEvent -ResourceGroupName cheggpolicy -PolicyAssignmentName d620f2d1462b4426a6b499fc -Top 1
	Validate-PolicyEvents $policyEvents 1
}
