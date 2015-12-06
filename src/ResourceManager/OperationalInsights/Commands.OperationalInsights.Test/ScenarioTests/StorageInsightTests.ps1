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
Create, update, and delete storage insights
#>
function Test-StorageInsightCreateUpdateDelete
{
    $wsname = Get-ResourceName
    $siname = Get-ResourceName
    $saname = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $said = Get-StorageResourceId $rgname $saname
    $wslocation = Get-ProviderLocation
    
    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    # Create a workspace to house the storage insight
    $workspace = New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Force

    # Create a storage insight
    $storageinsight = New-AzureRmOperationalInsightsStorageInsight -ResourceGroupName $rgname -WorkspaceName $wsname -Name $siname -Tables @("WADWindowsEventLogsTable", "LinuxSyslogVer2v0") -Containers @("wad-iis-logfiles") -StorageAccountResourceId $said -StorageAccountKey "fakekey"
    Assert-AreEqual $siname $storageInsight.Name
    Assert-NotNull $storageInsight.ResourceId
    Assert-AreEqual $rgname $storageInsight.ResourceGroupName
    Assert-AreEqual $wsname $storageInsight.WorkspaceName
    Assert-AreEqual $said $storageInsight.StorageAccountResourceId
    Assert-AreEqual "OK" $storageInsight.State
    Assert-AreEqualArray @("WADWindowsEventLogsTable", "LinuxSyslogVer2v0") $storageInsight.Tables
    Assert-AreEqualArray @("wad-iis-logfiles") $storageInsight.Containers

    # Get the storage insight that was created
    $storageInsight = Get-AzureRmOperationalInsightsStorageInsight -ResourceGroupName $rgname -WorkspaceName $wsname -Name $siname
    Assert-AreEqual $siname $storageInsight.Name
    Assert-NotNull $storageInsight.ResourceId
    Assert-AreEqual $rgname $storageInsight.ResourceGroupName
    Assert-AreEqual $wsname $storageInsight.WorkspaceName
    Assert-AreEqual $said $storageInsight.StorageAccountResourceId
    Assert-AreEqual "OK" $storageInsight.State
    Assert-AreEqualArray @("WADWindowsEventLogsTable", "LinuxSyslogVer2v0") $storageInsight.Tables
    Assert-AreEqualArray @("wad-iis-logfiles") $storageInsight.Containers

    # Create a second storage insight for list testing
    $sinametwo = Get-ResourceName
    $storageinsight = New-AzureRmOperationalInsightsStorageInsight -ResourceGroupName $rgname -WorkspaceName $wsname -Name $sinametwo -Tables @("WADWindowsEventLogsTable", "LinuxSyslogVer2v0") -StorageAccountResourceId $said -StorageAccountKey "fakekey"

    # List the storage insight in the workspace (both param sets)
    $storageinsights = Get-AzureRmOperationalInsightsStorageInsight -ResourceGroupName $rgname -WorkspaceName $wsname
    Assert-AreEqual 2 $storageinsights.Count
    Assert-AreEqual 1 ($storageinsights | Where {$_.Name -eq $siname}).Count
    Assert-AreEqual 1 ($storageinsights | Where {$_.Name -eq $sinametwo}).Count

    $storageinsights = Get-AzureRmOperationalInsightsStorageInsight -Workspace $workspace
    Assert-AreEqual 2 $storageinsights.Count
    Assert-AreEqual 1 ($storageinsights | Where {$_.Name -eq $siname}).Count
    Assert-AreEqual 1 ($storageinsights | Where {$_.Name -eq $sinametwo}).Count

    # Delete one of the storage insights
    Remove-AzureRmOperationalInsightsStorageInsight -ResourceGroupName $rgname -WorkspaceName $wsname -Name $sinametwo -Force
    Assert-ThrowsContains { Get-AzureRmOperationalInsightsStorageInsight -Workspace $workspace -Name $sinametwo } "NotFound"
    $storageinsights = Get-AzureRmOperationalInsightsStorageInsight -Workspace $workspace
    Assert-AreEqual 1 $storageinsights.Count
    Assert-AreEqual 1 ($storageinsights | Where {$_.Name -eq $siname}).Count
    Assert-AreEqual 0 ($storageinsights | Where {$_.Name -eq $sinametwo}).Count

    # Perform an update on the storage insight
    $storageinsight = Set-AzureRmOperationalInsightsStorageInsight -ResourceGroupName $rgname -WorkspaceName $wsname -Name $siname -Tables @("WADWindowsEventLogsTable") -Containers @() -StorageAccountKey "anotherfakekey"
    Assert-AreEqualArray @("WADWindowsEventLogsTable") $storageInsight.Tables
    Assert-AreEqualArray @() $storageInsight.Containers

    $storageinsight = $storageinsight | Set-AzureRmOperationalInsightsStorageInsight -Tables @() -Containers @("wad-iis-logfiles")
    Assert-AreEqualArray @() $storageInsight.Tables
    Assert-AreEqualArray @("wad-iis-logfiles") $storageInsight.Containers

    $storageinsight = New-AzureRmOperationalInsightsStorageInsight -Workspace $workspace -Name $siname -Tables @("WADWindowsEventLogsTable") -Containers @("wad-iis-logfiles") -StorageAccountKey "anotherfakekey" -StorageAccountResourceId $said -Force
    Assert-AreEqualArray @("WADWindowsEventLogsTable") $storageInsight.Tables
    Assert-AreEqualArray @("wad-iis-logfiles") $storageInsight.Containers

    # Delete the remaining storage insight via piping
    Remove-AzureRmOperationalInsightsStorageInsight -Workspace $workspace -Name $siname -Force
    Assert-ThrowsContains { Get-AzureRmOperationalInsightsStorageInsight -Workspace $workspace -Name $siname } "NotFound"
    $storageinsights = Get-AzureRmOperationalInsightsStorageInsight -Workspace $workspace
    Assert-AreEqual 0 $storageinsights.Count
}

<#
.SYNOPSIS
Validate that storage insight creation fails without a valid parent workspace
#>
function Test-StorageInsightCreateFailsWithoutWorkspace
{
    $wsname = Get-ResourceName
    $siname = Get-ResourceName
    $saname = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $said = Get-StorageResourceId $rgname $saname
    $wslocation = Get-ProviderLocation
    
    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    Assert-ThrowsContains { New-AzureRmOperationalInsightsStorageInsight -ResourceGroupName $rgname -WorkspaceName $wsname -Name $siname -Tables @("WADWindowsEventLogsTable", "LinuxSyslogVer2v0") -StorageAccountResourceId $said -StorageAccountKey "fakekey" } "ResourceNotFound"
}