if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzAdvisorRecommendation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzAdvisorRecommendation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzAdvisorRecommendation' {
    It 'IdParameterSet' {
        $Advisor =  Enable-AzAdvisorRecommendation -ResourceId $env.recommendationId
        $Advisor.Count | Should -BeGreaterOrEqual 1
    }

    It 'NameParameterSet' {
        $Advisor =  Enable-AzAdvisorRecommendation -RecommendationName $env.recommendationName
        $Advisor.Count | Should -BeGreaterOrEqual 1
    }

    It 'InputObjectParameterSet' {
        $recommendations = Get-AzAdvisorRecommendation -Id $env.recommendationName -ResourceUri $env.ResourceUri
        $Advisor =  $recommendations | Enable-AzAdvisorRecommendation
        $Advisor.Count | Should -BeGreaterOrEqual 1
    }
}
