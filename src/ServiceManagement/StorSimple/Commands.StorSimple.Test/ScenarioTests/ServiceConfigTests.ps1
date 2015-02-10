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
    $s = "Test" + $prefix
    #$s += "_"
    #$s += Get-Random
    $s
}

<#
.SYNOPSIS
Sets context to default resource
#>
function Set-DefaultResource
{
    $selectedResource = Select-AzureStorSimpleResource -ResourceName OneSDK-Resource -RegistrationKey "1975530557201809476:eOqMQdvHon3lGwKVYctxZVnwpZcqi8ZS1uyCLJAl6Wg=:JovQDqP1KyWdh4m3mYkdzQ==#4edfc1cde41104e5"
}

<#
.SYNOPSIS
Returns default values for the test
#>
function Get-DefaultValue ($key)
{
    $defaults = @{
		StorageAccountName = "wuscisclcis1mdsj5sy409";
		StorageAccountPrimaryAccessKey = "OKVxOKV5wDZ98Dq6ehBC29+R05XBXAEVvLOwpK6vh6PaOxRUocQXPY7WhLumiVo8osk/o4elSJR79USWtgSyCA==";
		StorageAccountSecondaryAccessKey = "lSNa58WEo/Nabrt0L+UCnVlQPdzq4kIUITVs5HzOb4ZZ7lsNdOR1wmcVQOWBLSR/OHy2qoM/90DTrSHWhrixGw=="
	}

	return $defaults[$key];
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
    $acrCreated = New-AzureStorSimpleAccessControlRecord -Name $acrName -iqn $iqn -WaitForComplete
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
    $acrCreated = New-AzureStorSimpleAccessControlRecord -Name $acrName -iqn $iqn -WaitForComplete
    Assert-NotNull $acrCreated

    $acrList = Get-AzureStorSimpleAccessControlRecord
    Assert-AreNotEqual 0 @($acrList).Count
    
    $iqnUpdated = $iqn + "_updated"
    $acrUpdated = Set-AzureStorSimpleAccessControlRecord -Name $acrName -IQN $iqnUpdated -WaitForComplete
    Assert-NotNull $acrUpdated
    
    (Get-AzureStorSimpleAccessControlRecord -Name $acrName) | Remove-AzureStorSimpleAccessControlRecord -Force -WaitForComplete
}

<#
.SYNOPSIS
Tests create, get and delete of SAC.
#>
function Test-CreateGetDeleteStorageAccountCredential
{
    $storageAccountName = Get-DefaultValue -key "StorageAccountName"
    $storageAccountKey = Get-DefaultValue -Key "StorageAccountPrimaryAccessKey"
	
    #Pre-req
    Set-DefaultResource
    
    # Test
    $sacCreated = New-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Key $storageAccountKey -UseSSL $true -WaitForComplete
    Assert-NotNull $sacCreated
    
    Remove-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Force -WaitForComplete
}

<#
.SYNOPSIS
Tests create, update and delete of SAC.
#>
function Test-CreateUpdateDeleteStorageAccountCredential
{
    $storageAccountName = Get-DefaultValue -key "StorageAccountName"
    $storageAccountKey = Get-DefaultValue -Key "StorageAccountPrimaryAccessKey"
    $storageAccountSecondaryKey = Get-DefaultValue -Key "StorageAccountSecondaryAccessKey"

    #Pre-req
    Set-DefaultResource
    
    # Test
    $useSSL = $false

    $sacCreated = New-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Key $storageAccountKey -UseSSL $useSSL -WaitForComplete
    Assert-NotNull $sacCreated
    Assert-AreEqual $sacCreated.UseSSL $useSSL

    $sacList = Get-AzureStorSimpleStorageAccountCredential
    Assert-AreNotEqual 0 @($sacList).Count
    
    $useSSL = $true

    $sacUpdated = Set-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Key $storageAccountSecondaryKey -UseSSL $useSSL -WaitForComplete
    Assert-NotNull $sacUpdated
    Assert-AreEqual $sacUpdated.UseSSL $useSSL
    
    (Get-AzureStorSimpleStorageAccountCredential -Name $storageAccountName) | Remove-AzureStorSimpleStorageAccountCredential -Force -WaitForComplete
}

<#
.SYNOPSIS
Tests creation of SAC with invalid creds, which should fail
#>
function Test-CreateStorageAccountCredential_InvalidCreds
{
    $storageAccountName = Get-DefaultValue -key "StorageAccountName"
    $storageAccountKey = Get-DefaultValue -Key "StorageAccountPrimaryAccessKey"

    $storageAccountName_Wrong = $storageAccountName.SubString(3)
    $storageAccountKey_Wrong = $storageAccountKey.SubString(3)

    #Pre-req
    Set-DefaultResource
    
    # Test
    New-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Key $storageAccountKey_Wrong -UseSSL $true -WaitForComplete -ErrorAction SilentlyContinue
    $sacCreated = Get-AzureStorSimpleStorageAccountCredential -Name $storageAccountName
    Assert-Null $sacCreated

    New-AzureStorSimpleStorageAccountCredential -Name $storageAccountName_Wrong -Key $storageAccountKey -UseSSL $true -WaitForComplete -ErrorAction SilentlyContinue
    $sacCreated = Get-AzureStorSimpleStorageAccountCredential -Name $storageAccountName_Wrong
    Assert-Null $sacCreated
}

<#
.SYNOPSIS
Tests update of SAC with invalid creds, which should fail
#>
function Test-UpdateStorageAccountCredential_InvalidCreds
{
    $storageAccountName = Get-DefaultValue -key "StorageAccountName"
    $storageAccountKey = Get-DefaultValue -Key "StorageAccountPrimaryAccessKey"

    $storageAccountKey_Wrong = $storageAccountKey.SubString(3)

    #Pre-req
    Set-DefaultResource
    
    # Test
    $sacCreated = New-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Key $storageAccountKey -UseSSL $true -WaitForComplete
    Assert-NotNull $sacCreated

    $sacUpdated = Set-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Key $storageAccountKey_Wrong -WaitForComplete -ErrorAction SilentlyContinue
    Assert-Null $sacUpdated
    
    (Get-AzureStorSimpleStorageAccountCredential -Name $storageAccountName) | Remove-AzureStorSimpleStorageAccountCredential -Force -WaitForComplete
}
