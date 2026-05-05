if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageCacheAmlFileSystemSubnetRequiredSize'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageCacheAmlFileSystemSubnetRequiredSize.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageCacheAmlFileSystemSubnetRequiredSize' {
    It 'GetExpanded' {
        {
            # Retrieve the required subnet size for the AML file system
            $result = Get-AzStorageCacheAmlFileSystemSubnetRequiredSize -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16
            $result | Should -Not -Be $null
            $result.FilesystemSubnetSize | Should -BeOfType [int]
            $result.FilesystemSubnetSize | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
