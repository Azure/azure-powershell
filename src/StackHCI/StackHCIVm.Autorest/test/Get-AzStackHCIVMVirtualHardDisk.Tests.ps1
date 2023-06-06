if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStackHCIVMVirtualHardDisk'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStackHCIVMVirtualHardDisk.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStackHCIVMVirtualHardDisk' {
    It 'ByResourceId' {
        Get-AzStackHCIVMVirtualHardDisk -ResourceId $env.vhdResourceId | Should -Not -BeNullOrEmpty
    }
}
