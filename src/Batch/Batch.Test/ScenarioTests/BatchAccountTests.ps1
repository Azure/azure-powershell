﻿# ----------------------------------------------------------------------------------
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
    Assert-Throws { Get-AzBatchAccount -Name "accountthatdoesnotexist" }
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
        New-AzResourceGroup -Name $resourceGroup -Location $location
        $createdAccount = New-AzBatchAccount -Name $accountName -ResourceGroupName $resourceGroup -Location $location -Tag @{$tagName = $tagValue}

        # Verify the properties match expectations
        Assert-AreEqual $accountName $createdAccount.AccountName
        Assert-AreEqual $resourceGroup $createdAccount.ResourceGroupName
        Assert-AreEqual $location $createdAccount.Location
        Assert-AreEqual 1 $createdAccount.Tags.Count
        Assert-AreEqual $tagValue $createdAccount.Tags[$tagName]
        Assert-True { $createdAccount.PoolQuota -gt 0 }
        Assert-True { $createdAccount.ActiveJobAndJobScheduleQuota -gt 0 }
		Assert-AreEqual "None" $createdAccount.Identity.Type

        # Update the Batch account
        $newTagName = "tag2"
        $newTagValue = "tagValue2"
        Set-AzBatchAccount -Name $accountName -ResourceGroupName $resourceGroup -Tag @{$newTagName = $newTagValue}

        # Get the account and verify the tags were updated
        $updatedAccount = Get-AzBatchAccount -Name $accountName -ResourceGroupName $resourceGroup

        Assert-AreEqual $accountName $updatedAccount.AccountName
        Assert-AreEqual 1 $updatedAccount.Tags.Count
        Assert-AreEqual $newTagValue $updatedAccount.Tags[$newTagName]

        # Get the account keys (without resource group)
        $accountWithKeys = Get-AzBatchAccountKeys -Name $accountName
        Assert-NotNull $accountWithKeys.PrimaryAccountKey
        Assert-NotNull $accountWithKeys.SecondaryAccountKey

        # Get the account keys (with resource group)
        $accountWithKeys = Get-AzBatchAccountKeys -Name $accountName -ResourceGroupName $resourceGroup
        Assert-NotNull $accountWithKeys.PrimaryAccountKey
        Assert-NotNull $accountWithKeys.SecondaryAccountKey

        # Regenerate the primary key
        $updatedKey = New-AzBatchAccountKey -Name $accountName -ResourceGroupName $resourceGroup -KeyType Primary
        Assert-NotNull $updatedKey.PrimaryAccountKey
        Assert-AreNotEqual $accountWithKeys.PrimaryAccountKey $updatedKey.PrimaryAccountKey
        Assert-AreEqual $accountWithKeys.SecondaryAccountKey $updatedKey.SecondaryAccountKey
    }
    finally
    {
        try
        {
            # Delete the account
            Remove-AzBatchAccount -Name $accountName -ResourceGroupName $resourceGroup -Force
            $errorMessage = "The specified account does not exist."
            Assert-ThrowsContains { Get-AzBatchAccount -Name $accountName -ResourceGroupName $resourceGroup } $errorMessage
        }
        finally
        {
            Remove-AzResourceGroup $resourceGroup
        }
    }
}

<#
.SYNOPSIS
Tests getting a list of Batch supported images
#>
function Test-GetBatchSupportedImage
{
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    # Get the node agent skus
    $supportedImages = Get-AzBatchSupportedImage -BatchContext $context

    foreach($supportedImage in $supportedImages)
    {
        Assert-True { $supportedImage.NodeAgentSkuId.StartsWith("batch.node") }
        Assert-True { $supportedImage.OSType -in "linux","windows" }
        Assert-AreNotEqual $null $supportedImage.VerificationType
    }
}

<#
.SYNOPSIS
Tests creating an account without public network access (note that as of the time of writing this test, it must be run in canary)
#>
function Test-CreateNewBatchAccountWithNoPublicIp
{
    # Setup
    $accountName = Get-BatchAccountName
    $resourceGroup = Get-ResourceGroupName

    try
    {
        $location = Get-BatchAccountProviderLocation
        # Create a Batch account
        New-AzResourceGroup -Name $resourceGroup -Location $location
        $createdAccount = New-AzBatchAccount -Name $accountName -ResourceGroupName $resourceGroup -Location $location -PublicNetworkAccess Disabled

        $subnetConfig = New-AzVirtualNetworkSubnetConfig -Name "mysubnet" -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPolicies "Disabled"
        New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Name "myvnet" -Location $location -AddressPrefix "11.0.0.0/16" -Subnet $subnetConfig
        $vnet = Get-AzVirtualNetwork -ResourceGroupName $resourceGroup -Name "myvnet"

        $privateLinkResource = Get-AzPrivateLinkResource -PrivateLinkResourceId $createdAccount.Id

        $plsConnection = New-AzPrivateLinkServiceConnection -Name "myplsconnection" -PrivateLinkServiceId $createdAccount.Id -GroupId $privateLinkResource.GroupId
        New-AzPrivateEndpoint -ResourceGroupName $resourceGroup -Name "mypec" -Location $location -Subnet $vnet.subnets[0] -PrivateLinkServiceConnection $plsConnection -ByManualRequest

        $connection = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $createdAccount.Id
    }
    finally
    {
        Remove-AzResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Tests creating an account with identity set to Microsoft.KeyVault
#>
function Test-CreateNewBatchAccountWithSystemIdentity
{
    # Setup
    $accountName = Get-BatchAccountName
    $resourceGroup = Get-ResourceGroupName

    try
    {
        $location = Get-BatchAccountProviderLocation
        # Create a Batch account
        New-AzResourceGroup -Name $resourceGroup -Location $location
        $createdAccount = New-AzBatchAccount -Name $accountName -ResourceGroupName $resourceGroup -Location $location -IdentityType "SystemAssigned"

		Assert-AreEqual $createdAccount.Identity.Type "SystemAssigned"
		Assert-NotNull $createdAccount.Identity.TenantId
		Assert-NotNull $createdAccount.Identity.PrincipalId
    }
    finally
    {
        Remove-AzResourceGroup $resourceGroup
    }
}