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
    #return "RGName-" + (getAssetName)
	return "Default-ServiceBus-WestUS"
}

<#
.SYNOPSIS
Get EventHub name
#>
function Get-EventHubName
{
    return "EventHub-" + (getAssetName)
}

<#
.SYNOPSIS
Get Namespace name
#>
function Get-NamespaceName
{
    return "Namespace-" + (getAssetName)
}

<#
.SYNOPSIS
Tests EventHub Namespace Create List Remove operations.
#>
function EventHubsNamespaceTests
{
    # Setup    
    $location = "West US"
 
    Write-Debug "Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
    Write-Debug "ResourceGroup name : $resourceGroupName" 

    $namespaceName = Get-NamespaceName
    
    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Location $location
    Wait-Seconds 15

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
    Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location $createdNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
            Assert-AreEqual "EventHub" $createdNamespace[$i].NamespaceType
            break
        }
    }

    Assert-True {$found -eq 0} "Namespace created earlier is not found."

    Write-Debug "Create one more resource group"
    $secondResourceGroup = Get-ResourceGroupName
    Write-Debug "ResourceGroup name : $secondResourceGroup" 
    New-AzureRmResourceGroup -Name $secondResourceGroup -Location $location -Force    

    Write-Debug "Create 2nd new eventHub namespace"
    $namespaceName2 = Get-NamespaceName
    Write-Debug "Namespace name : $namespaceName2" 
    $result = New-AzureRmEventHubsNamespace -ResourceGroup $secondResourceGroup -Namespace $namespaceName2 -Location $location
    Wait-Seconds 15

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzureRmEventHubsNamespace -ResourceGroup $secondResourceGroup 

    $found = 0
    for ($i = 0; $i -lt $allCreatedNamespace.Count; $i++)
    {
        if ($allCreatedNamespace[$i].Name -eq $namespaceName2)
        {
            $found = 1
            Assert-AreEqual $location $allCreatedNamespace[$i].Location
            Assert-AreEqual $secondResourceGroup $allCreatedNamespace[$i].ResourceGroupName
            Assert-AreEqual "EventHub" $allCreatedNamespace[$i].NamespaceType
            break
        }
    }

    Assert-True {$found -eq 0} "Namespace created earlier is not found."
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzureRmEventHubsNamespace 

    $found = 0
    for ($i = 0; $i -lt $allCreatedNamespace.Count; $i++)
    {
        if ($allCreatedNamespace[$i].Name -eq $namespaceName)
        {
            $found = $found + 1
            Assert-AreEqual $location $allCreatedNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $allCreatedNamespace[$i].ResourceGroupName
            Assert-AreEqual "EventHub" $allCreatedNamespace[$i].NamespaceType
        }

       if ($allCreatedNamespace[$i].Name -eq $namespaceName2)
        {
            $found = $found + 1
            Assert-AreEqual $location $allCreatedNamespace[$i].Location
            Assert-AreEqual $secondResourceGroup $allCreatedNamespace[$i].ResourceGroupName
            Assert-AreEqual "EventHub" $allCreatedNamespace[$i].NamespaceType
        }
    }

    Assert-True {$found -eq 0} "Namespaces created earlier is not found."    

    Write-Debug " Delete namespaces"
    Remove-AzureRmEventHubsNamespace -ResourceGroup $secondResourceGroup -Namespace $namespaceName2
    Remove-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName

    #Write-Debug " Remove resource group"
    #Remove-AzureRmEventHubsNamespace -Name $resourceGroupName #-Force
    #Remove-AzureRmEventHubsNamespace -Name $secondResourceGroup #-Force
}

<#
.SYNOPSIS
Tests EventHub Namespace AuthorizationRules Create List Remove operations.
#>
function EventHubsNamespaceAuthTests
{
    # Setup    
    $location = "West US"
    
    Write-Debug " Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = Get-NamespaceName
    
    Write-Debug " Create new notificationHub namespace"
    Write-Debug "Namespace name : $namespaceName"
	
    $result = New-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Location $location
    Wait-Seconds 15
    
	Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
    Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location $createdNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
           # Assert-AreEqual "EventHub" $createdNamespace[$i].NamespaceType
            break
        }
    }

    Assert-True {$found -eq 0} "Namespace created earlier is not found."

    Write-Debug "Create a Namespace Authorization Rule"
    $authRuleName = "TestAuthRule"
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzureRmEventHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -InputFile .\.\Resources\NewAuthorizationRule.json
																																	  

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmEventHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }   

    Write-Debug "Get the default Namespace AuthorizationRule"
    $defaultNamespaceAuthRule = "RootManageSharedAccessKey"
    $result = Get-AzureRmEventHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }  

    Write-Debug "Get All Namespace AuthorizationRule"
    $result = Get-AzureRmEventHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName 
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
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    #$newPrimaryKey = "SW4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkQWE="
    #$createdAuthRule.PrimaryKey = $newPrimaryKey
    $createdAuthRule.Rights.Add("Manage")

    $updatedAuthRule = Set-AzureRmEventHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -InputFile .\.\Resources\SetAuthorizationRule.json
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }   
    Wait-Seconds 15
    
    Write-Debug "Get updated Namespace AuthorizationRules"
    $updatedAuthRule = Get-AzureRmEventHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }


    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmEventHubsNamespaceListKeys -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}

    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzureRmEventHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName
    
    Write-Debug " Delete namespaces"
    Remove-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
	   
}