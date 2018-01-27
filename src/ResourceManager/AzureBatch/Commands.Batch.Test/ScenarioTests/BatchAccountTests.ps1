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
Tests Batch account scenarios
#>
function Test-BatchAccountEndToEnd
{
    # Setup
    $accountName = Get-BatchAccountName
    $resourceGroup = Get-ResourceGroupName

    try 
    {
        $location = Get-BatchAccountProviderLocation
        $tagName = "tag1"
        $tagValue = "tagValue1"

        # Create a Batch account
        New-AzureRmResourceGroup -Name $resourceGroup -Location $location
        $createdAccount = New-AzureRmBatchAccount -Name $accountName -ResourceGroupName $resourceGroup -Location $location -Tag @{$tagName = $tagValue}

        # Verify the properties match expectations
        Assert-AreEqual $accountName $createdAccount.AccountName
        Assert-AreEqual $resourceGroup $createdAccount.ResourceGroupName	
        Assert-AreEqual $location $createdAccount.Location
        Assert-AreEqual 1 $createdAccount.Tags.Count
        Assert-AreEqual $tagValue $createdAccount.Tags[$tagName]
        Assert-True { $createdAccount.CoreQuota -gt 0 }
        Assert-True { $createdAccount.PoolQuota -gt 0 }
        Assert-True { $createdAccount.ActiveJobAndJobScheduleQuota -gt 0 }

        # Update the Batch account
        $newTagName = "tag2"
        $newTagValue = "tagValue2"
        Set-AzureRmBatchAccount -Name $accountName -ResourceGroupName $resourceGroup -Tag @{$newTagName = $newTagValue}

        # Get the account and verify the tags were updated
        $updatedAccount = Get-AzureRmBatchAccount -Name $accountName -ResourceGroupName $resourceGroup

        Assert-AreEqual $accountName $updatedAccount.AccountName
        Assert-AreEqual 1 $updatedAccount.Tags.Count
        Assert-AreEqual $newTagValue $updatedAccount.Tags[$newTagName]

        # Get the account keys (without resource group)
        $accountWithKeys = Get-AzureRmBatchAccountKeys -Name $accountName
        Assert-NotNull $accountWithKeys.PrimaryAccountKey
        Assert-NotNull $accountWithKeys.SecondaryAccountKey

        # Get the account keys (with resource group)
        $accountWithKeys = Get-AzureRmBatchAccountKeys -Name $accountName -ResourceGroupName $resourceGroup
        Assert-NotNull $accountWithKeys.PrimaryAccountKey
        Assert-NotNull $accountWithKeys.SecondaryAccountKey

        # Regenerate the primary key
        $updatedKey = New-AzureRmBatchAccountKey -Name $accountName -ResourceGroupName $resourceGroup -KeyType Primary
        Assert-NotNull $updatedKey.PrimaryAccountKey
        Assert-AreNotEqual $accountWithKeys.PrimaryAccountKey $updatedKey.PrimaryAccountKey
        Assert-AreEqual $accountWithKeys.SecondaryAccountKey $updatedKey.SecondaryAccountKey
    }
    finally
    {
        try
        {
            # Delete the account
            Remove-AzureRmBatchAccount -Name $accountName -ResourceGroupName $resourceGroup -Force
            $errorMessage = "The specified account does not exist."
            Assert-ThrowsContains { Get-AzureRmBatchAccount -Name $accountName -ResourceGroupName $resourceGroup } $errorMessage
        }
        finally
        {
            Remove-AzureRmResourceGroup $resourceGroup
        }
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
        Assert-AreNotEqual $null $nodeAgentSku.VerifiedImageReferences
    }
}