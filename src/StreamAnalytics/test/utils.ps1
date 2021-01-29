function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Import module Az.StreamAnalytics for create a job for test.
    # Import-Module -Name Az.StreamAnalytics
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.subscriptionId = (Get-AzContext).Subscription.Id
    $env.tenant = (Get-AzContext).Tenant.Id
    $env.location = 'eastus'
    # For any resources you created for test, you should add it to $env here.

    $env.resourceGroup = 'streamanalyticscluster-rg' + (RandomString -allChars $false -len 6)

    $env.cluster00 = 'sac-' + (RandomString -allChars $false -len 6)
    $env.cluster01 = 'sac-' + (RandomString -allChars $false -len 6)
    $env.cluster02 = 'sac-' + (RandomString -allChars $false -len 6)
    $env.cluster03 = 'sac-' + (RandomString -allChars $false -len 6)

    $env.job01 = 'job-' + (RandomString -allChars $false -len 6)
    $env.job02 = 'job-' + (RandomString -allChars $false -len 6)

    # Deploy resource
    Write-Host -ForegroundColor Green "Create resource group for test."
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location
    
    Write-Host -ForegroundColor Green "Create three stream analytics clusters for test"
    Write-Host -ForegroundColor Yellow "Deploying stream analytics cluster could take around an hour to complete. "
    New-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster00 -Location $env.location -SkuName "Default" -SkuCapacity 36
    New-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster01 -Location $env.location -SkuName "Default" -SkuCapacity 36
    New-AzStreamAnalyticsCluster -ResourceGroupName $env.resourceGroup -Name $env.cluster02 -Location $env.location -SkuName "Default" -SkuCapacity 36
    Write-Host -ForegroundColor Green "Create completed"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

