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


    $LocalRulestackName = "azps-" + (RandomString -allChars $false -len 4)
    $PrefixListLocalRulestackName = "azps-" + (RandomString -allChars $false -len 4)
    $FqdnListLocalRulestack = "azps-" + (RandomString -allChars $false -len 4)
    $LocalRuleName = "azps-" + (RandomString -allChars $false -len 4)
    $CertificateObjectLocalRulestackName = "azps-" + (RandomString -allChars $false -len 4)

    $env.Add("LocalRulestackName", $LocalRulestackName)
    $env.Add("PrefixListLocalRulestackName", $PrefixListLocalRulestackName)
    $env.Add("FqdnListLocalRulestack", $FqdnListLocalRulestack)
    $env.Add("LocalRuleName", $LocalRuleName)
    $env.Add("CertificateObjectLocalRulestackName", $CertificateObjectLocalRulestackName)

    $env.Add("location", "eastus")

    # Create the test group
    write-host "start to create test group"
    $resourceGroup = "azps-testcase-pan"
    $env.Add("resourceGroup", $resourceGroup)

    # Need to create Managed Identity and copy the resourceid
    $managedIdentityId = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.resourceGroup)/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uami0524"
    $env.Add("managedIdentityId", $managedIdentityId)

    # Use mock environment, so we donnot run this cmdlet.
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

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

