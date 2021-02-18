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
function Get-AzureRmAllowedConnection-SubscriptionScope
{
    $AllowedConnection = Get-AzAllowedConnection
	Validate-AllowedConnection $AllowedConnection
}

<#
.SYNOPSIS
Get Allowed Connections
#>
function Get-AzureRmAllowedConnection-ResourceGroupLevelResource
{
	$AllowedConnection = Get-AzAllowedConnection | Select -First 1
	$rgName = Extract-ResourceGroup -ResourceId $AllowedConnection.Id
	$location = Extract-ResourceLocation -ResourceId $AllowedConnection.Id

    $fetchedAllowedConnection = Get-AzAllowedConnection -ResourceGroupName $rgName -Location $location -Name $AllowedConnection.Name
	Validate-AllowedConnection $fetchedAllowedConnection
}

<#
.SYNOPSIS
Get Allowed Connections by a resource ID
#>
function Get-AzureRmAllowedConnection-ResourceId
{
	$AllowedConnection = Get-AzAllowedConnection | Select -First 1

    $AllowedConnection = Get-AzAllowedConnection -ResourceId $AllowedConnection.Id
	Validate-AllowedConnection $AllowedConnection
}

<#
.SYNOPSIS
Validates a list of Allowed Connections
#>
function Validate-AllowedConnection
{
	param($AllowedConnection)

    Assert-True { $AllowedConnection.Count -gt 0 }

	Foreach($AllowedConnection in $AllowedConnection)
	{
		Validate-AllowedConnection $AllowedConnection
	}
}

<#
.SYNOPSIS
Validates a single Allowed Connection
#>
function Validate-AllowedConnection
{
	param($AllowedConnection)

	Assert-NotNull $AllowedConnection
}