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
    $policyStateSummary = Get-AzureRmPolicyStateSummary -ManagementGroupName "AzGovTest1"
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at subscription scope
#>
function Get-AzureRmPolicyStateSummary-SubscriptionScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at resource group scope
#>
function Get-AzureRmPolicyStateSummary-ResourceGroupScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -ResourceGroupName defaultresourcegroup-eus
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at resource scope
#>
function Get-AzureRmPolicyStateSummary-ResourceScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -ResourceId "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourcegroups/defaultresourcegroup-eus/providers/Microsoft.OperationsManagement/solutions/LogicAppsManagement(defaultworkspace-d0610b27-9663-4c05-89f8-5b4be01e86a5-eus)"
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at policy set definition scope
#>
function Get-AzureRmPolicyStateSummary-PolicySetDefinitionScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -PolicySetDefinitionName a03db67e-a286-43c3-9098-b2da83d361ad
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at policy definition scope
#>
function Get-AzureRmPolicyStateSummary-PolicyDefinitionScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -PolicyDefinitionName 71ff7afc-0e90-481b-b19d-38106ce490f1
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at subscription level policy assignment scope
#>
function Get-AzureRmPolicyStateSummary-SubscriptionLevelPolicyAssignmentScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -PolicyAssignmentName 0727ffc1697048c5b4884aef
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at resource group level policy assignment scope
#>
function Get-AzureRmPolicyStateSummary-ResourceGroupLevelPolicyAssignmentScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -ResourceGroupName bulenttestrg -PolicyAssignmentName f4d1645d-9180-4968-99df-17234d0f7019
	Validate-PolicyStateSummary $policyStateSummary
}
