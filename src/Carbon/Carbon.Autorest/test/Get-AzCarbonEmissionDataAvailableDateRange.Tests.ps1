if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCarbonEmissionDataAvailableDateRange'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCarbonEmissionDataAvailableDateRange.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCarbonEmissionDataAvailableDateRange' {
    It 'Get' {
        $response = Get-AzCarbonEmissionDataAvailableDateRange
        $response | Should -Not -Be $null
        $response.startDate | Should -Not -Be $null
        $response.endDate | Should -Not -Be $null
        $response.startDate | Should -Be "2024-03-01"
        $response.endDate | Should -Be "2025-03-01"
    }
}
