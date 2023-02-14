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

function Get-User
{
	return getAssetName
}

<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetNonExistingUser
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$name = Get-User
	
	# Test
	Assert-ThrowsContains { Get-AzDataBoxEdgeUser -ResourceGroupName $rgname -DeviceName $dfname -Name $name  } "not find"	
}


<#
.SYNOPSIS
Tests Create New User
#>
function Test-CreateNewUser
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$name = Get-User
	
	$passwordString = Get-Userpassword
	$password = ConvertTo-SecureString $passwordString -AsPlainText -Force
	$encryptionKey = Get-EncryptionKey 
		
	# Test
	try
	{
		$expected = New-AzDataBoxEdgeUser $rgname $dfname $name -Password $password -EncryptionKey $encryptionKey
		Assert-AreEqual $expected.Name $name
	}
	finally
	{
		Remove-AzDataBoxEdgeUser $rgname $dfname $name
	}  
}


<#
.SYNOPSIS
Test remove User. Creates new user then removes user and try to get the user
#>
function Test-RemoveUser
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$name = Get-User

	$password = Get-Userpassword
	$encryptionKey = Get-EncryptionKey

	# Test
	try
	{
		$expected = New-AzDataBoxEdgeUser $rgname $dfname $name -Password $password -EncryptionKey $encryptionKey
		Assert-AreEqual $expected.Name $name
		Remove-AzDataBoxEdgeUser $rgname $dfname $name
	}
	finally
	{
		Assert-ThrowsContains { Get-AzDataBoxEdgeUser -ResourceGroupName $rgname -DeviceName $dfname -Name $name  } "not find"	
	}  
}