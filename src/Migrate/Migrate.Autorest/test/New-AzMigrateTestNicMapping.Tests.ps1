if(($null -eq $TestName) -or ($TestName -contains 'New-AzMigrateTestNicMapping'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateTestNicMapping.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMigrateTestNicMapping' {
    It 'VMwareCbt' {
        $output = New-AzMigrateTestNicMapping -NicID "a2399354-653a-464e-a567-d30ef5467a31" -TestNicSubnet "subnet1"
        $output.Count | Should -BeGreaterOrEqual 1
    }
}
