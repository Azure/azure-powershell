if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistryNamespaceAsset'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistryNamespaceAsset.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistryNamespaceAsset' {
    It 'Delete' {
        $testConfig = $env.namespaceAssetTests.deleteTests.Delete
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.deleteTests.jsonFilePath
        
        # Create test asset to delete
        New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $jsonFilePath

        # Delete the asset
        Remove-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name

        # Verify the asset is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityNamespace' {
        $testConfig = $env.namespaceAssetTests.deleteTests.DeleteViaIdentityNamespace
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.deleteTests.jsonFilePath
        
        # Create test asset to delete
        New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $jsonFilePath

        # Create namespace identity object
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $resourceGroupName
            NamespaceName = $namespaceName
        }
        
        # Delete the asset using namespace identity
        Remove-AzDeviceRegistryNamespaceAsset -NamespaceInputObject $namespaceIdentity -AssetName $testConfig.name
        
        # Verify the asset is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistryNamespaceAsset -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -AssetName $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $testConfig = $env.namespaceAssetTests.deleteTests.DeleteViaIdentity
        $namespaceName = $env.namespaceAssetTests.namespaceName
        $resourceGroupName = $env.namespaceAssetTests.resourceGroupName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceAssetTests.deleteTests.jsonFilePath
        
        # Create test asset to delete
        $asset = New-AzDeviceRegistryNamespaceAsset -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -AssetName $testConfig.name -JsonFilePath $jsonFilePath

        # Delete the asset using the asset object as identity
        Remove-AzDeviceRegistryNamespaceAsset -InputObject $asset
        
        # Verify the asset is deleted by trying to get it using the asset object (should throw)
        { Get-AzDeviceRegistryNamespaceAsset -InputObject $asset -ErrorAction Stop } | Should -Throw
    }
}
