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
function Test-BackupVaultCrud
{
    $currentSub = (Get-AzureRmContext).Subscription
    $subsid = $currentSub.SubscriptionId
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName        
    $backupVaultName = Get-ResourceName
    $backupVaultName2 = Get-ResourceName
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"    
    $backupLocation = "eastus2"
    $label = "powershellBackupTest"
    $labelUpdate = "powershellBackupTestUpdate"
    $label2 = "powershellBackupTest2"


    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald';testTag1='psBackupVaultsTagValue1'}

        # try creating an Account -               
        $newTagName = "testTag1"
        $newTagValue = "psBackupVaultTagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name


        # Create BackupVault
        $retrievedVault = New-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName -Location $resourceLocation -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual "$accName1/$backupVaultName" $retrievedVault.Name

        $retrievedVault = Get-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName

        $updateTagName = "UpdateTag"
        $updateTagValue = "UpdateTagValue"

        $retrievedVault = Update-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName -Tag @{$updateTagName = $updateTagValue}

        $retrievedVault = Get-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName
        Assert-AreEqual "UpdateTagValue" $retrievedVault.Tags[$updateTagName].ToString()

        $updateTagValue = "SetTagValue"
        $retrievedVault = Set-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName -Tag @{$updateTagName = $updateTagValue}
        Assert-AreEqual "SetTagValue" $retrievedVault.Tags[$updateTagName].ToString()

        $retrievedVault = Get-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName
        Assert-AreEqual "SetTagValue" $retrievedVault.Tags[$updateTagName].ToString()               
        
        #create second BackupVault
        $secondBackupVault = New-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupVaultName2 -Location $resourceLocation -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual "$accName1/$backupVaultName2" $secondBackupVault.Name        
        
        # get and check BackupVault list
        $retrievedBackupVaultsList = Get-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-AreEqual 2 $retrievedBackupVaultsList.Length
        Assert-True {"$accName1/$backupVaultName" -eq $retrievedBackupVaultsList[0].Name -or "$accName1/$backupVaultName2" -eq $retrievedBackupVaultsList[0].Name}
        Assert-True {"$accName1/$backupVaultName" -eq $retrievedBackupVaultsList[1].Name -or "$accName1/$backupVaultName2" -eq $retrievedBackupVaultsList[1].Name}

        # get and check a Backup by name
        $getRetrievedBackupVault = Get-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName
        Assert-AreEqual "$accName1/$backupVaultName" $getRetrievedBackupVault.Name

        # get and check the Backup again using the resource id just obtained
        $getRetrievedBackupById = Get-AzNetAppFilesBackupVault -ResourceId $getRetrievedBackupVault.Id
        Assert-AreEqual "$accName1/$backupVaultName" $getRetrievedBackupVault.Name
        
        # delete one Backup by name and check removed
        # but test the WhatIf first, should not be removed
        Remove-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName  -WhatIf
        $retrievedBackupVaultsList = Get-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1
        Assert-AreEqual 2 $retrievedBackupVaultsList.Length
      
        #remove by name
        Remove-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName
        $retrievedBackupVaultsList = Get-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 
        Assert-AreEqual 1 $retrievedBackupVaultsList.Length
                
        # delete one BackupVault by id and check removed
        Remove-AzNetAppFilesBackupVault -ResourceId $secondBackupVault.Id
        $retrievedDeletedBackup = $null
        try
        {
            $retrievedDeletedBackup = Get-AzNetAppFilesBackupVault -ResourceGroupName $resourceGroup -AccountName $accName1 -BackupVaultName $backupVaultName
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
