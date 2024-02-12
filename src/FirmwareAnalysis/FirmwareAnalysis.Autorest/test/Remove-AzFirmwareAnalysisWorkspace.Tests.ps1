if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFirmwareAnalysisWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFirmwareAnalysisWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFirmwareAnalysisWorkspace' {
    It 'Delete' {
        { 
            $config = Remove-AzFirmwareAnalysisWorkspace -ResourceGroupName 'FirmwareAnalysisRG' -Name 'testworkspace1'
            $config.Count | Should -eq 0
        } | Should -Not -Throw
    }
}
