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
    
    # Load test environment variables from JSON file
    $envFile = 'localEnv.json'
    if ($TestMode -ne 'live') {
        $envFile = 'env.json'
    }
    
    $envFilePath = Join-Path $PSScriptRoot $envFile
    if (Test-Path -Path $envFilePath) {
        $envData = Get-Content $envFilePath | ConvertFrom-Json
        $envData.psobject.properties | ForEach-Object { 
            if (-not $env.Contains($_.Name)) {
                $env[$_.Name] = $_.Value 
            }
        }
    }
    
    # Create test resource group if it doesn't exist
    if ($env.resourceGroup -and $env.location) {
        Write-Host "Checking for resource group: $($env.resourceGroup)"
        $rg = Get-AzResourceGroup -Name $env.resourceGroup -ErrorAction SilentlyContinue
        if (-not $rg) {
            Write-Host "Creating resource group: $($env.resourceGroup) in location: $($env.location)"
            New-AzResourceGroup -Name $env.resourceGroup -Location $env.location | Out-Null
            Write-Host "Resource group created successfully"
        } else {
            Write-Host "Resource group already exists"
        }
    }
    
    # For any resources you created for test, you should add it to $env here.
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Optionally remove the resource group after tests
    # Uncomment the following lines if you want to auto-cleanup:
    # if ($env.resourceGroup) {
    #     Write-Host "Cleaning up resource group: $($env.resourceGroup)"
    #     Remove-AzResourceGroup -Name $env.resourceGroup -Force -AsJob | Out-Null
    # }
}

