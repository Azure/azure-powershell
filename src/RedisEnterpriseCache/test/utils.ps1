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
    $env.ClusterName  = 'ps-cache-test1-' + (RandomString -allChars $false -len 8)
    $env.ClusterName2 = 'ps-cache-test2-' + (RandomString -allChars $false -len 8)
    $env.ResourceGroupName = 'ps-redisenterprise-rg-' + (RandomString -allChars $false -len 8)
    $env.Location = 'East US'
    New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.Location | Out-Null

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroupName | Out-Null
}

