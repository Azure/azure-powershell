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
    $resourceGroup = "MySqlTestGroup"
    $location = "eastus2euap"
    $serverName = "mysql-test-100"
    $flexibleServerName = "mysql-flexible-test-100"
    $serverName = "mysql-test-100-2"
    $serverName = "mysql-test-100-3"
    $restoreName = "mysql-test-100-restore"
    $restoreName2 = "mysql-test-100-restore-2"
    $replicaName = "mysql-test-100-replica"
    $firewallRuleName = "mysqlrule01"
    $firewallRuleName = "mysqlrule02"
    $databaseName = "mysqldb"
    $VNetName = "mysqlvnet"
    $SubnetName = "mysql-test-subnet"
    $Sku = "GP_Gen5_4"
    $FlexibleSku = "Standard_B1ms"
    if ($TestMode -eq 'live') {
        $PowershellPrefix = "powershell-pipeline-mysql-"
        $RandomNumbers = ""
        for($i = 0; $i -lt 10; $i++){ $RandomNumbers += Get-Random -Maximum 10  }
        $serverName = $PowershellPrefix + "server" + $RandomNumbers
        $serverName2 = $PowershellPrefix + "2-flexibleserver" + $RandomNumbers
        $serverName3 = $PowershellPrefix + "3-flexibleserver" + $RandomNumbers
        $flexibleServerName = $PowershellPrefix + "flexibleserver" + $RandomNumbers
        $resourceGroup = $PowershellPrefix + "group" + $RandomNumbers
        $restoreName = $PowershellPrefix + "restore-server" + $RandomNumbers
        $restoreName2 = $PowershellPrefix + "2-restore-server" + $RandomNumbers
        $restoreName = $PowershellPrefix + "replica-server" + $RandomNumbers
        $firewallRuleName = $PowershellPrefix + "firewallrule" + $RandomNumbers
    }
    
    $env.Add("serverName", $serverName)
    $env.Add("flexibleServerName", $flexibleServerName)
    $env.Add("serverName2", $serverName2)
    $env.Add("serverName3", $serverName3)
    $env.Add("restoreName", $restoreName)
    $env.Add("restoreName2", $restoreName2)
    $env.Add("replicaName", $replicaName)
    $env.Add("firewallRuleName", $firewallRuleName)
    $env.Add("firewallRuleName2", $firewallRuleName2)
    $env.Add("databaseName", $databaseName)
    $env.Add("VNetName", $VNetName)
    $env.Add("SubnetName", $SubnetName)
    $env.Add("Sku", $Sku)
    $env.Add("flexibleSku", $FlexibleSku)
    $env.Add("resourceGroup", $resourceGroup)
    $env.Add("location", $location)

    # Create the test group
    write-host "start to create test group."
    New-AzResourceGroup -Name $resourceGroup -Location $location

    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $password = 'Pasword01!!2020' | ConvertTo-SecureString -AsPlainText -Force    
    
    # Create the test Vnet
    write-host "Deploy Vnet template"
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\virtual-network\template.json -TemplateParameterFile .\test\deployment-templates\virtual-network\parameters.json -Name vn -ResourceGroupName $resourceGroup

    write-host (Get-AzContext | Out-String)

    write-host "New-AzMySqlServer -Name $serverName -ResourceGroupName $resourceGroup -Location $location -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku $Sku"
    New-AzMySqlServer -Name $serverName -ResourceGroupName $resourceGroup -Location $location -AdministratorUserName mysql_test -AdministratorLoginPassword $password -Sku $Sku

    write-host "New-AzMySqlFlexibleServer -Name $flexibleServerName -ResourceGroupName $resourceGroup -AdministratorUserName mysql_test -AdministratorLoginPassword $password -PublicAccess all -Location $location"
    New-AzMySqlFlexibleServer -Name $flexibleServerName -ResourceGroupName $resourceGroup -AdministratorUserName mysql_test -AdministratorLoginPassword $password -PublicAccess all -Location $location

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
