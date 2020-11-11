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
Get external security solutions on a subscription scope
#>
function Get-AzureRmExternalSecuritySolution-SubscriptionScope
{
    $externalSecuritySolutions = Get-AzExternalSecuritySolution
	Validate-ExternalSecuritySolutions $externalSecuritySolutions
}

<#
.SYNOPSIS
Get external security solution
#>
function Get-AzureRmExternalSecuritySolution-ResourceGroupLevelResource
{
	$externalSecuritySolutions = Get-AzExternalSecuritySolution
	$externalSecuritySolution = $externalSecuritySolutions | Select -First 1
	$rgName = Extract-ResourceGroup -ResourceId $externalSecuritySolution.Id
	$location = Extract-ResourceLocation -ResourceId $externalSecuritySolution.Id

    $fetchedExternalSecuritySolution = Get-AzExternalSecuritySolution -ResourceGroupName $rgName -Location $location -Name $externalSecuritySolution.Name
	Validate-ExternalSecuritySolution $fetchedExternalSecuritySolution
}

<#
.SYNOPSIS
Get external security solution by a resource ID
#>
function Get-AzureRmExternalSecuritySolution-ResourceId
{
	$externalSecuritySolution = Get-AzExternalSecuritySolution | Select -First 1

    $fetchedExternalSecuritySolution = Get-AzExternalSecuritySolution -ResourceId $externalSecuritySolution.Id
	Validate-ExternalSecuritySolution $fetchedExternalSecuritySolution
}

<#
.SYNOPSIS
Validates a list of security externalSecuritySolutions
#>
function Validate-ExternalSecuritySolutions
{
	param($externalSecuritySolutions)

    Assert-True { $externalSecuritySolutions.Count -gt 0 }

	Foreach($externalSecuritySolution in $externalSecuritySolutions)
	{
		Validate-ExternalSecuritySolution $externalSecuritySolution
	}
}

<#
.SYNOPSIS
Validates a single externalSecuritySolution
#>
function Validate-ExternalSecuritySolution
{
	param($externalSecuritySolution)

	Assert-NotNull $externalSecuritySolution
}