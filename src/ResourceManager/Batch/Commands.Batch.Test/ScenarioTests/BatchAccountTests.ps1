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
Tests querying for a Batch account that does not exist throws
#>
function Test-GetNonExistingBatchAccount
{
    Assert-Throws { Get-AzureBatchAccount -Name "accountthatdoesnotexist" }
}

<#
.SYNOPSIS
Tests creating new Batch account.
#>
function Test-CreatesNewBatchAccount
{
    # Setup
	$account = Get-BatchAccountName
    $resourceGroup = Get-ResourceGroupName
    $location = Get-BatchAccountProviderLocation

    try 
    {
        New-AzureResourceGroup -Name $resourceGroup -Location $location

        # Test
        $actual = New-AzureBatchAccount -Name $account -ResourceGroupName $resourceGroup -Location $location -Tag @{Name = "testtag"; Value = "testval"} 
        $expected = Get-AzureBatchAccount -Name $account -ResourceGroupName $resourceGroup

        # Assert
		Assert-AreEqual $expected.AccountName $actual.AccountName
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
		Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual $expected.Tags[0]["Name"] $actual.Tags[0]["Name"]
		Assert-AreEqual $expected.Tags[0]["Value"] $actual.Tags[0]["Value"]
    }
    finally
    {
        # Cleanup
        Clean-BatchAccountAndResourceGroup $account $resourceGroup
    }
}

<#
.SYNOPSIS
Tests creating an account that already exists throws
#>
function Test-CreateExistingBatchAccount
{
    # Setup
	$account = Get-BatchAccountName
    $resourceGroup = Get-ResourceGroupName
    $location = Get-BatchAccountProviderLocation

    try 
    {
        New-AzureResourceGroup -Name $resourceGroup -Location $location

        # Test
        New-AzureBatchAccount -Name $account -ResourceGroupName $resourceGroup -Location $location -Tag @{Name = "testtag"; Value = "testval"} 

        Assert-Throws { New-AzureBatchAccount -Name $account -ResourceGroupName $resourceGroup -Location $location }
    }
    finally
    {
        # Cleanup
        Clean-BatchAccountAndResourceGroup $account $resourceGroup
    }
}

<#
.SYNOPSIS
Tests updating existing Batch account
#>
function Test-UpdatesExistingBatchAccount
{
    # Setup
	$account = Get-BatchAccountName
    $resourceGroup = Get-ResourceGroupName
    $location = Get-BatchAccountProviderLocation

	$tagName1 = "testtag1"
	$tagValue1 = "testval1"
	$tagName2 = "testtag2"
	$tagValue2 = "testval2"

    try 
    {
        New-AzureResourceGroup -Name $resourceGroup -Location $location

		#Test
        $new = New-AzureBatchAccount -Name $account -ResourceGroupName $resourceGroup -Location $location  -Tag @{Name = $tagName1; Value = $tagValue1} 
		Assert-AreEqual 1 $new.Tags.Count

		# Update Tag
        $actual = Set-AzureBatchAccount -Name $account -ResourceGroupName $resourceGroup -Tag @{Name = $tagName2; Value = $tagValue2} 
        $expected = Get-AzureBatchAccount -Name $account -ResourceGroupName $resourceGroup

        # Assert
		Assert-AreEqual $expected.AccountName $actual.AccountName
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
		Assert-AreEqual $expected.Location $actual.Location
		Assert-AreEqual 1 $expected.Tags.Count
		Assert-AreEqual $tagName2 $expected.Tags[0]["Name"]
		Assert-AreEqual $tagValue2 $expected.Tags[0]["Value"]
        Assert-AreEqual $expected.Tags[0]["Name"] $actual.Tags[0]["Name"]
		Assert-AreEqual $expected.Tags[0]["Value"] $actual.Tags[0]["Value"]
    }
    finally
    {
        # Cleanup
        Clean-BatchAccountAndResourceGroup $account $resourceGroup
    }
}

<#
.SYNOPSIS
Tests getting Batch accounts under resource groups
#>
function Test-GetBatchAccountsUnderResourceGroups
{
    # Setup
    $resourceGroup1 = Get-ResourceGroupName
	$resourceGroup2 = Get-ResourceGroupName
	$account11 = Get-BatchAccountName
	$account12 = Get-BatchAccountName
	$account21 = Get-BatchAccountName
    $location = Get-BatchAccountProviderLocation

    try 
    {
        New-AzureResourceGroup -Name $resourceGroup1 -Location $location
		New-AzureResourceGroup -Name $resourceGroup2 -Location $location
		New-AzureBatchAccount -Name $account11 -ResourceGroupName $resourceGroup1 -Location $location 
		New-AzureBatchAccount -Name $account12 -ResourceGroupName $resourceGroup1 -Location $location 
		New-AzureBatchAccount -Name $account21 -ResourceGroupName $resourceGroup2 -Location $location 

        # Test
		$allAccounts = Get-AzureBatchAccount | Where-Object {$_.ResourceGroupName -eq $resourceGroup1 -or $_.ResourceGroupName -eq $resourceGroup2}
		$resourceGroup1Accounts = Get-AzureBatchAccount -ResourceGroupName $resourceGroup1

		# Assert
		Assert-AreEqual 3 $allAccounts.Count
		Assert-AreEqual 2 $resourceGroup1Accounts.Count
		Assert-AreEqual 2 ($resourceGroup1Accounts | Where-Object {$_.ResourceGroupName -eq $resourceGroup1}).Count
    }
    finally
    {
        # Cleanup
		Clean-BatchAccount $account11 $resourceGroup1
		Clean-BatchAccountAndResourceGroup $account12 $resourceGroup1
        Clean-BatchAccountAndResourceGroup $account21 $resourceGroup2
    }
}


<#
.SYNOPSIS
Tests creating a new Batch account and deleting it via piping.
#>
function Test-CreateAndRemoveBatchAccountViaPiping
{
    # Setup
    $account1 = Get-BatchAccountName
	$account2 = Get-BatchAccountName
    $resourceGroup = Get-ResourceGroupName
    $location = Get-BatchAccountProviderLocation

	try
	{
		New-AzureResourceGroup -Name $resourceGroup -Location $location

		# Test
		New-AzureBatchAccount -Name $account1 -ResourceGroupName $resourceGroup -Location $location
		New-AzureBatchAccount -Name $account2 -ResourceGroupName $resourceGroup -Location $location
		Get-AzureBatchAccount | where {$_.AccountName -eq $account1 -or $_.AccountName -eq $account2} | Remove-AzureBatchAccount -Force

		# Assert
		Assert-Throws { Get-AzureBatchAccount -Name $account1 } 
		Assert-Throws { Get-AzureBatchAccount -Name $account2 } 
	}
	finally
	{
		Clean-ResourceGroup $resourceGroup
	}
}

<#
.SYNOPSIS
Tests getting/setting Batch account keys
#>
function Test-BatchAccountKeys
{
    # Setup
	$account = Get-BatchAccountName
    $resourceGroup = Get-ResourceGroupName
    $location = Get-BatchAccountProviderLocation

    try 
    {
        New-AzureResourceGroup -Name $resourceGroup -Location $location

        # Test
        $new = New-AzureBatchAccount -Name $account -ResourceGroupName $resourceGroup -Location $location -Tag @{Name = "testtag"; Value = "testval"} 
		$originalKeys =  Get-AzureBatchAccountKeys -Name $account -ResourceGroupName $resourceGroup
		$originalPrimaryKey = $originalKeys.PrimaryAccountKey
		$originalSecondaryKey = $originalKeys.SecondaryAccountKey
		$newPrimary = New-AzureBatchAccountKey -Name $account -ResourceGroupName $resourceGroup -KeyType Primary
		$newSecondary = New-AzureBatchAccountKey -Name $account -ResourceGroupName $resourceGroup -KeyType Secondary
        $finalKeys = Get-AzureBatchAccountKeys -Name $account -ResourceGroupName $resourceGroup
		$getAccountResult = Get-AzureBatchAccount -Name $account -ResourceGroupName $resourceGroup

        # Assert
		Assert-AreEqual $null $new.PrimaryAccountKey
        Assert-AreEqual $null $new.SecondaryAccountKey
		Assert-AreEqual $originalSecondaryKey $newPrimary.SecondaryAccountKey 
		Assert-AreEqual $newPrimary.PrimaryAccountKey $newSecondary.PrimaryAccountKey
		Assert-AreEqual $newPrimary.PrimaryAccountKey $finalKeys.PrimaryAccountKey
		Assert-AreEqual $newSecondary.SecondaryAccountKey $finalKeys.SecondaryAccountKey
		Assert-AreNotEqual $originalPrimaryKey $newPrimary.PrimaryAccountKey
		Assert-AreNotEqual $originalSecondaryKey $newSecondary.SecondaryAccountKey
		Assert-AreEqual $null $getAccountResult.PrimaryAccountKey
		Assert-AreEqual $null $getAccountResult.SecondaryAccountKey
    }
    finally
    {
        # Cleanup
        Clean-BatchAccountAndResourceGroup $account $resourceGroup
    }
}
