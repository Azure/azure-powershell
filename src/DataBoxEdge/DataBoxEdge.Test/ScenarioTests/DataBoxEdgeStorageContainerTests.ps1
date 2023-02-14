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

function Get-EdgeStorageContainerName
{
	return getAssetName
}



<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetEdgeStorageContainerNonExistent
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$estaname = Get-EdgeStorageAccountName
	$ecntname = Get-EdgeStorageContainerName
	
	# Test
	Assert-ThrowsContains { Get-AzDataBoxEdgeStorageContainer $rgname $dfname $ecntname } "not find"	
}

<#
.SYNOPSIS
Tests Create New StorageAccountCredential
#>
function Test-CreateEdgeStorageContainer
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$edgeStorageAccountName = Get-EdgeStorageAccountName
	$edgeStorageContainerName = Get-EdgeStorageContainerName
	

	$staname = Get-StorageAccountCredentialName
	$encryptionKey = Get-EncryptionKey 
	$storageAccountType = 'GeneralPurposeStorage'
	$storageAccountSkuName = 'Standard_LRS'
	$storageAccountLocation = 'WestUS'
	$storageAccount = New-AzStorageAccount $rgname $staname $storageAccountSkuName -Location $storageAccountLocation

	$storageAccountKeys = Get-AzStorageAccountKey $rgname $staname
	$storageAccountKey = ConvertTo-SecureString $storageAccountKeys[0] -AsPlainText -Force
	$storageAccountCredential = New-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname -StorageAccountType $storageAccountType -StorageAccountAccessKey $storageAccountKey -EncryptionKey $encryptionKey
	$edgeStorageAccount = New-AzDataBoxEdgeStorageAccount $rgname $dfname $edgeStorageAccountName -StorageAccountCredentialName $storageAccountCredential.Name
	# Test
	try
	{
		$expected = New-AzDataBoxEdgeStorageContainer $rgname $dfname $edgeStorageAccountName -Name $edgeStorageContainerName -DataFormat BlockBlob
		Assert-AreEqual $expected.Name $edgeStorageContainerName
		
	}
	finally
	{
		Remove-AzDataBoxEdgeStorageContainer $rgname $dfname $edgeStorageAccountName $edgeStorageContainerName
		Remove-AzDataBoxEdgeStorageAccount $rgname $dfname $edgeStorageAccountName
		Remove-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname
		Remove-AzStorageAccount $rgname $staname
	}  
}

<#
.SYNOPSIS
Tests Create New StorageAccountCredential
#>

function Test-RemoveEdgeStorageContainer
{	
	$rgname = Get-DeviceResourceGroupName
	$dfname = Get-DeviceName
	$edgeStorageAccountName = Get-EdgeStorageAccountName
	$edgeStorageContainerName = Get-EdgeStorageContainerName
	

	$staname = Get-StorageAccountCredentialName
	$encryptionKey = Get-EncryptionKey 
	$storageAccountType = 'GeneralPurposeStorage'
	$storageAccountSkuName = 'Standard_LRS'
	$storageAccountLocation = 'WestUS'
	$storageAccount = New-AzStorageAccount $rgname $staname $storageAccountSkuName -Location $storageAccountLocation

	$storageAccountKeys = Get-AzStorageAccountKey $rgname $staname
	$storageAccountKey = ConvertTo-SecureString $storageAccountKeys[0] -AsPlainText -Force
	$storageAccountCredential = New-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname -StorageAccountType $storageAccountType -StorageAccountAccessKey $storageAccountKey -EncryptionKey $encryptionKey
	$edgeStorageAccount = New-AzDataBoxEdgeStorageAccount $rgname $dfname $edgeStorageAccountName -StorageAccountCredentialName $storageAccountCredential.Name
	# Test
	try
	{
		$expected = New-AzDataBoxEdgeStorageContainer $rgname $dfname $edgeStorageAccountName -Name $edgeStorageContainerName -DataFormat BlockBlob
		Remove-AzDataBoxEdgeStorageContainer $rgname $dfname $edgeStorageAccountName $edgeStorageContainerName
		Assert-ThrowsContains { Get-AzDataBoxEdgeStorageContainer $rgname $dfname $edgeStorageAccountName $edgeStorageContainerName} "not find"	
		
	}
	finally
	{
		Remove-AzDataBoxEdgeStorageAccount $rgname $dfname $edgeStorageAccountName
		Remove-AzDataBoxEdgeStorageAccountCredential $rgname $dfname $staname
		Remove-AzStorageAccount $rgname $staname
	}  
}
