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
Test Backup CRUD operations
#>
function Test-BackupCrud
{
    $currentSub = (Get-AzureRmContext).Subscription	
    $subsid = $currentSub.SubscriptionId
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $poolName = Get-ResourceName
    $volName1 = Get-ResourceName
    $backupName1 = Get-ResourceName
    $backupName2 = Get-ResourceName    
    $backupPolicyName1 = Get-ResourceName
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $backupLocation = "southcentralus"
    $label = "powershellBackupTest"
    $label2 = "powershellBackupTest2"
    #voll props
    $volName1 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"
    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"
    $dailyBackupsToKeep = 4
    $weeklyBackupsToKeep = 3
    $monthlyBackupsToKeep = 2
    $yearlyBackupsToKeep = 1

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
        New-AzResourceGroup -Name $resourceGroup -Location $backupLocation

        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $backupLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # try creating an Account -               
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $backupLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name

        # create and check BackupPolicy
        $retrievedBackupPolicy = New-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -Name $backupPolicyName1 -Tag @{$newTagName = $newTagValue} -Enabled -DailyBackupsToKeep $dailyBackupsToKeep -WeeklyBackupsToKeep $weeklyBackupsToKeep -MonthlyBackupsToKeep $monthlyBackupsToKeep -YearlyBackupsToKeep $yearlyBackupsToKeep
        
        # create pool
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel

        # create  volume and check
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName1/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients 

        # get check Vaults 
        $retrievedVaultsList = Get-AzNetAppFilesVault -ResourceGroupName $resourceGroup -AccountName $accName1
        $backupObject = @{
            VaultId = $retrievedVaultsList[0].Id
            BackupEnabled = $true
            PolicyEnforced = $true
        }
         # volume update with backup policy
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Backup $backupObject
        
        # create and check Backup
        $retrievedBackup = New-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Name $backupName1 -Label $label
        Assert-AreEqual "$accName1/$poolName/$volName1/$backupName1" $retrievedBackup.Name
        # service side issue does not return label enable when fixed (ANF-8057)
        #Assert-AreEqual $label $retrievedBackup.Label
        
        # get and check a Backup by name and check again
        $getRetrievedBackup = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Name $backupName1
        Assert-AreEqual "$accName1/$poolName/$volName1/$backupName1" $getRetrievedBackup.Name
        # service side issue does not return label enable when fixed (ANF-8057)
        # Assert-AreEqual $label $getRetrievedBackup.Label
        
        #create second Backup       
        $secondBackup = New-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Name $backupName2 -Label $label2
        Assert-AreEqual "$accName1/$poolName/$volName1/$backupName2" $secondBackup.Name        
        # service side issue does not return label enable when fixed (ANF-8057)
        # Assert-AreEqual $label $secondBackup.Label2

        # get and check Backup by Volume (list)
        $retrievedBackupsList = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-AreEqual 2 $retrievedBackupsList.Length
        Assert-True {"$accName1/$poolName/$volName1/$backupName1" -eq $retrievedBackupsList[0].Name -or "$accName1/$poolName/$volName1/$backupName2" -eq $retrievedBackupsList[0].Name}
        Assert-True {"$accName1/$poolName/$volName1/$backupName1" -eq $retrievedBackupsList[1].Name -or "$accName1/$poolName/$volName1/$backupName2" -eq $retrievedBackupsList[1].Name}

        # get and check a Backup by name
        $getRetrievedBackup = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Name $backupName1
        Assert-AreEqual "$accName1/$poolName/$volName1/$backupName1" $getRetrievedBackup.Name

        # get and check the Backup again using the resource id just obtained
        $getRetrievedBackupById = Get-AzNetAppFilesBackup -ResourceId $getRetrievedBackup.Id
        Assert-AreEqual "$accName1/$poolName/$volName1/$backupName1" $getRetrievedBackupById.Name

        # delete one Backup retrieved by id and one by name and check removed
        Remove-AzNetAppFilesBackup -ResourceId $getRetrievedBackupById.Id

        # but test the WhatIf first, should not be removed
        Remove-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Name $backupName2 -WhatIf
        $retrievedBackupsList = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual 1 $retrievedBackupsList.Length
                                
        #remove by name
        Remove-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Name $backupName2
        $retrievedBackupsList = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual 0 $retrievedBackupsList.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
    
<#
.SYNOPSIS
Test Backup Pipeline operations (uses command aliases)
#>
function Test-BackupPipelines
{
    $resourceGroup = Get-ResourceGroupName
    $currentSub = (Get-AzureRmContext).Subscription	
    $subsid = $currentSub.SubscriptionId
    $accName1 = Get-ResourceName    
    $accName1 = Get-ResourceName
    $volName1 = Get-ResourceName
    $backupName1 = Get-ResourceName
    $backupName2 = Get-ResourceName
    $poolName = Get-ResourceName
    $label = "powershellBackupPipelineTest"
    $updateLabel = "powershellUpdateBackupPipelineTest"
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    $backupLocation = "southcentralus"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"
    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $backupLocation

        New-AnfAccount -ResourceGroupName $resourceGroup -Location $backupLocation -Name $accName1

        # create pool
        New-AnfPool -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -Name $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel 
        
        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $backupLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # create volume by piping from a pool
        # account name, pool name and service level are all acquired
        $retrievedVolume = Get-AnfPool -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $poolName | New-AnfVolume -Name $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -SubnetId $subnetId -ServiceLevel $serviceLevel
        Assert-AreEqual "$accName1/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual "Premium" $retrievedVolume.ServiceLevel
        
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $backupLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        # get check Vaults 
        $retrievedVaultsList = Get-AzNetAppFilesVault -ResourceGroupName $resourceGroup -AccountName $accName1
        $backupObject = @{
            VaultId = $retrievedVaultsList[0].Id
            BackupEnabled = $true
            PolicyEnforced = $true
        }
         # volume update with backup policy
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Backup $backupObject

        # create backup by piping from a Volume                
        #$retrieveSn = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName | New-AnfSnapshot -SnapshotName $snName1
        $retrievedBackup = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 | New-AnfBackup -BackupName $backupName1 -Label $label
        Assert-AreEqual "$accName1/$poolName/$volName1/$backupName1" $retrievedBackup.Name

       # $getRetrievedBackupPolicy = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -Name $volName1 | Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupName1

        $updateRetrievedBackup = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -Name $volName1 | Update-AzNetAppFilesBackup -Name $backupName1 -Label $updateLabel
        # service side issue does not return label enable when fixed (ANF-8057)
        # Assert-AreEqual $updateLabel $updateRetrievedBackup.Label2

        # get the current number of backups
        $retrievedVolume = Get-AnfBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1
        $numVolumes = $retrievedVolume.Length
        
        # delete the backup by piping from backup get
        Get-AnfBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Name $backupName1 | Remove-AnfBackup

        # and check the backup list by piping from get
        $retrievedBackup = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -Name $volName1 | Get-AnfBackup
        Assert-AreEqual ($numVolumes-1) $retrievedBackup.Length 

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
