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
    
    # Load environment from JSON file first
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    
    $envFilePath = Join-Path $PSScriptRoot $envFile
    if (Test-Path $envFilePath) {
        $envData = Get-Content $envFilePath | ConvertFrom-Json
        $envData.psobject.properties | ForEach-Object { 
            $env[$_.Name] = $_.Value 
        }
        Write-Host "Loaded environment from $envFile"
    } else {
        Write-Warning "Environment file $envFile not found at $envFilePath"
        return
    }
    
    # Set up resource group for testing
    $resourceGroupName = $env.resourceGroup
    $location = $env.location
    
    if ([string]::IsNullOrEmpty($resourceGroupName)) {
        Write-Error "Resource group name is not defined in environment configuration"
        return
    }
    
    if ([string]::IsNullOrEmpty($location)) {
        Write-Error "Location is not defined in environment configuration"
        return
    }
    
    # Create resource group if it doesn't exist
    $rg = Get-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue
    if (-not $rg) {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        Write-Host "Created resource group: $resourceGroupName in $location"
    }
    
    # Create test sites for the test scenarios
    CreateTestSites
    
    # Save the updated environment
    set-content -Path $envFilePath -Value (ConvertTo-Json $env)
}

function CreateTestSites() {
    # Validate required environment variables
    if ([string]::IsNullOrEmpty($env.resourceGroup)) {
        Write-Error "Resource group name not defined in environment"
        return
    }
    
    if ([string]::IsNullOrEmpty($env.SubscriptionId)) {
        Write-Error "Subscription ID not defined in environment"
        return
    }
    
    # Create primary test site
    if (-not [string]::IsNullOrEmpty($env.siteName01)) {
        $site1 = Get-AzSite -Name $env.siteName01 -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
        if (-not $site1) {
            Write-Host "Creating test site: $($env.siteName01)"
            New-AzSite -SiteName $env.siteName01 -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -DisplayName $env.displayName01 -Description $env.description01 -Country $env.country -PostalCode $env.postalCode
        }
    }
    
    # Create secondary test site  
    if (-not [string]::IsNullOrEmpty($env.siteName02)) {
        $site2 = Get-AzSite -Name $env.siteName02 -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
        if (-not $site2) {
            Write-Host "Creating test site: $($env.siteName02)"
            New-AzSite -SiteName $env.siteName02 -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -DisplayName $env.displayName02
        }
    }
}

function cleanupEnv() {
    # Clean up test resources
    Write-Host "Cleaning up test sites..."
    
    # Remove test sites
    @($env.siteName01, $env.siteName02, $env.siteName03) | ForEach-Object {
        $siteName = $_
        if ([string]::IsNullOrEmpty($siteName)) {
            Write-Verbose "Skipping empty site name"
            return
        }
        
        try {
            $site = Get-AzSite -Name $siteName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
            if ($site) {
                Remove-AzSite -Name $siteName -ResourceGroupName $env.resourceGroup -SubscriptionId $env.SubscriptionId
                Write-Host "Removed site: $siteName"
            }
        }
        catch {
            Write-Warning "Failed to remove site $siteName`: $($_.Exception.Message)"
        }
    }
    
    # Optionally remove the resource group (uncomment if desired)
    # Remove-AzResourceGroup -Name $env.resourceGroup -Force -AsJob
}

