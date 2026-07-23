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
            $fwidToDelete = '28960948-fca5-bc38-b261-881ebde4539e' #This was manually uploaded to the workspace to be deleted
            $config = Remove-AzFirmwareAnalysisFirmware -Id $fwidToDelete -ResourceGroupName $env.ResourceGroup -WorkspaceName 'testworkspace'
            $config.Count | Should -eq 0
        } | Should -Not -Throw
    }
}
