Invoke-LiveTestScenario -Name "Create new registration bot service" -Description "Test creating a new registration bot service with all default values" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $botName = New-LiveTestResourceName
    $botLocation = "westus"
    $WebApplication1 = "ae96ba8b-3711-4464-abc4-9aeec3531a87"

    $actual = New-AzBotService -ResourceGroupName $rgName -Name $botName -ApplicationId $WebApplication1 -Location $botLocation -Sku F0 -Description "description" -Registration
    Assert-AreEqual $botName $actual.Name
    Assert-AreEqual $botLocation $actual.Location
    Assert-AreEqual "F0" $actual.Sku.Name
}

Invoke-LiveTestScenario -Name "List bot service" -Description "Test listing bot services in a resourcegroup" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $botName = New-LiveTestResourceName
    $botLocation = "westus"
    $WebApplication1 = "ae96ba8b-3711-4464-abc4-9aeec3531a87"

    $null = New-AzBotService -ResourceGroupName $rgName -Name $botName -ApplicationId $WebApplication1 -Location $botLocation -Sku F0 -Description "description" -Registration
    $actual = Get-AzBotService -ResourceGroupName $rgName
    Assert-AreEqual 1 $actual.Count
}

Invoke-LiveTestScenario -Name "Get bot service" -Description "Test getting one specific bot service" -ScenarioScript `
{
    param ($rg)
    
    $rgName = $rg.ResourceGroupName
    $botName = New-LiveTestResourceName
    $botLocation = "westus"
    $WebApplication1 = "ae96ba8b-3711-4464-abc4-9aeec3531a87"

    $null = New-AzBotService -ResourceGroupName $rgName -Name $botName -ApplicationId $WebApplication1 -Location $botLocation -Sku F0 -Description "description" -Registration
    $actual = Get-AzBotService -ResourceGroupName $rgName -Name $botName
    Assert-AreEqual $botName $actual.Name
}

Invoke-LiveTestScenario -Name "Update bot service" -Description "Test Updating one specific bot service" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $botName = New-LiveTestResourceName
    $botLocation = "westus"
    $WebApplication1 = "ae96ba8b-3711-4464-abc4-9aeec3531a87"

    $null = New-AzBotService -ResourceGroupName $rgName -Name $botName -ApplicationId $WebApplication1 -Location $botLocation -Sku F0 -Description "description" -Registration
    $actual = Update-AzBotService -Name $botName -ResourceGroupName $rgName -Kind bot
    Assert-AreEqual "bot" $actual.Kind
}

Invoke-LiveTestScenario -Name "Remove bot servcie" -Description "Test Removing a bot service" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $botName = New-LiveTestResourceName
    $botLocation = "westus"
    $WebApplication1 = "ae96ba8b-3711-4464-abc4-9aeec3531a87"

    $null = New-AzBotService -ResourceGroupName $rgName -Name $botName -ApplicationId $WebApplication1 -Location $botLocation -Sku F0 -Description "description" -Registration
    Invoke-LiveTestCommand -Command "Remove-AzBotService -ResourceGroupName $rgName -Name $botName"
    $GetServiceList = Get-AzBotService
    Assert-False { $GetServiceList.Name -contains $botName}
}
