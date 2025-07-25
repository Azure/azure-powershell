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
    
    # Connect-AzAccount -SubscriptionId 61641157-140c-4b97-b365-30ff76d9f82e -TenantId 888d76fa-54b2-4ced-8ee5-aac1585adee7
    Write-Host "Connected to test subscription"

    $env.SubscriptionId = (Get-AzContext).Subscription.Id 
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.ResourceGroupName = 'astro-joyer'
    $env.ResourceName = 'astro.pwsh.test'
    $env.Location = 'eastus'
    $env.MarketplaceSubscriptionId = '61641157-140c-4b97-b365-30ff76d9f82e'
    $env.OfferOffer = 'astro'
    $env.OfferPlan = 'astro-paygo'
    $env.OfferPublisher = 'astronomer1591719760654'
    $env.OfferPlanName = 'Monthly Pay-As-You-Go'
    $env.OfferTerm = 'gmz7xq9ge3py'
    $env.AadDomain = 'MicrosoftCustomerLed.onmicrosoft.com'
    $env.UserEmail = 'v-jiaji@microsoft.com'
    $env.UserFirstName = 'Joyer'
    $env.UserLastName = 'Jin'

    Write-Host 'Start to create test resource group' $env.ResourceGroupName
    try {
        Get-AzResourceGroup -Name $env.ResourceGroupName -ErrorAction Stop
        Write-Host 'Get created group'
    } catch {
        New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.region
    }

    try {
        Get-AzAstroOrganization -ResourceGroupName $env.ResourceGroupName -Name UT.1.test -ErrorAction Stop
        Write-Host 'Get created organization'
    } catch {
        New-AzAstroOrganization -Name UT.1.test -ResourceGroupName $env.ResourceGroupName -Location $env.Location -MarketplaceSubscriptionId $env.MarketplaceSubscriptionId -OfferDetailOfferId $env.OfferOffer -OfferDetailPlanId $env.OfferPlan -OfferDetailPublisherId $env.OfferPublisher -OfferDetailPlanName $env.OfferPlanName -OfferDetailTermId $env.OfferTerm -OfferDetailTermUnit Monthly -UserEmailAddress $env.UserEmail -UserFirstName $env.UserFirstName -UserLastName $env.UserLastName -PartnerOrganizationPropertyWorkspaceName qqq -PartnerOrganizationPropertyOrganizationName www -SingleSignOnPropertyAadDomain $env.AadDomain
    }

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

