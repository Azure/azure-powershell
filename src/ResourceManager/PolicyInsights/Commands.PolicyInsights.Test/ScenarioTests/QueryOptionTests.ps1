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
Get latest policy states at subscription scope; with From query option
#>
function QueryOptions-QueryResultsWithFrom
{
	$from = Get-TestQueryIntervalStart

    $policyStates = Get-AzureRmPolicyState -From $from -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at subscription scope; with To query option
#>
function QueryOptions-QueryResultsWithTo
{
	$to = Get-TestQueryIntervalEnd

    $policyStates = Get-AzureRmPolicyState -To $to -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at subscription scope; with Top query option
#>
function QueryOptions-QueryResultsWithTop
{
    $policyStates = Get-AzureRmPolicyState -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at subscription scope; with OrderBy query option
#>
function QueryOptions-QueryResultsWithOrderBy
{
    $policyStates = Get-AzureRmPolicyState -OrderBy "Timestamp asc, PolicyDefinitionAction, PolicyAssignmentId asc" -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at subscription scope; with Select query option
#>
function QueryOptions-QueryResultsWithSelect
{
    $policyStates = Get-AzureRmPolicyState -Select "Timestamp, ResourceId, PolicyAssignmentId, PolicyDefinitionId, IsCompliant, SubscriptionId, PolicyDefinitionAction" -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at subscription scope; with Filter query option
#>
function QueryOptions-QueryResultsWithFilter
{
    $policyStates = Get-AzureRmPolicyState -Filter "IsCompliant eq false and PolicyDefinitionAction eq 'deny'" -Top 10
	Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at subscription scope; with Apply query option
#>
function QueryOptions-QueryResultsWithApply
{
    $policyStates = Get-AzureRmPolicyState -Apply "groupby((PolicyAssignmentId, PolicyDefinitionId, ResourceId))/groupby((PolicyAssignmentId, PolicyDefinitionId), aggregate(`$count as NumResources))" -Top 10
	Foreach($policyState in $policyStates)
	{
		Assert-NotNull $policyState

		Assert-Null $policyState.ResourceId
		Assert-NotNullOrEmpty $policyState.PolicyAssignmentId
		Assert-NotNullOrEmpty $policyState.PolicyDefinitionId

		Assert-NotNull $policyState.AdditionalProperties
		Assert-NotNull $policyState.AdditionalProperties["NumResources"]
	}
}
