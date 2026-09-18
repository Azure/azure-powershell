Invoke-LiveTestScenario -Name "Create ContainerGroup" -Description "Test New-AzContainerGroup" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $containerName = New-LiveTestResourceName
    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    $container = New-AzContainerInstanceObject -Name $containerName -Image 'mcr.microsoft.com/azure-powershell:azurelinux-3.0' -RequestCpu 1 -RequestMemoryInGb 1.5
    $actual = New-AzContainerGroup -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Container $container
    Assert-AreEqual $cgName $actual.Name
    Assert-AreEqual $cgLocation $actual.Location
}

Invoke-LiveTestScenario -Name "List ContainerGroup" -Description "Test listing ContainerGroup" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $containerName = New-LiveTestResourceName
    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    $container = New-AzContainerInstanceObject -Name $containerName -Image 'mcr.microsoft.com/azure-powershell:ubuntu-24.04' -RequestCpu 1 -RequestMemoryInGb 1.5
    $null = New-AzContainerGroup -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Container $container
    $actual = Get-AzContainerGroup -ResourceGroupName $rgName
    Assert-True { $actual.Count -ge 1 }
}

Invoke-LiveTestScenario -Name "Get ContainerGroup" -Description "Test getting one ContainerGroup" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $containerName = New-LiveTestResourceName
    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    $container = New-AzContainerInstanceObject -Name $containerName -Image 'mcr.microsoft.com/azure-powershell:alpine-3.23' -RequestCpu 1 -RequestMemoryInGb 1.5
    $null = New-AzContainerGroup -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Container $container
    $actual = Get-AzContainerGroup -ResourceGroupName $rgName -Name $cgName
    Assert-AreEqual $cgName $actual.Name
}

Invoke-LiveTestScenario -Name "Update ContainerGroup" -Description "Test Updating one specific ContainerGroup" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $containerName = New-LiveTestResourceName
    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    $tag = @{'key' = 'v' }
    $container = New-AzContainerInstanceObject -Name $containerName -Image 'mcr.microsoft.com/azure-powershell:alpine-3.23' -RequestCpu 1 -RequestMemoryInGb 1.5
    $null = New-AzContainerGroup -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Container $container
    $null = Update-AzContainerGroup -Name $cgName -ResourceGroupName $rgName -Tag $tag
    $actual = Get-AzContainerGroup -ResourceGroupName $rgName -Name $cgName
    Assert-AreEqual 1 $actual.Tag.Count
}

Invoke-LiveTestScenario -Name "Remove ContainerGroup" -Description "Test Removing ContainerGroup" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $containerName = New-LiveTestResourceName
    $cgName = New-LiveTestResourceName
    $cgLocation = "westus"
    $container = New-AzContainerInstanceObject -Name $containerName -Image 'mcr.microsoft.com/azure-powershell:debian-12' -RequestCpu 1 -RequestMemoryInGb 1.5
    $null = New-AzContainerGroup -ResourceGroupName $rgName -Name $cgName -Location $cgLocation -Container $container
    $null = Remove-AzContainerGroup -ResourceGroupName $rgName -Name $cgName
    $GetServiceList = Get-AzContainerGroup -ResourceGroupName $rgName
    Assert-False { $GetServiceList.Name -contains $cgName }
}
