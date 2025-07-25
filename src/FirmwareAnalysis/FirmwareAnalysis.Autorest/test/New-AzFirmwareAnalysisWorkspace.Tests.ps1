if(($null -eq $TestName) -or ($TestName -contains 'New-AzFirmwareAnalysisWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFirmwareAnalysisWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFirmwareAnalysisWorkspace' {
    It 'CreateExpanded' {
        { 
            $config = New-AzFirmwareAnalysisWorkspace -ResourceGroupName 'FirmwareAnalysisRG' -Name 'testworkspace' -Location 'East US'
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
