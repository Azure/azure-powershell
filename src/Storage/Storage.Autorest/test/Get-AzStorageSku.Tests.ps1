if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageSku'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageSku.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageSku' {
    It 'List' {
        $skus = Get-AzStorageSku
        $skus.Count | Should -BeGreaterThan 100
        $skus[0].Tier | Should -Not -BeNullOrEmpty
        $skus[0].Kind | Should -Not -BeNullOrEmpty
        $skus[0].Name | SHould -Not -BeNullOrEmpty
        $skus[0].Location.Count -ge 1
    }
}
