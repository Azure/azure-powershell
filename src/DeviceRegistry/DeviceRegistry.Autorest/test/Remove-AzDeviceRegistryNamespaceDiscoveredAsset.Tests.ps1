if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistryNamespaceDiscoveredAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistryNamespaceDiscoveredAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistryNamespaceDiscoveredAsset' {
    It 'Delete' {
        $testConfig = $env.namespaceDiscoveredAssetTests.deleteTests.Delete
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.deleteTests.jsonFilePath
        
        # Create test asset to delete
        New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $jsonFilePath
        
        # Delete the asset
        Remove-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name
        
        # Verify the asset is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityNamespace' {
        $testConfig = $env.namespaceDiscoveredAssetTests.deleteTests.DeleteViaIdentityNamespace
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.deleteTests.jsonFilePath
        
        # Create test asset to delete
        New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $jsonFilePath
        
        # Create namespace identity object
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            NamespaceName = $namespaceName
        }
        
        # Delete the asset using namespace identity
        Remove-AzDeviceRegistryNamespaceDiscoveredAsset -NamespaceInputObject $namespaceIdentity -DiscoveredAssetName $testConfig.name
        
        # Verify the asset is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $testConfig = $env.namespaceDiscoveredAssetTests.deleteTests.DeleteViaIdentity
        $namespaceName = $env.namespaceDiscoveredAssetTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredAssetTests.deleteTests.jsonFilePath
        
        # Create test asset to delete
        $asset = New-AzDeviceRegistryNamespaceDiscoveredAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredAssetName $testConfig.name -JsonFilePath $jsonFilePath
        
        # Delete the asset using the asset object as identity
        Remove-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject $asset
        
        # Verify the asset is deleted by trying to get it using the asset object (should throw)
        { Get-AzDeviceRegistryNamespaceDiscoveredAsset -InputObject $asset -ErrorAction Stop } | Should -Throw
    }
}
