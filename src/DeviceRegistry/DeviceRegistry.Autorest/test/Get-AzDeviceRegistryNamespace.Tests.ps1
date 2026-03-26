if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryNamespace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryNamespace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryNamespace' {
    It 'List' {
        $namespaceTestParams = $env.namespaceTests.getTests.List
        $jsonFilePath = (Join-Path $PSScriptRoot $namespaceTestParams.jsonFilePath)

        for ($i = 0; $i -lt $namespaceTestParams.names.Count; $i++) {
            New-AzDeviceRegistryNamespace -Name $namespaceTestParams.names[$i] -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        }

        $listOfNamespaces = Get-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup

        # The resource group should contain at least 2 namespaces
        $listOfNamespaces.Count -ge 2 | Should -Be $true
    }

    It 'Get' {
        $namespaceTestParams = $env.namespaceTests.getTests.Get
        $jsonFilePath = (Join-Path $PSScriptRoot $namespaceTestParams.jsonFilePath)
        New-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath

        $namespace = Get-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup -Name $namespaceTestParams.name

        $namespace.Name | Should -Be $namespaceTestParams.name
        $namespace.ResourceGroupName | Should -Be $env.resourceGroup
        $namespace.Location | Should -Be $env.location
        $key1 = $namespaceTestParams.key1
        $key2 = $namespaceTestParams.key2
        $endpoints = $namespaceTestParams.endpoints
        $namespace.MessagingEndpoint[$key1].endpointType | Should -Be $endpoints.myendpoint1.endpointType
        $namespace.MessagingEndpoint[$key1].address | Should -Be $endpoints.myendpoint1.address
        $namespace.MessagingEndpoint[$key1].resourceId | Should -Be $endpoints.myendpoint1.resourceId
        $namespace.MessagingEndpoint[$key2].endpointType | Should -Be $endpoints.myendpoint2.endpointType
        $namespace.MessagingEndpoint[$key2].address | Should -Be $endpoints.myendpoint2.address
        $namespace.MessagingEndpoint[$key2].resourceId | Should -Be $endpoints.myendpoint2.resourceId
    }

    It 'GetViaIdentity' {
        $namespaceTestParams = $env.namespaceTests.getTests.GetViaIdentity
        $jsonFilePath = (Join-Path $PSScriptRoot $namespaceTestParams.jsonFilePath)
        $namespaceIdentity = New-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath

        $namespace = Get-AzDeviceRegistryNamespace -InputObject $namespaceIdentity

        $namespace.Name | Should -Be $namespaceTestParams.name
        $namespace.ResourceGroupName | Should -Be $env.resourceGroup
        $namespace.Location | Should -Be $env.location
        $key1 = $namespaceTestParams.key1
        $key2 = $namespaceTestParams.key2
        $endpoints = $namespaceTestParams.endpoints
        $namespace.MessagingEndpoint[$key1].endpointType | Should -Be $endpoints.myendpoint1.endpointType
        $namespace.MessagingEndpoint[$key1].address | Should -Be $endpoints.myendpoint1.address
        $namespace.MessagingEndpoint[$key1].resourceId | Should -Be $endpoints.myendpoint1.resourceId
        $namespace.MessagingEndpoint[$key2].endpointType | Should -Be $endpoints.myendpoint2.endpointType
        $namespace.MessagingEndpoint[$key2].address | Should -Be $endpoints.myendpoint2.address
        $namespace.MessagingEndpoint[$key2].resourceId | Should -Be $endpoints.myendpoint2.resourceId
    }
}
