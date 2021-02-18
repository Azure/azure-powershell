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

function Get-EdgeStorageAccountName
{
	return getAssetName
}



<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetEdgeStorageAccountNonExistent
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$estaname = Get-EdgeStorageAccountName
	
	# Test
	Assert-ThrowsContains { Get-AzStackEdgeStorageAccount $rgname $dfname $estaname } "not find"	
}

<#
.SYNOPSIS
Tests Create New StorageAccountCredential
#>
function Test-CreateEdgeStorageAccount
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$edgeStorageAccountName = Get-EdgeStorageAccountName
	

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
		$expected = New-AzStackEdgeStorageAccount $rgname $dfname $edgeStorageAccountName -StorageAccountCredentialName $storageAccountCredential.Name
		Assert-AreEqual $expected.Name $edgeStorageAccountName
		
	}
	finally
	{
		Remove-AzStackEdgeStorageAccount $rgname $dfname $edgeStorageAccountName
		Remove-AzStackEdgeStorageAccountCredential $rgname $dfname $staname
		Remove-AzStorageAccount $rgname $staname
	}  
}

<#
.SYNOPSIS
Tests Create New StorageAccountCredential
#>
function Test-RemoveEdgeStorageAccount
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$edgeStorageAccountName = Get-EdgeStorageAccountName
	

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
		New-AzStackEdgeStorageAccount $rgname $dfname $edgeStorageAccountName -StorageAccountCredentialName $storageAccountCredential.Name
		Remove-AzStackEdgeStorageAccount $rgname $dfname $edgeStorageAccountName
		Assert-ThrowsContains { Get-AzStackEdgeStorageAccount $rgname $dfname $edgeStorageAccountName  } "not find"	
	
	}
	finally
	{
		Remove-AzStackEdgeStorageAccountCredential $rgname $dfname $staname
		Remove-AzStorageAccount $rgname $staname
	}  
	
		
	
}
