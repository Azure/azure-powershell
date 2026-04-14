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
Test Ransomware Protection and Ransomware Reports for a volume
#>
function Test-RansomwareReports
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName
    $volName2 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $resourceLocation = "uksouth"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        AllowedClients = '0.0.0.0/0'
    }

    $exportPolicy = @{
		Rules = (
			$rule1
		)
	}

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

        # create volume with ransomware protection enabled
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -ExportPolicy $exportPolicy -ProtocolType $protocolTypes -DesiredRansomwareProtectionState "Enabled"
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name

        # verify ransomware protection state is set on the volume
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-NotNull $retrievedVolume.DataProtection.RansomwareProtection
        Assert-AreEqual "Enabled" $retrievedVolume.DataProtection.RansomwareProtection.DesiredRansomwareProtectionState

        # create a second volume without ransomware protection
        $retrievedVolume2 = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName2 -CreationToken $volName2 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName2" $retrievedVolume2.Name

        # verify ransomware protection is not set on the second volume
        $retrievedVolume2 = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName2
        Assert-Null $retrievedVolume2.DataProtection.RansomwareProtection

        # enable ransomware protection on the second volume via update
        $updatedVolume2 = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName -VolumeName $volName2 -DesiredRansomwareProtectionState "Enabled"
        Assert-AreEqual "$accName/$poolName/$volName2" $updatedVolume2.Name
        Assert-NotNull $updatedVolume2.DataProtection.RansomwareProtection
        Assert-AreEqual "Enabled" $updatedVolume2.DataProtection.RansomwareProtection.DesiredRansomwareProtectionState

        # list ransomware reports - should be empty since no ransomware incident has occurred
        $ransomwareReports = Get-AzNetAppFilesRansomwareReport -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual 0 $ransomwareReports.Count

        # get single ransomware report with name 'current' - should throw since no active report exists
        Assert-Throws { Get-AzNetAppFilesRansomwareReport -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Name "current" }

        # clear ransomware suspects should fail since there are no active ransomware incidents
        Assert-Throws { Clear-AzNetAppFilesRansomwareReportSuspect -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Name "current" -Resolution "FalsePositive" -Extension @(".enc") }

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
