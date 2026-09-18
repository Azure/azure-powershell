if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistryNamespaceDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistryNamespaceDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistryNamespaceDevice' {
    It 'Delete' {
        $testConfig = $env.namespaceDeviceTests.deleteTests.Delete
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.deleteTests.jsonFilePath
        
        # Create test device to delete
        New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $jsonFilePath

        # Delete the device
        Remove-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name

        # Verify the device is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentityNamespace' {
        $testConfig = $env.namespaceDeviceTests.deleteTests.DeleteViaIdentityNamespace
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.deleteTests.jsonFilePath
        
        # Create test device to delete
        New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $jsonFilePath

        # Create namespace identity object
        $namespaceIdentity = @{
            SubscriptionId = $env.SubscriptionId
            ResourceGroupName = $resourceGroupName
            NamespaceName = $namespaceName
        }
        
        # Delete the device using namespace identity
        Remove-AzDeviceRegistryNamespaceDevice -NamespaceInputObject $namespaceIdentity -DeviceName $testConfig.name
        
        # Verify the device is deleted by trying to get it (should throw)
        { Get-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $testConfig = $env.namespaceDeviceTests.deleteTests.DeleteViaIdentity
        $namespaceName = $env.namespaceDeviceTests.namespaceName
        $resourceGroupName = $env.namespaceDeviceTests.resourceGroupName
        $jsonFilePath = Join-Path $PSScriptRoot $env.namespaceDeviceTests.deleteTests.jsonFilePath
        
        # Create test device to delete
        $device = New-AzDeviceRegistryNamespaceDevice -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -DeviceName $testConfig.name -JsonFilePath $jsonFilePath

        # Delete the device using the device object as identity
        Remove-AzDeviceRegistryNamespaceDevice -InputObject $device
        
        # Verify the device is deleted by trying to get it using the device object (should throw)
        { Get-AzDeviceRegistryNamespaceDevice -InputObject $device -ErrorAction Stop } | Should -Throw
    }
}
