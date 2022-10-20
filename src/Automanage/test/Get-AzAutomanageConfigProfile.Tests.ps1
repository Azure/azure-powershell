if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAutomanageConfigProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAutomanageConfigProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAutomanageConfigProfile' {
    It 'List1' {
        { Get-AzAutomanageConfigProfile } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzAutomanageConfigProfile -ResourceGroupName automangerg } | Should -Not -Throw
    }

    It 'List' {
        { Get-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name lucas-best-practices-devtest } | Should -Not -Throw
    }
}
