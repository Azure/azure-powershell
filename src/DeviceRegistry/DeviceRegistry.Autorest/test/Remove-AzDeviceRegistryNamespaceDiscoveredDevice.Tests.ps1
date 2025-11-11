if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistryNamespaceDiscoveredDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistryNamespaceDiscoveredDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistryNamespaceDiscoveredDevice' {
    It 'Delete' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.deleteTests.Delete
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.deleteTests.jsonFilePath
        
        # Create test device to delete
        New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $jsonFilePath
        
        # Delete the device
        Remove-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name
        
        # Verify the device is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityNamespace' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.deleteTests.DeleteViaIdentityNamespace
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.deleteTests.jsonFilePath
        
        # Create test device to delete
        New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $jsonFilePath
        
        # Create namespace identity object
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $env.resourceGroup
            NamespaceName = $namespaceName
        }
        
        # Delete the device using namespace identity
        Remove-AzDeviceRegistryNamespaceDiscoveredDevice -NamespaceInputObject $namespaceIdentity -DiscoveredDeviceName $testConfig.name
        
        # Verify the device is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $testConfig = $env.namespaceDiscoveredDeviceTests.deleteTests.DeleteViaIdentity
        $namespaceName = $env.namespaceDiscoveredDeviceTests.namespaceName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDiscoveredDeviceTests.deleteTests.jsonFilePath
        
        # Create test device to delete
        $device = New-AzDeviceRegistryNamespaceDiscoveredDevice -ResourceGroupName $env.resourceGroup -NamespaceName $namespaceName -DiscoveredDeviceName $testConfig.name -JsonFilePath $jsonFilePath
        
        # Delete the device using the device object as identity
        Remove-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject $device
        
        # Verify the device is deleted by trying to get it using the device object (should throw)
        { Get-AzDeviceRegistryNamespaceDiscoveredDevice -InputObject $device -ErrorAction Stop } | Should -Throw
    }
}
