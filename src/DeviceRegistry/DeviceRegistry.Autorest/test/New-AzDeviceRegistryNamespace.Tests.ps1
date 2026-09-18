if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistryNamespace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistryNamespace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistryNamespace' {
    It 'CreateExpanded' {
        $namespaceTestParams = $env.namespaceTests.createTests.CreateExpanded
        $endpoints = $env.namespaceTests.createTests.endpoints
        $endpointsHashtable = @{
            "myendpoint1" = @{
                "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace1"
                "address" = "https://myendpoint1.westeurope-1.iothub.azure.net"
                "endpointType" = "Microsoft.Devices/IotHubs"
            }
            "myendpoint2" = @{
                "resourceId" = "/subscriptions/efb15086-3322-405d-a9d0-c35715a9b722/resourceGroups/adr-pwsh-test-rg/providers/Microsoft.IotHub/namespaces/contoso-hub-namespace2"
                "address" = "https://myendpoint2.westeurope-1.iothub.azure.net"
                "endpointType" = "Microsoft.Devices/IotHubs"
            }
        }

        $namespace = New-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup -Location $env.location -MessagingEndpoint $endpointsHashtable
        
        $namespace.Name | Should -Be $namespaceTestParams.name
        $namespace.ResourceGroupName | Should -Be $env.resourceGroup
        $namespace.Location | Should -Be $env.location
        $key1 = $env.namespaceTests.createTests.key1
        $key2 = $env.namespaceTests.createTests.key2
        $namespace.MessagingEndpoint[$key1].endpointType | Should -Be $endpoints.myendpoint1.endpointType
        $namespace.MessagingEndpoint[$key1].address | Should -Be $endpoints.myendpoint1.address
        $namespace.MessagingEndpoint[$key1].resourceId | Should -Be $endpoints.myendpoint1.resourceId
        $namespace.MessagingEndpoint[$key2].endpointType | Should -Be $endpoints.myendpoint2.endpointType
        $namespace.MessagingEndpoint[$key2].address | Should -Be $endpoints.myendpoint2.address
        $namespace.MessagingEndpoint[$key2].resourceId | Should -Be $endpoints.myendpoint2.resourceId
    }

    It 'CreateViaJsonFilePath' {
        $namespaceTestParams = $env.namespaceTests.createTests.CreateViaJsonFilePath
        $endpoints = $env.namespaceTests.createTests.endpoints
        $jsonFilePath = (Join-Path $PSScriptRoot $namespaceTestParams.jsonFilePath)

        $namespace = New-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        
        $namespace.Name | Should -Be $namespaceTestParams.name
        $namespace.ResourceGroupName | Should -Be $env.resourceGroup
        $namespace.Location | Should -Be $env.location
        $key1 = $env.namespaceTests.createTests.key1
        $key2 = $env.namespaceTests.createTests.key2
        $namespace.MessagingEndpoint[$key1].endpointType | Should -Be $endpoints.myendpoint1.endpointType
        $namespace.MessagingEndpoint[$key1].address | Should -Be $endpoints.myendpoint1.address
        $namespace.MessagingEndpoint[$key1].resourceId | Should -Be $endpoints.myendpoint1.resourceId
        $namespace.MessagingEndpoint[$key2].endpointType | Should -Be $endpoints.myendpoint2.endpointType
        $namespace.MessagingEndpoint[$key2].address | Should -Be $endpoints.myendpoint2.address
        $namespace.MessagingEndpoint[$key2].resourceId | Should -Be $endpoints.myendpoint2.resourceId
    }

    It 'CreateViaJsonString' {
        $namespaceTestParams = $env.namespaceTests.createTests.CreateViaJsonString
        $endpoints = $env.namespaceTests.createTests.endpoints
        $jsonFilePath = (Join-Path $PSScriptRoot $namespaceTestParams.jsonStringFilePath)
        $jsonString = Get-Content -Path $jsonFilePath -Raw

        $namespace = New-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup -JsonString $jsonString

        $namespace.Name | Should -Be $namespaceTestParams.name
        $namespace.ResourceGroupName | Should -Be $env.resourceGroup
        $namespace.Location | Should -Be $env.location
        $key1 = $env.namespaceTests.createTests.key1
        $key2 = $env.namespaceTests.createTests.key2
        $namespace.MessagingEndpoint[$key1].endpointType | Should -Be $endpoints.myendpoint1.endpointType
        $namespace.MessagingEndpoint[$key1].address | Should -Be $endpoints.myendpoint1.address
        $namespace.MessagingEndpoint[$key1].resourceId | Should -Be $endpoints.myendpoint1.resourceId
        $namespace.MessagingEndpoint[$key2].endpointType | Should -Be $endpoints.myendpoint2.endpointType
        $namespace.MessagingEndpoint[$key2].address | Should -Be $endpoints.myendpoint2.address
        $namespace.MessagingEndpoint[$key2].resourceId | Should -Be $endpoints.myendpoint2.resourceId
    }
}
