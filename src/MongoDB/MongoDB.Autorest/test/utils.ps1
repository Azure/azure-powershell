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
    $env.ResourceGroupName = 'ajaykumar-rg'
    $env.ResourceName = 'MongoDBV2-11July-5'
    $env.NewResourceName = 'MongoDBV2-11July-6'
    $env.PartnerPropertyOrganizationName = 'MongoDBPortalTest'
    $env.Location = "East US 2"
    $env.SubscriptionId = "cbdb67be-e103-4770-a797-2a2fa42eb6f3"
    $env.MarketplaceSubscriptionId = "cbdb67be-e103-4770-a797-2a2fa42eb6f3"
    $env.OfferDetailOfferId = "mongodb_atlas_azure_native_prod"
    $env.OfferDetailPlanId = "private_plan"
    $env.OfferDetailPlanName = "Pay as You Go (Free) (Private)"
    $env.OfferDetailPublisherId = "mongodb"
    $env.OfferDetailTermId = "gmz7xq9ge3py"
    $env.OfferDetailTermUnit = "P1M"
    $env.UserEmailAddress = "ajaykumar@microsoft.com"
    $env.UserFirstName = "Ajay" 
    $env.UserLastName = "Kumar"
    $env.UserUpn = "ajaykumar@microsoft.com"
    $env.DeleteResourceName = "TestResource04July2025"
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

