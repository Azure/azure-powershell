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
Test Backup Policy CRUD operations
#>
function Test-BackupPolicyCrud
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $backupPolicyName1 = Get-ResourceName
    $backupPolicyName2 = Get-ResourceName
    $accName2 = Get-ResourceName
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $dailyBackupsToKeep = 4
    $weeklyBackupsToKeep = 3
    $monthlyBackupsToKeep = 2
    $yearlyBackupsToKeep = 1
    $backupLocation = "southcentralus"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $backupLocation -Tags @{Owner = 'b-aubald'}

        # try creating an Account -               
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $backupLocation -Name $accName1 -Tag @{$newTagName = $newTagValue}
        Assert-AreEqual $accName1 $retrievedAcc.Name
        
        # create and check BackupPolicy        
        $retrievedBackupPolicy = New-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -Name $backupPolicyName1 -Tag @{$newTagName = $newTagValue} -Enabled -DailyBackupsToKeep $dailyBackupsToKeep -WeeklyBackupsToKeep $weeklyBackupsToKeep -MonthlyBackupsToKeep $monthlyBackupsToKeep -YearlyBackupsToKeep $yearlyBackupsToKeep
        Assert-AreEqual "$accName1/$backupPolicyName1" $retrievedBackupPolicy.Name
        Assert-True {$retrievedBackupPolicy.Enabled}
        Assert-AreEqual $dailyBackupsToKeep $retrievedBackupPolicy.DailyBackupsToKeep
        Assert-AreEqual $weeklyBackupsToKeep $retrievedBackupPolicy.WeeklyBackupsToKeep
        Assert-AreEqual $monthlyBackupsToKeep $retrievedBackupPolicy.MonthlyBackupsToKeep
        #returns 0 atm service side issue
        #Assert-AreEqual $yearlyBackupsToKeep $retrievedBackupPolicy.YearlyBackupsToKeep
        
        # get and check a BackupPolicy by name and check again
        $getRetrievedBackupPolicy = Get-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupPolicyName1
        Assert-AreEqual "$accName1/$backupPolicyName1" $getRetrievedBackupPolicy.Name        
        Assert-True {$retrievedBackupPolicy.Enabled}
        Assert-AreEqual $dailyBackupsToKeep $getRetrievedBackupPolicy.DailyBackupsToKeep
        Assert-AreEqual $weeklyBackupsToKeep $getRetrievedBackupPolicy.WeeklyBackupsToKeep
        Assert-AreEqual $monthlyBackupsToKeep $getRetrievedBackupPolicy.MonthlyBackupsToKeep
        #returns 0 atm service side issue
        #Assert-AreEqual $yearlyBackupsToKeep $retrievedBackupPolicy.YearlyBackupsToKeep
        
        #update with set
        $setDailyBackupsToKeep = 3
        $retrievedBackupPolicy = Set-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -Name $backupPolicyName1 -Tag @{$newTagName = $newTagValue} -Enabled -DailyBackupsToKeep $setDailyBackupsToKeep -WeeklyBackupsToKeep $weeklyBackupsToKeep -MonthlyBackupsToKeep $monthlyBackupsToKeep -YearlyBackupsToKeep $yearlyBackupsToKeep

        $setDailyBackupsToKeep = Get-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupPolicyName1
        Assert-AreEqual $updatedDailyBackupsToKeep $getSetBackupPolicy.DailyBackupsToKeep


        $updatedDailyBackupsToKeep = 2
        $updatedBackupPolicy = Update-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -Name $backupPolicyName1 -DailyBackupsToKeep $updatedDailyBackupsToKeep
        $getUpdatedBackupPolicy = Get-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupPolicyName1

        Assert-AreEqual $updatedDailyBackupsToKeep $getUpdatedBackupPolicy.DailyBackupsToKeep

        #create second BackupPolicy
        $secondBackupPolicy = New-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -Location $backupLocation -AccountName $accName1 -Name $backupPolicyName2 -Tag @{$newTagName = $newTagValue} -Enabled -DailyBackupsToKeep $dailyBackupsToKeep -WeeklyBackupsToKeep $weeklyBackupsToKeep -MonthlyBackupsToKeep $monthlyBackupsToKeep -YearlyBackupsToKeep $yearlyBackupsToKeep
        Assert-AreEqual "$accName1/$backupPolicyName2" $secondBackupPolicy.Name        
        Assert-True {$retrievedBackupPolicy.Enabled}
        Assert-AreEqual $dailyBackupsToKeep $secondBackupPolicy.DailyBackupsToKeep
        Assert-AreEqual $weeklyBackupsToKeep $secondBackupPolicy.WeeklyBackupsToKeep
        Assert-AreEqual $monthlyBackupsToKeep $secondBackupPolicy.MonthlyBackupsToKeep
        #returns 0 atm service side issue
        #Assert-AreEqual $yearlyBackupsToKeep $retrievedBackupPolicy.YearlyBackupsToKeep

        # get and check BackupPolicies by Account (list)
        $retrievedBackupPolicyList = Get-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -AccountName $accName1
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-AreEqual 2 $retrievedBackupPolicyList.Length
        Assert-True {"$accName1/$backupPolicyName1" -eq $retrievedBackupPolicyList[0].Name -or "$accName1/$backupPolicyName2" -eq $retrievedBackupPolicyList[0].Name}
        Assert-True {"$accName1/$backupPolicyName1" -eq $retrievedBackupPolicyList[1].Name -or "$accName1/$backupPolicyName2" -eq $retrievedBackupPolicyList[1].Name}

        # get and check a BackupPolicy by name
        $getRetrievedBackupPolicy = Get-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupPolicyName1
        Assert-AreEqual $accName1 $retrievedAcc.Name

        # get and check the BackupPolicy again using the resource id just obtained
        $getRetrievedBackupPolicyById = Get-AzNetAppFilesBackupPolicy -ResourceId $retrievedBackupPolicy.Id
        Assert-AreEqual "$accName1/$backupPolicyName1" $getRetrievedBackupPolicyById.Name

        # delete one BackupPolicy retrieved by id and one by name and check removed
        Remove-AzNetAppFilesBackupPolicy -ResourceId $getRetrievedBackupPolicyById.Id
        
        # but test the WhatIf first, should not be removed
        Remove-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupPolicyName2 -WhatIf
        $retrievedBackupPolicyList = Get-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -AccountName $accName1
        Assert-AreEqual 1 $retrievedBackupPolicyList.Length
        
        #remove by name
        Remove-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $backupPolicyName2
        $retrievedBackupPolicyList = Get-AzNetAppFilesBackupPolicy -ResourceGroupName $resourceGroup -AccountName $accName1
        Assert-AreEqual 0 $retrievedBackupPolicyList.Length
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
    
<#
.SYNOPSIS
Test BackupPolicy Pipeline operations (uses command aliases)
#>
function Test-BackupPolicyPipelines
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $backupPolicyName1 = Get-ResourceName
    $backupPolicyName2 = Get-ResourceName
    $accName2 = Get-ResourceName
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"    
    $dailyBackupsToKeep = 4
    $weeklyBackupsToKeep = 3
    $monthlyBackupsToKeep = 2
    $yearlyBackupsToKeep = 1
    $backupLocation = "eastus2euap"

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $backupLocation -Tags @{Owner = 'b-aubald'}

        New-AnfAccount -ResourceGroupName $resourceGroup -Location $backupLocation -Name $accName1 
        $newTagName = "tag1"
        $newTagValue = "tagValue1"  
     
        $retrievedBackupPolicy = Get-AnfAccount -ResourceGroupName $resourceGroup -Name $accName1 | New-AzNetAppFilesBackupPolicy -Name $backupPolicyName1 -Tag @{$newTagName = $newTagValue} -Enabled -DailyBackupsToKeep $dailyBackupsToKeep -WeeklyBackupsToKeep $weeklyBackupsToKeep -MonthlyBackupsToKeep $monthlyBackupsToKeep -YearlyBackupsToKeep $yearlyBackupsToKeep

        # get the policy by piping in from account 
        $getRetrievedBackupPolicy = Get-AnfAccount -ResourceGroupName $resourceGroup -Name $accName1 | Get-AzNetAppFilesBackupPolicy -Name $backupPolicyName1
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
