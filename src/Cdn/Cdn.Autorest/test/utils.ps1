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
$script:cdnTestResourceGroupCreated = $false
$configurationFile = 'env.json'
if ($TestMode -eq 'live') {
    $configurationFile = 'localEnv.json'
}
if (Test-Path (Join-Path $PSScriptRoot $configurationFile)) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot $configurationFile) | ConvertFrom-Json
    $previousEnv.psobject.properties | ForEach-Object {
        if ($UsePreviousConfigForRecord -or $_.Name -in @('ClassicCdnProfileResourceId', 'EdgeActionResourceId')) {
            $env[$_.Name] = $_.Value
        }
    }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Certificate tests also require Secrets:Get access for the profile identity on their configured Key Vault.
    Write-Host -ForegroundColor Green "Start to import module."
    Import-Module -Name Az.FrontDoor
    Import-Module -Name Az.KeyVault

    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $subId = $env.SubscriptionId
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'westus'

    if ($env.ClassicCdnProfileResourceId -notmatch '^/subscriptions/([^/]+)/resourceGroups/([^/]+)/providers/Microsoft\.Cdn/profiles/([^/]+)$') {
        throw 'Configure ClassicCdnProfileResourceId with an existing Classic CDN profile before recording.'
    }
    if ($Matches[1] -ne $subId) {
        throw 'ClassicCdnProfileResourceId must belong to the current test subscription.'
    }
    $env.ClassicCdnResourceGroupName = $Matches[2]
    $env.ClassicCdnProfileName = $Matches[3]
    Get-AzCdnProfile -Name $env.ClassicCdnProfileName -ResourceGroupName $env.ClassicCdnResourceGroupName -ErrorAction Stop | Out-Null

    # If UsePreviousConfigForRecord is set, reuse existing resources from env.json
    # This allows re-running individual failed tests without recreating all resources
    if ($UsePreviousConfigForRecord -and $env.ResourceGroupName) {
        $rgExists = Get-AzResourceGroup -Name $env.ResourceGroupName -ErrorAction SilentlyContinue
        if ($rgExists) {
            Write-Host -ForegroundColor Green "Reusing previous environment from env.json (ResourceGroup: $($env.ResourceGroupName))"
            $profile = Get-AzFrontDoorCdnProfile -Name $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop
            if (-not $profile.IdentityType -or $profile.IdentityType -eq 'None') {
                Update-AzFrontDoorCdnProfile -Name $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -IdentityType SystemAssigned -ErrorAction Stop | Out-Null
            }
            return
        }
        # Resource group was deleted (e.g. by cleanupEnv), recreate with same names from env.json
        Write-Host -ForegroundColor Yellow "Resource group '$($env.ResourceGroupName)' no longer exists. Recreating with same names..."
        $resourceGroupName = $env.ResourceGroupName
        $frontDoorCdnProfileName = $env.FrontDoorCdnProfileName

        New-AzResourceGroup -Name $resourceGroupName -Location $env.location
        $script:cdnTestResourceGroupCreated = $true
        Write-Host -ForegroundColor Green "Recreated resource group: $resourceGroupName"

        New-AzFrontDoorCdnProfile -SkuName "Standard_AzureFrontDoor" -Name $frontDoorCdnProfileName -ResourceGroupName $resourceGroupName -Location Global -IdentityType SystemAssigned | Out-Null
        Write-Host -ForegroundColor Green "Recreated FrontDoor CDN profile: $frontDoorCdnProfileName"

        return
    }

    # Create the test resource group
    $resourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 4)
    Write-Host -ForegroundColor Green "Start to create test group $($resourceGroupName)"
    New-AzResourceGroup -Name $resourceGroupName -Location $env.location
    $script:cdnTestResourceGroupCreated = $true
    Write-Host -ForegroundColor Green "test group $($resourceGroupName) created"
    $env.Add("ResourceGroupName", $resourceGroupName)

    # Create FrontDoor CDN profile with Standard_AzureFrontDoor SKU
    $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6)
    Write-Host -ForegroundColor Green "Start to create Standard_AzureFrontDoor SKU profile: $($frontDoorCdnProfileName)"
    New-AzFrontDoorCdnProfile -SkuName "Standard_AzureFrontDoor" -Name $frontDoorCdnProfileName -ResourceGroupName $resourceGroupName -Location Global -IdentityType SystemAssigned | Out-Null
    $env.Add("FrontDoorCdnProfileName", $frontDoorCdnProfileName)
    Write-Host -ForegroundColor Green "Standard_AzureFrontDoor SKU profile created."

    Write-Host -ForegroundColor Green "Setup complete. Individual tests will create their own sub-resources."

    # Save env
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    if ($script:cdnTestResourceGroupCreated -and $env.ResourceGroupName -ne $env.ClassicCdnResourceGroupName) {
        Write-Host -ForegroundColor Green "Clean resources created for testing."
        Remove-AzResourceGroup -Name $env.ResourceGroupName -Force
    }
}
