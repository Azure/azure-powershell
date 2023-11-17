if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminUsage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminUsage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminUsage' {
    It 'List' {
        $usage = Get-AzDevCenterAdminUsage -Location $env.location
        $usage.Count | Should -Be 7
        $usage[0].NameValue | Should -Be "devBoxDefinitions"
        $usage[1].NameValue | Should -Be "devCenters"
        $usage[2].NameValue | Should -Be "networkConnections"
        $usage[3].NameValue | Should -Be "pools"
        $usage[4].NameValue | Should -Be "projects"
        $usage[5].NameValue | Should -Be "general_a_v2"
        $usage[6].NameValue | Should -Be "general_i_v2"

    }
}
