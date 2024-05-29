if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFirmwareAnalysisFirmware'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFirmwareAnalysisFirmware.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFirmwareAnalysisFirmware' {
    It 'Delete' {
        { 
            $config = Remove-AzFirmwareAnalysisFirmware -Id 'd46d4be7-12bc-4fb2-82ea-fa460c2c4c7e' -ResourceGroupName 'FirmwareAnalysisRG' -WorkspaceName 'default'
            $config.Count | Should -eq 0
        } | Should -Not -Throw
    }
}
