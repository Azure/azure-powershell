. ("$PSScriptRoot\helper.ps1")
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
    #Generate some strings for use in the test.
    $location = 'eastus'
    $rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr02 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $null = $env.Add('Location', $location)


    # Create test resource group.
    $resourceGroupGet = 'lucas-test-getcmd'
    $resourceGroup = 'lucas-test'
    Write-Host -ForegroundColor Green "Start to creating resource group for test..."
    #New-AzResourceGroup -Name $resourceGroup -Location $location
    #New-AzResourceGroup -Name $resourceGroupGet -Location $location  
    $null = $env.Add('ResourceGroupGet', $resourceGroupGet)
    $null = $env.Add('ResourceGroup', $resourceGroup)
    Write-Host -ForegroundColor Green "Resource group created successfully."
    # For any resources you created for test, you should add it to $env here.

    # create mariadb for test  
    Write-Host -ForegroundColor Green "Start to creating mariadb for test..."
    #Write-Host -ForegroundColor Green "mariadb name: $rstr01"
    #Write-Host -ForegroundColor Green "mariadb name: $rstr02"
    $mariaDbParam01 = @{Name=$rstr01; SkuName='B_Gen5_1'}
    $mariaDbParam02 = @{Name=$rstr02; SkuName='B_Gen5_1'}
    #GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam01 -ResourceGroup $resourceGroupGet
    #GetOrCreateMariaDb -forceCreate $true -mariaDb $mariaDbParam02 -ResourceGroup $resourceGroupGet
    $null = $env.add('rstr01', $rstr01)
    $null = $env.add('rstr02', $rstr02)
    Write-Host -ForegroundColor Green "MariaDB created successfully."
    
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    #set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.ResourceGroupGet
    Remove-AzResourceGroup -Name $env.ResourceGroup
}


