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
	$resourceGroupName = getAssetName "RGName"
	$namespaceName = getAssetName "Eventhub-Namespace-"
	$authRuleName =  getAssetName "Eventhub-Namespace-AuthorizationRule" 
    
    Write-Debug " Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
    
    Write-Debug " Create new Eventhub namespace"
    Write-Debug "Namespace name : $namespaceName"
	
    $result = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location
    
	Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
    
	#Assert
    Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."

    Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen","Send")																																	  

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }   

    Write-Debug "Get the default Namespace AuthorizationRule"
    $defaultNamespaceAuthRule = "RootManageSharedAccessKey"
    $result = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }  

    Write-Debug "Get All Namespace AuthorizationRule"
    $getallAuthrule = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName 
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
    $updatedAuthRule = Set-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -InputObj $createdAuthRule
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    
    Write-Debug "Get updated Namespace AuthorizationRules"
    $updatedAuthRule = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count "Rights Count does not match"
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }


    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}

	Write-Debug "Regenrate Authorizationrules Keys"
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}

	# Cleanup
    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Force
    
    Write-Debug " Delete namespaces"
    Remove-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests New Parameter for EventHub Namespace Create List Remove operations.
#>

function NamespaceTests
{
    # Setup    
    $location = Get-Location
	$namespaceName = getAssetName "Eventhub-Namespace1-"
	$namespaceName2 = getAssetName "Eventhub-Namespace2-"
    $resourceGroupName = getAssetName "RGName1-"
	$secondResourceGroup = getAssetName "RGName2-"

    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force 

    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $secondResourceGroup"
	New-AzureRmResourceGroup -Name $secondResourceGroup -Location $location -Force 

	# Check Namespace Name Availability

	$checkNameResult = Test-AzureRmEventHubName -Namespace $namespaceName 
	Assert-True {$checkNameResult.NameAvailable}
     
    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location -SkuName "Standard" -SkuCapacity "1" -EnableAutoInflate -MaximumThroughputUnits 10
	
	# Assert 
	Assert-AreEqual $result.ProvisioningState "Succeeded"

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

    Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."	  
    
    Write-Debug "Namespace name : $namespaceName2"
    $result = New-AzureRmEventHubNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2 -Location $location

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $secondResourceGroup
	
	#Assert
    Assert-True {$allCreatedNamespace.Count -ge 0 } "Namespace created earlier is not found. in list"
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzureRmEventHubNamespace
	
    Assert-True {$allCreatedNamespace.Count -ge 0} "Namespaces created earlier is not found."

    Write-Debug " Delete namespaces"
    Remove-AzureRmEventHubNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2
    Remove-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}