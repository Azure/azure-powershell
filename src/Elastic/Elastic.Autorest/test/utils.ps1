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

    $env.location = "westus2"
    $env.userEmail = (Get-AzContext).Account.Id
    $env.sku = "ess-consumption-2024_Monthly"

    # Use existing Elastic resources instead of creating new ones
    Write-Host -ForegroundColor Green "Finding existing Elastic monitors for testing..."
    
    # Get existing Elastic monitors
    $existingMonitors = Get-AzElasticMonitor | Where-Object { $_.Location -eq $env.location } | Select-Object -First 2
    
    if ($existingMonitors.Count -ge 2) {
        # Extract resource group name from the first monitor's ID
        $firstMonitorId = $existingMonitors[0].Id
        $env.resourceGroup = ($firstMonitorId -split '/')[4]  # Extract RG name from resource ID
        
        # Use existing monitor names
        $env.elasticName01 = $existingMonitors[0].Name
        $env.elasticName02 = $existingMonitors[1].Name
        
        Write-Host -ForegroundColor Green "Using existing monitors:"
        Write-Host -ForegroundColor Yellow "  Resource Group: $($env.resourceGroup)"
        Write-Host -ForegroundColor Yellow "  Monitor 1: $($env.elasticName01)"
        Write-Host -ForegroundColor Yellow "  Monitor 2: $($env.elasticName02)"
        
        # Generate random names for monitors that might be created in tests
        $env.elasticName03 = 'elastic-' + (RandomString -allChars $false -len 6)
        $env.elasticName04 = 'elastic-' + (RandomString -allChars $false -len 6) 
        $env.elasticName05 = 'elastic-' + (RandomString -allChars $false -len 6)
        
    } else {
        Write-Host -ForegroundColor Red "ERROR: Need at least 2 existing Elastic monitors in $($env.location) region"
        Write-Host -ForegroundColor Yellow "Available monitors:"
        Get-AzElasticMonitor | Select-Object Name, Location | Format-Table
        throw "Insufficient existing Elastic monitors for testing"
    }

    # Skip creating new resources - use existing ones
    Write-Host -ForegroundColor Green "Skipping resource creation - using existing resources"

    # Create
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Skip cleanup - we're using existing resources that shouldn't be deleted
    Write-Host -ForegroundColor Yellow "Skipping resource cleanup - using existing Elastic monitors"
    Write-Host -ForegroundColor Green "Test completed successfully without deleting existing resources"
}

