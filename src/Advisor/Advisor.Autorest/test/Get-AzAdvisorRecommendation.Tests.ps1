if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAdvisorRecommendation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAdvisorRecommendation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAdvisorRecommendation' {
    It 'ListByName' {
        $recommendations = Get-AzAdvisorRecommendation -ResourceGroupName $env.resourceGroup -Category Security
        $recommendations.Count | Should -BeGreaterOrEqual 1
    }

    It 'ListById' {
        $recommendations = Get-AzAdvisorRecommendation -ResourceId $env.recommendationResourceId  -Category Security
        $recommendations.Count | Should -BeGreaterOrEqual 1
    }

    It 'ListByFilter' {
        $recommendations = Get-AzAdvisorRecommendation -Filter "Category eq 'Security'"
        $recommendations.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetById' {
        $recommendations = Get-AzAdvisorRecommendation -Id $env.recommendationName -ResourceUri $env.ResourceUri
        $recommendations.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity1' -skip {
        $recommendations = Get-AzAdvisorRecommendation -Id $env.recommendationName -ResourceUri $env.ResourceUri
        $recommendations2 = $recommendations | Get-AzAdvisorRecommendation -Input
        $recommendations.Count | Should -BeGreaterOrEqual 1
    }

}
