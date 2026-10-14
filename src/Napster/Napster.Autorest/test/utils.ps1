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
    $env.ResourceGroupName = 'acctest0001'
    $env.ResourceName = 'napster-test1'
    $env.NewResourceName = 'napster-test3'
    $env.DeleteResourceName = 'napster-test2'
    $env.Location = "eastus2euap"
    $env.SubscriptionId = "61641157-140c-4b97-b365-30ff76d9f82e"
    $env.MarketplaceSubscriptionId = "09fffd7d-d000-4467-cc23-d82b97e9431d"
    $env.OfferDetailOfferId = "napster_companion_api"
    $env.OfferDetailPlanId = "napster_companion_api_feb_2026"
    $env.OfferDetailPlanName = "Pay As You Go"
    $env.OfferDetailPublisherId = "touchcastinc1655995956899"
    $env.OfferDetailTermId = "n7ja87drquhy"
    $env.OfferDetailTermUnit = "P1M"
    $env.PartnerPropertyApplication = "dsaf"
    $env.SingleSignOnPropertyType = "OpenId"
    $env.SingleSignOnPropertyState = "Initial"
    $env.SingleSignOnPropertyAadDomain = @("MicrosoftCustomerLed.onmicrosoft.com")
    $env.SingleSignOnPropertyUrl = "https://companion-api.napsterai.dev/admin/ms-auth"
    $env.UserEmailAddress = "yashikajain@microsoft.com"
    $env.UserFirstName = ""
    $env.UserLastName = ""
    $env.UserUpn = "yashikajain@microsoft.com"
    $env.SaaSResourceId = "/subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/Microsoft.SaaS/resources/a4fa84fc_dsafsa"
    $env.SaasGuid = "00000000-0000-0000-0000-000000000000"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

