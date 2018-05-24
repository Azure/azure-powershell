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
    $policyStateSummary = Get-AzureRmPolicyStateSummary -ManagementGroupName $ManagementGroupName -Top $Top -From $From
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at subscription scope
#>
function Get-AzureRmPolicyStateSummary-SubscriptionScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -Top $Top -From $From
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at resource group scope
#>
function Get-AzureRmPolicyStateSummary-ResourceGroupScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -ResourceGroupName $ResourceGroupName -Top $Top -From $From
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at resource scope
#>
function Get-AzureRmPolicyStateSummary-ResourceScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -ResourceId $ResourceId -Top $Top -From $From
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at policy set definition scope
#>
function Get-AzureRmPolicyStateSummary-PolicySetDefinitionScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -PolicySetDefinitionName $PolicySetDefinitionName -Top $Top -From $From
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at policy definition scope
#>
function Get-AzureRmPolicyStateSummary-PolicyDefinitionScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -PolicyDefinitionName $PolicyDefinitionName -Top $Top -From $From
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at subscription level policy assignment scope
#>
function Get-AzureRmPolicyStateSummary-SubscriptionLevelPolicyAssignmentScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -PolicyAssignmentName $PolicyAssignmentName -Top $Top -From $From
	Validate-PolicyStateSummary $policyStateSummary
}

<#
.SYNOPSIS
Get policy states summary at resource group level policy assignment scope
#>
function Get-AzureRmPolicyStateSummary-ResourceGroupLevelPolicyAssignmentScope
{
    $policyStateSummary = Get-AzureRmPolicyStateSummary -ResourceGroupName $ResourceGroupName -PolicyAssignmentName $PolicyAssignmentName -Top $Top -From $From
	Validate-PolicyStateSummary $policyStateSummary
}
