if(($null -eq $TestName) -or ($TestName -contains 'Update-AzElasticSan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzElasticSan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzElasticSan' {
    It 'UpdateExpanded' {
        $elasticSan = Update-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $env.ElasticSanName1 -BaseSizeTib 2 -ExtendedCapacitySizeTib 7 -Tag @{"tag3" = "value3"}
        $elasticSan.Name | Should -Be $env.ElasticSanName1 
        $elasticSan.BaseSizeTib | Should -Be 2 
        $elasticSan.ExtendedCapacitySizeTib | Should -Be 7
        $elasticSan.Tag.Count | Should -Be 1
        $elasticSan.Tag["tag3"] | Should -Be "value3"

        $elasticSan = Get-AzElasticSan  -ResourceGroupName $env.ResourceGroupName -Name $env.ElasticSanName1
        $elasticSan.Name | Should -Be $env.ElasticSanName1 
        $elasticSan.BaseSizeTib | Should -Be 2 
        $elasticSan.ExtendedCapacitySizeTib | Should -Be 7
        $elasticSan.Tag.Count | Should -Be 1
        $elasticSan.Tag["tag3"] | Should -Be "value3"
    }
}
