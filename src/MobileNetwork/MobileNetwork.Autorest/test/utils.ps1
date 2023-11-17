function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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

    $testNetwork1 = "test-mn1"
    $testNetwork2 = "test-mn2"
    $testNetwork3 = "test-mn3"
    $testSite = "test-mn-site"
    $testSlice = "test-mn-slice"
    $testDataNetwork = "test-mn-datanetwork"
    $testSimGroup = "test-mn-simgroup"
    $testService = "test-mn-service"
    $testSimPolicy = "test-mn-simpolicy"
    $env.Add("testNetwork1", $testNetwork1)
    $env.Add("testNetwork2", $testNetwork2)
    $env.Add("testNetwork3", $testNetwork3)
    $env.Add("testSite", $testSite)
    $env.Add("testSlice", $testSlice)
    $env.Add("testDataNetwork", $testDataNetwork)
    $env.Add("testSimGroup", $testSimGroup)
    $env.Add("testService", $testService)
    $env.Add("testSimPolicy", $testSimPolicy)

    write-host "start to create test group"
    $env.Add("location", "eastus")
    $resourceGroup = "testgroup-mobilenetwork"
    $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    write-host "start to create Mobile Network env"
    New-AzMobileNetwork -Name $env.testNetwork2 -ResourceGroupName $env.resourceGroup -Location $env.location -PublicLandMobileNetworkIdentifierMcc 001 -PublicLandMobileNetworkIdentifierMnc 01
    New-AzMobileNetwork -Name $env.testNetwork3 -ResourceGroupName $env.resourceGroup -Location $env.location -PublicLandMobileNetworkIdentifierMcc 001 -PublicLandMobileNetworkIdentifierMnc 01

    New-AzMobileNetworkDataNetwork -MobileNetworkName $env.testNetwork2 -Name $env.testDataNetwork -ResourceGroupName $env.resourceGroup -Location $env.location
    
    $ServiceDataFlowTemplate = New-AzMobileNetworkServiceDataFlowTemplateObject -Direction "Bidirectional" -Protocol "255" -RemoteIPList "any" -TemplateName test-mn-flow-template
    $PccRule = New-AzMobileNetworkPccRuleConfigurationObject -RuleName test-mn-service-rule -RulePrecedence 0 -ServiceDataFlowTemplate $ServiceDataFlowTemplate -TrafficControl 'Enabled' -RuleQoPolicyPreemptionVulnerability 'Preemptable' -RuleQoPolicyPreemptionCapability 'NotPreempt' -RuleQoPolicyAllocationAndRetentionPriorityLevel 9 -RuleQoPolicyMaximumBitRateDownlink "1 Gbps" -RuleQoPolicyMaximumBitRateUplink "500 Mbps"
    New-AzMobileNetworkService -MobileNetworkName $env.testNetwork2 -Name $env.testService -ResourceGroupName $env.resourceGroup -Location $env.location -PccRule $PccRule -ServicePrecedence 0 -MaximumBitRateDownlink "1 Gbps" -MaximumBitRateUplink "500 Mbps" -ServiceQoPolicyAllocationAndRetentionPriorityLevel 9 -ServiceQoPolicyFiveQi 9 -ServiceQoPolicyPreemptionCapability 'MayPreempt' -ServiceQoPolicyPreemptionVulnerability 'Preemptable'

    New-AzMobileNetworkSlice -MobileNetworkName $env.testNetwork2 -ResourceGroupName $env.resourceGroup -SliceName $env.testSlice -Location $env.location -SnssaiSst 1 -SnssaiSd "1abcde"
    
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.resourceGroup
}

