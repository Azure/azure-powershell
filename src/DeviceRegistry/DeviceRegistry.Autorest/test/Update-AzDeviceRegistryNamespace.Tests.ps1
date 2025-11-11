if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistryNamespace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistryNamespace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistryNamespace' {
    It 'UpdateExpanded' {
        $namespaceTestParams = $env.namespaceTests.updateTests.UpdateExpanded
        $jsonFilePath = (Join-Path $PSScriptRoot $env.namespaceTests.updateTests.createJsonFilePath)
        New-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath

        $patchBody = @{
            "myendpoint1" = @{
                "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                "address" = "https://myendpoint1.westeurope-1.iothub.azure.net"
                "endpointType" = "Microsoft.Devices/IotHubs"
            }
        }
        $namespace = Update-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup -Name $namespaceTestParams.name -MessagingEndpoint $patchBody
        $namespace.Name | Should -Be $namespaceTestParams.name
        $namespace.ResourceGroupName | Should -Be $env.resourceGroup
        $namespace.Location | Should -Be $env.location
        $key1 = $env.namespaceTests.updateTests.key1
        $endpoints = $env.namespaceTests.updateTests.endpoints
        $namespace.MessagingEndpoint.Count | Should -Be 1
        $namespace.MessagingEndpoint[$key1].endpointType | Should -Be $endpoints.myendpoint1.endpointType
        $namespace.MessagingEndpoint[$key1].address | Should -Be $endpoints.myendpoint1.address
        $namespace.MessagingEndpoint[$key1].resourceId | Should -Be $endpoints.myendpoint1.resourceId
    }

    It 'UpdateViaIdentityExpanded' {
        $namespaceTestParams = $env.namespaceTests.updateTests.UpdateViaJsonFilePath
        $jsonFilePath = (Join-Path $PSScriptRoot $env.namespaceTests.updateTests.createJsonFilePath)
        $namespaceIdentity = New-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        $patchBody = @{
            "myendpoint1" = @{
                "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                "address" = "https://myendpoint1.westeurope-1.iothub.azure.net"
                "endpointType" = "Microsoft.Devices/IotHubs"
            }
        }
        $namespace = Update-AzDeviceRegistryNamespace -InputObject $namespaceIdentity -MessagingEndpoint $patchBody

        $namespace.Name | Should -Be $namespaceTestParams.name
        $namespace.ResourceGroupName | Should -Be $env.resourceGroup
        $namespace.Location | Should -Be $env.location
        $key1 = $env.namespaceTests.updateTests.key1
        $endpoints = $env.namespaceTests.updateTests.endpoints
        $namespace.MessagingEndpoint.Count | Should -Be 1
        $namespace.MessagingEndpoint[$key1].endpointType | Should -Be $endpoints.myendpoint1.endpointType
        $namespace.MessagingEndpoint[$key1].address | Should -Be $endpoints.myendpoint1.address
        $namespace.MessagingEndpoint[$key1].resourceId | Should -Be $endpoints.myendpoint1.resourceId
    }
}
