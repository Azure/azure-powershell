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
function ServiceBusTests
{
     # Setup    
    $location = Get-Location
	$resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace1-"
	$namespaceName2 = getAssetName "Namespace2-"
 
    Write-Debug "Create resource group"    
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force 
     
	# Check Namespace Name Availability
	$checkNameResult = Test-AzureRmServiceBusName -NamespaceName $namespaceName 
	Assert-True {$checkNameResult.NameAvailable}

    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location  -Name $namespaceName -SkuName "Standard"
	# Assert 
	Assert-AreEqual $result.Name $namespaceName
	Assert-AreEqual $result.ProvisioningState "Succeeded"

    Write-Debug "Get the created namespace within the resource group"
    $getNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
	Assert-AreEqual $getNamespace.Name $namespaceName "Get-ServicebusName- created namespace not found"
    
	$UpdatedNameSpace = Set-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName -SkuName "Standard" -SkuCapacity 2	
	Assert-AreEqual $UpdatedNameSpace.Name $namespaceName

    Write-Debug "Namespace name : $namespaceName2"
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName2    

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName
	Assert-True {$allCreatedNamespace.Count -gt 1}
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzureRmServiceBusNamespace
	Assert-True {$allCreatedNamespace.Count -gt 1 }

    Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests EventHub Namespace AuthorizationRules Create List Remove operations.
#>
function ServiceBusNameSpaceAuthTests
{
    # Setup    
    $location = Get-Location
    $resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace-"
	$authRuleName = getAssetName "authorule-"
	$defaultNamespaceAuthRule = "RootManageSharedAccessKey"
	
    Write-Debug " Create resource group"    
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force    
    
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"	
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
        
	Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    Assert-AreEqual $createdNamespace.Name $namespaceName

    Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen","Send")
	
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

    Write-Debug "Get the default Namespace AuthorizationRule"   
    $result = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }

    Write-Debug "Get All Namespace AuthorizationRule"
    $result = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName

    $found = 0
    for ($i = 0; $i -lt $result.Count; $i++)
    {
        if ($result[$i].Name -eq $authRuleName)
        {
            $found = $found + 1
            Assert-AreEqual 2 $result[$i].Rights.Count
            Assert-True { $result[$i].Rights -Contains "Listen" }
            Assert-True { $result[$i].Rights -Contains "Send" }                      
        }

        if ($result[$i].Name -eq $defaultNamespaceAuthRule)
        {
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

    $updatedAuthRule = Set-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -InputObject $createdAuthRule -Name $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }    
    
    Write-Debug "Get updated Namespace AuthorizationRules"
    $updatedAuthRule = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }

    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}
	
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}

    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Force
    
    Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
	   
}