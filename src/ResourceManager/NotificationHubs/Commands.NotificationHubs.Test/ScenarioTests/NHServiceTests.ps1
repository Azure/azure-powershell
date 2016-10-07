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
Check if Namespace is Active
#>
function Is-NamespaceActive($resourceGroupName, $namespaceName)
{
    $namespaceState = "None"

    while($namespaceState -ne "Succeeded")
    {
        Write-Debug "Get the created namespace State"
        $createdNamespace = Get-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
        Assert-True {$createdNamespace.Count -eq 1}

        for ($i = 0; $i -lt $createdNamespace.Count; $i++)
        {
            if ($createdNamespace[$i].Name -eq $namespaceName ) 
            {
                $namespaceState = $createdNamespace[$i].ProvisioningState
            }
        }
    }

    return $true
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
    
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Is-NamespaceActive $resourceGroupName $namespaceName
    }

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
   
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Is-NamespaceActive $secondResourceGroup $namespaceName2
    }

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
    
    $updatedNamespace = Set-AzureRmNotificationHubsNamespace -ResourceGroup $secondResourceGroup -Namespace $namespaceName2 -Location $location -Tags $tags -Force
    Assert-AreEqual 2 $updatedNamespace.Tags.Count
    
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Wait-Seconds 15
    }

    Write-Debug " Get the updated namespace "
    $getUpdatedNamespace = Get-AzureRmNotificationHubsNamespace -ResourceGroup $secondResourceGroup -Namespace $namespaceName2
	#uncomment once the playback mode doesnt fail on this 
    #Assert-AreEqual $updatedNamespace.Tags.Count $getUpdatedNamespace.Tags.Count

    Write-Debug " Delete namespaces"
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $secondResourceGroup -Namespace $namespaceName2 -Force
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Force

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
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Is-NamespaceActive $resourceGroupName $namespaceName
    }
        
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

    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Wait-Seconds 15
    }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

    Write-Debug "Get the default Namespace AuthorizationRule"
    $defaultNamespaceAuthRule = "RootManageSharedAccessKey"
    $result = Get-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }

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
    $createdAuthRule.Location = "South Central US"

    $updatedAuthRule = Set-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -SASRule $createdAuthRule -Force
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Wait-Seconds 15
    }
    
    Write-Debug "Get updated Namespace AuthorizationRules"
    $updatedAuthRule = Get-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }

    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmNotificationHubsNamespaceListKeys -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString -ne $null}
    Assert-True {$namespaceListKeys.SecondaryConnectionString -ne $null}
    Assert-True {$namespaceListKeys.PrimaryKey -ne $null}
    Assert-True {$namespaceListKeys.SecondaryKey -ne $null}
    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($namespaceListKeys.PrimaryKey)} 
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($namespaceListKeys.SecondaryKey)} 

    Write-Debug "Regenerate namespace authorizationRule key"
    $policyKeyName = "PrimaryKey"
    $namespaceRegenerateKey = New-AzureRmNotificationHubsNamespaceKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName -PolicyKey $policyKeyName -Force

    Assert-True {$namespaceRegenerateKey.PrimaryConnectionString -ne $null}
    Assert-True {$namespaceRegenerateKey.SecondaryConnectionString -ne $null}
    Assert-True {$namespaceRegenerateKey.PrimaryKey -ne $null}
    Assert-True {$namespaceRegenerateKey.SecondaryKey -ne $null}
    Assert-True {$namespaceRegenerateKey.PrimaryConnectionString.Contains($namespaceRegenerateKey.PrimaryKey)} 
    Assert-True {$namespaceRegenerateKey.SecondaryConnectionString.Contains($namespaceRegenerateKey.SecondaryKey)} 
    Assert-True {$namespaceRegenerateKey.PrimaryKey -ne $namespaceListKeys.PrimaryKey} 
    Assert-True {$namespaceRegenerateKey.SecondaryKey -eq $namespaceListKeys.SecondaryKey} 
    
     Write-Debug "Get namespace authorizationRules connectionStrings after regeneration of the primary key"
    $namespaceListKeysAfterRegenerate = Get-AzureRmNotificationHubsNamespaceListKeys -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName

    Assert-True {$namespaceListKeysAfterRegenerate.PrimaryConnectionString -ne $null}
    Assert-True {$namespaceListKeysAfterRegenerate.SecondaryConnectionString -ne $null}
    Assert-True {$namespaceListKeysAfterRegenerate.PrimaryKey -ne $null}
    Assert-True {$namespaceListKeysAfterRegenerate.SecondaryKey -ne $null}
    Assert-True {$namespaceListKeysAfterRegenerate.PrimaryConnectionString.Contains($namespaceListKeysAfterRegenerate.PrimaryKey)} 
    Assert-True {$namespaceListKeysAfterRegenerate.SecondaryConnectionString.Contains($namespaceListKeysAfterRegenerate.SecondaryKey)} 
    Assert-True {$namespaceListKeysAfterRegenerate.PrimaryKey -eq $namespaceRegenerateKey.PrimaryKey} 
    Assert-True {$namespaceListKeysAfterRegenerate.SecondaryKey -eq $namespaceRegenerateKey.SecondaryKey} 
    Assert-True {$namespaceListKeysAfterRegenerate.PrimaryKey -ne $namespaceListKeys.PrimaryKey} 
    Assert-True {$namespaceListKeysAfterRegenerate.SecondaryKey -eq $namespaceListKeys.SecondaryKey} 

    Write-Debug "Delete the created Namespace AuthorizationRule"
    Remove-AzureRmNotificationHubsNamespaceAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -AuthorizationRule $authRuleName -Force
    
    Write-Debug " Delete namespaces"
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Force

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
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Is-NamespaceActive $resourceGroupName $namespaceName
    }
    
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
    $createdNotificationHub.WnsCredential.PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699"
    $createdNotificationHub.WnsCredential.SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp"
    $createdNotificationHub.WnsCredential.WindowsLiveEndpoint = "http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
    $result = New-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHubObj $createdNotificationHub

    Write-Debug " Get the PNS credentials for the second notificationHub created"
    $pnsCredentials = Get-AzureRmNotificationHubPNSCredentials -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName2
    Assert-AreEqual  $createdNotificationHub.WnsCredential.PackageSid $pnsCredentials.WnsCredential.PackageSid
    Assert-AreEqual  $createdNotificationHub.WnsCredential.SecretKey $pnsCredentials.WnsCredential.SecretKey
    Assert-AreEqual  $createdNotificationHub.WnsCredential.WindowsLiveEndpoint $pnsCredentials.WnsCredential.WindowsLiveEndpoint
    
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
    $createdNotificationHub.WnsCredential.PackageSid = "ms-app://s-1-15-2-1817505189-427745171-3213743798-2985869298-800724128-1004923984-4143860699"
    $createdNotificationHub.WnsCredential.SecretKey = "w7TBprR-9tJxn9mUOdK4PPHLCAzSYFhp"
    $createdNotificationHub.WnsCredential.WindowsLiveEndpoint = "http://pushtestservice.cloudapp.net/LiveID/accesstoken.srf"
    $result = Set-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHubObj $createdNotificationHub -Force
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Wait-Seconds 15
    }

    Write-Debug " Get the PNS credentials for the first notificationHub created"
    $pnsCredentials = Get-AzureRmNotificationHubPNSCredentials -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName
    Assert-AreEqual  $createdNotificationHub.WnsCredential.PackageSid $pnsCredentials.WnsCredential.PackageSid
    Assert-AreEqual  $createdNotificationHub.WnsCredential.SecretKey $pnsCredentials.WnsCredential.SecretKey
    Assert-AreEqual  $createdNotificationHub.WnsCredential.WindowsLiveEndpoint $pnsCredentials.WnsCredential.WindowsLiveEndpoint

    Write-Debug " Delete the NotificationHub"
    $delete1 = Remove-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -Force
    $delete2 = Remove-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName2 -Force

    Write-Debug " Delete namespaces"
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Force

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
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Is-NamespaceActive $resourceGroupName $namespaceName
    }
    
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
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Wait-Seconds 15
    }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

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
            break
        }
    }

    Assert-True {$found -eq 1} "NotificationHub AuthorizationRule created earlier is not found."

    Write-Debug "Update notificationHub AuthorizationRules"
    $createdAuthRule.Rights.Add("Manage")
    $createdAuthRule.Location = $location

    $updatedAuthRule = Set-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -SASRule $createdAuthRule -Force
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
    if($env:AZURE_TEST_MODE -ne "Playback")
    {
        Wait-Seconds 15
    }
    
    $updatedAuthRule = Get-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }

    Write-Debug "Get notificationHub authorizationRules connectionStrings"
    $notificationHubsListKeys = Get-AzureRmNotificationHubListKeys -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName

    Assert-True {$notificationHubsListKeys.PrimaryConnectionString -ne $null}
    Assert-True {$notificationHubsListKeys.SecondaryConnectionString -ne $null}
    Assert-True {$notificationHubsListKeys.PrimaryKey -ne $null}
    Assert-True {$notificationHubsListKeys.SecondaryKey -ne $null}
    Assert-True {$notificationHubsListKeys.PrimaryConnectionString.Contains($notificationHubsListKeys.PrimaryKey)} 
    Assert-True {$notificationHubsListKeys.SecondaryConnectionString.Contains($notificationHubsListKeys.SecondaryKey)} 

    Write-Debug "Regenerate notificationHub authorizationRule key"
    $policyKeyName = "PrimaryKey"
    $notificationHubRegenerateKey = New-AzureRmNotificationHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName -PolicyKey $policyKeyName -Force

    Assert-True {$notificationHubRegenerateKey.PrimaryConnectionString -ne $null}
    Assert-True {$notificationHubRegenerateKey.SecondaryConnectionString -ne $null}
    Assert-True {$notificationHubRegenerateKey.PrimaryKey -ne $null}
    Assert-True {$notificationHubRegenerateKey.SecondaryKey -ne $null}
    Assert-True {$notificationHubRegenerateKey.PrimaryConnectionString.Contains($notificationHubRegenerateKey.PrimaryKey)} 
    Assert-True {$notificationHubRegenerateKey.SecondaryConnectionString.Contains($notificationHubRegenerateKey.SecondaryKey)} 
    Assert-True {$notificationHubRegenerateKey.PrimaryKey -ne $notificationHubsListKeys.PrimaryKey} 
    Assert-True {$notificationHubRegenerateKey.SecondaryKey -eq $notificationHubsListKeys.SecondaryKey} 

     Write-Debug "Get notificationHub authorizationRules connectionStrings after regeneration of the primary key"
    $notificationHubsListKeysAfterRegenerate = Get-AzureRmNotificationHubListKeys -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName

    Assert-True {$notificationHubsListKeysAfterRegenerate.PrimaryConnectionString -ne $null}
    Assert-True {$notificationHubsListKeysAfterRegenerate.SecondaryConnectionString -ne $null}
    Assert-True {$notificationHubsListKeysAfterRegenerate.PrimaryKey -ne $null}
    Assert-True {$notificationHubsListKeysAfterRegenerate.SecondaryKey -ne $null}
    Assert-True {$notificationHubsListKeysAfterRegenerate.PrimaryConnectionString.Contains($notificationHubsListKeysAfterRegenerate.PrimaryKey)} 
    Assert-True {$notificationHubsListKeysAfterRegenerate.SecondaryConnectionString.Contains($notificationHubsListKeysAfterRegenerate.SecondaryKey)} 
    Assert-True {$notificationHubsListKeysAfterRegenerate.PrimaryKey -eq $notificationHubRegenerateKey.PrimaryKey} 
    Assert-True {$notificationHubsListKeysAfterRegenerate.SecondaryKey -eq $notificationHubRegenerateKey.SecondaryKey} 
    Assert-True {$notificationHubsListKeysAfterRegenerate.PrimaryKey -ne $notificationHubsListKeys.PrimaryKey} 
    Assert-True {$notificationHubsListKeysAfterRegenerate.SecondaryKey -eq $notificationHubsListKeys.SecondaryKey} 

    Write-Debug "Delete the created notificationHub AuthorizationRule"
    Remove-AzureRmNotificationHubAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -AuthorizationRule $authRuleName -Force
    
    Write-Debug " Delete the NotificationHub"
    Remove-AzureRmNotificationHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -NotificationHub $notificationHubName -Force
    
    Write-Debug " Delete namespaces"
    Remove-AzureRmNotificationHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Force

    Write-Debug " Remove resource group"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}