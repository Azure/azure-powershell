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
Tests EventHub Namespace Create List Remove operations.
#>

function ServiceBusTests {
    # Setup    
    $location = "East US 2"
    $resourceGroupName = getAssetName "RGName-"
    $namespaceName = getAssetName "Namespace1-"
    $namespaceName2 = getAssetName "Namespace2-"
    $namespaceName3 = getAssetName "Namespace3-"

 
    Write-Debug "Create resource group"    
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName"
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location  -Name $namespaceName -SkuName "Standard" -Tag @{Tag1="Tag1Value"} -MinimumTlsVersion 1.2
    # Assert
    Assert-AreEqual $result.Name $namespaceName
    Assert-AreEqual $result.ProvisioningState "Succeeded"
    Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
    Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"
    Assert-AreEqual $result.MinimumTlsVersion "1.2" "Namespace MinimumTlsVersion matches"

    Write-Debug "Get the created namespace within the resource group"
    $getNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    Assert-AreEqual $getNamespace.Name $namespaceName "Get-ServicebusName- created namespace not found"
    Assert-AreEqual $getNamespace.ResourceGroup $resourceGroupName "Namespace get : ResourceGroup name matches"
    Assert-AreEqual $getNamespace.ResourceGroupName $resourceGroupName "Namespace get : ResourceGroupName name matches"
    
    $UpdatedNameSpace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName -SkuName "Standard" -SkuCapacity 2 -Tag @{Tag1="Tag1Value"; Tag2="Tag1Value2"} -MinimumTlsVersion 1.1
    Assert-AreEqual $UpdatedNameSpace.Name $namespaceName
    Assert-True { $UpdatedNameSpace.Tags.Count -eq 2 }
    Assert-AreEqual $UpdatedNameSpace.MinimumTlsVersion "1.1" "Namespace MinimumTlsVersion matches after update"

    $UpdatedNameSpace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName -SkuName "Standard"
    Assert-AreEqual $UpdatedNameSpace.Name $namespaceName
    Assert-True { $UpdatedNameSpace.Tags.Count -eq 2 }

    Write-Debug "Namespace name : $namespaceName2"
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName2

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName
    Assert-True { $allCreatedNamespace.Count -gt 1 }
	
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzServiceBusNamespace
    Assert-True { $allCreatedNamespace.Count -gt 1 }

    # for ZoneRedundant and DisableLocalAuth 
    Write-Debug "NamespaceName : $namespaceName3"
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location  -Name $namespaceName3 -SkuName "Premium" -ZoneRedundant -DisableLocalAuth
    # Assert
    Assert-AreEqual $result.Name $namespaceName3
    Assert-True {$result.ZoneRedundant}
    Assert-True {$result.DisableLocalAuth}

    Write-Debug " Delete namespaces"
    Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName3
    Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2
    Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

    Write-Debug " Delete resourcegroup"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests EventHub Namespace AuthorizationRules Create List Remove operations.
#>

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

        $namespace = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -SkuName Standard -Location northeurope
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"

        $namespace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "SystemAssigned"
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned"

        $namespace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "UserAssigned" -IdentityId $uad1,$uad2
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }

        $namespace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "SystemAssigned, UserAssigned"
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned, UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }

        $namespace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "None" -IdentityId @()
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-Null $namespace.Identity
    }
    finally{
        Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1
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

        $namespace = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace2 -SkuName Premium -Location northeurope -IdentityType SystemAssigned
        Assert-AreEqual $namespace.Name $namespace2
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned"

        Set-AzKeyVaultAccessPolicy -VaultName $kv1 -ObjectId $namespace.Identity.PrincipalId -PermissionsToKeys wrapkey,unwrapkey,get -BypassObjectIdValidation

        $ec1 = New-AzServiceBusEncryptionConfig -KeyName key1 -KeyVaultUri $kv1uri
        $ec2 = New-AzServiceBusEncryptionConfig -KeyName key2 -KeyVaultUri $kv1uri

        $namespace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace2 -EncryptionConfig $ec1,$ec2
        Assert-AreEqual $namespace.Name $namespace2
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned"
        Assert-True { $namespace.EncryptionConfig.Count -eq 2 }


        $ec1 = New-AzServiceBusEncryptionConfig -KeyName key1 -KeyVaultUri $kv1uri -UserAssignedIdentity $uad1
        $ec2 = New-AzServiceBusEncryptionConfig -KeyName key2 -KeyVaultUri $kv1uri -UserAssignedIdentity $uad1

        $namespace = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -SkuName Premium -Location northeurope -IdentityType UserAssigned -IdentityId $uad1,$uad2 -EncryptionConfig $ec1,$ec2
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }
        Assert-True { $namespace.EncryptionConfig.Count -eq 2 }

        $ec3 = New-AzServiceBusEncryptionConfig -KeyName key1 -KeyVaultUri $kv2uri -UserAssignedIdentity $uad1
        $namespace.EncryptionConfig += $ec3

        $namespace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -EncryptionConfig $namespace.EncryptionConfig -Location northeurope
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }
        Assert-True { $namespace.EncryptionConfig.Count -eq 3 }

        $namespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }
        Assert-True { $namespace.EncryptionConfig.Count -eq 3 }

    }
     
    finally{
        Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace1
        Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespace2
    }
}