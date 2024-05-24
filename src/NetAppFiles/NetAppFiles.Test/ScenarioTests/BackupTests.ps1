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
    $backupVaultName = Get-ResourceName
    $backupName1 = Get-ResourceName
    $backupName2 = Get-ResourceName    
    $backupPolicyName1 = Get-ResourceName
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"    
    $backupLocation = "eastus2"
    $backupVNetLocation = "eastus2"
    #$backupLocation = "southcentralusstage"
    #$backupVNetLocation = "southcentralus"
    #$backupLocation = "centralus"
    $label = "powershellBackupTest"
    $labelUpdate = "powershellBackupTestUpdate"
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
        kerberos5ReadOnly = $false
        kerberos5ReadWrite = $false
        kerberos5iReadOnly = $false
        kerberos5iReadWrite = $false
        kerberos5pReadOnly = $false
        kerberos5pReadWrite = $false
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

    function WaitForSucceeded #($sourceOnly)
    {
        $i = 0 
        do
        {
            $sourceVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1
            Start-TestSleep -Seconds 10
            $i++
        }               
        until ($sourceVolume.ProvisioningState -eq "Succeeded" -or $i -eq 3);
    }

    function WaitForBackupSucceeded #($sourceOnly)    
    {
        $i = 0 
        do
        {
            $getRetrievedBackup = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName1
            Start-TestSleep -Seconds 10
            $i++
        }               
        until ($getRetrievedBackup.ProvisioningState -eq "Succeeded" -or $i -eq 3);

        $i = 0
        do
        {
            $backupStatus = Get-AzNetAppFilesVolumeBackupStatus -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -Name $volName1 
            Start-TestSleep -Seconds 20
            $i++
        }               
        until ($backupStatus.MirrorState -eq "Mirrored" -or $i -eq 10);
    }

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $backupVNetLocation -Tags @{Owner = 'b-aubald';testTag1='psBackupTagValue1'}

        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $backupVNetLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # try creating an Account -               
        $newTagName = "testTag1"
        $newTagValue = "psBackupTagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $backupLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name


        # Create BackupVault
        $retrievedVault = New-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName -Location $backupLocation -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual "$accName1/$backupVaultName" $retrievedVault.Name

        $retrievedVault = Get-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName
        # create and check BackupPolicy
        #$retrievedBackupPolicy = New-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -Name $backupPolicyName1 -Tag @{$newTagName = $newTagValue} -Enabled -DailyBackupsToKeep $dailyBackupsToKeep -WeeklyBackupsToKeep $weeklyBackupsToKeep -MonthlyBackupsToKeep $monthlyBackupsToKeep -YearlyBackupsToKeep $yearlyBackupsToKeep
        #Assert-NotNull $retrievedBackupPolicy.Id

        # create pool
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel

        # create  volume and check
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes 
        Assert-AreEqual "$accName1/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual $newTagValue $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients 
        
        Start-TestSleep -Seconds 30
        WaitForSucceeded
        

        $backupObject = @{
            BackupVaultId = $retrievedVault.Id
            PolicyEnforced = $true            
        }

        Start-TestSleep -Seconds 30
        WaitForSucceeded 

         # volume update with backup policy
        $updatedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Backup $backupObject
        Start-TestSleep -Seconds 30
        
       # Assert-ThrowsContains{ Get-AzNetAppFilesVolumeGroupIdListForLDAPUser -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Username $userName} 'Group Id list can be fetched for LDAP enabled volumes only. Please check that the volume is LDAP enabled'
        Assert-ThrowsContains{New-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName1 -Label $label -VolumeResourceId "bogus Id" } 'is an invalid resource Id'
        
        # create and check Backup
        $retrievedBackup = New-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName1 -Label $label -VolumeResourceId $retrievedVolume.Id
        Assert-AreEqual "$accName1/$backupVaultName/$backupName1" $retrievedBackup.Name
        WaitForBackupSucceeded $backupName1 $backupVaultName
        # service side issue does not return label enable when fixed (ANF-8057)
        #Assert-AreEqual $label $retrievedBackup.Label
        
        # get and check a Backup by name and check again
        $getRetrievedBackup = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName1
        Assert-AreEqual "$accName1/$backupVaultName/$backupName1" $getRetrievedBackup.Name        
        Assert-AreEqual $label $getRetrievedBackup.Label
        
        # update and check a Backup by name and check again
        #$updateBackup = Update-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -Location $backupLocation -PoolName $poolName -VolumeName $volName1 -Name $backupName1 -Label $labelUpdate
        # service side issue does not return label enable when fixed (ANF-8057)
        #Assert-AreEqual $labelUpdate $updateBackup.Label
        WaitForBackupSucceeded
        
        #Restore job not deployed on region enable when finished
        #Test restore files from backup,  
        #$fileList = New-Object string[] 1
        #$fileList[0] = "/dir1/customer1.db"
        #$getResultBackupRestore = Restore-AzNetAppFilesBackupFile -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -BackupName $backupName1 -FileList $fileList -DestinationVolumeId $retrievedVolume.Id
        
        #create second Backup       
        $secondBackup = New-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName2 -Label $label2 -VolumeResourceId $retrievedVolume.Id
        Assert-AreEqual "$accName1/$backupVaultName/$backupName2" $secondBackup.Name
        WaitForBackupSucceeded $backupName2 $backupVaultName
        Assert-AreEqual $label2 $secondBackup.Label

        # get and check Backup list
        $retrievedBackupsList = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-AreEqual 2 $retrievedBackupsList.Length
        Assert-True {"$accName1/$backupVaultName/$backupName1" -eq $retrievedBackupsList[0].Name -or "$accName1/$backupVaultName/$backupName2" -eq $retrievedBackupsList[0].Name}
        Assert-True {"$accName1/$backupVaultName/$backupName1" -eq $retrievedBackupsList[1].Name -or "$accName1/$backupVaultName/$backupName2" -eq $retrievedBackupsList[1].Name}

        # get and check Backup by Volume (list)
        $retrievedBackupsList = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Filter $retrievedVolume.Id
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-AreEqual 2 $retrievedBackupsList.Length
        Assert-True {"$accName1/$backupVaultName/$backupName1" -eq $retrievedBackupsList[0].Name -or "$accName1/$backupVaultName/$backupName2" -eq $retrievedBackupsList[0].Name}
        Assert-True {"$accName1/$backupVaultName/$backupName1" -eq $retrievedBackupsList[1].Name -or "$accName1/$backupVaultName/$backupName2" -eq $retrievedBackupsList[1].Name}


        # get and check a Backup by name
        $getRetrievedBackup = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName1
        Assert-AreEqual "$accName1/$backupVaultName/$backupName1" $getRetrievedBackup.Name

        # get and check the Backup again using the resource id just obtained
        $getRetrievedBackupById = Get-AzNetAppFilesBackup -ResourceId $getRetrievedBackup.Id
        Assert-AreEqual "$accName1/$backupVaultName/$backupName1" $getRetrievedBackupById.Name
        
        # delete one Backup by name and check removed
        # but test the WhatIf first, should not be removed
        Remove-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName1 -WhatIf
        $retrievedBackupsList = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Filter $retrievedVolume.Id
        Assert-AreEqual 2 $retrievedBackupsList.Length
      
        #remove by name
        Remove-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName1
        $retrievedBackupsList = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Filter $retrievedVolume.Id
        Assert-AreEqual 1 $retrievedBackupsList.Length
        
        Start-TestSleep -Seconds 200
        # delete volume to cleanup last backup and check removed
        Remove-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName
        Assert-AreEqual 0 $retrievedVolume.Length
        
        # delete one Backup  
        Remove-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -BackupName $backupName1 -WhatIf
        # delete one Backup by id and check removed
        Remove-AzNetAppFilesBackup -ResourceId $secondBackup.Id
        $retrievedDeletedBackup = $null
        try
        {
            $retrievedDeletedBackup = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -BackupName $backupName1
        }
        catch
        {
            $retrievedDeletedBackup = $null
        }
        Assert-Null $retrievedDeletedBackup
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
    $backupVaultName = Get-ResourceName
    $label = "powershellBackupPipelineTest"
    $updateLabel = "powershellUpdateBackupPipelineTest"
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte
    $doubleUsage = 2 * $usageThreshold
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    $backupLocation = "eastus2"
    $backupVNetLocation = "eastus2"
    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $vnetName = $resourceGroup + "-vnet"
    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    try
    {
        $newTagName = "tag1"
        $newTagValue = "psBackupTagValue1"
        
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $backupVNetLocation -Tags @{Owner = 'b-aubald'}

        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $backupVNetLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork

        # try creating an Account -               
        $newTagName = "testTag1"
        $newTagValue = "psBackupTagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $backupLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name

        # Create BackupVault
        $retrievedVault = Get-AzNetAppFilesAccount -ResourceGroupName $resourceGroup| New-AzNetAppFilesBackupVault -Name $backupVaultName -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual "$accName1/$backupVaultName" $retrievedVault.Name


        # create pool
        New-AnfPool -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -Name $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel 
        
        # create volume by piping from a pool
        # account name, pool name and service level are all acquired
        $retrievedVolume = Get-AnfPool -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $poolName | New-AnfVolume -Name $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -SubnetId $subnetId -ServiceLevel $serviceLevel
        Assert-AreEqual "$accName1/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual "Premium" $retrievedVolume.ServiceLevel      

        # get check Vaults 
        #$retrievedVaultsList = Get-AzNetAppFilesVault -ResourceGroupName $resourceGroup -AccountName $accName1
        $backupObject = @{
            BackupVaultId = $retrievedVault.Id            
            PolicyEnforced = $false
        }
         # volume update with backup 
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 -Backup $backupObject

        # create backup by piping from a backupVault
        #$retrieveSn = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName | New-AnfSnapshot -SnapshotName $snName1
        $retrievedBackup = Get-AnfBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName | New-AnfBackup -BackupName $backupName1 -Label $label -VolumeResourceId $retrievedVolume.Id
        Assert-AreEqual "$accName1/$backupVaultName/$backupName1" $retrievedBackup.Name
        
        WaitForBackupSucceeded $backupName1 $backupVaultName
       # $getRetrievedBackupPolicy = Get-AnfVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -Name $volName1 | Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupName1

        $updateRetrievedBackup = Get-AnfBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName | Update-AzNetAppFilesBackup -Name $backupName1 -Label $updateLabel
        # service side issue does not return label enable when fixed (ANF-8057)
        # Assert-AreEqual $updateLabel $updateRetrievedBackup.Label2

        # get the current number of backups
        $retrievedBackups = Get-AnfBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName
        Assert-AreEqual 1 $retrievedBackups.Length
        $numBackups = $retrievedBackups.Length
        
        #create another backup
        $retrievedBackup = Get-AnfBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName | New-AnfBackup -BackupName $backupName2 -Label $label -VolumeResourceId $retrievedVolume.Id
        Assert-AreEqual "$accName1/$backupVaultName/$backupName2" $retrievedBackup.Name        
        WaitForBackupSucceeded $backupName2 $backupVaultName

        $retrievedBackups = Get-AnfBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName
        Assert-AreEqual 2 $retrievedBackups.Length
        $numBackups = $retrievedBackups.Length
               
        
        # delete the first backup by piping from backup get
        Get-AnfBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName1 | Remove-AnfBackup
        # and check the backup list by piping from get
        $retrievedBackup = Get-AnfBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName | Get-AnfBackup
        Assert-AreEqual ($numBackups-1) $retrievedBackup.Length 
        Start-TestSleep -Seconds 200
        # delete volume so we can cleanup last remaining backup and check removed
        Remove-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName -VolumeName $volName1 
        $retrievedVolumes = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName1 -PoolName $poolName
        Assert-AreEqual 0 $retrievedVolumes.Length
        Start-TestSleep -Seconds 200
        # delete the last backup by piping from BackupVault get
        Get-AnfBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName2 | Remove-AnfBackup
        Start-TestSleep -Seconds 200
        # Check accountBackups
        $retrievedDeletedBackup = $null
        try
        {
            $retrievedDeletedBackup = Get-AnfBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName2
        }
        catch
        {
            $retrievedDeletedBackup = $null
        }
        Assert-Null $retrievedDeletedBackup
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test Volume Test-VolumeBackupStatusCrud operation
#>
function Test-VolumeBackupStatus
{
    $currentSub = (Get-AzureRmContext).Subscription	
    $subsid = $currentSub.SubscriptionId

    $resourceGroup = Get-ResourceGroupName
    $accName = Get-ResourceName
    $backupVaultName = Get-ResourceName
    $poolName = Get-ResourceName
    $poolName2 = Get-ResourceName
    $volName1 = Get-ResourceName
    $backupPolicyName1 = Get-ResourceName
    $backupName1 = Get-ResourceName
    $backupName2 = Get-ResourceName
    $gibibyte = 1024 * 1024 * 1024
    $usageThreshold = 100 * $gibibyte    
    #$resourceLocation = Get-ProviderLocation "Microsoft.NetApp" "eastus" -UseCanonical
    $resourceLocation = "eastus2"
    $backupLocation = "eastus2"
    $backupVNetLocation = "eastus2"
    $label = "powershellBackupTest"
    #$backupLocation = "eastus2euap"
    #$backupVNetLocation = "eastus2euap"

    $subnetName = "default"
    $poolSize = 4398046511104
    $serviceLevel = "Premium"
    $serviceLevelStandard = "Premium"
    $vnetName = $resourceGroup + "-vnet"
    $dailyBackupsToKeep = 4
    $weeklyBackupsToKeep = 3
    $monthlyBackupsToKeep = 2
    $yearlyBackupsToKeep = 1

    $subnetId = "/subscriptions/$subsId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$subnetName"

    $rule1 = @{
        RuleIndex = 1
        UnixReadOnly = $false
        UnixReadWrite = $true
        Cifs = $false
        Nfsv3 = $true
        Nfsv41 = $false
        kerberos5ReadOnly = $false
        kerberos5ReadWrite = $false
        kerberos5iReadOnly = $false
        kerberos5iReadWrite = $false
        kerberos5pReadOnly = $false
        kerberos5pReadWrite = $false
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
        New-AzResourceGroup -Name $resourceGroup -Location $backupVNetLocation -Tags @{Owner = 'b-aubald'}
		
        # create virtual network
        $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $resourceGroup -Location $backupVNetLocation -Name $vnetName -AddressPrefix 10.0.0.0/16
        $delegation = New-AzDelegation -Name "netAppVolumes" -ServiceName "Microsoft.Netapp/volumes"
        Add-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $delegation | Set-AzVirtualNetwork
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        # create account
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName 

        #Create backupVault
        $retrievedVault = New-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName -Name $backupVaultName -Location $backupLocation -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual "$accName/$backupVaultName" $retrievedVault.Name
	    
        # create and check BackupPolicy
        #$retrievedBackupPolicy = New-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName -Name $backupPolicyName1 -Tag @{$newTagName = $newTagValue} -Enabled -DailyBackupsToKeep $dailyBackupsToKeep -WeeklyBackupsToKeep $weeklyBackupsToKeep -MonthlyBackupsToKeep $monthlyBackupsToKeep -YearlyBackupsToKeep $yearlyBackupsToKeep
        #Assert-NotNull $retrievedBackupPolicy.Id

        # create pool
        $retrievedPool = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName -PoolName $poolName -PoolSize $poolSize -ServiceLevel $serviceLevel
                        
        # create  volume and check
        $retrievedVolume = New-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -CreationToken $volName1 -UsageThreshold $usageThreshold -ServiceLevel $serviceLevel -SubnetId $subnetId -Tag @{$newTagName = $newTagValue} -ExportPolicy $exportPolicy -ProtocolType $protocolTypes
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        Assert-AreEqual $serviceLevel $retrievedVolume.ServiceLevel
        Assert-AreEqual True $retrievedVolume.Tags.ContainsKey($newTagName)
        Assert-AreEqual "tagValue1" $retrievedVolume.Tags[$newTagName].ToString()
        Assert-NotNull $retrievedVolume.ExportPolicy
        Assert-AreEqual '0.0.0.0/0' $retrievedVolume.ExportPolicy.Rules[0].AllowedClients 

        Assert-AreEqual $retrievedVolume.ProtocolTypes[0] 'NFSv3'

        # get and check the volume by name
        $retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        Assert-AreEqual "$accName/$poolName/$volName1" $retrievedVolume.Name
        
        # get check Vaults 
        #$retrievedVaultsList = Get-AzNetAppFilesVault -ResourceGroupName $resourceGroup -AccountName $accName
        $backupObject = @{
            BackupVaultId = $retrievedVault.Id            
            PolicyEnforced = $true            
        }
        Start-TestSleep -Seconds 30        
        # volume update with backup policy
        $retrievedVolume = Update-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Backup $backupObject
        Start-TestSleep -Seconds 30
        # create and check Backup
        $retrievedBackup = New-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName -BackupVaultName $backupVaultName -Name $backupName1 -VolumeResourceId $retrievedVolume.Id -Label $label
        Assert-AreEqual "$accName/$backupVaultName/$backupName1" $retrievedBackup.Name
        Start-TestSleep -Seconds 30
        #$retrievedBackup = New-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName -PoolName $poolName -VolumeName $volName1 -Name $backupName2 -Label $label
        Start-TestSleep -Seconds 30
        #$retrievedVolume = Get-AzNetAppFilesVolume -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -VolumeName $volName1
        # Get volume backup status        
        Start-TestSleep -Seconds 200
        $retrievedBackupStatus = Get-AzNetAppFilesVolumeBackupStatus -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $volName1 
        Assert-NotNull $retrievedBackupStatus                
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
    function WaitForBackupSucceeded ($backupName, $backupVaultName)
    {
        $i = 0 
        do
        {
            $sourceBackup = Get-AzNetAppFilesBackup -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName -Name $backupName
            Start-TestSleep -Seconds 10
            $i++
        }               
        until ($sourceBackup.ProvisioningState -eq "Succeeded" -or $i -eq 10);
    }