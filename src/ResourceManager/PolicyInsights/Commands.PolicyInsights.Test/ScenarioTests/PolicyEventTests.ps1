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
    $policyEvents = Get-AzureRmPolicyEvent -ManagementGroupName $ManagementGroupName -Top $Top -From $From
	Validate-PolicyEvents $policyEvents $Top
}

<#
.SYNOPSIS
Get policy events at subscription scope
#>
function Get-AzureRmPolicyEvent-SubscriptionScope
{
    $policyEvents = Get-AzureRmPolicyEvent -Top $Top -From $From
	Validate-PolicyEvents $policyEvents $Top
}

<#
.SYNOPSIS
Get policy events at resource group scope
#>
function Get-AzureRmPolicyEvent-ResourceGroupScope
{
    $policyEvents = Get-AzureRmPolicyEvent -ResourceGroupName $ResourceGroupName -Top $Top -From $From
	Validate-PolicyEvents $policyEvents $Top
}

<#
.SYNOPSIS
Get policy events at resource scope
#>
function Get-AzureRmPolicyEvent-ResourceScope
{
    $policyEvents = Get-AzureRmPolicyEvent -ResourceId $ResourceId -Top $Top -From $From
	Validate-PolicyEvents $policyEvents $Top
}

<#
.SYNOPSIS
Get policy events at policy set definition scope
#>
function Get-AzureRmPolicyEvent-PolicySetDefinitionScope
{
    $policyEvents = Get-AzureRmPolicyEvent -PolicySetDefinitionName $PolicySetDefinitionName -Top $Top -From $From
	Validate-PolicyEvents $policyEvents $Top
}

<#
.SYNOPSIS
Get policy events at policy definition scope
#>
function Get-AzureRmPolicyEvent-PolicyDefinitionScope
{
    $policyEvents = Get-AzureRmPolicyEvent -PolicyDefinitionName $PolicyDefinitionName -Top $Top -From $From
	Validate-PolicyEvents $policyEvents $Top
}

<#
.SYNOPSIS
Get policy events at subscription level policy assignment scope
#>
function Get-AzureRmPolicyEvent-SubscriptionLevelPolicyAssignmentScope
{
    $policyEvents = Get-AzureRmPolicyEvent -PolicyAssignmentName $PolicyAssignmentName -Top $Top -From $From
	Validate-PolicyEvents $policyEvents $Top
}

<#
.SYNOPSIS
Get policy events at resource group level policy assignment scope
#>
function Get-AzureRmPolicyEvent-ResourceGroupLevelPolicyAssignmentScope
{
    $policyEvents = Get-AzureRmPolicyEvent -ResourceGroupName $ResourceGroupName -PolicyAssignmentName $PolicyAssignmentName -Top $Top -From $From
	Validate-PolicyEvents $policyEvents $Top
}
