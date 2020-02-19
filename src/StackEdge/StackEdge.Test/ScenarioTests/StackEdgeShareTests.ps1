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

function Get-StorageAccountCredentialName
{
	return getAssetName
}

function Get-ShareName
{
	return getAssetName
}



<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetShareNonExistent
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$sharename = Get-ShareName
	
	# Test
	Assert-ThrowsContains { Get-AzStackEdgeShare $rgname $dfname $sharename  } "not find"	
}

<#
.SYNOPSIS
Tests Create New StorageAccountCredential
#>
function Test-CreateShare
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$sharename = Get-ShareName
	$dataFormat = 'BlockBlob'


	$staname = Get-StorageAccountCredentialName
	$encryptionKey = Get-EncryptionKey 
	$storageAccountType = 'GeneralPurposeStorage'
	$storageAccountSkuName = 'Standard_LRS'
	$storageAccountLocation = 'WestUS'
	$storageAccount = New-AzStorageAccount $rgname $staname $storageAccountSkuName -Location $storageAccountLocation

	$storageAccountKeys = Get-AzStorageAccountKey $rgname $staname
	$storageAccountKey = ConvertTo-SecureString $storageAccountKeys[0] -AsPlainText -Force
	$storageAccountCredential = New-AzStackEdgeStorageAccountCredential $rgname $dfname $staname -StorageAccountType $storageAccountType -StorageAccountAccessKey $storageAccountKey -EncryptionKey $encryptionKey
		
	# Test
	try
	{
		$expected = New-AzStackEdgeShare $rgname $dfname $sharename $storageAccountCredential.Name -SMB -DataFormat $dataFormat
		Assert-AreEqual $expected.Name $sharename
		
	}
	finally
	{
		Remove-AzStackEdgeShare $rgname $dfname $sharename
		Remove-AzStackEdgeStorageAccountCredential $rgname $dfname $staname
		Remove-AzStorageAccount $rgname $staname
	}  
}

function Test-CreateLocalShare
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$sharename = Get-ShareName
		
	# Test
	try
	{
		$expected = New-AzStackEdgeShare $rgname $dfname $sharename -NFS 
		Assert-AreEqual $expected.Name $sharename
		
	}
	finally
	{
		Remove-AzStackEdgeShare $rgname $dfname $sharename
	}  
}

<#
.SYNOPSIS
Tests Create New StorageAccountCredential
#>
function Test-RemoveShare
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$sharename = Get-ShareName
	
	# Test
	
	$expected = New-AzStackEdgeShare $rgname $dfname $sharename -SMB
	Assert-AreEqual $expected.Name $sharename
	Remove-AzStackEdgeShare $rgname $dfname $sharename
	Assert-ThrowsContains { Get-AzStackEdgeShare $rgname $dfname $sharename  } "not find"	

		
	
}
