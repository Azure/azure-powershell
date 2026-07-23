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
Test Account Active Directory
#>
function Test-AccountActiveDirectory
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $accName2 = Get-ResourceName
    $accName3 = Get-ResourceName
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $resourceLocation = 'westus2'

    $activeDirectory1 = @{
        Username = "xxxxxxxx"
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="...")]#>
        Password = "xxxxxxxx"
        Domain = "sdkdomain"
        Dns = "192.0.2.2"
        SmbServerName = "PSMBSName1"
    }
    $activeDirectory2 = @{
        Username = "xxxxxxxx"
		<#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="...")]#>
        Password = "xxxxxxxx"
        Domain = "sdkdomain"
        Dns = "192.0.2.2"
        SmbServerName = "PSMBSName2"
    }

    try
    {
        # create the resource group
        $groupTagName = "owner"
        $groupTagValue = "b-aubald"
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{$groupTagName = $groupTagValue}

        # check multiple ADs are captured
        Write-log "Create Accoount multiple AD:"
        # currently this is not permitted and throws a message
        try
        {
            $activedirectories = @( $activeDirectory1, $activeDirectory2 )

            # create and check account 1
            $newTagName = "tag1"
            $newTagValue = "tagValue1"
            #$retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue} -ActiveDirector $activeDirectories
            #New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue} -ActiveDirectory $activeDirectories
            #With n ew feature multiple AD is not allowed
            #Assert-ThrowsContains{  New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue} -ActiveDirectory $activeDirectories} 'Only one active directory allowed';
            #Assert-True { $false }
        }
        catch
        {
            $ErrorMessage = $_.Exception.Message
            #Assert-True { ($ErrorMessage -contains 'Only one active directory allowed') }
            Assert-True { ($ErrorMessage -contains 'Only one') }
            #Assert-AreEqual $accName1 $retrievedAcc.Name
        }

        # try creating an AD -

        $activedirectories = @( $activeDirectory1 )

        # create and check account 1
        
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue} -ActiveDirectory $activeDirectories
        Assert-AreEqual $accName1 $retrievedAcc.Name
        Assert-AreEqual $activeDirectory1.SmbServerName $retrievedAcc.ActiveDirectories[0].SmbServerName
        Assert-AreEqual $activeDirectory1.Username $retrievedAcc.ActiveDirectories[0].Username

        # patch an Active Directory with no active directory. Should be no change
        # except for the tag update
        $newTagName = "tag1"
        $newTagValue = "tagValue2"
        $retrievedAcc = Update-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name
        Assert-AreEqual $activeDirectory1.SmbServerName $retrievedAcc.ActiveDirectories[0].SmbServerName
        Assert-AreEqual $activeDirectory1.Username $retrievedAcc.ActiveDirectories[0].Username
        Assert-AreEqual 1 $retrievedAcc.ActiveDirectories.Length
        Assert-AreEqual "tagValue2" $retrievedAcc.Tags[$newTagName].ToString()

        # update (put) the account. The absence of an active directory should result in the removal of any currently associated. Also tags
        $retrievedAcc = Set-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -AccountName $accName1 -Location $resourceLocation
        Assert-AreEqual $accName1 $retrievedAcc.Name
        Assert-Null $retrievedAcc.Tags
        Assert-Null $retrievedAcc.ActiveDirectories

        # patch an Active Directory. Should be updated to contain only the new one
        $activedirectories = @( $activeDirectory2 )
        $retrievedAcc = Update-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -ActiveDirectory $activedirectories
        Assert-AreEqual $accName1 $retrievedAcc.Name
        # correction to (wildcard values in) returned password expected in RP
        # add this check back in at that time since username/password are the two fields of concern
        # Assert-AreEqual $activeDirectory2.Password $retrievedAcc.ActiveDirectories[0].Password
        Assert-AreEqual $activeDirectory2.Username $retrievedAcc.ActiveDirectories[0].Username
        Assert-AreEqual 1 $retrievedAcc.ActiveDirectories.Length

        # update (put) the account. The absence of an active directory should result in the removal of any currently associated. Also tags
        $retrievedAcc = Set-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -AccountName $accName1 -Location $resourceLocation
        Assert-AreEqual $accName1 $retrievedAcc.Name

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
    
<#
.SYNOPSIS
Test Account CRUD operations
#>
function Test-AccountCrud
{
    #$resourceGroup = "somename2"
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $accName2 = Get-ResourceName
    $accName3 = Get-ResourceName
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        #New-AzResourceGroup -Name $resourceGroup -Tags @{Owner = 'b-aubald'} -Location $resourceLocation 
      
        # create and check account 1
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name
        Assert-AreEqual True $retrievedAcc.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedAcc.Tags[$newTagName].ToString()

        # create and check account 2 using the Confirm flag
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName2 -Confirm:$false
        Assert-AreEqual $accName2 $retrievedAcc.Name
		
        # create and check account 3 using the WhatIf - it should not be created
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName3 -WhatIf

        # get and check accounts by group (list)
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-True {"$accName1" -eq $retrievedAcc[0].Name -or "$accName2" -eq $retrievedAcc[0].Name}
        Assert-True {"$accName1" -eq $retrievedAcc[1].Name -or "$accName2" -eq $retrievedAcc[1].Name}
        Assert-AreEqual 2 $retrievedAcc.Length

        # get and check an account by name
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Name $accName1
        Assert-AreEqual $accName1 $retrievedAcc.Name

        # get and check the account again using the resource id just obtained
        $retrievedAccById = Get-AzNetAppFilesAccount -ResourceId $retrievedAcc.Id
        Assert-AreEqual $accName1 $retrievedAccById.Name

        # update and check the account (tags) - the active directory test checks this stuff

        # delete one account retrieved by id and one by name and check removed
        Remove-AzNetAppFilesAccount -ResourceId $retrievedAccById.Id

        # but test the WhatIf first
        Remove-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -AccountName $accName2 -WhatIf
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup
        Assert-AreEqual 1 $retrievedAcc.Length

        Remove-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -AccountName $accName2
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup
        Assert-AreEqual 0 $retrievedAcc.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test Account CMK CRUD operations
#>
function Test-AccountCMK
{
    #$resourceGroup = "somename2"
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $accName2 = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName

    $identityName = Get-ResourceName
    $akvPrivateEndpoint = Get-ResourceName
    #$keyVaultName = Get-ResourceName
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $resourceLocation = "westus"
    $keySource = "Microsoft.KeyVault"
    #$keyVaultUri = "https://akvtestvault2.vault.azure.net/"
    $keyVaultUri = "https://akvtestvaultwestus.vault.azure.net/"
    $keyName = "akvTestMaster"
    #$keyVaultName = "akvTestVault2"
    $keyVaultName = "akvTestVaultWestus"
    #$keyVaultName = Get-ResourceName
    #$keyVaultName =  "psAkv"+$resourceGroup+$resourceLocation
    #$keyVaultResourceId = "/subscriptions/0661b131-4a11-479b-96bf-2f95acca2f73/resourceGroups/akvTestRG/providers/Microsoft.KeyVault/vaults/akvTestVault2"
    $keyVaultResourceId = "/subscriptions/0661b131-4a11-479b-96bf-2f95acca2f73/resourceGroups/akvTestRG/providers/Microsoft.KeyVault/vaults/akvTestVaultWestus"
    $kvResourceGroup = "akvTestRG"
    # $userAssignedIdentity = "/subscriptions/$subsid/resourcegroups/$resourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/FakeUserIdentity"
    #$userAssignedIdentity = "/subscriptions/$subsid/resourcegroups/akvTestRG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/abAkvIdenity"

    $identityType = "SystemAssigned"

    #volume props
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $subnetName = "default"
    $akvSubnetName = "akvSubnet"
    $standardPoolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        # New-AzResourceGroup -Name $resourceGroup -Tags @{Owner = 'b-aubald'} -Location $resourceLocation
        # $userAssignedIdenity = New-AzUserAssignedIdentity -ResourceGroupName $resourceGroup -Name $identityName -Location $resourceLocation
        # Create keyvault and userIdeneity then give the identity access to the keyvault
        #$azKeyVault = New-AzKeyVault -ResourceGroupName $resourceGroup -Name $keyVaultName -Location $resourceLocation -EnablePurgeProtection
        #$azKeyVault = Get-AzKeyVault -ResourceGroupName $kvResourceGroup -Name $keyVaultName
        #Assert-NotNull $azKeyVault.ResourceID
        #$keyVaultResourceId = $azKeyVault.ResourceID
        
        #$keyVaultUri = $azKeyVault.VaultUri                
        #Create key in vault
        #Add-AzKeyVaultKey -VaultName $keyVaultName -Name $keyVaultName -Destination "Software"
        # create and check account 1
        $newTagName = "tag1"
        $newTagValue = "tagValue1"

        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Name $accName1 -Location $resourceLocation -Tag @{$newTagName = $newTagValue} -IdentityType $identityType
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Name $accName1 

        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        #set access policy account identity, and the permissions "Get," "Encrypt," and "Decrypt."       
        Set-AzKeyVaultAccessPolicy -ResourceGroupname $kvResourceGroup -VaultName $keyVaultName  -ObjectId $retrievedAcc.Identity.PrincipalId -PermissionsToKeys get,encrypt,decrypt -BypassObjectIdValidation
                

        #subnet for akv
        $akvSubnet = Add-AzVirtualNetworkSubnetConfig -Name $akvSubnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.2.0/24" -PrivateEndpointNetworkPoliciesFlag Disabled | Set-AzVirtualNetwork
 
        $subnetConfig = Add-AzVirtualNetworkSubnetConfig -Name 'AzureBastionSubnet' -VirtualNetwork $virtualNetwork -AddressPrefix '10.0.3.0/24' | Set-AzVirtualNetwork

        $ip = @{
            ResourceGroupName = $resourceGroup
            Name = 'public-ip'
            Location = $resourceLocation
            AllocationMethod = 'Static'
            Sku = 'Standard'            
        }
        New-AzPublicIpAddress @ip

        $bastion = @{
            Name = 'bastion'
            ResourceGroupName = $resourceGroup
            PublicIpAddressRgName = $resourceGroup  
            PublicIpAddressName = 'public-ip'
            VirtualNetworkRgName = $resourceGroup
            VirtualNetworkName = $virtualNetwork.Name
            Sku = 'Basic'
        }
        New-AzBastion @bastion
        # create pool and volume 
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -PoolName $poolName -PoolSize $standardPoolSize -ServiceLevel $serviceLevel
		
        ## Create the private endpoint connection. ## 
        $pec = @{
            Name = 'akvPrivateEndpoint'
            PrivateLinkServiceId = $keyVaultResourceId
            GroupID = 'vault'
        }
        $privateEndpointConnection = New-AzPrivateLinkServiceConnection @pec

        ## Get the virtual network we created previously into a variable. ##
        $vnet = Get-AzVirtualNetwork -ResourceGroupName $resourceGroup -Name $virtualNetwork.Name
        $akvSubnet = $vnet | Select-Object -ExpandProperty subnets | Where-Object Name -eq $akvSubnetName

        ## Create the private endpoint. ##
        $pe = @{
            ResourceGroupName = $resourceGroup
            Name = 'private-endpoint'
            Location = $resourceLocation
            Subnet = $akvSubnet
            PrivateLinkServiceConnection = $privateEndpointConnection
        }
        $privateEndpoint = New-AzPrivateEndpoint @pe

        #update account with cmk
        $retrievedAcc = Update-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Name $accName1 -EncryptionKeySource $keySource -KeyVaultKeyName $keyName -KeyVaultResourceId $keyVaultResourceId -KeyVaultUri $keyVaultUri
        Assert-AreEqual $accName1 $retrievedAcc.Name
        Assert-AreEqual True $retrievedAcc.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedAcc.Tags[$newTagName].ToString()
        #Assert-NotNull $retrievedAcc.Identity.UserAssignedIdentities
        Assert-AreEqual True $retrievedAcc.Tags.ContainsKey($newTagName)
        #Assert-AreEqual True $retrievedAcc.Identity.UserAssignedIdentities.ContainsKey($userAssignedIdentity)

        # create and check account 2 using the Confirm flag
        #$retrievedAcc2 = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName2 -IdentityType $identityType -Confirm:$false
        #Assert-AreEqual $accName2 $retrievedAcc2.Name

        # update and check account setting Encryption CMK properties
        #$retrievedAcc2 = Update-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName2 -EncryptionKeySource $keySource -IdentityType $identityType -KeyVaultKeyName $keyName -KeyVaultResourceId $keyVaultResourceId -KeyVaultUri $azKeyVault.VaultUri 
        #Assert-AreEqual $accName2 $retrievedAcc2.Name
        #Assert-NotNull $retrievedAcc.Identity.UserAssignedIdentities
        #Assert-AreEqual True $retrievedAcc.Tags.ContainsKey($newTagName)
        #Assert-AreEqual True $retrievedAcc.Identity.UserAssignedIdentities.ContainsKey($userAssignedIdentity)

        # Assert-ThrowsContains{$retrievedAcc = Update-AzNetAppFilesAccountCredential -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 } 'NetApp account does not have an MSI credentials, therefore it is ineligible for renewal of credentials'
        Update-AzNetAppFilesAccountCredential -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 


        #Create the CMK volume 
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -NetworkFeature Standard -EncryptionKeySource 'Microsoft.KeyVault' -KeyVaultPrivateEndpointResourceId $privateEndpoint.Id
        Assert-AreEqual "$accName1/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel

        # Get KeyVaultInformation 
        $keyVaultInfo = Get-AzNetAppFilesAccountKeyVaultStatus -ResourceGroupName $resourceGroup -AccountName $accName1
        Assert-Null $keyVaultInfo.KeyVaultPrivateEndpoints
        #$keyVaultPrivateEndpoint = @{
        #    VirtualNetworkId = $keyVaultInfo.KeyVaultPrivateEndpoints[0].VirtualNetworkId
        #    PrivateEndpointId = $keyVaultInfo.KeyVaultPrivateEndpoints[0].PrivateEndpointId
        #}

        $keyVaultPrivateEndpoint = @{
            VirtualNetworkId = $vnet.Id
            PrivateEndpointId = $privateEndpoint.Id
        }
        Assert-ThrowsContains{$retrievedAcc = Invoke-AzNetAppFilesAccountChangeKeyVault -ResourceGroupName $resourceGroup -AccountName $accName1 -KeyVaultUri $keyVaultUri -KeyVaultKeyName  $keyName -KeyVaultResourceId $keyVaultResourceId -KeyVaultPrivateEndpoint $keyVaultPrivateEndpoint} 'Volume encryption is already configured to use https://akvtestvaultwestus.vault.azure.net/. Please select a different key vault.'
        
        #Assert-ThrowsContains{$retrievedAcc = Convert-AzNetAppFilesAccountToCmk -ResourceGroupName $resourceGroup -AccountName $accName1 -VirtualNetworkId $keyVaultInfo.VirtualNetworkId -PrivateEndpointId $keyVaultInfo.PrivateEndpointId } 'NetApp account does not have an MSI credentials, therefore it is ineligible for renewal of credentials'       

        # get and check accounts by group (list)
        $retrievedAcc = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-AreEqual 1 $retrievedAcc.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}


<#
.SYNOPSIS
Test Account Pipeline operations (uses command aliases)
#>
function Test-AccountPipelines
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $accName2 = Get-ResourceName
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"

    try
    {
        # create the resource group
        $groupTagName = "owner"
        $groupTagValue = "b-aubald"
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tag @{$groupTagName = $groupTagValue}


        New-AnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 | Remove-AnfAccount

        New-AnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName2

        Get-AnfAccount -ResourceGroupName $resourceGroup -Name $accName2 | Remove-AnfAccount
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
