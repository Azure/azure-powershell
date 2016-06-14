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
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
    Write-Debug "ResourceGroup name : $resourceGroupName" 

    $namespaceName = Get-NamespaceName
    
    Write-Debug " Create new notificationHub namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Location $location
    Wait-Seconds 15

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
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
    New-AzureRmResourceGroup -Name $secondResourceGroup -Location $location -Force    

    Write-Debug "Create 2nd new notificationHub namespace"
    $namespaceName2 = Get-NamespaceName
    Write-Debug "Namespace name : $namespaceName2" 
    $result = New-AzureRmNotificationHubsNamespace -ResourceGroup $secondResourceGroup -Namespace $namespaceName2 -Location $location
    Wait-Seconds 15

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzureRmNotificationHubsNamespace -ResourceGroup $secondResourceGroup 

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
    $allCreatedNamespace = Get-AzureRmNotificationHubsNamespace 

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
    $tags = @{"tag1" = "value1" ; "tag2" = "value2"}
    Write-Debug  "Tags List : $tags"
    #New-Object 'System.Collections.Generic.Dictionary[String,String]'
    #$tags.Add("tag1","value1")
    #$tags.Add("tag2","value2")
    
    $updatedNamespace = Set-AzureRmNotificationHubsNamespace -ResourceGroup $secondResourceGroup -Namespace $namespaceName2 -Location $location -Tags $tags
    Assert-AreEqual 2 $updatedNamespace.Tags.Count
    Wait-Seconds 15

    Write-Debug " Get the updated namespace "
    $getUpdatedNamespace = Get-AzureRmNotificationHubsNamespace -ResourceGroup $secondResourceGroup -Namespace $namespaceName2
    Assert-AreEqual 2 $getUpdatedNamespace.Tags.Count

    Write-Debug " Delete namespaces"
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $secondResourceGroup -Namespace $namespaceName2
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName

    Write-Debug " Remove resource group"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
    Remove-AzureRmResourceGroup -Name $secondResourceGroup -Force
}

<#
.SYNOPSIS
Tests NotificationHub Namespace AuthorizationRules Create List Remove operations.
#>
function Test-CRUDNamespaceAuth
{
    # Setup    
    $location = "South Central US"
    
    Write-Debug " Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = Get-NamespaceName
    
    Write-Debug " Create new notificationHub namespace"
    Write-Debug "Namespace name : $namespaceName"

    $result = New-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Location $location
    Wait-Seconds 15
        
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
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

    Write-Debug "Create a Namespace Authorization Rule"
    $authRuleName = "TestAuthRule"
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -InputFile .\Resources\NewAuthorizationRule.json

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Assert-AreEqual "IR4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkATU=" $createdAuthRule.PrimaryKey
    Assert-NotNull $createdAuthRule.SecondaryKey

    Write-Debug "Get the default Namespace AuthorizationRule"
    $defaultNamespaceAuthRule = "RootManageSharedAccessKey"
    $result = Get-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }
    Assert-NotNull $result.PrimaryKey
    Assert-NotNull $result.SecondaryKey

    Write-Debug "Get All Namespace AuthorizationRule"
    $result = Get-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName
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
            Assert-NotNull $result[$i].PrimaryKey
            #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
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

    Write-Debug "Update Namespace AuthorizationRules"
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $newPrimaryKey = "SW4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkQWE="
    $createdAuthRule.PrimaryKey = $newPrimaryKey
    $createdAuthRule.Rights.Add("Manage")

    $updatedAuthRule = Set-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -SASRule $createdAuthRule
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    Assert-AreEqual $newPrimaryKey $updatedAuthRule.PrimaryKey
    Assert-NotNull $updatedAuthRule.SecondaryKey
    Wait-Seconds 15
    
    Write-Debug "Get updated Namespace AuthorizationRules"
    $updatedAuthRule = Get-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    Assert-AreEqual $newPrimaryKey $updatedAuthRule.PrimaryKey
    Assert-NotNull $updatedAuthRule.SecondaryKey

    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmNotificationHubsNamespaceListKeys -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}

    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName
    
    Write-Debug " Delete namespaces"
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName

    Write-Debug " Remove resource group"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}


<#
.SYNOPSIS
Tests NotificationHub Create List Remove operations.
#>
function Test-CRUDNotificationHub
{
    # Setup    
    $location = "South Central US"
    
    Write-Debug "  Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    Write-Debug " Resource Group Name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = Get-NamespaceName
    
    Write-Debug "  Create new notificationHub namespace"
    Write-Debug " Namespace name : $namespaceName"
    $result = New-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Location $location
    Wait-Seconds 15
    
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
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

    Write-Debug " Create new notificationHub "
    $notificationHubName = "TestNh"
    $result = New-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -InputFile .\Resources\NewNotificationHub.json

    Write-Debug " Get the created notificationHub "
    $createdNotificationHub = Get-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName
    Assert-True {$createdNotificationHub.Count -eq 1}
    Assert-True {$createdNotificationHub.Tags.Count -eq 2}

    Write-Debug " Create another new notificationHub "
    $notificationHubName2 = Get-NotificationHubName
    $createdNotificationHub.Name = $notificationHubName2
    $createdNotificationHub.Location = "South Central US"
    $createdNotificationHub.WnsCredential = New-Object 'Microsoft.Azure.Management.NotificationHubs.Models.WnsCredential'
    $createdNotificationHub.WnsCredential.Properties = New-Object 'Microsoft.Azure.Management.NotificationHubs.Models.WnsCredentialProperties'
    $createdNotificationHub.WnsCredential.Properties.PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699"
    $createdNotificationHub.WnsCredential.Properties.SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp"
    $createdNotificationHub.WnsCredential.Properties.WindowsLiveEndpoint = "http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
    $result = New-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHubObj $createdNotificationHub

    Write-Debug " Get the PNS credentials for the second notificationHub created"
    $pnsCredentials = Get-AzureRmNotificationHubPNSCredentials -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName2
    Assert-AreEqual  $createdNotificationHub.WnsCredential.Properties.PackageSid $pnsCredentials.WnsCredential.Properties.PackageSid
    Assert-AreEqual  $createdNotificationHub.WnsCredential.Properties.SecretKey $pnsCredentials.WnsCredential.Properties.SecretKey
    Assert-AreEqual  $createdNotificationHub.WnsCredential.Properties.WindowsLiveEndpoint $pnsCredentials.WnsCredential.Properties.WindowsLiveEndpoint
    
    Write-Debug " Get all the created notificationHub "
    $createdNotificationHubList = Get-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName

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

    Write-Debug " Update the first notificationHub "
    $createdNotificationHub.Name = $notificationHubName
    $createdNotificationHub.Location = "South Central US"
    $createdNotificationHub.WnsCredential = New-Object 'Microsoft.Azure.Management.NotificationHubs.Models.WnsCredential'
    $createdNotificationHub.WnsCredential.Properties = New-Object 'Microsoft.Azure.Management.NotificationHubs.Models.WnsCredentialProperties'
    $createdNotificationHub.WnsCredential.Properties.PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699"
    $createdNotificationHub.WnsCredential.Properties.SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp"
    $createdNotificationHub.WnsCredential.Properties.WindowsLiveEndpoint = "http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
    $result = Set-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHubObj $createdNotificationHub
    Wait-Seconds 15

    Write-Debug " Get the PNS credentials for the first notificationHub created"
    $pnsCredentials = Get-AzureRmNotificationHubPNSCredentials -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName
    Assert-AreEqual  $createdNotificationHub.WnsCredential.Properties.PackageSid $pnsCredentials.WnsCredential.Properties.PackageSid
    Assert-AreEqual  $createdNotificationHub.WnsCredential.Properties.SecretKey $pnsCredentials.WnsCredential.Properties.SecretKey
    Assert-AreEqual  $createdNotificationHub.WnsCredential.Properties.WindowsLiveEndpoint $pnsCredentials.WnsCredential.Properties.WindowsLiveEndpoint

    Write-Debug " Delete the NotificationHub"
    $delete1 = Remove-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName
    $delete2 = Remove-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName2

    Write-Debug " Delete namespaces"
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName

    Write-Debug " Remove resource group"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests NotificationHub AuthorizationRules Create List Remove operations.
#>
function Test-CRUDNHAuth
{
    # Setup    
    $location = "South Central US"
    
    Write-Debug " Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = Get-NamespaceName
    
    Write-Debug " Create new notificationHub namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Location $location
    Wait-Seconds 15
    
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
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

    Write-Debug " Create new notificationHub "
    $notificationHubName = "TestNh"
    $result = New-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -InputFile .\Resources\NewNotificationHub.json

    Write-Debug " Get the created notificationHub "
    $createdNotificationHub = Get-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName
    Assert-True {$createdNotificationHub.Count -eq 1}

    Write-Debug "Create a notificationHub Authorization Rule"
    $authRuleName = "TestAuthRule"
    $result = New-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -InputFile .\Resources\NewAuthorizationRule.json

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Wait-Seconds 15

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    Assert-AreEqual "IR4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkATU=" $createdAuthRule.PrimaryKey
    Assert-NotNull $createdAuthRule.SecondaryKey

    Write-Debug "Get All notificationHub AuthorizationRule"
    $result = Get-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName 

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
            #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            Assert-AreEqual "IR4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkATU=" $result[$i].PrimaryKey
            Assert-NotNull $result[$i].SecondaryKey
            break
        }
    }

    Assert-True {$found -eq 1} "NotificationHub AuthorizationRule created earlier is not found."

    Write-Debug "Update notificationHub AuthorizationRules"
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $newPrimaryKey = "SW4qH02MB2yXjlekt5fhlgMR9YAoMsXHTkUqarUkQWE="
    $createdAuthRule.PrimaryKey = $newPrimaryKey
    $createdAuthRule.Rights.Add("Manage")

    $updatedAuthRule = Set-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -SASRule $createdAuthRule
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    Assert-AreEqual $newPrimaryKey $updatedAuthRule.PrimaryKey
    Assert-NotNull $updatedAuthRule.SecondaryKey
    Wait-Seconds 15
    
    $updatedAuthRule = Get-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    Assert-AreEqual $newPrimaryKey $updatedAuthRule.PrimaryKey
    Assert-NotNull $updatedAuthRule.SecondaryKey

    Write-Debug "Get notificationHub authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmNotificationHubListKeys -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}

    Write-Debug "Delete the created notificationHub AuthorizationRule"
    $result = Remove-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName
    
    Write-Debug " Delete the NotificationHub"
    Remove-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName
    
    Write-Debug " Delete namespaces"
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName

    Write-Debug " Remove resource group"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}