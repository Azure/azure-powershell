function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'eastus'
    # For any resources you created for test, you should add it to $env here.
    $env.resourceGroup = 'test-rg-' + (RandomString -allChars $false -len 5)
    $env.tenantName00 = (RandomString -allChars $false -len 8) + '.onmicrosoft.com'
    $env.tenantName01 = (RandomString -allChars $false -len 8) + '.onmicrosoft.com'
    $env.tenantName02 = (RandomString -allChars $false -len 8) + '.onmicrosoft.com'

    # Create some resource for test.
    Write-Debug "Create resource group for test"
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    Write-Debug "Create ADB2CTenant for test."
    New-AzADB2CTenant -ResourceGroupName $env.resourceGroup -Name $env.tenantName00 -Location 'United States' -Sku Standard -CountryCode US -DisplayName $env.tenantName00
    New-AzADB2CTenant -ResourceGroupName $env.resourceGroup -Name $env.tenantName01 -Location 'United States' -Sku Standard -CountryCode US -DisplayName $env.tenantName01

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

