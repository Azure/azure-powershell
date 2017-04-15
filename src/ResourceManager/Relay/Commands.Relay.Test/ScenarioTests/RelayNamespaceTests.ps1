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
Get ResourceGroup name
#>
function Get-ResourceGroupName
{
  return "RGName-" + (getAssetName)
}

<#
.SYNOPSIS
Get Relay name
#>
function Get-RelayName
{
    return "Relay-" + (getAssetName)
}

<#
.SYNOPSIS
Get Namespace name
#>
function Get-NamespaceName
{
    return "Relay-Namespace-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid AuthorizationRule name
#>
function Get-AuthorizationRuleName
{
    return "Relay-Namespace-AuthorizationRule" + (getAssetName)
	
}

<#
.SYNOPSIS
Tests Relay Namespace AuthorizationRules Create List Remove operations.
#>
function RelayNamespaceAuthTests
{
    # Setup    
    $location = Get-Location
	$resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName
	$authRuleName = Get-AuthorizationRuleName	
    
    Write-Debug " Create resource group"    
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force    
    
    Write-Debug " Create new RelayNamespace namespace"
    Write-Debug "Namespace name : $namespaceName"
	
    $result = New-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location
    Wait-Seconds 15

	Assert-True {$result.ProvisioningState -eq "Succeeded"}
    
	Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

    Assert-True {$createdNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."

    Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzureRmRelayNamespaceAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName -Rights @("Listen","Send")

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmRelayNamespaceAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }   

    Write-Debug "Get the default Namespace AuthorizationRule"
    $defaultNamespaceAuthRule = "RootManageSharedAccessKey"
    $result = Get-AzureRmRelayNamespaceAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count 
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }  

    Write-Debug "Get All Namespace AuthorizationRule"
    $result = Get-AzureRmRelayNamespaceAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName 
    $count = $result.Items.Count
    Write-Debug "Auth Rule Count : $count"

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

    Assert-True {$found -eq 2} "Namespace AuthorizationRules created earlier is not found."

	
    Write-Debug "Update Namespace AuthorizationRules"   
    $createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzureRmRelayNamespaceAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthRuleObj $createdAuthRule
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }   
    Wait-Seconds 15
    
    Write-Debug "Get updated Namespace AuthorizationRules"
    $updatedAuthRule = Get-AzureRmRelayNamespaceAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }


    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmRelayNamespaceKey -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}

	Write-Debug "Regenrate Authorizationrules Keys"
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmRelayNamespaceKey -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName  -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmRelayNamespaceKey -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName  -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}


	# Cleanup
    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzureRmRelayNamespaceAuthorizationRule -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName
    
    Write-Debug " Delete namespaces"
    Remove-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force	   
}

<#
.SYNOPSIS
Tests Relay Namespace Create List Remove operations.
#>
function RelayNamespaceTests 
{
    # Setup    
    $location = Get-Location
	$namespaceName = Get-NamespaceName
	$namespaceName2 = Get-NamespaceName
    $resourceGroupName = Get-ResourceGroupName
	$secondResourceGroup = Get-ResourceGroupName
 
    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force 

    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $secondResourceGroup"
	New-AzureRmResourceGroup -Name $secondResourceGroup -Location $location -Force 
     
     
    Write-Debug " Create new Relay namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location
    Wait-Seconds 15
	
	# Assert 
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
   
    Assert-True {$createdNamespace.Name -eq $namespaceName} "Get-AzureRmRelayNamespace Namespace created earlier is not found. "    

    
    Write-Debug "Namespace name : $namespaceName2" 
    $result = New-AzureRmRelayNamespace -ResourceGroupName $secondResourceGroup -NamespaceName $namespaceName2 -Location $location
    Wait-Seconds 15

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzureRmRelayNamespace -ResourceGroupName $secondResourceGroup 

    Assert-True {$allCreatedNamespace[0].Name -eq $namespaceName2} "Get-AzureRmRelayNamespace - ResourceGroup Namespace created earlier is not found"
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzureRmRelayNamespace 

    $found = 0
    for ($i = 0; $i -lt $allCreatedNamespace.Items.Count; $i++)
    {
        if ($allCreatedNamespace[$i].Name -eq $namespaceName)
        {
            $found = $found + 1
            Assert-AreEqual $location $allCreatedNamespace[$i].Location
        }

       if ($allCreatedNamespace[$i].Name -eq $namespaceName2)
        {
            $found = $found + 1
            Assert-AreEqual $location $allCreatedNamespace[$i].Location
        }
    }

    Assert-True {$found -eq 0} "Get-AzureRmRelayNamespace - Subscription Namespaces created earlier is not found. 3"    

    Write-Debug " Delete namespaces"
    Remove-AzureRmRelayNamespace -ResourceGroupName $secondResourceGroup -NamespaceName $namespaceName2
    Remove-AzureRmRelayNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}