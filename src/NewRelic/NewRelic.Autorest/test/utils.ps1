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
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    $resourceGroup = 'testgroup-joyer'
    $env.Add('resourceGroup', $resourceGroup)

    $region = 'eastus'
    $env.Add('region', $region)

    $testerEmail = 'v-jiaji@microsoft.com'
    $testerFirstName = 'Joyer'
    $testerLastName = 'Jin'

    $env.Add('testerEmail', $testerEmail)
    $env.Add('testerFirstName', $testerFirstName)
    $env.Add('testerLastName', $testerLastName)

    $testMonitorName = 'testMonitor-01'
    $env.Add('testMonitorName', $testMonitorName)

    $NewMonitorName = 'test-01' + (RandomString -allChars $false -len 6)
    $env.Add('NewMonitorName', $NewMonitorName)

    $testAppPlanName = 'joyertestplan'
    $testAppName = 'joyertestapp'
    $testVMName = 'joyertestmachine01'
    $env.Add('testVMName', $testVMName)
    #Plan Data $env.SubscriptionId = 272c26cb-7026-4b37-b190-7cb7b2abecb0
    # Step 1: Create test group
    Write-Host 'Start to create test resource group' $resourceGroup
    try {
        $null = Get-AzResourceGroup -Name $resourceGroup -ErrorAction Stop
        Write-Host 'Get created group, go ahead'
    } catch {
        # New-AzResourceGroup -Name $env.resourceGroup -Location $env.region
        Write-Error 'Please create related resources'
        throw
    }
    # Step 2: Create monitor
    $planDetails = "newrelic-pay-as-you-go-free-live@TIDgmz7xq9ge3py@PUBIDnewrelicinc1635200720692.newrelic_liftr_payg"
    $env.Add('planDetails', $planDetails)
    $billingCycle = "MONTHLY"
    $env.Add('billingCycle', $billingCycle)
    $usageType = 'PAYG'
    $env.Add('usageType', $usageType)

    # New-AzNewRelicMonitor -Name $env.testMonitorName -ResourceGroupName $env.resourceGroup -Location $env.region -PlanDataPlanDetail $env.planDetails -PlanDataBillingCycle $env.billingCycle -PlanDataUsageType $env.usageType -PlanDataEffectiveDate (Get-Date -DisplayHint DateTime) -UserInfoEmailAddress $env.testerEmail -UserInfoFirstName $env.testerFirstName -UserInfoLastName $env.testerLastName
    try {
        $null = Get-AzNewRelicMonitor -Name $env.testMonitorName -ResourceGroupName $env.resourceGroup -ErrorAction Stop
    }
    catch {
        Write-Error 'Please create a monitor firstly.'
        throw
    }
    
    # Write-Host 'create app service'
    # Step 2: Create an App Service plan
    # $null = New-AzAppServicePlan -ResourceGroupName $env.resourceGroup -Name $testAppPlanName -Location $env.region -Tier "Free"
    # Step 3: Create the web app
    # $testApp = New-AzWebApp -Name $testAppName -ResourceGroupName $env.resourceGroup -AppServicePlan $testAppPlanName
    # Step 4: Install extension New Relic .NET Agent
    try {
        $testApp = Get-AzWebApp -Name $testAppName -ResourceGroupName $env.resourceGroup -ErrorAction Stop
    }
    catch {
        Write-Error 'Please create a web app firstly.'
        throw
    }

    $env.Add('testApp', $testApp.Id)

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

