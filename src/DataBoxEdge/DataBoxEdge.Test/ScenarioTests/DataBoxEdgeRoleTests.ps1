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
	Assert-ThrowsContains { Get-AzDataBoxEdgeRole $rgname $dfname $name  } "not find"    
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

	$deviceConnectionString = "HostName=iothub.azure-devices.net;DeviceId=iotDevice;SharedAccessKey=2C750FscEas3JmQ8Bnui5yQWZPyml0/UiRt1bQwd8="
	$deviceConnSec = ConvertTo-SecureString $deviceConnectionString -AsPlainText -Force

	$iotDeviceConnectionString = "HostName=iothub.azure-devices.net;DeviceId=iotEdge;SharedAccessKey=2C750FscEas3JmQ8Bnui5yQWZPyml0/UiRt1bQwd8="
	$iotDeviceConnSec = ConvertTo-SecureString $iotDeviceConnectionString -AsPlainText -Force

	$encryptionKey = ConvertTo-SecureString -String "d8c66216b4fb71c3fe572a5592dbedcef5eb6f3c45d3b0e38c94f9b838e92d38a89bdda7a269c9da3b126906d037904c0d4451d4442c4ff8ef70124501d67fd2" -AsPlainText -Force

	$enabled = "Enabled"
	$platform = "Windows"
    # Test
	try
    {
		$expected  = New-AzDataBoxEdgeRole -ResourceGroupName $rgname -DeviceName $dfname -Name $name -ConnectionString -IotEdgeDeviceConnectionString $iotDeviceConnSec -IotDeviceConnectionString $deviceConnSec -Platform $platform -RoleStatus $enabled -EncryptionKey $encryptionKey
        Assert-AreEqual $expected.Name $name	
    }
    finally
    {
		Remove-AzDataBoxEdgeRole $rgname $dfname $name
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

	$deviceConnectionString = "HostName=iothub.azure-devices.net;DeviceId=iotDevice;SharedAccessKey=2C750FscEas3JmQ8Bnui5yQWZPyml0/UiRt1bQwd8="
	$deviceConnSec = ConvertTo-SecureString $deviceConnectionString -AsPlainText -Force

	$iotDeviceConnectionString = "HostName=iothub.azure-devices.net;DeviceId=iotEdge;SharedAccessKey=2C750FscEas3JmQ8Bnui5yQWZPyml0/UiRt1bQwd8="
	$iotDeviceConnSec = ConvertTo-SecureString $iotDeviceConnectionString -AsPlainText -Force

	$encryptionKey = ConvertTo-SecureString -String "d8c66216b4fb71c3fe572a5592dbedcef5eb6f3c45d3b0e38c94f9b838e92d38a89bdda7a269c9da3b126906d037904c0d4451d4442c4ff8ef70124501d67fd2" -AsPlainText -Force

	$enabled = "Enabled"
	$platform = "Windows"
    # Test
	try
    {
		$expected  = New-AzDataBoxEdgeRole -ResourceGroupName $rgname -DeviceName $dfname -Name $name -ConnectionString -IotEdgeDeviceConnectionString $iotDeviceConnSec -IotDeviceConnectionString $deviceConnSec -Platform $platform -RoleStatus $enabled -EncryptionKey $encryptionKey
		Remove-AzDataBoxEdgeRole $rgname $dfname $name
    }
    finally
    {
		Assert-ThrowsContains { Get-AzDataBoxEdgeRole $rgname $dfname $name  } "not find"    
    }  
}