function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.Location = "westus2"
    $env.resourceGroup = 'AMCS-TEST'
    $env.resourceGroup2 = 'AMCS-TEST2'
    $env.testCollectionRule1 = 'testCollectionRule1'
    $env.testCollectionRule2 = 'testCollectionRule2'
    $env.testCollectionRule3 = 'testCollectionRule3'
    $env.testCollectionRule4 = 'testCollectionRule4'

    $env.testCollectionEndpoint = 'testCollectionEndpoint'
    $env.testCollectionEndpoint2 = 'testCollectionEndpoint2'

    $env.testAssociation1 = 'testCollectionRule-association1'
    $env.testAssociation2 = 'testCollectionRule-association2'
    $env.testEndpointAssociation = 'configurationAccessEndpoint'

    Write-Host "Start to create test resource group" $env.resourceGroup
    try {
        Get-AzResourceGroup -Name $env.resourceGroup -ErrorAction Stop
        Write-Host "Get created group"
    } catch {
        New-AzResourceGroup -Name $env.resourceGroup -Location $env.Location
    }
    Write-Host "Start to create test resource group" $env.resourceGroup2
    try {
        Get-AzResourceGroup -Name $env.resourceGroup2 -ErrorAction Stop
        Write-Host "Get created group"
    } catch {
        New-AzResourceGroup -Name $env.resourceGroup2 -Location $env.Location
    }

    $workspaceName = 'amcs-logtest-ws'
    Write-Host "Start to create test workspace" $workspaceName
    try {
        $workspace = Get-AzOperationalInsightsWorkspace -Name $workspaceName -ResourceGroupName $env.resourceGroup2 -ErrorAction Stop
        Write-Host "Get created workspace"
    } catch {
        $workspace = New-AzOperationalInsightsWorkspace -Location $env.Location -Name $workspaceName -ResourceGroupName $env.resourceGroup2
    }
    $null = $env.Add("workspaceId", $workspace.ResourceId)
    Write-Host "Workspace ID:" $workspace.ResourceId

    Write-Host "Start to create test VM"
    $vmname = "testAMCSvm"
    $user = "amcsuser"
    $password = RandomString -allChars $True -len 13
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword)
    try {
        Write-Host "Get created VM"
        $VM = Get-AzVM -ResourceGroupName $env.resourceGroup -Name $vmname -ErrorAction Stop
    }
    catch {
        Write-Host "Create test VM"
        $VM = New-AzVM -ResourceGroupName $env.resourceGroup -Location $env.Location -Name $vmname -Credential $cred
    }
    $env.VMId = $VM.Id

    Write-Host "Start to create test data"
    Write-Host "Create data collection rules"
    $null = New-AzDataCollectionRule -Name $env.testCollectionRule1 -ResourceGroupName $env.resourceGroup -JsonFilePath (Join-Path $PSScriptRoot '.\jsonfile\ruleTest1.json')

    $dataflow = New-AzDataFlowObject -Stream Microsoft-Perf,Microsoft-Syslog -Destination centralWorkspace
    $performanceCounter1 = New-AzPerfCounterDataSourceObject -CounterSpecifier "\\Processor(_Total)\\% Processor Time","\\Memory\\Committed Bytes","\\LogicalDisk(_Total)\\Free Megabytes","\\PhysicalDisk(_Total)\\Avg. Disk Queue Length" -Name cloudTeamCoreCounters -SamplingFrequencyInSecond 15 -Stream Microsoft-Perf
    $performanceCounter2 = New-AzPerfCounterDataSourceObject -CounterSpecifier "\\Process(_Total)\\Thread Count" -Name appTeamExtraCounters -SamplingFrequencyInSecond 30 -Stream Microsoft-Perf
    $windowsEvent1 = New-AzWindowsEventLogDataSourceObject -Name cloudSecurityTeamEvents -Stream Microsoft-WindowsEvent -XPathQuery "Security!*"
    $windowsEvent2 = New-AzWindowsEventLogDataSourceObject -Name appTeam1AppEvents -Stream Microsoft-WindowsEvent -XPathQuery "System![System[(Level = 1 or Level = 2 or Level = 3)]]", "Application!*[System[(Level = 1 or Level = 2 or Level = 3)]]"
    $logAnalytics = New-AzLogAnalyticsDestinationObject -Name centralWorkspace -WorkspaceResourceId $env.workspaceId
    $cronlog = New-AzSyslogDataSourceObject -FacilityName cron -LogLevel Debug,Critical,Emergency -Name cronSyslog -Stream Microsoft-Syslog
    $syslog = New-AzSyslogDataSourceObject -FacilityName syslog -LogLevel Alert,Critical,Emergency -Name syslogBase -Stream Microsoft-Syslog
    $rule = New-AzDataCollectionRule -Name $env.testCollectionRule2 -ResourceGroupName $env.resourceGroup2 -Location eastus -DataFlow $dataflow -DataSourcePerformanceCounter $performanceCounter1,$performanceCounter2 -DataSourceWindowsEventLog $windowsEvent1,$windowsEvent2 -DestinationLogAnalytic $logAnalytics -DataSourceSyslog $cronlog,$syslog
    $env.ruleID = $rule.Id

    Write-Host "Create data collection endpoints"
    $endpoint = New-AzDataCollectionEndpoint -Name $env.testCollectionEndpoint -ResourceGroupName $env.resourceGroup -Location $env.Location -NetworkAclsPublicNetworkAccess Enabled
    $null = New-AzDataCollectionEndpoint -Name $env.testCollectionEndpoint2 -ResourceGroupName $env.resourceGroup2 -JsonFilePath (Join-Path $PSScriptRoot '.\jsonfile\endpointTest1.json')
    $env.endpointId = $endpoint.Id

    Write-Host "Create data collection associations"
    $null = New-AzDataCollectionRuleAssociation -AssociationName $env.testEndpointAssociation -ResourceUri $env.VMId -DataCollectionEndpointId $env.endpointId
    $null = New-AzDataCollectionRuleAssociation -AssociationName $env.testAssociation2 -ResourceUri $env.VMId -DataCollectionRuleId $env.ruleID

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzDataCollectionRuleAssociation -AssociationName $env.testEndpointAssociation -ResourceUri $env.VMId
    Remove-AzDataCollectionRuleAssociation -AssociationName $env.testAssociation2 -ResourceUri $env.VMId
    Remove-AzDataCollectionEndpoint -Name $env.testCollectionEndpoint -ResourceGroupName $env.resourceGroup
    Remove-AzDataCollectionRule -ResourceGroupName $env.resourceGroup -Name $env.testCollectionRule1
    Remove-AzDataCollectionRule -ResourceGroupName $env.resourceGroup2 -Name $env.testCollectionRule2
}

