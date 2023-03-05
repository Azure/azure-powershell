Invoke-LiveTestScenario -Name "Create ContainerRegistry" -Description "Test Create AzContainerRegistry" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    $actual = New-AzContainerRegistry -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Sku Basic
    Assert-AreEqual $cgName $actual.Name
    Assert-AreEqual $cgLocation $actual.Location
}

Invoke-LiveTestScenario -Name "List ContainerRegistry" -Description "Test listing ContainerRegistry" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    $null = New-AzContainerRegistry -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Sku Basic
    $actual = Get-AzContainerRegistry -ResourceGroupName $rgName
    Assert-True { $actual.Count -ge 1 }
}

Invoke-LiveTestScenario -Name "Get ContainerRegistry" -Description "Test getting one ContainerRegistry" -ScenarioScript `
{
    param ($rg)
    
    $rgName = $rg.ResourceGroupName

    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    
    $null = New-AzContainerRegistry -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Sku Basic 
    $actual = Get-AzContainerRegistry -ResourceGroupName $rgName -Name $cgName
    Assert-AreEqual $cgName $actual.Name
}

Invoke-LiveTestScenario -Name "Update ContainerRegistry" -Description "Test Updating one specific ContainerRegistry" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    $null = New-AzContainerRegistry -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Sku Basic 
    $null = Update-AzContainerRegistry -Name $cgName -ResourceGroupName $rgName -EnableAdminUser
    $actual = Get-AzContainerRegistry -ResourceGroupName $rgName -Name $cgName
    Assert-AreEqual $actual.AdminUserEnabled True
}

Invoke-LiveTestScenario -Name "Remove ContainerRegistry" -Description "Test Removing ContainerRegistry" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    $null = New-AzContainerRegistry -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Sku Basic 
    $null = Remove-AzContainerRegistry -ResourceGroupName $rgName -Name $cgName
    $GetServiceList = Get-AzContainerRegistry -ResourceGroupName $rgName
    Assert-False { $GetServiceList.Name -contains $cgName}
}