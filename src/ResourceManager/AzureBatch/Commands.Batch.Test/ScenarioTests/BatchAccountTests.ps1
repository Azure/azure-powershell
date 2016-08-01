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
    Assert-Throws { Get-AzureRmBatchAccount -Name "accountthatdoesnotexist" }
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
    $tagName = "testtag"
    $tagValue = "testval"

    try 
    {
        New-AzureRmResourceGroup -Name $resourceGroup -Location $location

        # Test
        $actual = New-AzureRmBatchAccount -Name $account -ResourceGroupName $resourceGroup -Location $location -Tag @{$tagName = $tagValue} 
        $expected = Get-AzureRmBatchAccount -Name $account -ResourceGroupName $resourceGroup

        # Assert
        Assert-AreEqual $expected.AccountName $actual.AccountName
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual $expected.Tags[$tagName] $actual.Tags[$tagName]
        Assert-True { $actual.CoreQuota -gt 0 }
        Assert-True { $actual.PoolQuota -gt 0 }
        Assert-True { $actual.ActiveJobAndJobScheduleQuota -gt 0 }
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
        New-AzureRmResourceGroup -Name $resourceGroup -Location $location

        #Test
        $new = New-AzureRmBatchAccount -Name $account -ResourceGroupName $resourceGroup -Location $location  -Tag @{$tagName1 = $tagValue1} 
        Assert-AreEqual 1 $new.Tags.Count

        # Update Tag
        $actual = Set-AzureRmBatchAccount -Name $account -ResourceGroupName $resourceGroup -Tag @{$tagName2 = $tagValue2} 
        $expected = Get-AzureRmBatchAccount -Name $account -ResourceGroupName $resourceGroup

        # Assert
        Assert-AreEqual $expected.AccountName $actual.AccountName
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual 1 $expected.Tags.Count
        Assert-AreEqual $tagValue2 $expected.Tags[$tagName2]
        Assert-AreEqual $expected.Tags[$tagName2] $actual.Tags[$tagName2]

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
    $account = Get-BatchAccountName
    $location = Get-BatchAccountProviderLocation

    try 
    {
        New-AzureRmResourceGroup -Name $resourceGroup1 -Location $location
        New-AzureRmResourceGroup -Name $resourceGroup2 -Location $location
        New-AzureRmBatchAccount -Name $account -ResourceGroupName $resourceGroup1 -Location $location 

        # Test
        $resourceGroup1Accounts = Get-AzureRmBatchAccount -ResourceGroupName $resourceGroup1
		$resourceGroup2Accounts = Get-AzureRmBatchAccount -ResourceGroupName $resourceGroup2

        # Assert
        Assert-AreEqual 1 $resourceGroup1Accounts.Count
        Assert-AreEqual $null $resourceGroup2Accounts
    }
    finally
    {
        # Cleanup
        Clean-BatchAccountAndResourceGroup $account $resourceGroup1
		Clean-ResourceGroup $resourceGroup2
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
    $location1 = Get-BatchAccountProviderLocation
    $location2 = Get-BatchAccountProviderLocation 4 

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroup -Location $location1

        # Test
        New-AzureRmBatchAccount -Name $account1 -ResourceGroupName $resourceGroup -Location $location1
        New-AzureRmBatchAccount -Name $account2 -ResourceGroupName $resourceGroup -Location $location2
        Get-AzureRmBatchAccount | where {$_.AccountName -eq $account1 -or $_.AccountName -eq $account2} | Remove-AzureRmBatchAccount -Force

        # Assert
        Assert-Throws { Get-AzureRmBatchAccount -Name $account1 } 
        Assert-Throws { Get-AzureRmBatchAccount -Name $account2 } 
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
    $tagName = "testtag"
    $tagValue = "testval"

    try 
    {
        New-AzureRmResourceGroup -Name $resourceGroup -Location $location

        # Test
        $new = New-AzureRmBatchAccount -Name $account -ResourceGroupName $resourceGroup -Location $location -Tag @{$tagName = $tagValue} 
        $originalKeys =  Get-AzureRmBatchAccountKeys -Name $account -ResourceGroupName $resourceGroup
        $originalPrimaryKey = $originalKeys.PrimaryAccountKey
        $originalSecondaryKey = $originalKeys.SecondaryAccountKey
        $newPrimary = New-AzureRmBatchAccountKey -Name $account -ResourceGroupName $resourceGroup -KeyType Primary
        $newSecondary = New-AzureRmBatchAccountKey -Name $account -ResourceGroupName $resourceGroup -KeyType Secondary
        $finalKeys = Get-AzureRmBatchAccountKeys -Name $account -ResourceGroupName $resourceGroup
        $getAccountResult = Get-AzureRmBatchAccount -Name $account -ResourceGroupName $resourceGroup

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

<#
.SYNOPSIS
Tests getting a list of Batch node agent skus
#>
function Test-GetBatchNodeAgentSkus
{
	$context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

	# Get the node agent skus
	$nodeAgentSkus = Get-AzureBatchNodeAgentSku -BatchContext $context

	foreach($nodeAgentSku in $nodeAgentSkus)
    {
        Assert-True { $nodeAgentSku.Id.StartsWith("batch.node") }
		Assert-True { $nodeAgentSku.OSType -in "linux","windows" }
		Assert-AreNotEqual 0 $nodeAgentSku.VerifiedImageReferences.Count
    }
}