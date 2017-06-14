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
Get valid resource group name
#>
function Get-ResourceGroupName
{
    return "RGName-" + (getAssetName)	
}

<#
.SYNOPSIS
Get valid Namespace name
#>
function Get-NamespaceName
{
    return "SBNamespace-" + (getAssetName)
}


<#
.SYNOPSIS
Get valid AuthorizationRule name
#>
function Get-AuthorizationRuleName
{
    return "Servicebus-Namespace-AuthorizationRule" + (getAssetName)
	
}

<#
.SYNOPSIS
Tests EventHub Namespace Create List Remove operations.
#>
function ServiceBusTests
{
     # Setup    
    $location = Get-Location
	$namespaceName = Get-NamespaceName
	$namespaceName2 = Get-NamespaceName
	
 
    Write-Debug "Create resource group"
    $resourceGroupName = Get-ResourceGroupName
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force 
     
    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Location $location -SkuName "Standard" 
    Wait-Seconds 15
	
	# Assert 
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
    
	$UpdatedNameSpace = Set-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -Location $location -NamespaceName $namespaceName -SkuName "Standard" -SkuCapacity 10

     $found = 0
     if ($UpdatedNameSpace.Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location.Replace(' ','') $UpdatedNameSpace.Location.Replace(' ','')
            #Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
            #Assert-AreEqual "ServiceBus" $createdNamespace.NamespaceType
            break
        }  

   # Assert-True {$found -eq 0} "Namespace created earlier is not found." 


    Write-Debug "Namespace name : $namespaceName2"
    $result = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location
    Wait-Seconds 15

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName

   $found = 0
    for ($i = 0; $i -lt $allCreatedNamespace.Count; $i++)
    {
        if ($allCreatedNamespace[$i].Name -eq $namespaceName2)
        {
            $found = 1
            Assert-AreEqual $location.Replace(' ','') $allCreatedNamespace[$i].Location.Replace(' ','')
            #Assert-AreEqual $resourceGroupName $allCreatedNamespace[$i].ResourceGroupName
            #Assert-AreEqual "ServiceBus" $allCreatedNamespace[$i].NamespaceType
            break
        }
    }

    #Assert-True {$found -eq 0} "Namespace created earlier is not found in the List."
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzureRmServiceBusNamespace 

    $found = 0
    for ($i = 0; $i -lt $allCreatedNamespace.Count; $i++)
    {
        if ($allCreatedNamespace[$i].Name -eq $namespaceName)
        {
            $found = $found + 1
            Assert-AreEqual $location.Replace(' ','') $allCreatedNamespace[$i].Location.Replace(' ','')
            #Assert-AreEqual $resourceGroupName $allCreatedNamespace[$i].ResourceGroupName
           # Assert-AreEqual "ServiceBus" $allCreatedNamespace[$i].NamespaceType
        }

       if ($allCreatedNamespace[$i].Name -eq $namespaceName2)
        {
            $found = $found + 1
            #Assert-AreEqual $location.Replace(' ','') $allCreatedNamespace[$i].Location.Replace(' ','')
            #Assert-AreEqual $resourceGroupName $allCreatedNamespace[$i].ResourceGroupName
           # Assert-AreEqual "ServiceBus" $allCreatedNamespace[$i].NamespaceType
        }
    }

    #Assert-True {$found -eq 0} "Namespaces created earlier is not found."

    Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
    Remove-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName

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
    $location = "West US"
    
    Write-Debug " Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = Get-NamespaceName
    
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"
	
    $result = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Location $location
    Wait-Seconds 15
    
	Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
    Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location.Replace(' ','') $createdNamespace[$i].Location.Replace(' ','')
           # Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
           # Assert-AreEqual "Messaging" $createdNamespace[$i].NamespaceType
            break
        }
    }

   # Assert-True {$found -eq 0} "Namespace created earlier is not found."

    Write-Debug "Create a Namespace Authorization Rule"
    $authRuleName = Get-AuthorizationRuleName
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzureRmServiceBusNamespaceAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName -Rights @("Listen","Send")
																																	  

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmServiceBusNamespaceAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }   

    Write-Debug "Get the default Namespace AuthorizationRule"
    $defaultNamespaceAuthRule = "RootManageSharedAccessKey"
    $result = Get-AzureRmServiceBusNamespaceAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }  

    Write-Debug "Get All Namespace AuthorizationRule"
    $result = Get-AzureRmServiceBusNamespaceAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName 
    $count = $result.Count
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

	
    Write-Debug "Update Namespace AuthorizationRules ListKeys"
    
    $createdAuthRule.Rights.Add("Manage")

    $updatedAuthRule = Set-AzureRmServiceBusNamespaceAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -AuthRuleObj $createdAuthRule
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }   
    Wait-Seconds 15
    
    Write-Debug "Get updated Namespace AuthorizationRules"
    $updatedAuthRule = Get-AzureRmServiceBusNamespaceAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }


    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmServiceBusNamespaceKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}
	
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmServiceBusNamespaceKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -AuthorizationRule $authRuleName -RegenerateKeys $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmServiceBusNamespaceKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -AuthorizationRule $authRuleName -RegenerateKeys $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}

    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzureRmServiceBusNamespaceAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName
    
    Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
	   
}