if(($null -eq $TestName) -or ($TestName -contains 'New-AzMigrateHCIDiskMapping'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateHCIDiskMapping.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMigrateHCIDiskMapping' {
    It '__AllParameterSets' {
        $output = New-AzMigrateHCIDiskMapping -DiskID a -IsOSDisk true -IsDynamic true -Size 1 -Format VHDX
        $output.Count | Should -BeGreaterOrEqual 1 
        $output.DiskId | Should -Be a
    }
}
