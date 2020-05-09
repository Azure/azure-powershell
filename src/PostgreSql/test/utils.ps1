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
    $env.Add("serverName2", "postgresql-test-100-2")
    $env.Add("restoreName", "postgresql-test-100-restore")
    $env.Add("restoreName2", "postgresql-test-100-restore-2")
    $env.Add("replicaName", "postgresql-test-100-replica")
    $env.Add("firewallRuleName", "postgresqlrule01")
    $env.Add("firewallRuleName2", "postgresqlrule02")
    $env.Add("VNetName", "postgresqlvnet")

    # Create the test group
    write-host "start to create test group."
    $resourceGroup = "PostgreSqlTest"
    $location = "eastus"
    $env.Add("resourceGroup", $resourceGroup)
    $env.Add("location", $location)
    New-AzResourceGroup -Name $resourceGroup -Location $location

    # Create the test Vnet
    write-host "Deploy Vnet template"
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\virtual-network\template.json -TemplateParameterFile .\test\deployment-templates\virtual-network\parameters.json -Name vn -ResourceGroupName $resourceGroup

    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $password = 'Pa88word!' | ConvertTo-SecureString -AsPlainText -Force
    $serverName = "postgresql-test-100"
    $env.Add("serverName", $serverName)
    $Sku = "GP_Gen5_4"
    $env.Add("Sku", $Sku)

    write-host (Get-AzContext | Out-String)

    write-host "New-AzPostgreSqlServer -Name $serverName -ResourceGroupName $resourceGroup -Location $location -AdministratorUserName postgresql_test -AdministratorLoginPassword $password -Sku $Sku"
    New-AzPostgreSqlServer -Name $serverName -ResourceGroupName $resourceGroup -Location $location -AdministratorUserName postgresql_test -AdministratorLoginPassword $password -Sku $Sku

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

