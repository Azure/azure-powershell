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
    $policyStates = Get-AzureRmPolicyState -ManagementGroupName $ManagementGroupName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get all policy states at management group scope
#>
function Get-AzureRmPolicyState-AllManagementGroupScope
{
    $policyStates = Get-AzureRmPolicyState -All -ManagementGroupName $ManagementGroupName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get latest policy states at subscription scope
#>
function Get-AzureRmPolicyState-LatestSubscriptionScope
{
    $policyStates = Get-AzureRmPolicyState -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get all policy states at subscription scope
#>
function Get-AzureRmPolicyState-AllSubscriptionScope
{
    $policyStates = Get-AzureRmPolicyState -All -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get latest policy states at resource group scope
#>
function Get-AzureRmPolicyState-LatestResourceGroupScope
{
    $policyStates = Get-AzureRmPolicyState -ResourceGroupName $ResourceGroupName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get all policy states at resource group scope
#>
function Get-AzureRmPolicyState-AllResourceGroupScope
{
    $policyStates = Get-AzureRmPolicyState -All -ResourceGroupName $ResourceGroupName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get latest policy states at resource scope
#>
function Get-AzureRmPolicyState-LatestResourceScope
{
    $policyStates = Get-AzureRmPolicyState -ResourceId $ResourceId -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get all policy states at resource scope
#>
function Get-AzureRmPolicyState-AllResourceScope
{
    $policyStates = Get-AzureRmPolicyState -All -ResourceId $ResourceId -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get latest policy states at policy set definition scope
#>
function Get-AzureRmPolicyState-LatestPolicySetDefinitionScope
{
    $policyStates = Get-AzureRmPolicyState -PolicySetDefinitionName $PolicySetDefinitionName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get all policy states at policy set definition scope
#>
function Get-AzureRmPolicyState-AllPolicySetDefinitionScope
{
    $policyStates = Get-AzureRmPolicyState -All -PolicySetDefinitionName $PolicySetDefinitionName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get latest policy states at policy definition scope
#>
function Get-AzureRmPolicyState-LatestPolicyDefinitionScope
{
    $policyStates = Get-AzureRmPolicyState -PolicyDefinitionName $PolicyDefinitionName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get all policy states at policy definition scope
#>
function Get-AzureRmPolicyState-AllPolicyDefinitionScope
{
    $policyStates = Get-AzureRmPolicyState -All -PolicyDefinitionName $PolicyDefinitionName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get latest policy states at subscription level policy assignment scope
#>
function Get-AzureRmPolicyState-LatestSubscriptionLevelPolicyAssignmentScope
{
    $policyStates = Get-AzureRmPolicyState -PolicyAssignmentName $PolicyAssignmentName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get all policy states at subscription level policy assignment scope
#>
function Get-AzureRmPolicyState-AllSubscriptionLevelPolicyAssignmentScope
{
    $policyStates = Get-AzureRmPolicyState -All -PolicyAssignmentName $PolicyAssignmentName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get latest policy states at resource group level policy assignment scope
#>
function Get-AzureRmPolicyState-LatestResourceGroupLevelPolicyAssignmentScope
{
    $policyStates = Get-AzureRmPolicyState -ResourceGroupName $ResourceGroupName -PolicyAssignmentName $PolicyAssignmentName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}

<#
.SYNOPSIS
Get all policy states at resource group level policy assignment scope
#>
function Get-AzureRmPolicyState-AllResourceGroupLevelPolicyAssignmentScope
{
    $policyStates = Get-AzureRmPolicyState -All -ResourceGroupName $ResourceGroupName -PolicyAssignmentName $PolicyAssignmentName -Top $Top -From $From
	Validate-PolicyStates $policyStates $Top
}
