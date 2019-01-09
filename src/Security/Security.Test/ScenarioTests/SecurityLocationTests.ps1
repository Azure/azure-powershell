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
Get security locations on a subscription
#>
function Get-AzureRmSecurityLocation-SubscriptionScope
{
    $locations = Get-AzSecurityLocation
	Validate-Locations $locations
}

<#
.SYNOPSIS
Get security location on a subscription
#>
function Get-AzureRmSecurityLocation-SubscriptionLevelResource
{
	$location = Get-AzSecurityLocation | Select -First 1
    $fetchedLocation = Get-AzSecurityLocation -Name $location.Name
	Validate-Location $fetchedLocation
}

<#
.SYNOPSIS
Get security location by resource ID
#>
function Get-AzureRmSecurityLocation-ResourceId
{
	$location = Get-AzSecurityLocation | Select -First 1
    $fetchedLocation = Get-AzSecurityLocation -ResourceId $location.Id
	Validate-Location $fetchedLocation
}

<#
.SYNOPSIS
Validates a list of security locations
#>
function Validate-Locations
{
	param($locations)

    Assert-True { $locations.Count -gt 0 }

	Foreach($location in $locations)
	{
		Validate-Location $location
	}
}

<#
.SYNOPSIS
Validates a single location
#>
function Validate-Location
{
	param($location)

	Assert-NotNull $location
}