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
    # Need New-AzApplicationInsights to create app insights. The app insights deployed template cannot be export in the azure portal.
    # Check whether the Az.ApplicationInsights module been installed in local test environment.
    $appInsightsModule = Get-Module -Name Az.ApplicationInsights -ListAvailable
    if ($null -eq $appInsightsModule)
    {
        Write-Host -ForegroundColor Yellow "The Az.ApplicationInsights module not found. Please install it. Test script dependent Az.ApplicationInsights module."
    }
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'westus2'
    $env.geoLocation01 = 'emea-nl-ams-azr'
    $env.geoLocation02 = 'us-ca-sjc-azr'
    $env.geoLocation03 = 'emea-ru-msa-edge'
    $env.geoLocation04 = 'emea-se-sto-edge'
    $standardWebTest01 = 'standardwebtest-' + (RandomString -allChars $false -len 6) + '-pwsh'
    $env.AddWithCache("standardWebTest01", $standardWebTest01, $UsePreviousConfigForRecord)
    $standardWebTest02 = 'standardwebtest-' + (RandomString -allChars $false -len 6) + '-pwsh'
    $env.AddWithCache("standardWebTest02", $standardWebTest02, $UsePreviousConfigForRecord)
    $basicWebTest03 = 'basicwebtest-' + (RandomString -allChars $false -len 6) + '-pwsh'
    $env.AddWithCache("basicWebTest03", $basicWebTest03, $UsePreviousConfigForRecord)
    $basicWebTest04 = 'basicwebtest-' + (RandomString -allChars $false -len 6) + '-pwsh'
    $env.AddWithCache("basicWebTest04", $basicWebTest04, $UsePreviousConfigForRecord)
    # Create resource group for test.
    $resourceGroupName = 'appInsights-' + (RandomString -allChars $false -len 6) + '-test'
    $env.AddWithCache("resourceGroup", $resourceGroupName, $UsePreviousConfigForRecord)
    Write-Host -ForegroundColor Green 'Start creating Resource Group for test...'
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location
    Write-Host -ForegroundColor Green 'Resource Group created successfully.'

    # Create application insights for test
    $appInsightsName01 = 'appInsights-' + (RandomString -allChars $false -len 6) + '-pwsh'
    $env.AddWithCache("appInsights01", $appInsightsName01, $UsePreviousConfigForRecord)
    $appInsightsName02 = 'appInsights-' + (RandomString -allChars $false -len 6) + '-pwsh'
    $env.AddWithCache("appInsights02", $appInsightsName02, $UsePreviousConfigForRecord)
    Write-Host -ForegroundColor Green 'Start creating application insights for test...'
    $appInsights01 = New-AzApplicationInsights -ResourceGroupName $env.resourceGroup -Name $env.appInsights01 -Location $env.location
    $appInsights02 = New-AzApplicationInsights -ResourceGroupName $env.resourceGroup -Name $env.appInsights02 -Location $env.location
    $env.appInsights01Id = $appInsights01.Id
    $env.appInsights02Id = $appInsights02.Id
    Write-Host -ForegroundColor Green 'application insights created successfully.'

    # Create web test for test
    Write-Host -ForegroundColor Green 'Start creating standard web test for test...'
    $geoLocation = @()
    $geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location $env.geoLocation01
    $geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location $env.geoLocation02
    New-AzApplicationInsightsWebTest -ResourceGroup $env.resourceGroup -Name $env.standardWebTest01 -Location $env.location `
    -Tag @{"hidden-link:$($env.appInsights01Id)" = "Resource"} `
    -RequestUrl "https://learn.microsoft.com/" -RequestHttpVerb "GET" -TestName $env.standardWebTest01 `
    -RuleExpectedHttpStatusCode 200 -Frequency 300 -Enabled -Timeout 120 -Kind 'standard' -RetryEnabled -GeoLocation $geoLocation
    Write-Host -ForegroundColor Green 'standard web test created successfully.'

    #Variables for application insights test
    $component1 = "component" + (RandomString -allChars $false -len 6)
    $env.AddWithCache("component1", $component1, $UsePreviousConfigForRecord)
    $component2 = "component" + (RandomString -allChars $false -len 6)
    $env.AddWithCache("component2", $component2, $UsePreviousConfigForRecord)

    $env.workbookTemplate01 = '23eb2aa1-0cf5-4f1d-b733-7ccb0ecec467'
    $env.workbook01 = "7f066122-885c-489b-b5f7-fa594c2775e5"
    $env.myWorkbook01 = "f48d5ba6-9da7-4dd2-aed4-71edd6e5e517"
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}
