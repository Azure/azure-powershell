Invoke-LiveTestScenario -Name "Create ConnectedKubernetes" -Description "Test New-AzConnectedKubernetes" -ScenarioScript `
{
    param ($rg)
    $rgName = $rg.ResourceGroupName
    $ckName = New-LiveTestResourceName
    $ckLocation = "westus"
    $actual = New-AzConnectedKubernetes -ClusterName $ckName -ResourceGroupName $rgName -Location $ckLocation
    Assert-AreEqual $ckName $actual.Name
    Assert-AreEqual $ckLocation $actual.Location
}

Invoke-LiveTestScenario -Name "List ConnectedKubernetes" -Description "Test listing ConnectedKubernetes" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $ckName = New-LiveTestResourceName
    $ckLocation = "westus"
    $null = New-AzConnectedKubernetes -ClusterName $ckName -ResourceGroupName $rgName -Location $ckLocation
    $actual = Get-AzConnectedKubernetes -ResourceGroupName $rgName
    Assert-AreEqual 1 $actual.Count
}

Invoke-LiveTestScenario -Name "Get ConnectedKubernetes" -Description "Test getting one ConnectedKubernetes" -ScenarioScript `
{
    param ($rg)
    
    $rgName = $rg.ResourceGroupName
    $ckName = New-LiveTestResourceName
    $ckLocation = "westus"
    $null = New-AzConnectedKubernetes -ClusterName $ckName -ResourceGroupName $rgName -Location $ckLocation
    $actual = Get-AzConnectedKubernetes -ResourceGroupName $rgName -ClusterName $ckName
    Assert-AreEqual $ckName $actual.Name
}

Invoke-LiveTestScenario -Name "Update ConnectedKubernetes" -Description "Test Updating one specific ConnectedKubernetes" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $ckName = New-LiveTestResourceName
    $ckLocation = "westus"
    $tag = @{'key'='1'}
    $null = New-AzConnectedKubernetes -ClusterName $ckName -ResourceGroupName $rgName -Location $ckLocation
    $null = Update-AzConnectedKubernetes -ClusterName $ckName -ResourceGroupName $rgName -Tag $tag
    $actual = Get-AzConnectedKubernetes -ResourceGroupName $rgName -ClusterName $ckName
    Assert-AreEqual $actual.$tag["key"] "1"
}

Invoke-LiveTestScenario -Name "Remove ConnectedKubernetes" -Description "Test Removing ConnectedKubernetes" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $ckName = New-LiveTestResourceName
    $ckLocation = "westus"
    $actual = New-AzConnectedKubernetes -ClusterName $ckName -ResourceGroupName $rgName -Location $ckLocation
    Remove-AzConnectedKubernetes -ResourceGroupName $rgName -Name $ckName
    $GetServiceList = Get-AzConnectedKubernetes -ResourceGroupName $rgName
    Assert-False { $GetServiceList.Name -contains $rgName}
}