if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFirmwareAnalysisFirmware'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFirmwareAnalysisFirmware.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFirmwareAnalysisFirmware' {
    It 'Get' {
        { 
            $config = Get-AzFirmwareAnalysisFirmware -Id $env.FirmwareId -ResourceGroupName $env.ResourceGroup -WorkspaceName $env.WorkspaceName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List' {
        { 
            $config = Get-AzFirmwareAnalysisFirmware -ResourceGroupName $env.ResourceGroup -WorkspaceName $env.WorkspaceName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
