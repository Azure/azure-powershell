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
Get Allowed Connections on a subscription scope
#>
function Get-AzureRmAllowedConnections-SubscriptionScope
{
    $AllowedConnections = Get-AzAllowedConnections
	Validate-AllowedConnections $AllowedConnections
}

<#
.SYNOPSIS
Get Allowed Connections
#>
function Get-AzureRmAllowedConnections-ResourceGroupLevelResource
{
	$AllowedConnections = Get-AzAllowedConnections | Select -First 1
	$rgName = Extract-ResourceGroup -ResourceId $AllowedConnections.Id
	$location = Extract-ResourceLocation -ResourceId $AllowedConnections.Id

    $fetchedAllowedConnections = Get-AzAllowedConnections -ResourceGroupName $rgName -Location $location -Name $AllowedConnections.Name
	Validate-AllowedConnections $fetchedAllowedConnections
}

<#
.SYNOPSIS
Get Allowed Connections by a resource ID
#>
function Get-AzureRmAllowedConnections-ResourceId
{
	$AllowedConnections = Get-AzAllowedConnections | Select -First 1

    $AllowedConnections = Get-AzAllowedConnections -ResourceId $AllowedConnections.Id
	Validate-AllowedConnections $AllowedConnections
}

<#
.SYNOPSIS
Validates a list of Allowed Connections
#>
function Validate-AllowedConnections
{
	param($AllowedConnections)

    Assert-True { $AllowedConnections.Count -gt 0 }

	Foreach($AllowedConnections in $AllowedConnections)
	{
		Validate-AllowedConnections $AllowedConnections
	}
}

<#
.SYNOPSIS
Validates a single Allowed Connection
#>
function Validate-AllowedConnections
{
	param($AllowedConnections)

	Assert-NotNull $AllowedConnections
}