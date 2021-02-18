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

function Get-RoleName
{
	return getAssetName
}


<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetRoleNonExistent
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$name = Get-RoleName
	
	# Test
	Assert-ThrowsContains { Get-AzStackEdgeRole $rgname $dfname $name  } "not find"	
}

<#
.SYNOPSIS
Tests Create New Role
#>
function Test-CreateRole
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$name = Get-RoleName
	$deviceConnSec = Get-DeviceConnectionString
	$iotDeviceConnSec = Get-IotDeviceConnectionString
	$encryptionKey = Get-EncryptionKey 
	
	$enabled = "Enabled"
	$platform = "Windows"
	# Test
	try
	{
		$expected  = New-AzStackEdgeRole -ResourceGroupName $rgname -DeviceName $dfname -Name $name -ConnectionString -IotEdgeDeviceConnectionString $iotDeviceConnSec -IotDeviceConnectionString $deviceConnSec -Platform $platform -RoleStatus $enabled -EncryptionKey $encryptionKey
		Assert-AreEqual $expected.Name $name	
	}
	finally
	{
		Remove-AzStackEdgeRole $rgname $dfname $name
	}  
}

<#
.SYNOPSIS
Tests Remove Role
#>
function Test-RemoveRole
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$name = Get-RoleName
	$deviceConnSec = Get-DeviceConnectionString
	$iotDeviceConnSec = Get-IotDeviceConnectionString
	$encryptionKey = Get-EncryptionKey 
	
	$enabled = "Enabled"
	$platform = "Windows"
	# Test
	try
	{
		$expected  = New-AzStackEdgeRole -ResourceGroupName $rgname -DeviceName $dfname -Name $name -ConnectionString -IotEdgeDeviceConnectionString $iotDeviceConnSec -IotDeviceConnectionString $deviceConnSec -Platform $platform -RoleStatus $enabled -EncryptionKey $encryptionKey
		Remove-AzStackEdgeRole $rgname $dfname $name
	}
	finally
	{
		Assert-ThrowsContains { Get-AzStackEdgeRole $rgname $dfname $name  } "not find"	
	}  
}