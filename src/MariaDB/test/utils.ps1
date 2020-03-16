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
    $adminLogin = 'administrator'
    $adminLoginPassword = 'Password01!!'
    $rstr01 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr02 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $rstr03 = 'mariadb-test-' + (RandomString -allChars $false -len 6)
    $null = $env.Add('Location', $location)
    $null = $env.Add('AdminLogin', $adminLogin)
    $null = $env.Add('AdminLoginPassword',$adminLoginPassword)
    $null = $env.add('rstr01', $rstr01)
    $null = $env.add('rstr02', $rstr02)
    $null = $env.add('rstr03', $rstr03)

    # Create test resource group.
    $resourceGroupGet = 'lucas-test-getcmd'
    $resourceGroup = 'lucas-test'
    
    $null = $env.Add('ResourceGroupGet', $resourceGroupGet)
    $null = $env.Add('ResourceGroup', $resourceGroup)
    Write-Host -ForegroundColor Green "Start to creating test resource group..."
    New-AzResourceGroup -Name $resourceGroup -Location $location
    New-AzResourceGroup -Name $resourceGroupGet -Location $location
    Write-Host -ForegroundColor Green "Created successfully."
    # For any resources you created for test, you should add it to $env here.

    # create mariadb for test  
    # ConvertTo-SecureString "P@ssW0rD!" -AsPlainText -Force
    Write-Host -ForegroundColor Green "Start to creating test mariadb."
    $adminLoginPasswordSecure =  ConvertTo-SecureString adminLoginPassword -AsPlainText -Force 
    $mariadbTest01 = New-AzMariaDBServer -Name $rstr01 -ResourceGroupName $env.ResourceGroupGet -AdministratorLogin $adminLogin -AdministratorLoginPassword $adminLoginPasswordSecure -Location eastus
    $mariadbTest02 = New-AzMariaDBServer -Name $rstr02 -ResourceGroupName $env.ResourceGroupGet -AdministratorLogin $adminLogin -AdministratorLoginPassword $adminLoginPasswordSecure -Location eastus
    $mariadbTest03 = New-AzMariaDBServer -Name $rstr03 -ResourceGroupName $env.ResourceGroupGet -AdministratorLogin $adminLogin -AdministratorLoginPassword $adminLoginPasswordSecure -Location eastus -SkuName GP_Gen5_4
    Write-Host -ForegroundColor Green "Created successfully."
    
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.ResourceGroup
    # Remove-AzResourceGroup -Name $env.ResourceGroup
}


