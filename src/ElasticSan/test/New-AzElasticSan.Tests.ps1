if(($null -eq $TestName) -or ($TestName -contains 'New-AzElasticSan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzElasticSan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzElasticSan' {
    It 'CreateExpanded' {
        $elasticSanName = "testsan" + $env.RandomString
        $elasticSan = New-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName -AvailabilityZone "zone1" -BaseSizeTib $env.BaseSizeTib -ExtendedCapacitySizeTib $env.ExtendedCapacitySizeTib -Location $env.ElasticSanLocation -SkuName "Premium_LRS" -Tag @{tag1="value1";tag2="value2"}
        $elasticSan.Name | Should -Be $elasticSanName
        $elasticSan.BaseSizeTib | Should -Be $env.BaseSizeTib
        $elasticSan.ExtendedCapacitySizeTib | Should -Be $env.ExtendedCapacitySizeTib
        $elasticSan.Tag.Count | Should -BeGreaterOrEqual 2 
    }
}
