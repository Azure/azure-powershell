Invoke-LiveTestScenario -Name "Create, get, update and remove a new SQL Server" -Description "Test on new SQL Server" -PowerShellVersion "5.1", "Latest" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"
    $adminSqlLogin = New-LiveTestResourceName
    $password = "password@123"
    $serverName = New-LiveTestResourceName
    # Create a Sql Server
    $actual = New-AzSqlServer -ResourceGroupName $rgName `
        -ServerName $serverName `
        -Location $location `
        -SqlAdministratorCredentials $(New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $adminSqlLogin, $(ConvertTo-SecureString -String $password -AsPlainText -Force))
    Assert-AreEqual $serverName $actual.ServerName
    Assert-AreEqual $rgName $actual.ResourceGroupName
    # Get created Sql Server
    $actual = Get-AzSqlServer -ResourceGroupName $rgName -ServerName $serverName
    Assert-AreEqual $serverName $actual.ServerName
    # Update a Sql server
    $updatedPassword = "newpassword@123"
    $secureString = ConvertTo-SecureString $updatedPassword -AsPlainText -Force
    $null = Set-AzSqlServer -ResourceGroupName $rgName -ServerName $serverName -PublicNetworkAccess Disabled
    $actual = Get-AzSqlServer -ResourceGroupName $rgName -ServerName $serverName
    Assert-AreEqual "Disabled" $actual.PublicNetworkAccess
    # Remove a Sql server
    $null = Remove-AzSqlServer -ResourceGroup $rgName -ServerName $serverName
    $actual = Get-AzSqlServer -ResourceGroup $rgName
    Assert-False { $actual.ServerName -contains $serverName }
}
# After testing the cmdlets of Sql Server, create a Sql Server for sql database testing.

$ServerResourceGroup = New-LiveTestResourceGroup -Location eastus
$ServerResourceGroup
$ServerResourceGroup.ResourceGroupName
$RgName = $ServerResourceGroup.ResourceGroupName
$ResourceGroupLocation = $ServerResourceGroup.Location
Write-Host "##[section]Successfully created the resource group for sql server." -ForegroundColor Green
$AdminSqlLogin = New-LiveTestResourceName
$Password = "password@1234"
$ServerName = New-LiveTestResourceName

$SqlServer = New-AzSqlServer -ResourceGroupName $RgName `
    -ServerName $ServerName `
    -Location $ResourceGroupLocation `
    -SqlAdministratorCredentials $(New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $AdminSqlLogin, $(ConvertTo-SecureString -String $Password -AsPlainText -Force))

Invoke-LiveTestScenario -Name "Create a Sql Database" -Description "Test New-AzSqlDatabase" -PowerShellVersion "5.1", "Latest" -NoResourceGroup -ScenarioScript `
{
    $dbName = New-LiveTestResourceName

    $actual = New-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
    $actual.ServerName
    Assert-AreEqual $ServerName $actual.ServerName
    Assert-AreEqual $RgName $actual.ResourceGroupName
    Assert-AreEqual $dbName $actual.DatabaseName
    Remove-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
}

Invoke-LiveTestScenario -Name "Get a Sql Database" -Description "Test Get-AzSqlDatabase" -PowerShellVersion "5.1", "Latest" -NoResourceGroup -ScenarioScript `
{
    $dbName = New-LiveTestResourceName

    $null = New-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
    $actual = Get-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
    Assert-AreEqual $serverName $actual.ServerName
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $dbName $actual.DatabaseName
    Remove-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
}

Invoke-LiveTestScenario -Name "Update a Sql Database" -Description "Test Set-AzSqlDatabase" -PowerShellVersion "5.1", "Latest" -NoResourceGroup -ScenarioScript `
{
    $dbName = New-LiveTestResourceName

    $null = New-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
    $null = Set-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName -Edition "Standard" -RequestedServiceObjectiveName "S0"
    $actual = Get-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
    Assert-AreEqual $dbName $actual.DatabaseName
    Assert-AreEqual "S0" $actual.RequestedServiceObjectiveName
    Assert-AreEqual "Standard" $actual.Edition
    Remove-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
}

Invoke-LiveTestScenario -Name "Remove a Sql Database" -Description "Test Remove-AzSqlDatabase" -PowerShellVersion "5.1", "Latest" -NoResourceGroup -ScenarioScript `
{
    $dbName = New-LiveTestResourceName

    $null = New-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
    Remove-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName -DatabaseName $dbName
    $actual = Get-AzSqlDatabase -ResourceGroupName $RgName -ServerName $ServerName

    Assert-False { $actual.DatabaseName -contains $dbName }
}
# At the end of db test, clear the resource group
Clear-LiveTestResources -Name $RgName
