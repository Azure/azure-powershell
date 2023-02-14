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

function Get-PSResourceGroupName
{
	return Get-DeviceResourceGroupName
}

function Get-PSDeviceName
{
	return getAssetName
}

<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetDeviceNonExistent
{	
	$rgname = Get-PSResourceGroupName
	$dfname = Get-PSDeviceName
	
	# Test
	Assert-ThrowsContains { Get-AzDataBoxEdgeDevice $rgname $dfname } "not found"	
}

<#
.SYNOPSIS
Tests Create New StorageAccountCredential
#>
function Test-CreateDevice
{	
	$rgname = Get-PSResourceGroupName
	$dfname = Get-PSDeviceName
	$sku = 'Edge'
	$location = 'westus2'

	# Test
	try
	{
		$expected = New-AzDataBoxEdgeDevice $rgname $dfname -Sku $sku -Location $location
		Assert-AreEqual $expected.Name $dfname
		
	}
	finally
	{
		Remove-AzDataBoxEdgeDevice $rgname $dfname
	}  
}

<#
.SYNOPSIS
Tests Create New StorageAccountCredential
#>
function Test-RemoveDevice
{	
	$rgname = Get-PSResourceGroupName
	$dfname = Get-PSDeviceName
	$sku = 'Edge'
	$location = 'westus2'

		
	# Test
	$expected = New-AzDataBoxEdgeDevice $rgname $dfname -Sku $sku -Location $location
	Remove-AzDataBoxEdgeDevice $rgname $dfname
	Assert-ThrowsContains { Get-AzDataBoxEdgeDevice $rgname $dfname } "not found"
	
}
