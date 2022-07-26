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
     
    # Check Namespace Name Availability
    $checkNameResult = Test-AzServiceBusName -NamespaceName $namespaceName 
    Assert-True { $checkNameResult.NameAvailable }

    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName"
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location  -Name $namespaceName -SkuName "Standard" -Tag @{Tag1="Tag1Value"}
    # Assert
    Assert-AreEqual $result.Name $namespaceName
    Assert-AreEqual $result.ProvisioningState "Succeeded"
    Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
    Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"

    Write-Debug "Get the created namespace within the resource group"
    $getNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    Assert-AreEqual $getNamespace.Name $namespaceName "Get-ServicebusName- created namespace not found"
    Assert-AreEqual $getNamespace.ResourceGroup $resourceGroupName "Namespace get : ResourceGroup name matches"
    Assert-AreEqual $getNamespace.ResourceGroupName $resourceGroupName "Namespace get : ResourceGroupName name matches"
    
    $UpdatedNameSpace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName -SkuName "Standard" -SkuCapacity 2 -Tag @{Tag1="Tag1Value"; Tag2="Tag1Value2"}
    Assert-AreEqual $UpdatedNameSpace.Name $namespaceName
    Assert-True { $UpdatedNameSpace.Tags.Count -eq 2 }

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
function ServiceBusNameSpaceAuthTests {
    # Setup    
    $location = Get-Location
    $resourceGroupName = getAssetName "RGName-"
    $namespaceName = getAssetName "Namespace-"
    $authRuleName = getAssetName "authorule-"
    $authRuleNameListen = getAssetName "authorule-"
    $authRuleNameSend = getAssetName "authorule-"
    $authRuleNameAll = getAssetName "authorule-"
    $defaultNamespaceAuthRule = "RootManageSharedAccessKey"
	
    Write-Debug " Create resource group"    
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force    
    
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"	
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
        
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    Assert-AreEqual $createdNamespace.Name $namespaceName

    Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen", "Send")
	
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

    $resultListen = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleNameListen -Rights @("Listen")
    Assert-AreEqual $authRuleNameListen $resultListen.Name
    Assert-AreEqual 1 $resultListen.Rights.Count
    Assert-True { $resultListen.Rights -Contains "Listen" }

    $resultSend = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleNameSend -Rights @("Send")
    Assert-AreEqual $authRuleNameSend $resultSend.Name
    Assert-AreEqual 1 $resultSend.Rights.Count
    Assert-True { $resultSend.Rights -Contains "Send" }

    $resultAll3 = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleNameAll -Rights @("Listen", "Send", "Manage")
    Assert-AreEqual $authRuleNameAll $resultAll3.Name
    Assert-AreEqual 3 $resultAll3.Rights.Count
    Assert-True { $resultAll3.Rights -Contains "Send" }
    Assert-True { $resultAll3.Rights -Contains "Listen" }
    Assert-True { $resultAll3.Rights -Contains "Manage" }

    Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen", "Send")
	
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

    Write-Debug "Get the default Namespace AuthorizationRule"   
    $result = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }

    Write-Debug "Get All Namespace AuthorizationRule"
    $result = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName

    $found = 0
    for ($i = 0; $i -lt $result.Count; $i++) {
        if ($result[$i].Name -eq $authRuleName) {
            $found = $found + 1
            Assert-AreEqual 2 $result[$i].Rights.Count
            Assert-True { $result[$i].Rights -Contains "Listen" }
            Assert-True { $result[$i].Rights -Contains "Send" }                      
        }

        if ($result[$i].Name -eq $defaultNamespaceAuthRule) {
            $found = $found + 1
            Assert-AreEqual 3 $result[$i].Rights.Count
            Assert-True { $result[$i].Rights -Contains "Listen" }
            Assert-True { $result[$i].Rights -Contains "Send" }
            Assert-True { $result[$i].Rights -Contains "Manage" }         
        }
    }

    Assert-AreEqual $found 2 "All Authorizationrules: Namespace AuthorizationRules created earlier is not found."
		
    Write-Debug "Update Namespace AuthorizationRules ListKeys"
    
    $createdAuthRule.Rights.Add("Manage")

    $updatedAuthRule = Set-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -InputObject $createdAuthRule -Name $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }    
    
    Write-Debug "Get updated Namespace AuthorizationRules"
    $updatedAuthRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }

    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-True { $namespaceListKeys.PrimaryConnectionString -like "*$($updatedAuthRule.PrimaryKey)*" }
    Assert-True { $namespaceListKeys.SecondaryConnectionString -like "*$($updatedAuthRule.SecondaryKey)*" }
	
    # Regentrate the Keys 
    $policyKey = "PrimaryKey"

    $namespaceRegenerateKeysDefault = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey
    Assert-True { $namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey }

    $namespaceRegenerateKeys = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey -KeyValue $namespaceListKeys.PrimaryKey
    Assert-AreEqual $namespaceRegenerateKeys.PrimaryKey $namespaceListKeys.PrimaryKey

    $policyKey1 = "SecondaryKey"

    $namespaceRegenerateKeys1 = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey1 -KeyValue $namespaceListKeys.PrimaryKey
    Assert-AreEqual $namespaceRegenerateKeys1.SecondaryKey $namespaceListKeys.PrimaryKey
																	
    $namespaceRegenerateKeys1 = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey1
    Assert-True { $namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.PrimaryKey }
    Assert-True { $namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey }

    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Force
    
    Write-Debug " Delete namespaces"
    Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
	   
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
        Assert-AreEqual $namespace.IdentityType "SystemAssignedUserAssigned"
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