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
Test List Resource Skus
#>
function Test-GetResourceSku
{
	$skulist = Get-AzComputeResourceSku | where {$_.Locations -eq "eastus"};
	Assert-True { $skulist.Count -gt 0; }
	$output = $skulist | Out-String;
	Assert-True { $output.Contains("availabilitySets"); }
	Assert-True { $output.Contains("virtualMachines"); }
	Assert-True { $output.Contains("Zones"); }
}

<#
.SYNOPSIS
Test List Resource Skus by Location
#>
function Test-GetResourceSkuByLocation
{
	$skulist = Get-AzComputeResourceSku "westus" | where {$_.Locations -eq "eastus"};
	Assert-True { $skulist.Count -eq 0; }
}
