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

function NamespaceAuthTests
{
    # Setup    
    $location = Get-Location
	$locationKafka = "westus"
	$resourceGroupName = getAssetName "RGName"
	$namespaceName = getAssetName "Eventhub-Namespace-"
	$namespaceNameKafka = getAssetName "Eh-NamespaceKafka-"
	$authRuleName =  getAssetName "Eventhub-Namespace-AuthorizationRule"
	$authRuleName = getAssetName "authorule-"
	$authRuleNameListen = getAssetName "authorule-"
	$authRuleNameSend = getAssetName "authorule-"
	$authRuleNameAll = getAssetName "authorule-"
    
    Write-Debug " Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
    
	Write-Debug " Create new Eventhub Kafka namespace"
    Write-Debug "Kafka Namespace name : $namespaceNameKafka"	
    $resultkafka = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceNameKafka -Location $locationKafka -EnableKafka
	Assert-AreEqual $resultkafka.Name $namespaceNameKafka "Namespace created earlier is not found."
	Assert-True{$resultkafka.KafkaEnabled}

    Write-Debug " Create new Eventhub namespace"
    Write-Debug "Namespace name : $namespaceName"	
    $result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location
	Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
	Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"
    
	Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	Assert-AreEqual $createdNamespace.ResourceGroup $resourceGroupName "Namespace get : ResourceGroup name matches"
	Assert-AreEqual $createdNamespace.ResourceGroupName $resourceGroupName "Namespace get : ResourceGroupName name matches"
    
	#Assert
    Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."

    Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen", "Send")																																	  

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

	$resultListen = New-AzEventHubAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleNameListen -Rights @("Listen")
	Assert-AreEqual $authRuleNameListen $resultListen.Name
    Assert-AreEqual 1 $resultListen.Rights.Count
    Assert-True { $resultListen.Rights -Contains "Listen" }

	$resultSend = New-AzEventHubAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleNameSend -Rights @("Send")
	Assert-AreEqual $authRuleNameSend $resultSend.Name
    Assert-AreEqual 1 $resultSend.Rights.Count
    Assert-True { $resultSend.Rights -Contains "Send" }

	$resultAll3 = New-AzEventHubAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleNameAll -Rights @("Listen","Send","Manage")
	Assert-AreEqual $authRuleNameAll $resultAll3.Name
    Assert-AreEqual 3 $resultAll3.Rights.Count
    Assert-True { $resultAll3.Rights -Contains "Send" }
	Assert-True { $resultAll3.Rights -Contains "Listen" }
	Assert-True { $resultAll3.Rights -Contains "Manage" }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }   

    Write-Debug "Get the default Namespace AuthorizationRule"
    $defaultNamespaceAuthRule = "RootManageSharedAccessKey"
    $result = Get-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }  

    Write-Debug "Get All Namespace AuthorizationRule"
    $getallAuthrule = Get-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName 
    $count = $getallAuthrule.Count
    Write-Debug "Auth Rule Count : $count"

	Assert-True {$count -ge 1 } "List AuthorizationRule: Namespace AuthorizationRules created earlier is not found."

    for ($i = 0; $i -lt $getallAuthrule.Count; $i++)
    {
        if ($getallAuthrule[$i].Name -eq $authRuleName)
        {
            Assert-AreEqual 2 $getallAuthrule[$i].Rights.Count
            Assert-True { $getallAuthrule[$i].Rights -Contains "Listen" }
            Assert-True { $getallAuthrule[$i].Rights -Contains "Send" }                      
        }

        if ($getallAuthrule[$i].Name -eq $defaultNamespaceAuthRule)
        {            
            Assert-AreEqual 3 $getallAuthrule[$i].Rights.Count
            Assert-True { $getallAuthrule[$i].Rights -Contains "Listen" }
            Assert-True { $getallAuthrule[$i].Rights -Contains "Send" }
            Assert-True { $getallAuthrule[$i].Rights -Contains "Manage" }         
        }
    }
	
    Write-Debug "Update Namespace AuthorizationRules"   
    $createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -InputObj $createdAuthRule
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    
    Write-Debug "Get updated Namespace AuthorizationRules"
    $updatedAuthRule = Get-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count "Rights Count does not match"
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString -like "*$($updatedAuthRule.PrimaryKey)*"}
    Assert-True {$namespaceListKeys.SecondaryConnectionString -like "*$($updatedAuthRule.SecondaryKey)*"}

	Write-Debug "Regenrate Authorizationrules Keys"
	$policyKey = "PrimaryKey"

	$StartTime = Get-Date
	$EndTime = $StartTime.AddHours(2.0)
	$SasToken = New-AzEventHubAuthorizationRuleSASToken -ResourceId $updatedAuthRule.Id  -KeyType Primary -ExpiryTime $EndTime -StartTime $StartTime
	$SasToken = New-AzEventHubAuthorizationRuleSASToken -AuthorizationRuleId $updatedAuthRule.Id  -KeyType Primary -ExpiryTime $EndTime -StartTime $StartTime

	$namespaceRegenerateKeysDefault = New-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeysDefault.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$namespaceRegenerateKeys = New-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey -KeyValue $namespaceListKeys.PrimaryKey
	Assert-AreEqual $namespaceRegenerateKeys.PrimaryKey $namespaceListKeys.PrimaryKey

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey1 -KeyValue $namespaceListKeys.PrimaryKey
	Assert-AreEqual $namespaceRegenerateKeys1.SecondaryKey $namespaceListKeys.PrimaryKey
	
	$namespaceRegenerateKeys1 = New-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.PrimaryKey}

	# Cleanup
    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Force
    
    Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
    Remove-AzEventHubNamespace -ResourceId $resultkafka.Id

	Write-Debug " Delete resourcegroup"
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests New Parameter for EventHub Namespace Create List Remove operations.
#>

function NamespaceTests
{
    # Setup    
    $location = Get-Location	
	$locationKafka = "westus"
	$namespaceName = getAssetName "Eventhub-Namespace1-"
	$namespaceName2 = getAssetName "Eventhub-Namespace2-"
    $resourceGroupName = getAssetName "RGName1-"
	$secondResourceGroup = getAssetName "RGName2-"
	$namespaceNameKafka = getAssetName "Eh-NamespaceKafka-"


    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
	New-AzResourceGroup -Name $resourceGroupName -Location $location -Force 

    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $secondResourceGroup"
	New-AzResourceGroup -Name $secondResourceGroup -Location $location -Force 

	# Check Namespace Name Availability

	$checkNameResult = Test-AzEventHubName -Namespace $namespaceName 
	Assert-True {$checkNameResult.NameAvailable}

	Write-Debug " Create new Eventhub Kafka namespace"
    Write-Debug "Kafka Namespace name : $namespaceNameKafka"	
    $resultkafka = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceNameKafka -Location $locationKafka -EnableKafka
	Assert-AreEqual $resultkafka.Name $namespaceNameKafka "Namespace created earlier is not found."
	Assert-True {$resultkafka.KafkaEnabled}
    
    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location -SkuName "Standard" -SkuCapacity "1" -EnableAutoInflate -MaximumThroughputUnits 10
	Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
	Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"
	
	# Assert 
	Assert-AreEqual $result.ProvisioningState "Succeeded"

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	Assert-AreEqual $createdNamespace.ResourceGroup $resourceGroupName "Namespace get : ResourceGroup name matches"
	Assert-AreEqual $createdNamespace.ResourceGroupName $resourceGroupName "Namespace get: ResourceGroupName name matches"

    Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."	  
    
    Write-Debug "Namespace name : $namespaceName2"
    $result = New-AzEventHubNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2 -Location $location

	### change the Namespace SKU to Basic
	Write-Debug "Namespace name : $namespaceName2"
	$result = Set-AzEventHubNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2 -Location $location -SkuName "Basic"
	Assert-AreEqual $result.Sku.Name "Basic" "Namespace SKU not changed."
	   
    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzEventHubNamespace -ResourceGroup $secondResourceGroup
	
	#Assert
    Assert-True {$allCreatedNamespace.Count -ge 0 } "Namespace created earlier is not found. in list"
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzEventHubNamespace
	
    Assert-True {$allCreatedNamespace.Count -ge 0} "Namespaces created earlier is not found."

    Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2
    Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}
