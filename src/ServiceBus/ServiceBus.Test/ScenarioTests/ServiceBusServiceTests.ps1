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
<<<<<<< HEAD
function ServiceBusTests
{
     # Setup    
    $location = Get-Location
	$resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace1-"
	$namespaceName2 = getAssetName "Namespace2-"
 
    Write-Debug "Create resource group"    
	New-AzResourceGroup -Name $resourceGroupName -Location $location -Force 
     
	# Check Namespace Name Availability
	$checkNameResult = Test-AzServiceBusName -NamespaceName $namespaceName 
	Assert-True {$checkNameResult.NameAvailable}
=======
function ServiceBusTests {
    # Setup    
    $location = Get-Location
    $resourceGroupName = getAssetName "RGName-"
    $namespaceName = getAssetName "Namespace1-"
    $namespaceName2 = getAssetName "Namespace2-"
 
    Write-Debug "Create resource group"    
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force 
     
    # Check Namespace Name Availability
    $checkNameResult = Test-AzServiceBusName -NamespaceName $namespaceName 
    Assert-True { $checkNameResult.NameAvailable }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName"
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location  -Name $namespaceName -SkuName "Standard"
<<<<<<< HEAD
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
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    Write-Debug "Namespace name : $namespaceName2"
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName2

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName
<<<<<<< HEAD
	Assert-True {$allCreatedNamespace.Count -gt 1}
	
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzServiceBusNamespace
	Assert-True {$allCreatedNamespace.Count -gt 1 }
=======
    Assert-True { $allCreatedNamespace.Count -gt 1 }
	
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzServiceBusNamespace
    Assert-True { $allCreatedNamespace.Count -gt 1 }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    Write-Debug " Delete namespaces"
    Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2
    Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

<<<<<<< HEAD
	Write-Debug " Delete resourcegroup"
	Remove-AzResourceGroup -Name $resourceGroupName -Force
=======
    Write-Debug " Delete resourcegroup"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

<#
.SYNOPSIS
Tests EventHub Namespace AuthorizationRules Create List Remove operations.
#>
<<<<<<< HEAD
function ServiceBusNameSpaceAuthTests
{
    # Setup    
    $location = Get-Location
    $resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace-"
	$authRuleName = getAssetName "authorule-"
	$defaultNamespaceAuthRule = "RootManageSharedAccessKey"
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	
    Write-Debug " Create resource group"    
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force    
    
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"	
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
        
<<<<<<< HEAD
	Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    Assert-AreEqual $createdNamespace.Name $namespaceName

	Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen","Send")
=======
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    Assert-AreEqual $createdNamespace.Name $namespaceName

    Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen", "Send")
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

<<<<<<< HEAD

    Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen","Send")
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	
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
<<<<<<< HEAD
    for ($i = 0; $i -lt $result.Count; $i++)
    {
        if ($result[$i].Name -eq $authRuleName)
        {
=======
    for ($i = 0; $i -lt $result.Count; $i++) {
        if ($result[$i].Name -eq $authRuleName) {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            $found = $found + 1
            Assert-AreEqual 2 $result[$i].Rights.Count
            Assert-True { $result[$i].Rights -Contains "Listen" }
            Assert-True { $result[$i].Rights -Contains "Send" }                      
        }

<<<<<<< HEAD
        if ($result[$i].Name -eq $defaultNamespaceAuthRule)
        {
=======
        if ($result[$i].Name -eq $defaultNamespaceAuthRule) {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
    Assert-True {$namespaceListKeys.PrimaryConnectionString -like "*$($updatedAuthRule.PrimaryKey)*"}
    Assert-True {$namespaceListKeys.SecondaryConnectionString -like "*$($updatedAuthRule.SecondaryKey)*"}
	
	# Regentrate the Keys 
	$policyKey = "PrimaryKey"

	$StartTime = Get-Date
	$EndTime = $StartTime.AddHours(2.0)
	$SasToken = New-AzServiceBusAuthorizationRuleSASToken -ResourceId $updatedAuthRule.Id  -KeyType Primary -ExpiryTime $EndTime -StartTime $StartTime
	$SasToken = New-AzServiceBusAuthorizationRuleSASToken -AuthorizationRuleId $updatedAuthRule.Id  -KeyType Primary -ExpiryTime $EndTime -StartTime $StartTime

	$namespaceRegenerateKeysDefualt = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$namespaceRegenerateKeys = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey -KeyValue $namespaceListKeys.PrimaryKey
	Assert-AreEqual $namespaceRegenerateKeys.PrimaryKey $namespaceListKeys.PrimaryKey

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey1 -KeyValue $namespaceListKeys.PrimaryKey
	Assert-AreEqual $namespaceRegenerateKeys1.SecondaryKey $namespaceListKeys.PrimaryKey
																	
	$namespaceRegenerateKeys1 = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.PrimaryKey}
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Force
    
    Write-Debug " Delete namespaces"
    Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
	   
}