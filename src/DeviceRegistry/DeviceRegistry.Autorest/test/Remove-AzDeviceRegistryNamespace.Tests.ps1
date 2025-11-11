if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistryNamespace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistryNamespace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistryNamespace' {
    It 'Delete' {
        $namespaceTestParams = $env.namespaceTests.deleteTests.Delete
        $jsonFilePath = (Join-Path $PSScriptRoot $namespaceTestParams.jsonFilePath)
        New-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        Remove-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup
        { Get-AzDeviceRegistryNamespace -ResourceGroupName $env.resourceGroup -Name $namespaceTestParams.name -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $namespaceTestParams = $env.namespaceTests.deleteTests.DeleteViaIdentity
        $jsonFilePath = (Join-Path $PSScriptRoot $namespaceTestParams.jsonFilePath)
        $namespace = New-AzDeviceRegistryNamespace -Name $namespaceTestParams.name -ResourceGroupName $env.resourceGroup -JsonFilePath $jsonFilePath
        Remove-AzDeviceRegistryNamespace -InputObject $namespace
        { Get-AzDeviceRegistryNamespace -InputObject $namespace -ErrorAction Stop } | Should -Throw
    }
}
