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

<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetStorageAccountCredentialNonExistent
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$staname = Get-StorageAccountCredentialName
	
	# Test
	Assert-ThrowsContains { Get-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname  } "not find"
}

<#
.SYNOPSIS
Tests Create New StorageAccountCredential
#>
function Test-CreateStorageAccountCredential
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$staname = Get-StorageAccountCredentialName
	$encryptionKey = Get-EncryptionKey 
	
	$storageAccountType = 'GeneralPurposeStorage'
	$storageAccountSkuName = 'Standard_LRS'
	$storageAccountLocation = 'WestUS'
	$storageAccount = New-AzStorageAccount $rgname $staname $storageAccountSkuName -Location $storageAccountLocation

	$storageAccountKeys = Get-AzStorageAccountKey $rgname $staname
	$storageAccountKey = ConvertTo-SecureString $storageAccountKeys[0] -AsPlainText -Force
	# Test
	try
	{
		$expected = New-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname -StorageAccountType $storageAccountType -StorageAccountAccessKey $storageAccountKey -EncryptionKey $encryptionKey
		Assert-AreEqual $expected.Name $staname
		
	}
	finally
	{
		Remove-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname
		Remove-AzStorageAccount $rgname $staname
	}  
}

<#
.SYNOPSIS
Tests Remove StorageAccountCredential
#>
function Test-RemoveStorageAccountCredential
{	
	 $rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$staname = Get-StorageAccountCredentialName 
	$encryptionKey = Get-EncryptionKey

	$storageAccountType = 'GeneralPurposeStorage'
	$storageAccountSkuName = 'Standard_LRS'
	$storageAccountLocation = 'WestUS'
	$storageAccount = New-AzStorageAccount $rgname $staname $storageAccountSkuName -Location $storageAccountLocation

	$storageAccountKeys = Get-AzStorageAccountKey $rgname $staname
	$storageAccountKey = ConvertTo-SecureString $storageAccountKeys[0] -AsPlainText -Force
	# Test
	try
	{
		New-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname -StorageAccountType $storageAccountType -StorageAccountAccessKey $storageAccountKey -EncryptionKey $encryptionKey
		Remove-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname
	}
	finally
	{
		Assert-ThrowsContains { Get-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname  } "not find"	
		Remove-AzStorageAccount $rgname $staname 
	}  
}
