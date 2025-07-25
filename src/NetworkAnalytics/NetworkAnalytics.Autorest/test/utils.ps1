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
    $env.Add("DataProductName", "dataproduct1")
    $env.Add("DataProductNameForMaxSet", "dataproduct2")
    $env.Add("Product", "MCC")
    $env.Add("MajorVersion", "2.0.0")
    $env.Add("Publisher", "Microsoft")
    $env.Add("Location", "southcentralus")
    $env.Add("ResourceGroupName", "powershell-test")

    # Default Settings
    $env.Add("PurviewAccount", "/subscriptions/subscriptionId/resourceGroups/aw8-compute-resgrp/providers/Microsoft.Purview/accounts/AOI-Test-Instance")
    $env.Add("PurviewCollection", "8m7kmz")
    $env.Add("Redundancy", "Disabled")
    $env.Add("CurrentMinorVersion", "2.0.0")
    #$env.Add("Tag", $null )
    $env.Add("Owner", @("testuser1@microsoft.com","testuser2@microsoft.com"))
    $env.Add("CustomerEncryptionKeyName", "testadx")
    $env.Add("CustomerEncryptionKeyVaultUri", "https://testkv.vault.azure.net")
    $env.Add("CustomerEncryptionKeyVersion", "6adfebea181a443b90cc89362d5888b5")
    $env.Add("CustomerManagedKeyEncryptionEnabled", "Disabled")

    $env.Add("PublicNetworkAccess", "Enabled")
    $env.Add("PrivateLinksEnabled", "Disabled")
    #$env.Add("NetworkaclVirtualNetworkRule", $null)
    #$env.Add("NetworkaclIPRule", $null)
    $env.Add("NetworkaclAllowedQueryIPRangeList", @("1.1.1.1","2.2.2.2"))
    $env.Add("NetworkaclDefaultAction", "Allow")
    $env.Add("IdentityType", "UserAssigned")
    #$env.Add("IdentityUserAssignedIdentity",$null)
    $env.Add("RoleId", " ")
    $env.Add("Role", "Reader")
    $env.Add("PrincipalType", "user")
    $env.Add("DataTypeScope", "dataproduct1")
    $env.Add("RoleAssignmentId","confc9uee8dm")

    $env.Add("UserOnePrincipalId","testuser1@microsoft.com")
    $env.Add("UserOneName", "Test User1")
    $env.Add("UserTwoPrincipalId","testuser2@microsoft.com")
    $env.Add("UserTwoName", "Test User2")

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

