Invoke-LiveTestScenario -Name "Create new web with service plan" -Description "Test creating a new web app with service plan" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $webAppName = New-LiveTestResourceName
    $webLocation = "westus"
    $whpName = New-LiveTestResourceName
    $tier = "Shared"

    $serverFarm = New-AzAppServicePlan -ResourceGroupName $rgName -Name $whpName -Location $weblocation -Tier $tier
    $actual = New-AzWebApp -ResourceGroupName $rgName -Name $webAppName -Location $webLocation -AppServicePlan $whpName
    Set-AzWebApp -ResourceGroupName $rgName -Name $webAppName -MinTlsVersion "1.2"

    Assert-AreEqual $webAppName $actual.Name
	Assert-AreEqual $serverFarm.Id $actual.ServerFarmId
}

Invoke-LiveTestScenario -Name "Get a webapp" -Description "Test getting a new webapp" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $webAppName = New-LiveTestResourceName
    $webLocation = "westus"
    $whpName = New-LiveTestResourceName
    $tier = "Shared"

    $serverFarm = New-AzAppServicePlan -ResourceGroupName $rgName -Name $whpName -Location $weblocation -Tier $tier
    $null = New-AzWebApp -ResourceGroupName $rgName -Name $webAppName -Location $webLocation -AppServicePlan $whpName
    Set-AzWebApp -ResourceGroupName $rgName -Name $webAppName -MinTlsVersion "1.2"

    $webApp = Get-AzWebApp -ResourceGroupName $rgName -Name $webAppName
    Assert-AreEqual $webAppName $webApp.Name
    Assert-AreEqual $rgName $webApp.ResourceGroup
    Assert-AreEqual $serverFarm.Id $webApp.ServerFarmId
}

Invoke-LiveTestScenario -Name "Update web app" -Description "Test updating service plan & set site properties for existing web app" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $webAppName = New-LiveTestResourceName
    $webLocation = "westus"
    $appServicePlanName1 = New-LiveTestResourceName
	$appServicePlanName2 = New-LiveTestResourceName
	$tier1 = "Shared"
	$tier2 = "Standard"

    $serverFarm1 = New-AzAppServicePlan -ResourceGroupName $rgName -Name  $appServicePlanName1 -Location  $webLocation -Tier $tier1
	$serverFarm2 = New-AzAppServicePlan -ResourceGroupName $rgName -Name  $appServicePlanName2 -Location  $webLocation -Tier $tier2
    $webApp = New-AzWebApp -ResourceGroupName $rgName -Name $webAppName -Location $webLocation -AppServicePlan $appServicePlanName1
    Set-AzWebApp -ResourceGroupName $rgName -Name $webAppName -MinTlsVersion "1.2"

    Assert-AreEqual $webAppName $webApp.Name
    Assert-AreEqual $serverFarm1.Id $webApp.ServerFarmId
    Assert-Null $webApp.Identity
    Assert-NotNull $webApp.SiteConfig.phpVersion
    Assert-AreEqual $false $webApp.HttpsOnly

    # Update service plan & set site properties
    $job = Set-AzWebApp -ResourceGroupName $rgName -Name $webAppName -AppServicePlan $appServicePlanName2 -HttpsOnly $true -AlwaysOn $false -AsJob
    $job | Wait-Job
    $webApp = $job | Receive-Job

    # Assert
    Assert-AreEqual $webAppName $webApp.Name
    Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId
    Assert-AreEqual $true $webApp.HttpsOnly
    Assert-AreEqual $false $webapp.SiteConfig.AlwaysOn

    # Set config properties
    $webapp.SiteConfig.HttpLoggingEnabled = $true
    $webapp.SiteConfig.RequestTracingEnabled = $true
    $webapp.SiteConfig.FtpsState = "FtpsOnly"
    $webApp.SiteConfig.HealthCheckPath = "/api/path"

    # Set site properties
    $webApp = $webApp | Set-AzWebApp

    # Assert
    Assert-AreEqual $webAppName $webApp.Name
    Assert-AreEqual $serverFarm2.Id $webApp.ServerFarmId
    Assert-AreEqual $true $webApp.SiteConfig.HttpLoggingEnabled
    Assert-AreEqual $true $webApp.SiteConfig.RequestTracingEnabled
    Assert-AreEqual $false $webApp.SiteConfig.AlwaysOn
    Assert-AreEqual "FtpsOnly" $webApp.SiteConfig.FtpsState
    Assert-AreEqual "/api/path" $webApp.SiteConfig.HealthCheckPath
}

Invoke-LiveTestScenario -Name "Delete web app" -Description "Test deleting web app" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $webAppName = New-LiveTestResourceName
    $webLocation = "westus"
    $whpName = New-LiveTestResourceName
    $tier = "Shared"

    $null = New-AzAppServicePlan -ResourceGroupName $rgName -Name $whpName -Location $webLocation -Tier $tier
    $null = New-AzWebApp -ResourceGroupName $rgName -Name $webAppName -Location $webLocation -AppServicePlan $whpName
    Set-AzWebApp -ResourceGroupName $rgName -Name $webAppName -MinTlsVersion "1.2"
    Remove-AzWebApp -ResourceGroupName $rgName -Name $webAppName -Force

    $webAppNames = (Get-AzWebApp -ResourceGroupName $rgName) | Select-Object -Property Name
    Assert-False { $webAppNames -contains $webAppName }
}

Invoke-LiveTestScenario -Name "Start, Stop and Restart WebApp" -Description "Test Stop-AzWebApp, Start-AzWebApp, Restart-AzWebApp" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $webAppName = New-LiveTestResourceName
    $webLocation = "westus"
    $whpName = New-LiveTestResourceName
    $tier = "Shared"

    $null = New-AzAppServicePlan -ResourceGroupName $rgName -Name $whpName -Location $webLocation -Tier $tier
    $webApp = New-AzWebApp -ResourceGroupName $rgName -Name $webAppName -Location $webLocation -AppServicePlan $whpName
    Set-AzWebApp -ResourceGroupName $rgName -Name $webAppName -MinTlsVersion "1.2"

    # Stop web app
    $webApp = $webApp | Stop-AzWebApp
    Assert-AreEqual "Stopped" $webApp.State

    # Start web app
    $webApp = $webApp | Start-AzWebApp
    Assert-AreEqual "Running" $webApp.State

    # Restart web app
    $webApp = $webApp | Restart-AzWebApp
    Assert-AreEqual "Running" $webApp.State

    # Stop web app
    $webApp = Stop-AzWebApp -ResourceGroupName $rgName -Name $webAppName
    Assert-AreEqual "Stopped" $webApp.State

    # Start web app
    $webApp = Start-AzWebApp -ResourceGroupName $rgName -Name $webAppName
    Assert-AreEqual "Running" $webApp.State

    # Retart web app
    $webApp = Restart-AzWebApp -ResourceGroupName $rgName -Name $webAppName
    Assert-AreEqual "Running" $webApp.State
}
