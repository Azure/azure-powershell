Invoke-LiveTestScenario -Name "Create Spring Cloud Instance" -Description "Test the process of create a new spring cloud instance." -Platform Linux -PowerShellVersion Latest -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"
    $springCloudServiceName = New-LiveTestResourceName

    $springCloudInstance = New-AzSpringCloud -ResourceGroupName $rgName -Name $springCloudServiceName -Location $location -SkuTier "Basic" -SkuName "B0"

    Assert-AreEqual $springCloudServiceName $springCloudInstance.Name
}

Invoke-LiveTestScenario -Name "Create Spring Cloud App Instance" -Description "Test the process of create a new spring cloud app instance." -Platform Linux -PowerShellVersion Latest -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"
    $springCloudServiceName = New-LiveTestResourceName
    $appName = New-LiveTestResourceName

    $springCloudInstance = New-AzSpringCloud -ResourceGroupName $rgName -Name $springCloudServiceName -Location $location -SkuTier "Basic" -SkuName "B0"
    $appInstance = New-AzSpringCloudApp -ResourceGroupName $rgName -ServiceName $springCloudServiceName -Name $appName

    Assert-AreEqual $appName $appInstance.Name
}

Invoke-LiveTestScenario -Name "Create Spring Cloud App Deployment Instance" -Description "Test the process of create a new spring cloud app deployment instance." -Platform Linux -PowerShellVersion Latest -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $location = "eastus"
    $springCloudServiceName = New-LiveTestResourceName
    $appName = New-LiveTestResourceName
    $deploymentName = "default"

    $springCloudInstance = New-AzSpringCloud -ResourceGroupName $rgName -Name $springCloudServiceName -Location $location -SkuTier "Basic" -SkuName "B0"
    $appInstance = New-AzSpringCloudApp -ResourceGroupName $rgName -ServiceName $springCloudServiceName -Name $appName
    $jarSource = New-AzSpringCloudAppDeploymentJarUploadedObject -RuntimeVersion "Java_8"
    $deployment = New-AzSpringCloudAppDeployment -ResourceGroupName $rgName -ServiceName $springCloudServiceName -AppName $appName -DeploymentName $deploymentName -Source $jarSource -EnvironmentVariable @{"env" = "prod"}

    Assert-AreEqual $appName $appInstance.Name
}
