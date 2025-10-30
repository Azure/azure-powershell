if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFirmwareAnalysisFirmware'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFirmwareAnalysisFirmware.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFirmwareAnalysisFirmware' {
    It 'UpdateExpanded' {
        { 
            $config = Update-AzFirmwareAnalysisFirmware -FirmwareId $env.FirmwareId -ResourceGroupName $env.ResourceGroup -WorkspaceName $env.WorkspaceName -FileName 'newFile' -Vendor 'newVendor'
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
