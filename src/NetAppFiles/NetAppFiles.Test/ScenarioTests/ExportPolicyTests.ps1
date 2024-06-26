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
Test ExportPolicy operations
#>
function Test-ExportPolicy
{
    $currentSub = (Get-AzureRmContext).Subscription	
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName    
    $volName1 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    #$resourceLocation = "eastus2euap"
    $resourceLocation = "westus2"

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
        #$exportPolicyRule = New-AzExportPolicyRuleObject -RuleIndex 1 -AllowedClients '0.0.0.0/0' -UnixReadOnly $false -UnixReadWrite $false -Cifs $false -Nfsv3 $true -Nfsv41 $false
        $exportPolicyRule = New-AzNetAppFilesExportPolicyRuleObject -RuleIndex 1 -AllowedClient '0.0.0.0/0' -UnixReadOnly -UnixReadWrite -Cifs -Nfsv3 
        $exportPolicyRules = $($exportPolicyRule)
        
        $newExportPolicy = New-AzNetAppFilesExportPolicyObject -Rule $exportPolicyRules

        # create first volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $newExportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients 

        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'
        Assert-NotNull $retrievedVolume.MountTargets
        
        # use the NFSv4.1
        $protocolTypesv4 = New-Object string[] 1
        $protocolTypesv4[0] = "NFSv4.1"

        #get and check a volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}