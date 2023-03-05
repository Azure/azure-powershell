Invoke-LiveTestScenario -Name "Create ApplicationInsights" -Description "Test New-AzApplicationInsights" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $appLocation = "westus"
    $appKind = "java"

    $actual = New-AzApplicationInsights -Kind $appKind -ResourceGroupName $rgName -Name $appName -location $appLocation
    Assert-AreEqual $appName $actual.Name
    Assert-AreEqual $appLocation $actual.Location
    Assert-AreEqual $appKind $actual.Kind
}

Invoke-LiveTestScenario -Name "Get ApplicationInsights" -Description "Test getting one ApplicationInsights" -ScenarioScript `
{
    param ($rg)
    
    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $appLocation = "westus"
    $appKind = "java"

    $null = New-AzApplicationInsights -Kind $appKind -ResourceGroupName $rgName -Name $appName -location $appLocation
    $actual = Get-AzApplicationInsights -ResourceGroupName $rgName -Name $appName
    Assert-AreEqual $appName $actual.Name
}

Invoke-LiveTestScenario -Name "Update ApplicationInsights" -Description "Test Updating one specific ApplicationInsights" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $appLocation = "westus"
    $appKind = "java"

    $null = New-AzApplicationInsights -Kind $appKind -ResourceGroupName $rgName -Name $appName -location $appLocation
    $null = Update-AzApplicationInsights -ResourceGroupName $rgName -Name $appName -PublicNetworkAccessForIngestion "Disabled"
    $actual = Get-AzApplicationInsights -Name $appName -ResourceGroupName $rgName
    Assert-AreEqual $actual.PublicNetworkAccessForIngestion "Disabled"
}

Invoke-LiveTestScenario -Name "Remove ApplicationInsights" -Description "Test Removing ApplicationInsights" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $appName = New-LiveTestResourceName
    $appLocation = "westus"
    $appKind = "java"

    $null = New-AzApplicationInsights -Kind $appKind -ResourceGroupName $rgName -Name $appName -location $appLocation
    Remove-AzApplicationInsights -ResourceGroupName $rgName -Name $appName
    $GetServiceList = Get-AzApplicationInsights -ResourceGroupName $rgName
    Assert-False { $GetServiceList.Name -contains $appName}
}