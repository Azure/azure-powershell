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
    $env.location = 'westcentralus'
    $env.creatorLocation = 'eastus2'
    # For any resources you created for test, you should add it to $env here.
    $env.resourceGroup = 'maps-rg-' + (RandomString -allChars $false -len 6)

    $env.mapsName01 = 'maps'+(RandomString -allChars $false -len 6)
    $env.mapsName02 = 'maps'+(RandomString -allChars $false -len 6)
    $env.mapsName03 = 'maps'+(RandomString -allChars $false -len 6)

    $env.creatorName01 = 'creator'+(RandomString -allChars $false -len 6) 
    $env.creatorName02 = 'creator'+(RandomString -allChars $false -len 6) 
    $env.creatorName03 = 'creator'+(RandomString -allChars $false -len 6) 
    
    # Create resource group for test.
    Write-Host -ForegroundColor Green "Create resource group for test."
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    # Create resources for test.
    Write-Host -ForegroundColor Green "Create maps account for test"
    New-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName01 -SkuName S1 -Location $env.location
    New-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName02 -SkuName S1 -Location $env.location
    # New-AzMapsAccount -ResourceGroupName $env.resourceGroup -Name $env.mapsName03 -SkuName S1 -Location $env.location

    Write-Host -ForegroundColor Green "Create crearor for test"
    New-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName01 -Name $env.creatorName01 -Location $env.creatorLocation -StorageUnit 3
    New-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName02 -Name $env.creatorName02 -Location $env.creatorLocation -StorageUnit 3
    # New-AzMapsCreator -ResourceGroupName $env.resourceGroup -AccountName $env.mapsName03 -Name $env.creatorName03 -Location $env.creatorLocation -StorageUnit 3

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

