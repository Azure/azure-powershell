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
Test ExpressRoutePortsLocation
#>
function Test-ExpressRoutePortsLocationRead
{
    $vExpressRoutePortsLocationList = Get-AzureRmExpressRoutePortsLocation
    Assert-NotNull $vExpressRoutePortsLocationList
	Assert-True { $vExpressRoutePortsLocationList.Count -eq 6 }
	Assert-NotNull $vExpressRoutePortsLocationList[0].Address
	Assert-NotNull $vExpressRoutePortsLocationList[0].Contact
	Assert-NotNull $vExpressRoutePortsLocationList[0].AvailableBandwidths
	Assert-True { $vExpressRoutePortsLocationList[0].AvailableBandwidths.Count -eq 0 }

	# Get details of a location
	$vExpressRoutePortsLocation = Get-AzureRmExpressRoutePortsLocation -LocationName "Cheyenne-ERDirect"
	Assert-NotNull $vExpressRoutePortsLocation
	Assert-NotNull $vExpressRoutePortsLocation.Address
	Assert-NotNull $vExpressRoutePortsLocation.Contact
	Assert-NotNull $vExpressRoutePortsLocation.AvailableBandwidths
	Assert-True { $vExpressRoutePortsLocation.AvailableBandwidths.Count -eq 1 }
}
