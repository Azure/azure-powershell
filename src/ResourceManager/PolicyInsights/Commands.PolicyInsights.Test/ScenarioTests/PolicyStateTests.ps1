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
Get latest policy states at management group scope
#>
function Get-AzureRmPolicyState-LatestManagementGroupScope
{
    $policyStates = Get-AzureRmPolicyState -ManagementGroupName "AzGovTest1" -Top 3
	Validate-PolicyStates $policyStates 3
}

<#
.SYNOPSIS
Get all policy states at management group scope
#>
function Get-AzureRmPolicyState-AllManagementGroupScope
{
    $policyStates = Get-AzureRmPolicyState -All -ManagementGroupName "AzGovTest1" -Top 3
	Validate-PolicyStates $policyStates 3
}

<#
.SYNOPSIS
Get latest policy states at subscription scope
#>
function Get-AzureRmPolicyState-LatestSubscriptionScope
{
    $policyStates = Get-AzureRmPolicyState -Top 5
	Validate-PolicyStates $policyStates 5
}

<#
.SYNOPSIS
Get all policy states at subscription scope
#>
function Get-AzureRmPolicyState-AllSubscriptionScope
{
    $policyStates = Get-AzureRmPolicyState -All -Top 5
	Validate-PolicyStates $policyStates 5
}

<#
.SYNOPSIS
Get latest policy states at resource group scope
#>
function Get-AzureRmPolicyState-LatestResourceGroupScope
{
    $policyStates = Get-AzureRmPolicyState -ResourceGroupName defaultresourcegroup-eus -Top 5
	Validate-PolicyStates $policyStates 5
}

<#
.SYNOPSIS
Get all policy states at resource group scope
#>
function Get-AzureRmPolicyState-AllResourceGroupScope
{
    $policyStates = Get-AzureRmPolicyState -All -ResourceGroupName defaultresourcegroup-eus -Top 5
	Validate-PolicyStates $policyStates 5
}

<#
.SYNOPSIS
Get latest policy states at resource scope
#>
function Get-AzureRmPolicyState-LatestResourceScope
{
    $policyStates = Get-AzureRmPolicyState -ResourceId "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/defaultresourcegroup-eus/providers/Microsoft.OperationsManagement/solutions/LogicAppsManagement(defaultworkspace-d0610b27-9663-4c05-89f8-5b4be01e86a5-eus)" -Top 2
	Validate-PolicyStates $policyStates 2
}

<#
.SYNOPSIS
Get all policy states at resource scope
#>
function Get-AzureRmPolicyState-AllResourceScope
{
    $policyStates = Get-AzureRmPolicyState -All -ResourceId "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/defaultresourcegroup-eus/providers/Microsoft.OperationsManagement/solutions/LogicAppsManagement(defaultworkspace-d0610b27-9663-4c05-89f8-5b4be01e86a5-eus)" -Top 2
	Validate-PolicyStates $policyStates 2
}

<#
.SYNOPSIS
Get latest policy states at policy set definition scope
#>
function Get-AzureRmPolicyState-LatestPolicySetDefinitionScope
{
    $policyStates = Get-AzureRmPolicyState -PolicySetDefinitionName a03db67e-a286-43c3-9098-b2da83d361ad -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at policy set definition scope
#>
function Get-AzureRmPolicyState-AllPolicySetDefinitionScope
{
    $policyStates = Get-AzureRmPolicyState -All -PolicySetDefinitionName a03db67e-a286-43c3-9098-b2da83d361ad -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at policy definition scope
#>
function Get-AzureRmPolicyState-LatestPolicyDefinitionScope
{
    $policyStates = Get-AzureRmPolicyState -PolicyDefinitionName 71ff7afc-0e90-481b-b19d-38106ce490f1 -Top 3
	Validate-PolicyStates $policyStates 3
}

<#
.SYNOPSIS
Get all policy states at policy definition scope
#>
function Get-AzureRmPolicyState-AllPolicyDefinitionScope
{
    $policyStates = Get-AzureRmPolicyState -All -PolicyDefinitionName 71ff7afc-0e90-481b-b19d-38106ce490f1 -Top 3
	Validate-PolicyStates $policyStates 3
}

<#
.SYNOPSIS
Get latest policy states at subscription level policy assignment scope
#>
function Get-AzureRmPolicyState-LatestSubscriptionLevelPolicyAssignmentScope
{
    $policyStates = Get-AzureRmPolicyState -PolicyAssignmentName 0727ffc1697048c5b4884aef -Top 1
	Validate-PolicyStates $policyStates 1
}

<#
.SYNOPSIS
Get all policy states at subscription level policy assignment scope
#>
function Get-AzureRmPolicyState-AllSubscriptionLevelPolicyAssignmentScope
{
    $policyStates = Get-AzureRmPolicyState -All -PolicyAssignmentName 0727ffc1697048c5b4884aef -Top 1
	Validate-PolicyStates $policyStates 1
}

<#
.SYNOPSIS
Get latest policy states at resource group level policy assignment scope
#>
function Get-AzureRmPolicyState-LatestResourceGroupLevelPolicyAssignmentScope
{
    $policyStates = Get-AzureRmPolicyState -ResourceGroupName bulenttestrg -PolicyAssignmentName f4d1645d-9180-4968-99df-17234d0f7019 -Top 2
	Validate-PolicyStates $policyStates 2
}

<#
.SYNOPSIS
Get all policy states at resource group level policy assignment scope
#>
function Get-AzureRmPolicyState-AllResourceGroupLevelPolicyAssignmentScope
{
    $policyStates = Get-AzureRmPolicyState -All -ResourceGroupName bulenttestrg -PolicyAssignmentName f4d1645d-9180-4968-99df-17234d0f7019 -Top 2
	Validate-PolicyStates $policyStates 2
}
