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
Gets private stores that were defined in tenant level 
#>
function Test-GetAzMarketplacePrivateStore
{
	$propertiesCount=6
	$AvailabilityValue="enabled"
	$PrivateStoreIdValue="a70d384d-ec34-47dd-9d38-ec6df452cba1"

	$queryResult = Get-AzMarketplacePrivateStore
	
	Assert-NotNull  $queryResult
	Assert-AreEqual $queryResult.Count 1

	for ($i = 0; $i -lt $queryResult.Count; $i++)
    {
		Assert-PropertiesCount $queryResult[$i] $propertiesCount
		Assert-AreEqual $queryResult[$i].Availability $AvailabilityValue
		Assert-AreEqual $queryResult[$i].PrivateStoreId $PrivateStoreIdValue
    }
}