if(($null -eq $TestName) -or ($TestName -contains 'Disable-AzAdvisorRecommendation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzAdvisorRecommendation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Disable-AzAdvisorRecommendation' {
    It 'IdParameterSet' {
        $Advisor =  Disable-AzAdvisorRecommendation -ResourceId $env.recommendationId -Day 3
        $Advisor.Count | Should -BeGreaterOrEqual 1
    }

    It 'NameParameterSet' {
        $Advisor =  Disable-AzAdvisorRecommendation -RecommendationName $env.recommendationName -Day 3
        $Advisor.Count | Should -BeGreaterOrEqual 1
    }

    It 'InputObjectParameterSet' {
        $recommendations = Get-AzAdvisorRecommendation -Id $env.recommendationName -ResourceUri $env.ResourceUri
        $Advisor =  $recommendations | Disable-AzAdvisorRecommendation
        $Advisor.Count | Should -BeGreaterOrEqual 1
    }
}
