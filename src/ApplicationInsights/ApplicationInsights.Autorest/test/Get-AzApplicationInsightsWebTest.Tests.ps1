if(($null -eq $TestName) -or ($TestName -contains 'Get-AzApplicationInsightsWebTest'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationInsightsWebTest.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzApplicationInsightsWebTest' {
    It 'List1' {
        $webTestList = Get-AzApplicationInsightsWebTest
        $webTestList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $webTest = Get-AzApplicationInsightsWebTest -ResourceGroupName $env.resourceGroup -Name $env.standardWebTest01
        $webTest.Name | Should -Be $env.standardWebTest01
    }

    It 'List2' {
        $webTestList = Get-AzApplicationInsightsWebTest -ResourceGroupName $env.resourceGroup
        $webTestList.Count | Should -BeGreaterOrEqual 1
    }

    It 'List' {
        $webTest = Get-AzApplicationInsightsWebTest -ResourceGroupName $env.resourceGroup -AppInsightsName $env.appInsights01
        $webTest.Name | Should -Be $env.standardWebTest01

    }

    It 'GetViaIdentity' {
        $webTest = Get-AzApplicationInsightsWebTest -ResourceGroupName $env.resourceGroup -Name $env.standardWebTest01
        $webTest = Get-AzApplicationInsightsWebTest -InputObject $webTest
        $webTest.Name | Should -Be $env.standardWebTest01
    }
}
