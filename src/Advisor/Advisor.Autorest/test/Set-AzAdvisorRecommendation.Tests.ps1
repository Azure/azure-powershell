if(($null -eq $TestName) -or ($TestName -contains 'Set-AzAdvisorRecommendation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzAdvisorRecommendation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzAdvisorRecommendation' {
    It 'CreateByLCT' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateByRG' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateByInputObject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
