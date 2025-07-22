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
Test QueryRegionInfo
#>
function Test-CheckFilePathAvailability
{
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"    
    try
    {        
        $currentSub = (Get-AzureRmContext).Subscription	
        $subsid = $currentSub.SubscriptionId

        $resourceGroup = Get-ResourceGroupName
        $accName = Get-ResourceName
        $poolName = Get-ResourceName
        $volName = Get-ResourceName    
        $snName1 = Get-ResourceName
        $snName2 = Get-ResourceName
        $gibibyte = 1024 * 1024 * 1024
        $usageThreshold = 100 * $gibibyte
        $doubleUsage = 2 * $usageThreshold
        #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus2euap" -UseCanonical
        #$resourceLocation = "eastus2euap"
        $resourceLocation = "westus2"

        $subnetName = "default"
        $standardPoolSize = 4398046511104
        $serviceLevel = "Premium"
        $vnetName = $resourceGroup + "-vnet"
        $standarNetworkFeatures = "Standard"
        $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}
        
        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # create the resource group
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        # create account, pool and volume
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName

        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $standardPoolSize -ServiceLevel $serviceLevel
        
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName -CreationToken $volName -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId
        Assert-AreEqual "$accName/$poolName/$volName" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel

        # check FilePathAvailability  
        $filePathAvailability = Get-AzNetAppFilesFilePathAvailability -Location $resourceLocation -Name "filename" -SubnetId $subnetId
        Assert-NotNull $filePathAvailability
        Assert-True {$filePathAvailability.IsAvailable}
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test QueryRegionInfo
#>
function Test-CheckQuotaAvailability
{
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"    
    try
    {        
        $currentSub = (Get-AzureRmContext).Subscription	
        $subsid = $currentSub.SubscriptionId

        $resourceGroup = Get-ResourceGroupName

        $resourceLocation = "westus2"

        $resourceType = "Microsoft.NetApp/netAppAccounts"

        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}
        
        # create the resource group
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        # check QuotaAvailability  
        $quotaAvailability = Get-AzNetAppFilesQuotaAvailability -ResourceGroupName $resourceGroup -Location $resourceLocation -Type $resourceType  -Name "resourceName" 
        Assert-NotNull $quotaAvailability
        Assert-True {$quotaAvailability.IsAvailable}
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test QueryRegionInfo
#>
function Test-CheckNameAvailability
{
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"    
    try
    {
        $accName = Get-ResourceName
        $currentSub = (Get-AzureRmContext).Subscription	
        $subsid = $currentSub.SubscriptionId
        $resourceGroup = Get-ResourceGroupName
        $resourceLocation = "westus2"
        $resourceType = "Microsoft.NetApp/netAppAccounts"

        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}
        
        # create the resource group
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        # check NameAvailability  
        $quotaAvailability = Get-AzNetAppFilesNameAvailability -ResourceGroupName $resourceGroup -Location $resourceLocation -Type $resourceType  -Name $accName
        Assert-NotNull $quotaAvailability
        Assert-True {$quotaAvailability.IsAvailable}

        # create account
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName

        # check NameAvailability  
        $nameAvailability = Get-AzNetAppFilesNameAvailability -ResourceGroupName $resourceGroup -Location $resourceLocation -Type $resourceType  -Name $accName
        Assert-NotNull $nameAvailability
        Assert-False {$nameAvailability.IsAvailable}

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test GetUsage
#>
function Test-GetUsage
{
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"    
    try
    {        
        $currentSub = (Get-AzureRmContext).Subscription	
        $subsid = $currentSub.SubscriptionId        
        $resourceLocation = "westus2"
        $usageType = "totalTibsPerSubscription"

        # create the resource group
        #New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}
        
        # create the resource group
        #New-AzResourceGroup -Name $resourceGroupName -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        # check Get Usages
        $usageResult = Get-AzNetAppFilesUsage -Location $resourceLocation -UsageType $usageType
        Assert-NotNull $usageResult
        Assert-AreEqual $usageType $usageResult.Name.Value       

        # List usages                
        $usageResult = Get-AzNetAppFilesUsage -ResourceGroupName $resourceGroup -Location $resourceLocation 
        Assert-NotNull $nameAvailability        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}