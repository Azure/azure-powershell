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
Tests EventHub Namespace AuthorizationRules Create List Remove operations.
#>

function assertNamespaceUpdates{
    param([Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes]$expectedNamespace,[Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes]$namespace)

    Assert-AreEqual $expectedNamespace.Sku.Name $namespace.Sku.Name
    Assert-AreEqual $expectedNamespace.Sku.Tier $namespace.Sku.Tier
    Assert-AreEqual $expectedNamespace.Sku.Capacity $namespace.Sku.Capacity
    Assert-AreEqual $expectedNamespace.Name $namespace.Name
    Assert-AreEqual $expectedNamespace.MaximumThroughputUnits $namespace.MaximumThroughputUnits
    Assert-AreEqual $expectedNamespace.MinimumTlsVersion $namespace.MinimumTlsVersion
    Assert-AreEqual $expectedNamespace.Location $namespace.Location
    Assert-AreEqual $expectedNamespace.IsAutoInflateEnabled $namespace.IsAutoInflateEnabled
    Assert-AreEqual $expectedNamespace.KafkaEnabled $namespace.KafkaEnabled
    Assert-AreEqual $expectedNamespace.ZoneRedundant $namespace.ZoneRedundant
    Assert-AreEqual $expectedNamespace.DisableLocalAuth $namespace.DisableLocalAuth
    Assert-AreEqual $expectedNamespace.Tags.Count $namespace.Tags.Count
}

function assertStandardNamespace{
    param([Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes]$namespace)

    Assert-AreEqual 1 $namespace.Sku.Capacity
    Assert-AreEqual 'Standard' $namespace.Sku.Name
    Assert-AreEqual 0 $namespace.MaximumThroughputUnits
    Assert-AreEqual '1.2' $namespace.MinimumTlsVersion
    Assert-AreEqual 'East US' $namespace.Location
    Assert-False { $namespace.IsAutoInflateEnabled }
    Assert-False { $namespace.ZoneRedundant }
    Assert-False { $namespace.DisableLocalAuth }
    Assert-True { $namespace.KafkaEnabled }
}

function assertPremiumNamespace{
    param([Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes]$namespace)

    Assert-AreEqual 1 $namespace.Sku.Capacity
    Assert-AreEqual 'Premium' $namespace.Sku.Name
    Assert-AreEqual 0 $namespace.MaximumThroughputUnits
    Assert-AreEqual '1.2' $namespace.MinimumTlsVersion
    Assert-AreEqual 'East US' $namespace.Location
    Assert-False { $namespace.IsAutoInflateEnabled }
    Assert-True { $namespace.ZoneRedundant }
    Assert-False { $namespace.DisableLocalAuth }
    Assert-True { $namespace.KafkaEnabled }
}

function NamespaceTests
{
    try{
        
        # Setup    
        $location = "eastus"
	    $namespaceName = getAssetName "Eventhub-Namespace1-"
	    $namespaceName2 = getAssetName "Eventhub-Namespace2-"
        $namespaceName3 = getAssetName "Eventhub-Namespace3-"
        $resourceGroupName = getAssetName "RGName1-"


        Write-Debug "Create resource group"
        Write-Debug "ResourceGroup name : $resourceGroupName"
	    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force 

        $namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -SkuCapacity 10 -MaximumThroughputUnits 18 -SkuName Standard -Location $location -ZoneRedundant -Tag @{k1='v1'; k2='v2'} -EnableAutoInflate -DisableLocalAuth -EnableKafka -MinimumTlsVersion 1.1
    
        Assert-AreEqual 10 $namespace.Sku.Capacity
        Assert-AreEqual 'Standard' $namespace.Sku.Name
        Assert-AreEqual 18 $namespace.MaximumThroughputUnits
        Assert-AreEqual '1.1' $namespace.MinimumTlsVersion
        Assert-AreEqual 'East US' $namespace.Location
        Assert-True { $namespace.IsAutoInflateEnabled }
        Assert-True { $namespace.ZoneRedundant }
        Assert-True { $namespace.DisableLocalAuth }
        Assert-True { $namespace.KafkaEnabled }

        $expectedNamespace = $namespace

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -EnableAutoInflate:$false -MaximumThroughputUnits 0
        $expectedNamespace.IsAutoInflateEnabled = $false
        $expectedNamespace.MaximumThroughputUnits = 0
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -EnableAutoInflate:$true -MaximumThroughputUnits 18
        $expectedNamespace.IsAutoInflateEnabled = $true
        $expectedNamespace.MaximumThroughputUnits = 18
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -SkuCapacity 12
        $expectedNamespace.Sku.Capacity = 12
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -MaximumThroughputUnits 25
        $expectedNamespace.MaximumThroughputUnits = 25
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -MinimumTlsVersion 1.0
        $expectedNamespace.MinimumTlsVersion = '1.0'
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -MinimumTlsVersion 1.2
        $expectedNamespace.MinimumTlsVersion = '1.2'
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -DisableLocalAuth:$false
        $expectedNamespace.DisableLocalAuth = $false
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -DisableLocalAuth
        $expectedNamespace.DisableLocalAuth = $true
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2 -SkuName Standard -Location $location
        assertStandardNamespace $namespace

        $namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName3 -SkuName Premium -Location $location
        assertPremiumNamespace $namespace

        $listOfNamespaces = Get-AzEventHubNamespace -ResourceGroupName $resourceGroupName
        Assert-AreEqual 3 $listOfNamespaces.Count

        # $listOfNamespaces = Get-AzEventHubNamespace
        # Assert-True { $listOfNamespaces.Count -gt 0 }

    }
    finally{
        
        Write-Debug " Delete namespaces"
        Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName3
        Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName2
        Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

        Write-Debug " Delete resourcegroup"
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

function MSITest{
    $resourceGroupName = "PS-Testing"
    $msi1 = "PS-Testing-MSI1"
    $msi2 = "PS-Testing-MSI2"
    $msi3 = "PS-Testing-MSI3"
    $namespace1 = getAssetName "Namespace1-"
    $namespace2 = getAssetName "Namespace2-"
    try{

        $uad1 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI1"
        $uad2 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI2"
        $uad3 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI3"

        $namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -SkuName Standard -Location eastus
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "SystemAssigned"
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned"

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "UserAssigned" -IdentityId $uad1,$uad2
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "SystemAssigned, UserAssigned"
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-AreEqual $namespace.IdentityType "SystemAssignedUserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "None" -IdentityId @()
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-Null $namespace.Identity
    }
    finally{
        Remove-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1
    }
}

function EncryptionTest{
    try{
        $resourceGroupName = "PS-Testing"
        $msi1 = "PS-Testing-MSI1"
        $msi2 = "PS-Testing-MSI2"
        $msi3 = "PS-Testing-MSI3"
        $kv1 = "PS-Test-kv1"
        $kv2 = "PS-Test-kv2"
        $kv1uri = "https://ps-test-kv1.vault.azure.net/"
        $kv2uri = "https://ps-test-kv2.vault.azure.net"
        $namespace1 = getAssetName "Namespace1-"
        $namespace2 = getAssetName "Namespace2-"

        $uad1 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI1"
        $uad2 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI2"
        $uad3 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI3"

        $namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace2 -SkuName Premium -Location eastus -IdentityType SystemAssigned
        Assert-AreEqual $namespace.Name $namespace2
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned"

        Set-AzKeyVaultAccessPolicy -VaultName $kv1 -ObjectId $namespace.Identity.PrincipalId -PermissionsToKeys wrapkey,unwrapkey,get -BypassObjectIdValidation

        $ec1 = New-AzEventHubEncryptionConfig -KeyName key1 -KeyVaultUri $kv1uri
        $ec2 = New-AzEventHubEncryptionConfig -KeyName key2 -KeyVaultUri $kv1uri

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace2 -EncryptionConfig $ec1,$ec2
        Assert-AreEqual $namespace.Name $namespace2
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned"
        Assert-True { $namespace.EncryptionConfig.Count -eq 2 }

        $ec1 = New-AzEventHubEncryptionConfig -KeyName key1 -KeyVaultUri $kv1uri -UserAssignedIdentity $uad1
        $ec2 = New-AzEventHubEncryptionConfig -KeyName key2 -KeyVaultUri $kv1uri -UserAssignedIdentity $uad1

        $namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -SkuName Premium -Location northeurope -IdentityType UserAssigned -IdentityId $uad1,$uad2 -EncryptionConfig $ec1,$ec2
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }
        Assert-True { $namespace.EncryptionConfig.Count -eq 2 }

        $ec3 = New-AzEventHubEncryptionConfig -KeyName key1 -KeyVaultUri $kv2uri -UserAssignedIdentity $uad1
        $namespace.EncryptionConfig += $ec3

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -EncryptionConfig $namespace.EncryptionConfig -Location northeurope
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }
        Assert-True { $namespace.EncryptionConfig.Count -eq 3 }


        $namespace = Get-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }
        Assert-True { $namespace.EncryptionConfig.Count -eq 3 }

    }
     
    finally{
        Remove-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1
    }
}

