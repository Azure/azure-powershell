if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFirmwareAnalysisWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFirmwareAnalysisWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFirmwareAnalysisWorkspace' {
    It 'List' {
        { 
            $config = Get-AzFirmwareAnalysisWorkspace -ResourceGroupName 'FirmwareAnalysisRG'
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        { 
            $config = Get-AzFirmwareAnalysisWorkspace -ResourceGroupName 'FirmwareAnalysisRG' -WorkspaceName 'default'
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}