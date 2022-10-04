if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticSan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticSan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticSan' {
    It 'List' {
        $elasticSanList = Get-AzElasticSan
        $elasticSanList.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $elasticSan = Get-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $env.ElasticSanName1
        $elasticSan.Name | Should -Be $env.ElasticSanName1
        $elasticSan.BaseSizeTib | Should -Be $env.BaseSizeTib
        $elasticSan.ExtendedCapacitySizeTib | Should -Be $env.ExtendedCapacitySizeTib
        $elasticSan.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'List1' {
        $elasticSanList = Get-AzElasticSan -ResourceGroupName $env.ResourceGroupName
        $elasticSanList.Count | Should -BeGreaterOrEqual 1
    }
}
