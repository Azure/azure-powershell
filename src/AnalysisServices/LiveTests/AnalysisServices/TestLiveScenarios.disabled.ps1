Invoke-LiveTestScenario -Name "Create a new Analysis Service Server" -Description "Test creating a new Analysis Service Server" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $serverName = New-LiveTestResourceName
    $location = "westus"
    $SkuName = "S1"

    $actual = New-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName -Location $location -Sku $SkuName
    Assert-AreEqual $serverName $actual.Name
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $SkuName $actual.Sku.Name
}

Invoke-LiveTestScenario -Name "Get an Analysis Service Server" -Description "Test getting an Analysis Service Server" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $serverName = New-LiveTestResourceName
    $location = "westus"
    $SkuName = "S1"

    $null = New-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName -Location $location -Sku $SkuName
    $actual = Get-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName
    Assert-AreEqual $serverName $actual.Name
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $SkuName $actual.Sku.Name
}

Invoke-LiveTestScenario -Name "Update an Analysis Service Server" -Description "Test invoking Set-AzAnalysisServicesServer" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $serverName = New-LiveTestResourceName
    $location = "westus"
    $SkuName = "S1"
    $key = new-LiveTestResourceName
    $value = new-LiveTestResourceName

    $null = New-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName -Location $location -Sku $SkuName
    $null = Set-AzAnalysisServicesServer -Name $serverName -ResourceGroupName $rgName -Tag @{$key = $value}
    $actual = get-AzAnalysisServicesServer -Name $serverName -ResourceGroupName $rgName
    
    Assert-AreEqual $serverName $actual.Name
    Assert-AreEqual $actual.Tag[$key] $value
}

Invoke-LiveTestScenario -Name "Delete an Analysis Service Server" -Description "Test invoking Remove-AzAnalysisServicesServer" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $serverName = New-LiveTestResourceName
    $location = "westus"
    $SkuName = "S1"

    $null = New-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName -Location $location -Sku $SkuName
    # Delete Analysis Servicesserver
    Remove-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName -PassThru

    # Verify that it is gone by trying to get it again
    Assert-Throws {Get-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName}
}

Invoke-LiveTestScenario -Name "Suspend and Resume an Analysis Service Server" -Description "Test Suspend-AzAnalysisServicesServer & Resume-AzAnalysisServicesServer" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $serverName = New-LiveTestResourceName
    $location = "westus"
    $SkuName = "S1"

    $null = New-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName -Location $location -Sku $SkuName
    # Suspend Analysis Servicesserver
    Suspend-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName
    $serverGet = Get-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName
    Assert-True {$serverGet.State -like "Paused"}
    # Assert-True {$serverGet.ProvisioningState -like "Succeeded"} # TODO: Uncomment this in future after fix is deployed.

    # Resume Analysis Servicesserver
    Resume-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName
    $serverGet = Get-AzAnalysisServicesServer -ResourceGroupName $rgName -Name $serverName
    Assert-True {$serverGet.ProvisioningState -like "Succeeded"}
    Assert-True {$serverGet.State -like "Succeeded"}
}
