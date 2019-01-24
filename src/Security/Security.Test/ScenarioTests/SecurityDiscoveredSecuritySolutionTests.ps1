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
Get discovered security solutions on a subscription scope
#>
function Get-AzureRmDiscoveredSecuritySolution-SubscriptionScope
{
    $discoveredSecuritySolutions = Get-AzDiscoveredSecuritySolution
	Validate-DiscoveredSecuritySolutions $discoveredSecuritySolutions
}

<#
.SYNOPSIS
Get discovered security solution
#>
function Get-AzureRmDiscoveredSecuritySolution-ResourceGroupLevelResource
{
	$discoveredSecuritySolution = Get-AzDiscoveredSecuritySolution | Select -First 1
	$rgName = Extract-ResourceGroup -ResourceId $discoveredSecuritySolution.Id
	$location = Extract-ResourceLocation -ResourceId $discoveredSecuritySolution.Id

    $fetchedDiscoveredSecuritySolution = Get-AzDiscoveredSecuritySolution -ResourceGroupName $rgName -Location $location -Name $discoveredSecuritySolution.Name
	Validate-DiscoveredSecuritySolution $fetchedDiscoveredSecuritySolution
}

<#
.SYNOPSIS
Get discovered security solution by a resource ID
#>
function Get-AzureRmDiscoveredSecuritySolution-ResourceId
{
	$discoveredSecuritySolution = Get-AzDiscoveredSecuritySolution | Select -First 1

    $discoveredSecuritySolutions = Get-AzDiscoveredSecuritySolution -ResourceId $discoveredSecuritySolution.Id
	Validate-DiscoveredSecuritySolutions $discoveredSecuritySolutions
}

<#
.SYNOPSIS
Validates a list of security discoveredSecuritySolutions
#>
function Validate-DiscoveredSecuritySolutions
{
	param($discoveredSecuritySolutions)

    Assert-True { $discoveredSecuritySolutions.Count -gt 0 }

	Foreach($discoveredSecuritySolution in $discoveredSecuritySolutions)
	{
		Validate-DiscoveredSecuritySolution $discoveredSecuritySolution
	}
}

<#
.SYNOPSIS
Validates a single discoveredSecuritySolution
#>
function Validate-DiscoveredSecuritySolution
{
	param($discoveredSecuritySolution)

	Assert-NotNull $discoveredSecuritySolution
}