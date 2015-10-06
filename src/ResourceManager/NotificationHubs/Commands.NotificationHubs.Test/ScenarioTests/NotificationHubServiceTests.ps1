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
Get valid NotificationHub name
#>
function Get-NotificationHubName
{
    return "NotificationHub-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid Namespace name
#>
function Get-NamespaceName
{
    return "Namespace-" + (getAssetName)
}

<#
.SYNOPSIS
Tests NotificationHub Namespace Create List Remove operations.
#>
function Test-CRUDNamespace
{
    # Setup    
    $location = "South Central US"
	
	Write-Debug "Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    New-AzureResourceGroup -Name $resourceGroupName -Location $location -Force
	Write-Debug "ResourceGroup name : $resourceGroupName" 

    $namespaceName = Get-NamespaceName
    
    Write-Debug " Create new notificationHub namespace"
	Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location

	Write-Debug "Result :"
	Write-Debug $result

    #Assert-AreEqual $namespaceName $result.properties.name
    #Assert-AreEqual $location $result.Location
	#Assert-AreEqual "NotificationHub" $result.properties.namespaceType

	Start-Sleep -Seconds 10
	
    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
    Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location $createdNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
			Assert-AreEqual "NotificationHub" $createdNamespace[$i].NamespaceType
            break
        }
    }

    Assert-True {$found -eq 1} "Namespace created earlier is not found."

	Write-Debug "Create one more resource group"
    $secondResourceGroup = Get-ResourceGroupName
	Write-Debug "ResourceGroup name : $secondResourceGroup" 
    New-AzureResourceGroup -Name $secondResourceGroup -Location $location -Force	

	Write-Debug "Create 2nd new notificationHub namespace"
	$namespaceName2 = Get-NamespaceName
	Write-Debug "Namespace name : $namespaceName2" 
    $result = New-AzureNotificationHubsNamespace -ResourceGroupName $secondResourceGroup -NamespaceName $namespaceName2 -Location $location

    #Assert-AreEqual $secondResourceGroup $result.ResourceGroupName
    #Assert-AreEqual $namespaceName2 $result.Name
    #Assert-AreEqual $location $result.Location
	#Assert-AreEqual "NotificationHub" $result.NamespaceType

	Write-Debug "Get all the namespaces created in the resourceGroup"
	$allCreatedNamespace = Get-AzureNotificationHubsNamespace -ResourceGroupName $secondResourceGroup 

    $found = 0
    for ($i = 0; $i -lt $allCreatedNamespace.Count; $i++)
    {
        if ($allCreatedNamespace[$i].Name -eq $namespaceName2)
        {
            $found = 1
            Assert-AreEqual $location $allCreatedNamespace[$i].Location
            Assert-AreEqual $secondResourceGroup $allCreatedNamespace[$i].ResourceGroupName
			Assert-AreEqual "NotificationHub" $allCreatedNamespace[$i].NamespaceType
            break
        }
    }

	Assert-True {$found -eq 1} "Namespace created earlier is not found."
	
	Write-Debug "Get all the namespaces created in the subscription"
	$allCreatedNamespace = Get-AzureNotificationHubsNamespace 

    $found = 0
    for ($i = 0; $i -lt $allCreatedNamespace.Count; $i++)
    {
        if ($allCreatedNamespace[$i].Name -eq $namespaceName)
        {
            $found = $found + 1
            Assert-AreEqual $location $allCreatedNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $allCreatedNamespace[$i].ResourceGroupName
			Assert-AreEqual "NotificationHub" $allCreatedNamespace[$i].NamespaceType
        }

	   if ($allCreatedNamespace[$i].Name -eq $namespaceName2)
        {
            $found = $found + 1
            Assert-AreEqual $location $allCreatedNamespace[$i].Location
            Assert-AreEqual $secondResourceGroup $allCreatedNamespace[$i].ResourceGroupName
			Assert-AreEqual "NotificationHub" $allCreatedNamespace[$i].NamespaceType
        }
    }

	Assert-True {$found -eq 2} "Namespaces created earlier is not found."	

	Write-Debug " Update an existing namespace"
	$tags = New-Object 'System.Collections.Generic.Dictionary[String,String]'
	$tags.Add("tag1","value1")
	$tags.Add("tag2","value2")
    $updatedNamespace = Set-AzureNotificationHubsNamespace -ResourceGroupName $secondResourceGroup -NamespaceName $namespaceName2 -Location $location -Tags $tags 
	Assert-AreEqual 2 $updatedNamespace.Tags.Count

	Write-Debug " Get the updated namespace "
    $getUpdatedNamespace = Get-AzureNotificationHubsNamespace -ResourceGroupName $secondResourceGroup -NamespaceName $namespaceName2
    Assert-AreEqual 2 $getUpdatedNamespace.Tags.Count

    Write-Debug " Delete namespaces"
    Remove-AzureNotificationHubsNamespace -ResourceGroupName $secondResourceGroup -NamespaceName $namespaceName2
    Remove-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

    $firstRG = Get-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName
    $secondRG = Get-AzureNotificationHubsNamespace -ResourceGroupName $secondResourceGroup
    Assert-AreEqual 0 $firstRG.Count
    Assert-AreEqual 0 $secondRG.Count

    Write-Debug " Remove resource group"
    Remove-AzureResourceGroup -Name $resourceGroupName -Force
    Remove-AzureResourceGroup -Name $secondResourceGroup -Force
}

<#
.SYNOPSIS
Tests NotificationHub Namespace AuthorizationRules Create List Remove operations.
#>
function Test-CRUDNamespaceAuthorizationRules
{
    # Setup    
    $location = "South Central US"
	
	# Create resource group
    $resourceGroupName = Get-ResourceGroupName
    New-AzureResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = Get-NamespaceName
    
    # Create new notificationHub namespace
    $result = New-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location

    Assert-AreEqual $resourceGroupName $result.ResourceGroupName
    Assert-AreEqual $namespaceName $result.Name
    Assert-AreEqual $location $result.Location
	Assert-AreEqual "NotificationHub" $result.NamespaceType

	Start-Sleep -Seconds 10
	
    # Get the created namespace within the resource group
    $createdNamespace = Get-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
    Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location $createdNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
			Assert-AreEqual "NotificationHub" $createdNamespace[$i].NamespaceType
            break
        }
    }

    Assert-True {$found -eq 1} "Namespace created earlier is not found."

	#Create a Namespace Authorization Rule
	$authRuleName = "TestAuthRule"
	$result = New-AzureNotificationHubsNamespaceAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -InputFile .\Resources\NewAuthorizationRule.json

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
	Assert-True { $result.Rights -Contains "Listen" }
	Assert-True { $result.Rights -Contains "Send" }

	#Get created authorizationRule
    $createdAuthRule = Get-AzureNotificationHubsNamespaceAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
	Assert-True { $createdAuthRule.Rights -Contains "Listen" }
	Assert-True { $createdAuthRule.Rights -Contains "Send" }
    Assert-AreEqual "IR4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkATU=" $createdAuthRule.PrimaryKey
    Assert-NotNull $createdAuthRule.SecondaryKey

	#Get the default Namespace AuthorizationRule
	$defaultNamespaceAuthRule = "RootManageSharedAccessKey"
	$result = Get-AzureNotificationHubsNamespaceAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
	Assert-True { $result.Rights -Contains "Listen" }
	Assert-True { $result.Rights -Contains "Send" }
	Assert-True { $result.Rights -Contains "Manage" }
    Assert-NotNull $result.PrimaryKey
    Assert-NotNull $result.SecondaryKey


	#Get All Namespace AuthorizationRule
    $result = Get-AzureNotificationHubsNamespaceAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

    Assert-AreEqual {2 -ge $result.Count } 

    $found = 0
    for ($i = 0; $i -lt $result.Count; $i++)
    {
        if ($result[$i].Name -eq $authRuleName)
        {
            $found = $found + 1
			Assert-AreEqual 2 $result[$i].Rights.Count
			Assert-True { $result[$i].Rights -Contains "Listen" }
			Assert-True { $result[$i].Rights -Contains "Send" }
			Assert-NotNull $result[$i].PrimaryKey
			Assert-AreEqual "IR4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkATU=" $result[$i].PrimaryKey
			Assert-NotNull $result[$i].SecondaryKey
        }

		if ($result[$i].Name -eq $defaultNamespaceAuthRule)
        {
            $found = $found + 1
			Assert-AreEqual 3 $result[$i].Rights.Count
			Assert-True { $result[$i].Rights -Contains "Listen" }
			Assert-True { $result[$i].Rights -Contains "Send" }
			Assert-True { $result[$i].Rights -Contains "Manage" }
			Assert-NotNull $result[$i].PrimaryKey
			Assert-NotNull $result[$i].SecondaryKey
        }
    }

    Assert-True {$found -eq 2} "Namespace AuthorizationRules created earlier is not found."

	#Update Namespace AuthorizationRules
	$newPrimaryKey = "SW4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkQWE="
	$createdAuthRule.PrimaryKey = $newPrimaryKey
	$createdAuthRule.Rights.Add("Manage")

	$updatedAuthRule = Set-AzureNotificationHubsNamespaceAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -SASRule $createdAuthRule
	
	Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
	Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
	Assert-True { $updatedAuthRule.Rights -Contains "Send" }
	Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    Assert-AreEqual $newPrimaryKey $updatedAuthRule.PrimaryKey
    Assert-NotNull $updatedAuthRule.SecondaryKey

	Start-Sleep -Seconds 10
	
	$updatedAuthRule = Get-AzureNotificationHubsNamespaceAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName
	
	Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
	Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
	Assert-True { $updatedAuthRule.Rights -Contains "Send" }
	Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    Assert-AreEqual $newPrimaryKey $updatedAuthRule.PrimaryKey
    Assert-NotNull $updatedAuthRule.SecondaryKey

	#Get namespace authorizationRules connectionStrings
	$namespaceListKeys = Get-AzureNotificationHubsNamespaceListKeys -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName

	Assert-AreEqual $namespaceListKeys.PrimaryConnectionString.Contains($newPrimaryKey)
    Assert-AreEqual 3 $namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)

	#Delete the created Namespace AuthorizationRule
	$result = Remove-AzureNotificationHubsNamespaceListKeys -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName
	
	$getDeletedNSAuth = Get-AzureNotificationHubsNamespaceListKeys -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AuthorizationRuleName $authRuleName
    Assert-AreEqual 0 $getDeletedNSAuth.Count
	
	# Delete namespaces
    Remove-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

    $getDeletedNS = Get-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName
    Assert-AreEqual 0 $getDeletedNS.Count

    # Remove resource group
    Remove-AzureResourceGroup -Name $resourceGroupName -Force
}


<#
.SYNOPSIS
Tests NotificationHub Create List Remove operations.
#>
function Test-CRUDNotificationHub
{
	# Setup    
    $location = "South Central US"
	
	# Create resource group
    $resourceGroupName = Get-ResourceGroupName
    New-AzureResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = Get-NamespaceName
    
    # Create new notificationHub namespace
    $result = New-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location

    Assert-AreEqual $resourceGroupName $result.ResourceGroupName
    Assert-AreEqual $namespaceName $result.Name
    Assert-AreEqual $location $result.Location
	Assert-AreEqual "NotificationHub" $result.NamespaceType

	Start-Sleep -Seconds 10
	
    # Get the created namespace within the resource group
    $createdNamespace = Get-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
    Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location $createdNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
			Assert-AreEqual "NotificationHub" $createdNamespace[$i].NamespaceType
            break
        }
    }

    Assert-True {$found -eq 1} "Namespace created earlier is not found."

    # Create new notificationHub 
	$notificationHubName = "TestNh"
    $result = New-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -InputFile .\Resources\NewNotificationHub.json

	# Get the created notificationHub 
    $createdNotificationHub = Get-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName
    Assert-True {$createdNotificationHub.Count -eq 1}

	# Create another new notificationHub 
	$notificationHubName2 = Get-NotificatioHubName
	$createdNotificationHub.Name = $notificationHubName2
	$createdNotificationHub.Location = "South Central US"
	$createdNotificationHub.WnsCredential.PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699"
	$createdNotificationHub.WnsCredential.SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp"
	$createdNotificationHub.WnsCredential.WindowsLiveEndpoint = "http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
    $result = New-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubObj $createdNotificationHub

	# Get the PNS credentials for the second notificationHub created
	$pnsCredentials = Get-AzureNotificationHubPNSCredentials -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName2
	Assert-AreEqual  $createdNotificationHub.WnsCredential.PackageSid $pnsCredentials.WnsCredential.PackageSid
	Assert-AreEqual  $createdNotificationHub.WnsCredential.SecretKey $pnsCredentials.WnsCredential.SecretKey
	Assert-AreEqual  $createdNotificationHub.WnsCredential.WindowsLiveEndpoint $pnsCredentials.WnsCredential.WindowsLiveEndpoint
	
	# Get all the created notificationHub 
    $createdNotificationHubList = Get-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
    Assert-True {$createdNotificationHub.Count -ge 2}

	$found = 0
    for ($i = 0; $i -lt $createdNotificationHubList.Count; $i++)
    {
        if ($createdNotificationHubList[$i].Name -eq $notificationHubName)
        {
            $found = $found + 1
        }

		if ($createdNotificationHubList[$i].Name -eq $notificationHubName2)
        {
            $found = $found + 1
        }
    }

    Assert-True {$found -eq 2} "NotificationHubs created earlier is not found."

	# Update the first notificationHub 
	$createdNotificationHub.Name = $notificationHubName
	$createdNotificationHub.Location = "South Central US"
	$createdNotificationHub.WnsCredential.PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699"
	$createdNotificationHub.WnsCredential.SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp"
	$createdNotificationHub.WnsCredential.WindowsLiveEndpoint = "http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
    $result = Set-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubObj $createdNotificationHub

	# Get the PNS credentials for the first notificationHub created
	$pnsCredentials = Get-AzureNotificationHubPNSCredentials -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName
	Assert-AreEqual  $createdNotificationHub.WnsCredential.PackageSid $pnsCredentials.WnsCredential.PackageSid
	Assert-AreEqual  $createdNotificationHub.WnsCredential.SecretKey $pnsCredentials.WnsCredential.SecretKey
	Assert-AreEqual  $createdNotificationHub.WnsCredential.WindowsLiveEndpoint $pnsCredentials.WnsCredential.WindowsLiveEndpoint

	# Delete the NotificationHub
	$delete1 = Remove-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName
	$delete2 = Remove-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName2

	# Get the deleted notificationHub 
    $deletedNotificationHub = Get-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName
    Assert-True {$deletedNotificationHub.Count -eq 0}

	$deletedNotificationHub = Get-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName2
    Assert-True {$deletedNotificationHub.Count -eq 0}

	# Delete namespaces
    Remove-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

    $getDeletedNS = Get-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName
    Assert-AreEqual 0 $getDeletedNS.Count

    # Remove resource group
    Remove-AzureResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests NotificationHub AuthorizationRules Create List Remove operations.
#>
function Test-CRUDNotificationHubAuthorizationRules
{
    # Setup    
    $location = "South Central US"
	
	# Create resource group
    $resourceGroupName = Get-ResourceGroupName
    New-AzureResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = Get-NamespaceName
    
    # Create new notificationHub namespace
    $result = New-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location

    Assert-AreEqual $resourceGroupName $result.ResourceGroupName
    Assert-AreEqual $namespaceName $result.Name
    Assert-AreEqual $location $result.Location
	Assert-AreEqual "NotificationHub" $result.NamespaceType

	Start-Sleep -Seconds 10
	
    # Get the created namespace within the resource group
    $createdNamespace = Get-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
    Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location $createdNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
			Assert-AreEqual "NotificationHub" $createdNamespace[$i].NamespaceType
            break
        }
    }

    Assert-True {$found -eq 1} "Namespace created earlier is not found."

	# Create new notificationHub 
	$notificationHubName = "TestNh"
    $result = New-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -InputFile .\Resources\NewNotificationHub.json

	# Get the created notificationHub 
    $createdNotificationHub = Get-AzureNotificationHub -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName
    Assert-True {$createdNotificationHub.Count -eq 1}

	#Create a notificationHub Authorization Rule
	$authRuleName = "TestAuthRule"
	$result = New-AzureNotificationHubAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName -InputFile .\Resources\NewAuthorizationRule.json

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 3 $result.Rights.Count
	Assert-True { $result.Rights -Contains "Listen" }
	Assert-True { $result.Rights -Contains "Send" }

	#Get created authorizationRule
    $createdAuthRule = Get-AzureNotificationHubAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName -AuthorizationRuleName $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 3 $createdAuthRule.Rights.Count
	Assert-True { $createdAuthRule.Rights -Contains "Listen" }
	Assert-True { $createdAuthRule.Rights -Contains "Send" }
    Assert-AreEqual "IR4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkATU=" $createdAuthRule.PrimaryKey
    Assert-NotNull $createdAuthRule.SecondaryKey

	#Get All notificationHub AuthorizationRule
    $result = Get-AzureNotificationHubAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName 

    Assert-AreEqual {3 -ge $result.Count } 

    $found = 0
    for ($i = 0; $i -lt $result.Count; $i++)
    {
        if ($result[$i].Name -eq $authRuleName)
        {
            $found = 1
			Assert-AreEqual 2 $result[$i].Rights.Count
			Assert-True { $result[$i].Rights -Contains "Listen" }
			Assert-True { $result[$i].Rights -Contains "Send" }
			Assert-NotNull $result[$i].PrimaryKey
			Assert-AreEqual "IR4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkATU=" $result[$i].PrimaryKey
			Assert-NotNull $result[$i].SecondaryKey
			break
        }
    }

    Assert-True {$found -eq 1} "NotificationHub AuthorizationRule created earlier is not found."

	#Update notificationHub AuthorizationRules
	$newPrimaryKey = "SW4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkQWE="
	$createdAuthRule.PrimaryKey = $newPrimaryKey
	$createdAuthRule.Rights.Add("Manage")

	$updatedAuthRule = Set-AzureNotificationHubAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName -SASRule $createdAuthRule
	
	Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
	Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
	Assert-True { $updatedAuthRule.Rights -Contains "Send" }
	Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    Assert-AreEqual $newPrimaryKey $updatedAuthRule.PrimaryKey
    Assert-NotNull $updatedAuthRule.SecondaryKey

	Start-Sleep -Seconds 10
	
	$updatedAuthRule = Get-AzureNotificationHubAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName -AuthorizationRuleName $authRuleName
	
	Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
	Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
	Assert-True { $updatedAuthRule.Rights -Contains "Send" }
	Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    Assert-AreEqual $newPrimaryKey $updatedAuthRule.PrimaryKey
    Assert-NotNull $updatedAuthRule.SecondaryKey

	#Get notificationHub authorizationRules connectionStrings
	$namespaceListKeys = Get-AzureNotificationHubAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName -AuthorizationRuleName $authRuleName

	Assert-AreEqual $namespaceListKeys.PrimaryConnectionString.Contains($newPrimaryKey)
    Assert-AreEqual 3 $namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)

	#Delete the created notificationHub AuthorizationRule
	$result = Remove-AzureNotificationHubAuthorizationRules -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName -AuthorizationRuleName $authRuleName
	
	$getDeletedNSAuth = Get-AzureNotificationHubListKeys -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -NotificationHubName $notificationHubName -AuthorizationRuleName $authRuleName
    Assert-AreEqual 0 $getDeletedNSAuth.Count
	
	# Delete namespaces
    Remove-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName

    $getDeletedNS = Get-AzureNotificationHubsNamespace -ResourceGroupName $resourceGroupName
    Assert-AreEqual 0 $getDeletedNS.Count

    # Remove resource group
    Remove-AzureResourceGroup -Name $resourceGroupName -Force
}