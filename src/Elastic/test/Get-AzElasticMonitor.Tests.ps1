if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticMonitor' {
    It 'List' {
        $elasticList = Get-AzElasticMonitor 
        $elasticList.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01
        $elastic.Name | Should -Be $env.elasticName01
    }

    It 'List1' {
        $elasticList = Get-AzElasticMonitor -ResourceGroup $env.resourceGroup
        $elasticList.Count | Should -BeGreaterOrEqual 2
    }

    It 'GetViaIdentity' {
        $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01
        Get-AzElasticMonitor -InputObject $elastic
        $elastic.Name | Should -Be $env.elasticName01
    }
}
