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
Create, update, and delete data sources
#>
function Test-DataSourceCreateUpdateDelete
{
    $wsname = Get-ResourceName
    $dsName = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $subId1 = "0b88dfdb-55b3-4fb0-b474-5b6dcbe6b2ef"
    $subId2 = "bc8edd8f-a09f-499d-978d-6b5ed2f84852"
    $wslocation = Get-ProviderLocation

    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    # Create a workspace to house the data sources
    $workspace = New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Force

    # Create a data source
    $dataSource = New-AzureRmOperationalInsightsAzureAuditDataSource -Workspace $workspace -Name $dsName -SubscriptionId $subId1
    Assert-AreEqual $dsName $dataSource.Name
    Assert-NotNull $dataSource.ResourceId
    Assert-AreEqual $rgname $dataSource.ResourceGroupName
    Assert-AreEqual $wsname $dataSource.WorkspaceName
    Assert-AreEqual $subId1 $dataSource.Properties.SubscriptionId
    Assert-AreEqual "AzureAuditLog" $dataSource.Kind

    # Get the data source that was created
    $dataSource = Get-AzureRmOperationalInsightsDataSource -Workspace $workspace -Name $dsName
    Assert-AreEqual $dsName $dataSource.Name
    Assert-NotNull $dataSource.ResourceId
    Assert-AreEqual $rgname $dataSource.ResourceGroupName
    Assert-AreEqual $wsname $dataSource.WorkspaceName
    Assert-AreEqual $subId1 $dataSource.Properties.SubscriptionId
    Assert-AreEqual "AzureAuditLog" $dataSource.Kind

    # Create a second data source for list testing
    $daNametwo = Get-ResourceName
    $dataSource = New-AzureRmOperationalInsightsAzureAuditDataSource -Workspace $workspace -Name $daNametwo -SubscriptionId $subId2

    # List the data source in the workspace (both param sets)
    $dataSources = Get-AzureRmOperationalInsightsDataSource -Workspace $workspace -Kind AzureAuditLog
    Assert-AreEqual 2 $dataSources.Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $dsName}).Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $daNametwo}).Count

    $dataSources = Get-AzureRmOperationalInsightsDataSource -ResourceGroupName $rgname -WorkspaceName $wsname -Kind AzureAuditLog
    Assert-AreEqual 2 $dataSources.Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $dsName}).Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $daNametwo}).Count

    # Delete one of the data sources
    Remove-AzureRmOperationalInsightsDataSource -Workspace $workspace -Name $daNametwo -Force
    Assert-ThrowsContains { Get-AzureRmOperationalInsightsDataSource -Workspace $workspace -Name $daNametwo } "NotFound"
    $dataSources = Get-AzureRmOperationalInsightsDataSource -Workspace $workspace -Kind AzureAuditLog
    Assert-AreEqual 1 $dataSources.Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $dsName}).Count
    Assert-AreEqual 0 ($dataSources | Where {$_.Name -eq $daNametwo}).Count

    # Perform an update on the data source
    $dataSource = $dataSources[0]
    $dataSource.Properties.SubscriptionId = $subId2
    $dataSource = Set-AzureRmOperationalInsightsDataSource -DataSource $dataSource
    Assert-AreEqual "AzureAuditLog" $dataSource.Kind
    Assert-AreEqual $subId2 $dataSource.Properties.SubscriptionId

    # Delete the remaining data source via piping
    Remove-AzureRmOperationalInsightsDataSource -Workspace $workspace -Name $dsName -Force
    Assert-ThrowsContains { Get-AzureRmOperationalInsightsDataSource -Workspace $workspace -Name $dsName } "NotFound"
    $dataSources = Get-AzureRmOperationalInsightsDataSource -Workspace $workspace -Kind AzureAuditLog
    Assert-AreEqual 0 $dataSources.Count
}

<#
.SYNOPSIS
Validate that data source creation fails without a valid parent workspace
#>
function Test-DataSourceCreateFailsWithoutWorkspace
{
    $wsname = Get-ResourceName
    $dsName = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $subId1 = "0b88dfdb-55b3-4fb0-b474-5b6dcbe6b2ef"
    $wslocation = Get-ProviderLocation

    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    Assert-ThrowsContains { New-AzureRmOperationalInsightsAzureAuditDataSource -ResourceGroupName $rgname -WorkspaceName $wsname -Name $dsName -SubscriptionId $subId1 } "ResourceNotFound"
}

<#
.SYNOPSIS
Validate that we can create all kinds of DataSource
#>
function Test-CreateAllKindsOfDataSource
{
    $wsname = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $subId1 = "0b88dfdb-55b3-4fb0-b474-5b6dcbe6b2ef"
    $wslocation = Get-ProviderLocation

    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    # Create a workspace to house the data source
    $workspace = New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Force

    # AzureAuditLog data source
    $auditLogDataSource = New-AzureRmOperationalInsightsAzureAuditDataSource -Workspace $workspace -Name "myAuditLog" -SubscriptionId $subId1

    # windows event data source
    $windowsEventDataSource = New-AzureRmOperationalInsightsWindowsEventDataSource -Workspace $workspace -Name Application -EventLogName "Application" -CollectErrors -CollectWarnings -CollectInformation

    # windows performance data source
    $windowsPerfDataSource = New-AzureRmOperationalInsightsWindowsPerformanceCounterDataSource -Workspace $workspace -Name "processorPerf" -ObjectName Processor -InstanceName * -CounterName "% Processor Time" -IntervalSeconds 10

    # linux syslog data source
    $syslogDataSource = New-AzureRmOperationalInsightsLinuxSyslogDataSource -Workspace $workspace -Name "syslog-local1" -Facility "local1" -CollectEmergency -CollectAlert -CollectCritical -CollectError -CollectWarning -CollectNotice -CollectDebug -CollectInformational

    # linux performance data source
    $linuxPerfDataSource = New-AzureRmOperationalInsightsLinuxPerformanceObjectDataSource -Workspace $workspace -Name "MemoryLinux" -ObjectName "Memory" -InstanceName * -CounterNames "Available bytes" -IntervalSeconds 10

    # customlog
    $customLogRawJson = '{"customLogName":"Validation_CL","description":"test","inputs":[{"location":{"fileSystemLocations":{"linuxFileTypeLogPaths":null,"windowsFileTypeLogPaths":["C:\\e2e\\Evan\\ArubaSECURITY\\*.log"]}},"recordDelimiter":{"regexDelimiter":{"pattern":"\\n","matchIndex":0}}}],"extractions":[{"extractionName":"TimeGenerated","extractionType":"DateTime","extractionProperties":{"dateTimeExtraction":{"regex":null,"joinStringRegex":null}}}]}'
    $customLogDataSource = New-AzureRmOperationalInsightsCustomLogDataSource -Workspace $workspace -CustomLogRawJson $customLogRawJson -Name "MyCustomLog"

}

<#
.SYNOPSIS
Validate that we can enable/disable singleton datasources
#>
function Test-ToggleSingletonDataSourceState
{
    $wsname = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $subId1 = "0b88dfdb-55b3-4fb0-b474-5b6dcbe6b2ef"
    $wslocation = Get-ProviderLocation

    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    # Create a workspace to house the data source
    $workspace = New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Force

    # enable/disable iislog collection
    Enable-AzureRmOperationalInsightsIISLogCollection -Workspace $workspace
    Disable-AzureRmOperationalInsightsIISLogCollection -Workspace $workspace

    # enable/disable customlog collection on linux
    Enable-AzureRmOperationalInsightsLinuxCustomLogCollection -Workspace $workspace
    Disable-AzureRmOperationalInsightsLinuxCustomLogCollection -Workspace $workspace

    # enable/disable linux perf collection
    Enable-AzureRmOperationalInsightsLinuxPerformanceCollection -Workspace $workspace
    Disable-AzureRmOperationalInsightsLinuxPerformanceCollection -Workspace $workspace

    # enable/disable syslog collection
    Enable-AzureRmOperationalInsightsLinuxSyslogCollection -Workspace $workspace
    Disable-AzureRmOperationalInsightsLinuxSyslogCollection -Workspace $workspace

}