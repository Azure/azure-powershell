if(($null -eq $TestName) -or ($TestName -contains 'New-AzMetricFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMetricFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMetricFilter' {
    It '__AllParameterSets' {
        {
            $expect = "City eq 'Seattle' or City eq 'New York'"
            $string = New-AzMetricFilter -Dimension City -Operator eq -Value "Seattle","New York"
            $string | Should -Be $expect
        } | Should -Not -Throw
    }
}
