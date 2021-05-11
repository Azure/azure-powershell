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
    $env.resourceGroupName = "test-rg" + (RandomString -allChars $false -len 5)
    $env.location = "eastus"
    $env.containerGroupName = "bez-test-cg"
    $env.containerGroupName1 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.containerGroupName2 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.containerGroupName3 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.containerGroupName4 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.containerGroupName5 = "test-cg" + (RandomString -allChars $false -len 5)
    $env.containerInstanceName = "bez-test-ci"
    $env.image = "nginx"
    $env.osType = "Linux"
    $env.restartPolicy = "Never"
    $env.port1 = 8000
    $env.port2 = 8001

    # Create some resource for test.
    Write-Debug "Create resource group for test"
    New-AzResourceGroup -Name $env.resourceGroupName -Location $env.location

    Write-Debug "Create container group for test"
    $container = New-AzContainerInstanceObject -Name $env.containerInstanceName -Image $env.image
    New-AzContainerGroup -ResourceGroupName $env.resourceGroupName -Name $env.containerGroupName -Location $env.location -Container $container

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroupName
}

