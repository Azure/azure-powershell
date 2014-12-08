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
Generates unique name with given prefix
#>
function Generate-Name ($prefix)
{
    $s = $prefix
    $s += "_"
    $s += Get-Random
    $s
}

<#
.SYNOPSIS
Sets context to default resource
#>
function Set-DefaultResource
{
    $selectedResource = Select-AzureStorSimpleResource -ResourceName OneSDK-Resource
}

<#
.SYNOPSIS
Returns default values for the test
#>
function Get-DefaultValue ($key)
{
    $defaults = @{
		StorageAccountName = "storsimple1htg67zmg7",
		StorageAccountPrimaryAccessKey = "Xk12mx7wGl4uCc2yEYvNXkGXHR9/jUyVDmVT4rVS+1EFEUcdKynl1w8/cUc03ZMjkw3ooPpi0yTBmwyPrxGyNg==",
		StorageAccountSecondaryAccessKey = "HSXNE9BMSWa0rjX77svBkNI2PBng0UVVF1HOxCLvQloV0zePzxLQc3Fy5h51Tou22ojBUj+LqCrg+01D1JS0mQ=="
	}

	return $defaults[key];
}

<#
.SYNOPSIS
Tests create, get and delete of ACR.
#>
function Test-CreateGetDeleteAccessControlRecord
{
    # Unique object names
	$acrName = Generate-Name("ACR")
    $iqn = Generate-Name("IQN")

    #Pre-req
    Set-DefaultResource
    
    # Test
    New-AzureStorSimpleAccessControlRecord -Name $acrName -iqn $iqn -WaitForComplete
    
    $acrCreated = Get-AzureStorSimpleAccessControlRecord -Name $acrName
    Assert-NotNull $acrCreated
    
    Remove-AzureStorSimpleAccessControlRecord -Name $acrName -Force -WaitForComplete
}

<#
.SYNOPSIS
Tests create, update and delete of ACR.
#>
function Test-CreateUpdateDeleteAccessControlRecord
{
    # Unique object names
	$acrName = Generate-Name("ACR")
    $iqn = Generate-Name("IQN")

    #Pre-req
    Set-DefaultResource
    
    # Test
    New-AzureStorSimpleAccessControlRecord -Name $acrName -iqn $iqn -WaitForComplete
    
    $acrList = Get-AzureStorSimpleAccessControlRecord
    Assert-AreNotEqual 0 @($acrList).Count
    $acrCreated = Get-AzureStorSimpleAccessControlRecord -Name $acrName
    Assert-NotNull $acrCreated

    $iqnUpdated = $iqn + "_updated"
    Set-AzureStorSimpleAccessControlRecord -Name $acrName -IQN $iqnUpdated -WaitForComplete
    
    (Get-AzureStorSimpleAccessControlRecord -Name $acrName) | Remove-AzureStorSimpleAccessControlRecord -Force -WaitForComplete
}

<#
.SYNOPSIS
Tests create, get and delete of SAC.
#>
function Test-CreateGetDeleteStorageAccountCredential
{
    $storageAccountName = Get-DefaultValye -key "StorageAccountName"
    $storageAccountKey = Get-DefaultValue -Key "StorageAccountPrimaryAccessKey"
	
    #Pre-req
    Set-DefaultResource
    
    # Test
    New-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Key $storageAccountKey -UseSSL $true -WaitForComplete
    
    $sacCreated = Get-AzureStorSimpleStorageAccountCredential -Name $storageAccountName
    Assert-NotNull $sacCreated
    
    Remove-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Force -WaitForComplete
}

<#
.SYNOPSIS
Tests create, update and delete of ACR.
#>
function Test-CreateUpdateDeleteStorageAccountCredential
{
    $storageAccountName = Get-DefaultValye -key "StorageAccountName"
    $storageAccountKey = Get-DefaultValue -Key "StorageAccountPrimaryAccessKey"
    $storageAccountSecondaryKey = Get-DefaultValue -Key "StorageAccountSecondaryAccessKey"

    #Pre-req
    Set-DefaultResource
    
    # Test
    New-AzureStorSimpleStorageAccountCredential -Name $stoargeAccountName -Key $storageAccountKey -UseSSL $true -WaitForComplete
    
    $sacList = Get-AzureStorSimpleStorageAccountCredential
    Assert-AreNotEqual 0 @($sacList).Count
    $sacCreated = Get-AzureStorSimpleStorageAccountCredential -Name $storageAccountName
    Assert-NotNull $sacCreated

    Set-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Key $storageAccountSecondaryKey -WaitForComplete
    
    (Get-AzureStorSimpleStorageAccountCredential -Name $storageAccountName) | Remove-AzureStorSimpleStorageAccountCredential -Force -WaitForComplete
}
