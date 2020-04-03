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

    # Create the test group
    write-host "start to create test group."
    $resourceGroup = "mysql_test"
    $location = "westcentralus"
    $env.Add("resourceGroup", $resourceGroup)
    $env.Add("location", $location)
    New-AzResourceGroup -Name $resourceGroup -Location $location

    $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
    $serverName = "mysql-azure-powershell"
    $env.Add("serverName", $serverName)

    write-host (Get-AzContext | Out-String)

    write-host "New-AzMySqlServer -Name $serverName -ResourceGroupName $resourceGroup -Location $location -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku GP_Gen5_4"
    New-AzMySqlServer -Name $serverName -ResourceGroupName $resourceGroup -Location $location -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku GP_Gen5_4

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Removing resourcegroup will clean all the resources created for testing.
    write-host "Clean resources you create for testing."
    Remove-AzResourceGroup -Name $env.resourceGroup
}

