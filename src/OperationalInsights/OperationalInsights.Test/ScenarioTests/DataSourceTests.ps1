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

    New-AzResourceGroup -Name $rgname -Location $wslocation -Force

    # Create a workspace to house the data sources
    $workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku premium -Force

    # Create a data source
    $dataSource = New-AzOperationalInsightsAzureActivityLogDataSource -Workspace $workspace -Name $dsName -SubscriptionId $subId1
    Assert-AreEqual $dsName $dataSource.Name
    Assert-NotNull $dataSource.ResourceId
    Assert-AreEqual $rgname $dataSource.ResourceGroupName
    Assert-AreEqual $wsname $dataSource.WorkspaceName
    Assert-AreEqual $subId1 $dataSource.Properties.SubscriptionId
    Assert-AreEqual "AzureActivityLog" $dataSource.Kind

    # Get the data source that was created
    $dataSource = Get-AzOperationalInsightsDataSource -Workspace $workspace -Name $dsName
    Assert-AreEqual $dsName $dataSource.Name
    Assert-NotNull $dataSource.ResourceId
    Assert-AreEqual $rgname $dataSource.ResourceGroupName
    Assert-AreEqual $wsname $dataSource.WorkspaceName
    Assert-AreEqual $subId1 $dataSource.Properties.SubscriptionId
    Assert-AreEqual "AzureActivityLog" $dataSource.Kind

    # Create a second data source for list testing, also cover the alias.
    $daNametwo = Get-ResourceName
    $dataSource = New-AzOperationalInsightsAzureAuditDataSource -Workspace $workspace -Name $daNametwo -SubscriptionId $subId2

    # List the data source in the workspace (both param sets)
    $dataSources = Get-AzOperationalInsightsDataSource -Workspace $workspace -Kind AzureActivityLog
    Assert-AreEqual 2 $dataSources.Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $dsName}).Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $daNametwo}).Count

    $dataSources = Get-AzOperationalInsightsDataSource -ResourceGroupName $rgname -WorkspaceName $wsname -Kind AzureActivityLog
    Assert-AreEqual 2 $dataSources.Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $dsName}).Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $daNametwo}).Count

    # Delete one of the data sources
    Remove-AzOperationalInsightsDataSource -Workspace $workspace -Name $daNametwo -Force
    $dataSources = Get-AzOperationalInsightsDataSource -Workspace $workspace -Kind AzureActivityLog
    Assert-AreEqual 1 $dataSources.Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $dsName}).Count
    Assert-AreEqual 0 ($dataSources | Where {$_.Name -eq $daNametwo}).Count

    # Perform an update on the data source
    $dataSource = $dataSources[0]
    $dataSource.Properties.SubscriptionId = $subId2
    $dataSource = Set-AzOperationalInsightsDataSource -DataSource $dataSource
    Assert-AreEqual "AzureActivityLog" $dataSource.Kind
    Assert-AreEqual $subId2 $dataSource.Properties.SubscriptionId

    # Delete the remaining data source via piping
    Remove-AzOperationalInsightsDataSource -Workspace $workspace -Name $dsName -Force
    $dataSources = Get-AzOperationalInsightsDataSource -Workspace $workspace -Kind AzureActivityLog
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

    New-AzResourceGroup -Name $rgname -Location $wslocation -Force

    Assert-ThrowsContains { New-AzOperationalInsightsAzureActivityLogDataSource -ResourceGroupName $rgname -WorkspaceName $wsname -Name $dsName -SubscriptionId $subId1 } "NotFound"
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
    $subId2 = "aaaadfdb-55b3-4fb0-b474-5b6dcbe6aaaa"
    $wslocation = Get-ProviderLocation

    New-AzResourceGroup -Name $rgname -Location $wslocation -Force

    # Create a workspace to house the data source
    $workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku premium -Force

    # AzureActivityLog data source
    $auditLogDataSource = New-AzOperationalInsightsAzureActivityLogDataSource -Workspace $workspace -Name "myAuditLog" -SubscriptionId $subId1

    # windows event data source
    $windowsEventDataSource = New-AzOperationalInsightsWindowsEventDataSource -Workspace $workspace -Name Application -EventLogName "Application" -CollectErrors -CollectWarnings -CollectInformation

    # windows performance data source
    $windowsPerfDataSource = New-AzOperationalInsightsWindowsPerformanceCounterDataSource -Workspace $workspace -Name "processorPerf" -ObjectName Processor -InstanceName * -CounterName "% Processor Time" -IntervalSeconds 10 -UseLegacyCollector

    # linux syslog data source
    $syslogDataSource = New-AzOperationalInsightsLinuxSyslogDataSource -Workspace $workspace -Name "syslog-local1" -Facility "local1" -CollectEmergency -CollectAlert -CollectCritical -CollectError -CollectWarning -CollectNotice -CollectDebug -CollectInformational

    # linux performance data source
    $linuxPerfDataSource = New-AzOperationalInsightsLinuxPerformanceObjectDataSource -Workspace $workspace -Name "MemoryLinux" -ObjectName "Memory" -InstanceName * -CounterNames "Available bytes" -IntervalSeconds 10

    # customlog, regex string
    $customLogRawJson = '{"customLogName":"Validation_CL","description":"test","inputs":[{"location":{"fileSystemLocations":{"linuxFileTypeLogPaths":null,"windowsFileTypeLogPaths":["C:\\e2e\\Evan\\ArubaSECURITY\\*.log"]}},"recordDelimiter":{"regexDelimiter":{"pattern":"\\n","matchIndex":0}}}],"extractions":[{"extractionName":"TimeGenerated","extractionType":"DateTime","extractionProperties":{"dateTimeExtraction":{"regex":"((\\d{2})|(\\d{4}))-([0-1]\\d)-(([0-3]\\d)|(\\d))\\s((\\d)|([0-1]\\d)|(2[0-4])):[0-5][0-9]:[0-5][0-9]","joinStringRegex":null}}}]}'
    $customLogDataSource = New-AzOperationalInsightsCustomLogDataSource -Workspace $workspace -CustomLogRawJson $customLogRawJson -Name "MyCustomLog"
	
	# customlog, regex null
    $customLogRawJson1 = '{"customLogName":"Validation_CL1","description":"test","inputs":[{"location":{"fileSystemLocations":{"linuxFileTypeLogPaths":null,"windowsFileTypeLogPaths":["C:\\e2e\\Evan\\ArubaSECURITY\\*.log"]}},"recordDelimiter":{"regexDelimiter":{"pattern":"\\n","matchIndex":0}}}],"extractions":[{"extractionName":"TimeGenerated","extractionType":"DateTime","extractionProperties":{"dateTimeExtraction":{"regex":null,"joinStringRegex":null}}}]}'
    $customLogDataSource1 = New-AzOperationalInsightsCustomLogDataSource -Workspace $workspace -CustomLogRawJson $customLogRawJson1 -Name "MyCustomLog1"
	

    # customlog
    $customLogRawJson2 = '{"customLogName":"Validation_CL2","description":"test","inputs":[{"location":{"fileSystemLocations":{"linuxFileTypeLogPaths":null,"windowsFileTypeLogPaths":["C:\\e2e\\Evan\\ArubaSECURITY\\*.log"]}},"recordDelimiter":{"regexDelimiter":{"pattern":"\\n","matchIndex":0}}}],"extractions":[{"extractionName":"TimeGenerated","extractionType":"DateTime","extractionProperties":{"dateTimeExtraction":{"regex":[{"matchIndex":0,"numberdGroup":null,"pattern":"((\\d{2})|(\\d{4}))-([0-1]\\d)-(([0-3]\\d)|(\\d))\\s((\\d)|([0-1]\\d)|(2[0-4])):[0-5][0-9]:[0-5][0-9]"}],"joinStringRegex":null}}}]}'
    $customLogDataSource2 = New-AzOperationalInsightsCustomLogDataSource -Workspace $workspace -CustomLogRawJson $customLogRawJson2 -Name "MyCustomLog2"

    # ApplicationInsights data source
    $applicationInsightsDataSource1 = New-AzOperationalInsightsApplicationInsightsDataSource -Workspace $workspace -ApplicationSubscriptionId $subId1 -ApplicationResourceGroupName $rgname -ApplicationName "ai-app"
    Assert-NotNull $applicationInsightsDataSource1
    Assert-AreEqual "subscriptions/$subId1/resourceGroups/$rgname/providers/microsoft.insights/components/ai-app" $applicationInsightsDataSource1.Name 
    Assert-AreEqual "ApplicationInsights" $applicationInsightsDataSource1.Kind 
    Assert-AreEqual $rgname $applicationInsightsDataSource1.ResourceGroupName

    # ApplicationInsights data source by application resourceId 
    $applicationInsightsDataSource2 = New-AzOperationalInsightsApplicationInsightsDataSource -Workspace $workspace -ApplicationResourceId "/subscriptions/$subId2/resourceGroups/$rgname/providers/microsoft.insights/components/ai-app2"
    Assert-NotNull $applicationInsightsDataSource2
    Assert-AreEqual "subscriptions/$subId2/resourceGroups/$rgname/providers/microsoft.insights/components/ai-app2" $applicationInsightsDataSource2.Name 
    Assert-AreEqual "ApplicationInsights" $applicationInsightsDataSource2.Kind 
    Assert-AreEqual $rgname $applicationInsightsDataSource2.ResourceGroupName
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

    New-AzResourceGroup -Name $rgname -Location $wslocation -Force

    # Create a workspace to house the data source
    $workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Sku premium -Force

    # enable/disable iislog collection
    Enable-AzOperationalInsightsIISLogCollection -Workspace $workspace
    Disable-AzOperationalInsightsIISLogCollection -Workspace $workspace

    # enable/disable customlog collection on linux
    Enable-AzOperationalInsightsLinuxCustomLogCollection -Workspace $workspace
    Disable-AzOperationalInsightsLinuxCustomLogCollection -Workspace $workspace

    # enable/disable linux perf collection
    Enable-AzOperationalInsightsLinuxPerformanceCollection -Workspace $workspace
    Disable-AzOperationalInsightsLinuxPerformanceCollection -Workspace $workspace

    # enable/disable syslog collection
    Enable-AzOperationalInsightsLinuxSyslogCollection -Workspace $workspace
    Disable-AzOperationalInsightsLinuxSyslogCollection -Workspace $workspace

}
