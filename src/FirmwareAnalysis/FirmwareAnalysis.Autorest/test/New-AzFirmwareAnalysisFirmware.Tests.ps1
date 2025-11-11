if(($null -eq $TestName) -or ($TestName -contains 'New-AzFirmwareAnalysisFirmware'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFirmwareAnalysisFirmware.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFirmwareAnalysisFirmware' {
    It 'CreateExpanded' {
        { 
            $config = New-AzFirmwareAnalysisFirmware -Id $env.FirmwareId -ResourceGroupName $env.ResourceGroup -WorkspaceName $env.WorkspaceName -Description 'description' -FileSize 1  -FileName 'file' -Vendor 'vendor' -Model 'model' -Version 'version'
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
