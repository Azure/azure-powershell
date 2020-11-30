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
    # For any resources you created for test, you should add it to $env here.
    $env.location = 'eastus'
    # Generate some random strings for use in the test.
    $env.rstr1 = RandomString -allChars $false -len 6
    $env.rstr2 = RandomString -allChars $false -len 6
    $env.rstr3 = RandomString -allChars $false -len 6

    $env.wis01 = 'wis-' + (RandomString -allChars $false -len 6)
    $env.wis02 = 'wis-' + (RandomString -allChars $false -len 6)
    $env.wis03 = 'wis-' + (RandomString -allChars $false -len 6)
    $env.wis04 = 'wis-' + (RandomString -allChars $false -len 6)

    # Create the test group
    Write-Host -ForegroundColor Green "start to create test group"
    $env.resourceGroup = 'wis-' + $env.rstr1 + '-test'
    New-AzResourceGroup -Name $env.resourceGroup -Location eastus
    Write-Host -ForegroundColor Green "----------------------------"
    
    Write-Host -ForegroundColor Green "Creating the windows iot service for test..."
    New-AzWindowsIotServicesDevice -Name $env.wis01 -ResourceGroupName $env.resourceGroup -Location eastus -Quantity 10 -BillingDomainName 'microsoft.onmicrosoft.com' -AdminDomainName 'microsoft.onmicrosoft.com'
    New-AzWindowsIotServicesDevice -Name $env.wis02 -ResourceGroupName $env.resourceGroup -Location eastus -Quantity 10 -BillingDomainName 'microsoft.onmicrosoft.com' -AdminDomainName 'microsoft.onmicrosoft.com'
    Write-Host -ForegroundColor Green "Create completed"
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

