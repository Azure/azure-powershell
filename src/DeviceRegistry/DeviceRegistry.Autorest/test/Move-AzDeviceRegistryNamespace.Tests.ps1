if(($null -eq $TestName) -or ($TestName -contains 'Move-AzDeviceRegistryNamespace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Move-AzDeviceRegistryNamespace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Move-AzDeviceRegistryNamespace' {
    It 'MigrateExpanded' {
        $testConfig = $env.namespaceTests.migrateTests.MigrateExpanded
        $commonProperties = $env.namespaceTests.migrateTests.commonProperties

        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $testConfig.assetName -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location -AssetEndpointProfileRef $testConfig.assetEndpointProfileName
        New-AzDeviceRegistryAssetEndpointProfile -ResourceGroupName $env.resourceGroup -Name $testConfig.assetEndpointProfileName -TargetAddress $commonProperties.targetAddress -EndpointProfileType $commonProperties.endpointProfileType -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location

        $resourceId = $commonProperties.resourceIdPrefix + $testConfig.assetName
        Move-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup -Name $commonProperties.namespace -ResourceId $resourceId

        $assetResult = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $env.resourceGroup -AssetName $testConfig.assetName -NamespaceName $commonProperties.namespace
        $assetResult | Should -Not -BeNullOrEmpty
        
        $deviceResult = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $env.resourceGroup -DeviceName $testConfig.assetEndpointProfileName -NamespaceName $commonProperties.namespace
        $deviceResult | Should -Not -BeNullOrEmpty
    }

    It 'MigrateViaJsonString' {
        $testConfig = $env.namespaceTests.migrateTests.MigrateViaJsonString
        $commonProperties = $env.namespaceTests.migrateTests.commonProperties

        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $testConfig.assetName -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location -AssetEndpointProfileRef $testConfig.assetEndpointProfileName
        New-AzDeviceRegistryAssetEndpointProfile -ResourceGroupName $env.resourceGroup -Name $testConfig.assetEndpointProfileName -TargetAddress $commonProperties.targetAddress -EndpointProfileType $commonProperties.endpointProfileType -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location

        $resourceId = $commonProperties.resourceIdPrefix + $testConfig.assetName
        $migrateRequest = @{
            resourceIds = @($resourceId)
        }
        $jsonString = $migrateRequest | ConvertTo-Json -Depth 10

        Move-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup -Name $commonProperties.namespace -JsonString $jsonString

        $assetResult = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $env.resourceGroup -AssetName $testConfig.assetName -NamespaceName $commonProperties.namespace
        $assetResult | Should -Not -BeNullOrEmpty
        
        $deviceResult = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $env.resourceGroup -DeviceName $testConfig.assetEndpointProfileName -NamespaceName $commonProperties.namespace
        $deviceResult | Should -Not -BeNullOrEmpty
    }

    It 'MigrateViaJsonFilePath' {
        $testConfig = $env.namespaceTests.migrateTests.MigrateViaJsonFilePath
        $commonProperties = $env.namespaceTests.migrateTests.commonProperties
        $jsonFilePath = Join-Path $PSScriptRoot $testConfig.jsonFilePath

        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $testConfig.assetName -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location -AssetEndpointProfileRef $testConfig.assetEndpointProfileName
        New-AzDeviceRegistryAssetEndpointProfile -ResourceGroupName $env.resourceGroup -Name $testConfig.assetEndpointProfileName -TargetAddress $commonProperties.targetAddress -EndpointProfileType $commonProperties.endpointProfileType -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location

        Move-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup -Name $commonProperties.namespace -JsonFilePath $jsonFilePath

        $assetResult = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $env.resourceGroup -AssetName $testConfig.assetName -NamespaceName $commonProperties.namespace
        $assetResult | Should -Not -BeNullOrEmpty
        
        $deviceResult = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $env.resourceGroup -DeviceName $testConfig.assetEndpointProfileName -NamespaceName $commonProperties.namespace
        $deviceResult | Should -Not -BeNullOrEmpty
    }

    It 'Migrate' {
        $testConfig = $env.namespaceTests.migrateTests.Migrate
        $commonProperties = $env.namespaceTests.migrateTests.commonProperties

        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $testConfig.assetName -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location -AssetEndpointProfileRef $testConfig.assetEndpointProfileName
        New-AzDeviceRegistryAssetEndpointProfile -ResourceGroupName $env.resourceGroup -Name $testConfig.assetEndpointProfileName -TargetAddress $commonProperties.targetAddress -EndpointProfileType $commonProperties.endpointProfileType -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location

        $resourceIds = @($commonProperties.resourceIdPrefix + $testConfig.assetName)
        Move-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup -Name $commonProperties.namespace -ResourceId $resourceIds

        $assetResult = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $env.resourceGroup -AssetName $testConfig.assetName -NamespaceName $commonProperties.namespace
        $assetResult | Should -Not -BeNullOrEmpty
        
        $deviceResult = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $env.resourceGroup -DeviceName $testConfig.assetEndpointProfileName -NamespaceName $commonProperties.namespace
        $deviceResult | Should -Not -BeNullOrEmpty
    }

    It 'MigrateViaIdentityExpanded' {
        $testConfig = $env.namespaceTests.migrateTests.MigrateViaIdentityExpanded
        $commonProperties = $env.namespaceTests.migrateTests.commonProperties

        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $testConfig.assetName -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location -AssetEndpointProfileRef $testConfig.assetEndpointProfileName
        New-AzDeviceRegistryAssetEndpointProfile -ResourceGroupName $env.resourceGroup -Name $testConfig.assetEndpointProfileName -TargetAddress $commonProperties.targetAddress -EndpointProfileType $commonProperties.endpointProfileType -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location

        # Get namespace identity
        $namespace = Get-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup -Name $commonProperties.namespace

        $resourceId = $commonProperties.resourceIdPrefix + $testConfig.assetName
        Move-AzDeviceRegistryNamespace -InputObject $namespace -ResourceId $resourceId

        $assetResult = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $env.resourceGroup -AssetName $testConfig.assetName -NamespaceName $commonProperties.namespace
        $assetResult | Should -Not -BeNullOrEmpty
        
        $deviceResult = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $env.resourceGroup -DeviceName $testConfig.assetEndpointProfileName -NamespaceName $commonProperties.namespace
        $deviceResult | Should -Not -BeNullOrEmpty
    }

    It 'MigrateViaIdentity' {
        $testConfig = $env.namespaceTests.migrateTests.MigrateViaIdentity
        $commonProperties = $env.namespaceTests.migrateTests.commonProperties

        New-AzDeviceRegistryAsset -ResourceGroupName $env.resourceGroup -Name $testConfig.assetName -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location -AssetEndpointProfileRef $testConfig.assetEndpointProfileName
        New-AzDeviceRegistryAssetEndpointProfile -ResourceGroupName $env.resourceGroup -Name $testConfig.assetEndpointProfileName -TargetAddress $commonProperties.targetAddress -EndpointProfileType $commonProperties.endpointProfileType -ExtendedLocationType $env.extendedLocationType -ExtendedLocationName $env.extendedLocationName -Location $env.location

        # Get namespace identity
        $namespace = Get-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup -Name $commonProperties.namespace

        $resourceIds = @($commonProperties.resourceIdPrefix + $testConfig.assetName)
        Move-AzDeviceRegistryNamespace -InputObject $namespace -ResourceId $resourceIds

        $assetResult = Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $env.resourceGroup -AssetName $testConfig.assetName -NamespaceName $commonProperties.namespace
        $assetResult | Should -Not -BeNullOrEmpty
        
        $deviceResult = Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $env.resourceGroup -DeviceName $testConfig.assetEndpointProfileName -NamespaceName $commonProperties.namespace
        $deviceResult | Should -Not -BeNullOrEmpty
    }
}
