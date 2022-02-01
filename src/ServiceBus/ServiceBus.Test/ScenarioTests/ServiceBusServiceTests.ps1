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
function DebugTest{
     $location = "East US 2"
     $resourceGroupName = getAssetName "RGName-sdktesting"
     
     $namespaceName1 = getAssetName "Namespace1-"
     $namespaceName2 = getAssetName "Namespace2-"
     $namespaceName3 = getAssetName "Namespace3-"
     $namespaceName4 = getAssetName "Namespace4-"
     
     $keyvault1 = getAssetName "kv1"
     $keyvault2 = getAssetName "kv2"
     $keyName1 = getAssetName "keyName1-"
     $keyName2 = getAssetName "keyName2-"
     $keyName3 = getAssetName "keyName3-"
     
     $userAssignedIdentity1 = getAssetName "uad1-"
     $userAssignedIdentity2 = getAssetName "uad2-"
     $userAssignedIdentity3 = getAssetName "uad3-"

     try{
        Write-Debug "Create resource group"    
        New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
        
        
        #Create User Assigned Identity 1
        $uad1 = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $userAssignedIdentity1

        #Create User Assigned Identity 2
        $uad2 = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $userAssignedIdentity2

        #Create User Assigned Identity 3
        $uad3 = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $userAssignedIdentity3

        #Create KeyVault1
        $kv1 = New-AzKeyVault -VaultName $keyvault1 -ResourceGroupName $resourceGroupName -Location $location -EnablePurgeProtection
        #Create Keys
        Add-AzKeyVaultKey -VaultName $keyvault1 -Name $keyName1 -Destination 'Software'
        Add-AzKeyVaultKey -VaultName $keyvault1 -Name $keyName2 -Destination 'Software'
        Add-AzKeyVaultKey -VaultName $keyvault1 -Name $keyName3 -Destination 'Software'

        #Give access policy permissions to both MSI
        Set-AzKeyVaultAccessPolicy -VaultName $keyvault1 -ServicePrincipalName $uad1.ClientId -PermissionsToKeys @('All') -PassThru
        Set-AzKeyVaultAccessPolicy -VaultName $keyvault1 -ServicePrincipalName $uad2.ClientId -PermissionsToKeys @('All') -PassThru
        Set-AzKeyVaultAccessPolicy -VaultName $keyvault1 -ServicePrincipalName $uad3.ClientId -PermissionsToKeys @('All') -PassThru

        #Create KeyVault2
        $kv2 = New-AzKeyVault -VaultName $keyvault2 -ResourceGroupName $resourceGroupName -Location $location -EnablePurgeProtection

        #Create Keys
        Add-AzKeyVaultKey -VaultName $keyvault2 -Name $keyName1 -Destination 'Software'
        Add-AzKeyVaultKey -VaultName $keyvault2 -Name $keyName2 -Destination 'Software'
        Add-AzKeyVaultKey -VaultName $keyvault2 -Name $keyName3 -Destination 'Software'

        #Give access policy permissions to both MSI
        Set-AzKeyVaultAccessPolicy -VaultName $keyvault2 -ServicePrincipalName $uad1.ClientId -PermissionsToKeys @('All') -PassThru
        Set-AzKeyVaultAccessPolicy -VaultName $keyvault2 -ServicePrincipalName $uad2.ClientId -PermissionsToKeys @('All') -PassThru
        Set-AzKeyVaultAccessPolicy -VaultName $keyvault2 -ServicePrincipalName $uad3.ClientId -PermissionsToKeys @('All') -PassThru

        $kvsb1 = New-AzServiceBusEncryptionConfig -KeyName $keyName1 -KeyVaultUri $kv1.VaultUri -UserAssignedIdentity $uad1.Id
        $kvsb2 = New-AzServiceBusEncryptionConfig -KeyName $keyName2 -KeyVaultUri $kv1.VaultUri -UserAssignedIdentity $uad1.Id

        $createdNamespace = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName1 -Location $location -SkuName Premium -IdentityType UserAssigned -IdentityId @($uad1.Id,$uad2.Id) -EncryptionConfigs $kvsb1,$kvsb2

        $encryptionConfigs = @($kvsb1,$kvsb2)
        $identityIds = @($uad1.Id,$uad2.Id)

        Assert-AreEqual $createdNamespace.Name $namespaceName1 "Namespace name matches"
        Assert-AreEqual $createdNamespace.ProvisioningState "Succeeded"
        Assert-AreEqual $createdNamespace.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"
        Assert-AreEqual $createdNamespace.EncryptionConfigs $encryptionConfigs "Encryption Configs match"
        Assert-AreEqual $createdNamespace.IdentityIds $identityIds
        Assert-AreEqual $createdNamespace.IdentityType "UserAssigned"
        Assert-AreEqual $createdNamespace.Location "East US 2"
        Assert-AreEqual $createdNamespace.SkuName "Premium"

        $getCreatedNamespace = Get-AzServiceBusName -ResourceGroupName $resourceGroupName -Name $namespaceName1

        Assert-AreEqual $getCreatedNamespace.Name $createdNamespace.Name "Namespace name matches"
        Assert-AreEqual $getCreatedNamespace.ProvisioningState "Succeeded"
        Assert-AreEqual $getCreatedNamespace.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"
        Assert-AreEqual $getCreatedNamespace.EncryptionConfigs $encryptionConfigs "Encryption Configs match"
        Assert-AreEqual $getCreatedNamespace.IdentityIds $identityIds
        Assert-AreEqual $getCreatedNamespace.IdentityType "UserAssigned"
        Assert-AreEqual $getCreatedNamespace.Location $location
        Assert-AreEqual $getCreatedNamespace.SkuName "Premium"

        $kvsb3 = New-AzServiceBusEncryptionConfig -KeyName $keyName3 -KeyVaultUri $kv2.VaultUri -UserAssignedIdentity $uad1.Id
        $getCreatedNamespace.EncryptionConfigs += $kvsb3

        $encryptionConfigs = @($kvsb1,$kvsb2,$kvsb3)
        $identityIds = @($uad1.Id,$uad2.Id,$uad3.Id)

        $updatedNamespace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName1 -Location $location -SkuName Premium -IdentityType UserAssigned -IdentityId $getCreatedNamespace.IdentityIds @($uad3.Id) -EncryptionConfigs $getCreatedNamespace.EncryptionConfigs

        Assert-AreEqual $updatedNamespace.Name $namespaceName1 "Namespace name matches"
        Assert-AreEqual $updatedNamespace.ProvisioningState "Succeeded"
        Assert-AreEqual $updatedNamespace.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"
        Assert-AreEqual $updatedNamespace.EncryptionConfigs $encryptionConfigs "Encryption Configs match"
        Assert-AreEqual $updatedNamespace.IdentityIds $identityIds
        Assert-AreEqual $updatedNamespace.IdentityType "UserAssigned"
        Assert-AreEqual $updatedNamespace.Location $location
        Assert-AreEqual $updatedNamespace.SkuName "Premium"

        

        Remove-AzKeyVault -Name $keyvault1 -ResourceGroupName $resourceGroupName
        Remove-AzKeyVault -Name $keyvault2 -ResourceGroupName $resourceGroupName

        Write-Debug " Delete namespaces"
        #Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName3
        #Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2
        Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName1
        #Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName4
     }
     
     finally{
        Write-Debug " Delete resourcegroup"
        Remove-AzResourceGroup -Name $resourceGroupName -Force
     }
}

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
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location  -Name $namespaceName -SkuName "Standard"
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
    
    $UpdatedNameSpace = Set-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName -SkuName "Standard" -SkuCapacity 2
    Assert-AreEqual $UpdatedNameSpace.Name $namespaceName

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