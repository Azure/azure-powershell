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
Test Volume CRUD operations
#>
function Test-VolumeQuotaRuleCrud
{
	$currentSub = (Get-AzureRmContext).Subscription
	$subsid = $currentSub.SubscriptionId
    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName    
    $volName1 = Get-ResourceName
    $volQuotaRuleName1 = Get-ResourceName
    $volQuotaRuleName2 = Get-ResourceName
    $quotaRuleType = "DefaultGroupQuota"
    $quotaRuleType2 = "DefaultUserQuota"
    $quotaRuleTarget = ""
    $quotaRuleSize = 100006
    $quotaRuleSize2 = 100007
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $resourceLocation = "eastus2"

    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"
    
    # create the list of protocol types
    $protocolTypes = New-Object string[] 1
    $protocolTypes[0] = "NFSv3"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}
        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # create account
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName 
	    
        # create pool
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel
        # create first volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients
        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'

        # create first quota rule and check
        $retrievedQuotaRule = New-AzNetAppFilesVolumeQuotaRule -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Name $volQuotaRuleName1  -QuotaType $quotaRuleType -QuotaSize $quotaRuleSize 
        Assert-AreEqual $quotaRuleType $retrievedQuotaRule.QuotaType
        
        # get first quotaRule and check
        $getQuotaRule = Get-AzNetAppFilesVolumeQuotaRule -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Name $volQuotaRuleName1         
        Assert-AreEqual $quotaRuleType $getQuotaRule.QuotaType

        # Update quotaRule and check
        $updatedQuotaRule = Update-AzNetAppFilesVolumeQuotaRule -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Name $volQuotaRuleName1 -QuotaSize $quotaRuleSize2
        Assert-AreEqual $quotaRuleSize2 $updatedQuotaRule.QuotaSize
        
        # create second quotaRule and check
        $retrievedQuotaRule = New-AzNetAppFilesVolumeQuotaRule -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Name $volQuotaRuleName2  -QuotaType $quotaRuleType2 -QuotaSize $quotaRuleSize
        Assert-AreEqual $quotaRuleType2 $retrievedQuotaRule.QuotaType
        
        # get list and check
        $getQuotaRules = Get-AzNetAppFilesVolumeQuotaRule -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual 2 $getQuotaRules.Length

        #Delete quotaRule 1
        $updatedQuotaRule = Remove-AzNetAppFilesVolumeQuotaRule -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Name $volQuotaRuleName1

        # get list and check again
        $getQuotaRules = Get-AzNetAppFilesVolumeQuotaRule -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual 1 $getQuotaRules.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}