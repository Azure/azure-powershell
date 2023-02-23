Invoke-LiveTestScenario -Name "Create function app" -Description "Test creating function app" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $saName = New-LiveTestStorageAccountName
    $funcAppName = New-LiveTestResourceName
    $location = "westus"

    New-AzStorageAccount -ResourceGroupName $rgName -Name $saName -Location $location -SkuName Standard_LRS
    New-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName -Location $location -FunctionsVersion 4 -StorageAccountName $saName -OSType Windows -Runtime PowerShell -RuntimeVersion 7.2

    $actual = Get-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $funcAppName $actual.Name
    Assert-AreEqual "Running" $actual.State
    Assert-AreEqual "Windows" $actual.OSType
    Assert-AreEqual "PowerShell" $actual.Runtime
}

Invoke-LiveTestScenario -Name "Update function app" -Description "Test updating an existing function app" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $saName = New-LiveTestStorageAccountName
    $funcAppName = New-LiveTestResourceName
    $location = "eastus"

    New-AzStorageAccount -ResourceGroupName $rgName -Name $saName -Location $location -SkuName Standard_LRS
    $funcApp = New-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName -Location $location -FunctionsVersion 4 -StorageAccountName $saName -OSType Windows -Runtime PowerShell -RuntimeVersion 7.2
    $funcApp | Update-AzFunctionApp -Tag @{ "key" = "value" } -Force
    Update-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName -IdentityType SystemAssigned -Force

    $actual = Get-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName
    Assert-NotNull $actual
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $funcAppName $actual.Name
    Assert-AreEqual "Running" $actual.State
    Assert-AreEqual "SystemAssigned" $actual.IdentityType
    Assert-AreEqual 1 $actual.Tag.Count
}

Invoke-LiveTestScenario -Name "Remove function app" -Description "Test removing function app" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $saName = New-LiveTestStorageAccountName
    $funcAppName = New-LiveTestResourceName
    $location = "centralus"

    New-AzStorageAccount -ResourceGroupName $rgName -Name $saName -Location $location -SkuName Standard_LRS
    New-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName -Location $location -FunctionsVersion 4 -StorageAccountName $saName -OSType Windows -Runtime PowerShell -RuntimeVersion 7.2
    Remove-AzFunctionApp -ResourceGroupName $rgName -name $funcAppName -Force

    $actual = Get-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName -ErrorAction SilentlyContinue
    Assert-Null $actual
}

Invoke-LiveTestScenario -Name "Operate function app" -Description "Test operating function app by starting, stopping and restarting it" -ResourceGroupLocation "eastus" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $saName = New-LiveTestStorageAccountName
    $funcAppName = New-LiveTestResourceName
    $location = "eastus"

    New-AzStorageAccount -ResourceGroupName $rgName -Name $saName -Location $location -SkuName Standard_LRS
    New-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName -Location $location -FunctionsVersion 4 -StorageAccountName $saName -OSType Windows -Runtime PowerShell -RuntimeVersion 7.2

    Stop-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName -Force
    $app = Get-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName
    Assert-NotNull $app
    Assert-AreEqual "Stopped" $app.State

    $app | Start-AzFunctionApp
    $app = Get-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName
    Assert-NotNull $app
    Assert-AreEqual "Running" $app.State

    Restart-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName -Force
    $app = Get-AzFunctionApp -ResourceGroupName $rgName -Name $funcAppName
    Assert-NotNull $app
    Assert-AreEqual "Running" $app.State
}
