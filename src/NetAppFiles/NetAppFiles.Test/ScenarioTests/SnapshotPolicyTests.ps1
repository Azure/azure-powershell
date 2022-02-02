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
Test Snapshot Policy CRUD operations
#>
function Test-SnapshotPolicyCrud
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName
    $snapshotPolicyName1 = Get-ResourceName
    $snapshotPolicyName2 = Get-ResourceName    
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"    

    $hourlySchedule = @{        
        Minute = 2
        SnapshotsToKeep = 6
    }
    $dailySchedule = @{
        Hour = 1
        Minute = 2
        SnapshotsToKeep = 6
    }
    $weeklySchedule = @{
        Minute = 2    
        Hour = 1		        
        Day = "Sunday,Monday"
        SnapshotsToKeep = 6
    }
    $monthlySchedule = @{
        Minute = 2    
        Hour = 1        
        DaysOfMonth = "2,11,21"
        SnapshotsToKeep = 6
    }

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        # try creating an Account -               
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedAcc = New-AzNetAppFilesAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 -Tag @{$newTagName = $newTagValue} 
        Assert-AreEqual $accName1 $retrievedAcc.Name
        
        # create and check SnapshotPolicy        
        $retrievedSnapshotPolicy = New-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -Name $snapshotPolicyName1 -Enabled -HourlySchedule $hourlySchedule -DailySchedule $dailySchedule -WeeklySchedule $weeklySchedule -MonthlySchedule $monthlySchedule
        Assert-AreEqual "$accName1/$snapshotPolicyName1" $retrievedSnapshotPolicy.Name        
        Assert-AreEqual $hourlySchedule["Minute"] $retrievedSnapshotPolicy.HourlySchedule.Minute
        Assert-AreEqual $dailySchedule["Hour"] $retrievedSnapshotPolicy.DailySchedule.Hour
        Assert-AreEqual $weeklySchedule["Day"] $retrievedSnapshotPolicy.WeeklySchedule.Day
        Assert-AreEqual $monthlySchedule["DaysOfMonth"] $retrievedSnapshotPolicy.MonthlySchedule.DaysOfMonth
        
        # get and check a SnapshotPolicy by name and check again
        $getRetrievedSnapshotPolicy = Get-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $snapshotPolicyName1
        Assert-AreEqual "$accName1/$snapshotPolicyName1" $retrievedSnapshotPolicy.Name
        Assert-AreEqual $hourlySchedule["Minute"] $getRetrievedSnapshotPolicy.HourlySchedule.Minute
        Assert-AreEqual $dailySchedule["Hour"] $getRetrievedSnapshotPolicy.DailySchedule.Hour
        Assert-AreEqual $weeklySchedule["Day"] $getRetrievedSnapshotPolicy.WeeklySchedule.Day
        Assert-AreEqual $monthlySchedule["DaysOfMonth"] $getRetrievedSnapshotPolicy.MonthlySchedule.DaysOfMonth

        #update with set
        $hourlySchedule2 = @{
            Minute = 2
            SnapshotsToKeep = 3
        }
        #Check update with set
        $setRetrievedSnapshotPolicy = Set-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -Name $snapshotPolicyName1 -Enabled -HourlySchedule $hourlySchedule -DailySchedule $dailySchedule -WeeklySchedule $weeklySchedule -MonthlySchedule $monthlySchedule
        Assert-AreEqual $hourlySchedule["Minute"] $setRetrievedSnapshotPolicy.HourlySchedule.Minute

        $hourlySchedule2 = @{
            Minute = 1
            SnapshotsToKeep = 3
        }
        $updatedSnapshotPolicy = Update-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -Name $snapshotPolicyName1 -HourlySchedule $hourlySchedule2
        Assert-AreEqual $hourlySchedule2["Minute"] $updatedSnapshotPolicy.HourlySchedule.Minute

        #create second SnapshotPolicy
        $secondSnapshotPolicy = New-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName1 -Name $snapshotPolicyName2 -Enabled -HourlySchedule $hourlySchedule -DailySchedule $dailySchedule -WeeklySchedule $weeklySchedule -MonthlySchedule $monthlySchedule
        Assert-AreEqual "$accName1/$snapshotPolicyName2" $secondSnapshotPolicy.Name        
        Assert-AreEqual $hourlySchedule["Minute"] $secondSnapshotPolicy.HourlySchedule.Minute
        Assert-AreEqual $dailySchedule["Hour"] $secondSnapshotPolicy.DailySchedule.Hour
        Assert-AreEqual $weeklySchedule["Day"] $secondSnapshotPolicy.WeeklySchedule.Day
        Assert-AreEqual $monthlySchedule["DaysOfMonth"] $secondSnapshotPolicy.MonthlySchedule.DaysOfMonth

        # get and check SnapshotPolicies by Account (list)
        $retrievedSnapshotPolicyList = Get-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -AccountName $accName1
        # check the names but the order does not appear to be guaranteed (perhaps because the names are randomly generated)
        Assert-AreEqual 2 $retrievedSnapshotPolicyList.Length
        Assert-True {"$accName1/$snapshotPolicyName1" -eq $retrievedSnapshotPolicyList[0].Name -or "$accName1/$snapshotPolicyName2" -eq $retrievedSnapshotPolicyList[0].Name}
        Assert-True {"$accName1/$snapshotPolicyName1" -eq $retrievedSnapshotPolicyList[1].Name -or "$accName1/$snapshotPolicyName2" -eq $retrievedSnapshotPolicyList[1].Name}

        # get and check a SnapshotPolicy by name
        $getRetrievedSnapshotPolicy = Get-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $snapshotPolicyName1
        Assert-AreEqual "$accName1/$snapshotPolicyName1" $getRetrievedSnapshotPolicy.Name

        # get and check the SnapshotPolicy again using the resource id just obtained
        $getRetrievedSnapshotPolicyById = Get-AzNetAppFilesSnapshotPolicy -ResourceId $retrievedSnapshotPolicy.Id
        Assert-AreEqual "$accName1/$snapshotPolicyName1" $getRetrievedSnapshotPolicyById.Name

        # delete one account retrieved by id and one by name and check removed
        Remove-AzNetAppFilesSnapshotPolicy -ResourceId $retrievedSnapshotPolicy.Id
                        
        # but test the WhatIf first, should not be removed
        Remove-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $snapshotPolicyName1 -WhatIf
        $retrievedSnapshotPolicyList = Get-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -AccountName $accName1
        Assert-AreEqual 1 $retrievedAcc.Length
        
        #remove by name
        Remove-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $snapshotPolicyName1
        $retrievedSnapshotPolicyList = Get-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -AccountName $accName1
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
Test SnapshotPolicy Pipeline operations (uses command aliases)
#>
function Test-SnapshotPolicyPipelines
{
    $resourceGroup = Get-ResourceGroupName
    $accName1 = Get-ResourceName    
    $accName1 = Get-ResourceName
    $snapshotPolicyName1 = Get-ResourceName
    $snapshotPolicyName2 = Get-ResourceName

    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $hourlySchedule = @{        
        Minute = 2
        SnapshotsToKeep = 6
    }
    $dailySchedule = @{
        Hour = 1
        Minute = 2
        SnapshotsToKeep = 6
    }
    $weeklySchedule = @{
        Minute = 2    
        Hour = 1		        
        Day = "Sunday,Monday"
        SnapshotsToKeep = 6
    }
    $monthlySchedule = @{
        Minute = 2    
        Hour = 1        
        DaysOfMonth = "2,11,21"
        SnapshotsToKeep = 6
    }

    try
    {
        # create the resource group
        New-AzResourceGroup -Name $resourceGroup -Location $resourceLocation -Tags @{Owner = 'b-aubald'}

        New-AnfAccount -ResourceGroupName $resourceGroup -Location $resourceLocation -Name $accName1 
        # try creating an Account -               
        $newTagName = "tag1"
        $newTagValue = "tagValue1"
        $retrievedSnapshotPolicy = Get-AnfAccount -ResourceGroupName $resourceGroup -Name $accName1 | New-AzNetAppFilesSnapshotPolicy -Name $snapshotPolicyName1 -Tag @{$newTagName = $newTagValue} -HourlySchedule $hourlySchedule -DailySchedule $dailySchedule -WeeklySchedule $weeklySchedule -MonthlySchedule $monthlySchedule

        $getRetrievedSnapshotPolicy = Get-AzNetAppFilesSnapshotPolicy -ResourceGroupName $resourceGroup -AccountName $accName1 -Name $snapshotPolicyName1
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
