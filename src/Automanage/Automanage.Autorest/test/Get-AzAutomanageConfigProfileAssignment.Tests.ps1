if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAutomanageConfigProfileAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAutomanageConfigProfileAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAutomanageConfigProfileAssignment' {
    It 'List2' {
        { Get-AzAutomanageConfigProfileAssignment} | Should -Not -Throw
    }

    It 'List4' {
        { Get-AzAutomanageConfigProfileAssignment -ResourceGroupName automangerg } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzAutomanageConfigProfileAssignment -ResourceGroupName automangerg -VMName aglinuxvm} | Should -Not -Throw
    }
}
