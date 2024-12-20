Invoke-LiveTestScenario -Name "Create access connector for databricks" -Description "Test creating access connector for data bricks" -ResourceGroupLocation "eastus" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $connName = New-LiveTestResourceName
    $location = "eastus"

    New-AzDatabricksAccessConnector -ResourceGroupName $rgName -Name $connName -Location $location

    $actual = Get-AzDatabricksAccessConnector -ResourceGroupName $rgName -Name $connName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $connName $actual.Name
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual "Succeeded" $actual.ProvisioningState
}

Invoke-LiveTestScenario -Name "Update access connector for databricks" -Description "Test updating an existing access connector for data bricks" -ResourceGroupLocation "eastus" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $connName = New-LiveTestResourceName
    $location = "eastus"

    $connector = New-AzDatabricksAccessConnector -ResourceGroupName $rgName -Name $connName -Location $location
    $connector | Update-AzDatabricksAccessConnector -Tag @{ "key" = "value" }

    $actual = Get-AzDatabricksAccessConnector -ResourceGroupName $rgName -Name $connName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $connName $actual.Name
    Assert-AreEqual $location $actual.Location
    Assert-AreEqual "Succeeded" $actual.ProvisioningState
    Assert-AreEqual 1 $actual.Tag.Count
}

Invoke-LiveTestScenario -Name "Remove access connector for data bricks" -Description "Test removing access connector for data bricks" -ResourceGroupLocation "eastus" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $connName = New-LiveTestResourceName
    $location = "eastus"

    New-AzDatabricksAccessConnector -ResourceGroupName $rgName -Name $connName -Location $location
    Remove-AzDatabricksAccessConnector -ResourceGroupName $rgName -name $connName

    $actual = Get-AzDatabricksAccessConnector -ResourceGroupName $rgName -Name $connName -ErrorAction SilentlyContinue
    Assert-Null $actual
}
