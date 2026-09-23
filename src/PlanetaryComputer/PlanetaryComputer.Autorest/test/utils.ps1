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

    # Use existing resource group and GeoCatalog for Get, Update, Delete tests
    $env.AddWithCache("ResourceGroupName", "internal-testing", $UsePreviousConfigForRecord)
    $env.AddWithCache("CatalogName", "PE-03-20-2", $UsePreviousConfigForRecord)
    $env.AddWithCache("Location", "centralus", $UsePreviousConfigForRecord)
    $env.AddWithCache("UserAssignedIdentityId", "/subscriptions/$($env.SubscriptionId)/resourcegroups/internal-testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/aopc-mi-fix-test", $UsePreviousConfigForRecord)

    # Resource group and catalog name for create test
    $newRgName = "pctestRg" + (RandomString -allChars $false -len 6)
    $env.AddWithCache("NewResourceGroupName", $newRgName, $UsePreviousConfigForRecord)

    $catalogName2 = "pccat" + (RandomString -allChars $false -len 6)
    $env.AddWithCache("CatalogName2", $catalogName2, $UsePreviousConfigForRecord)

    # Create resource group for the New (create) test
    Write-Host "Creating resource group $($env.NewResourceGroupName) for create test ..."
    New-AzResourceGroup -Name $env.NewResourceGroupName -Location $env.Location

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources created for testing (only the new RG)
    Write-Host "Cleaning up resource group $($env.NewResourceGroupName) ..."
    Remove-AzResourceGroup -Name $env.NewResourceGroupName
}

