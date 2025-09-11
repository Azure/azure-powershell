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

Describe 'New/Remove ElasticSan' {
    It 'CreateExpanded' {
        $elasticSanName = "testsan" + $env.RandomString
        $elasticSan = New-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName -BaseSizeTib $env.BaseSizeTib -ExtendedCapacitySizeTib $env.ExtendedCapacitySizeTib -Location $env.ElasticSanLocation -SkuName "Premium_LRS" -Tag @{tag1="value1";tag2="value2"} -CapacityUnitScaleUpLimitTiB 24 -IncreaseCapacityUnitByTiB 1 -UnusedSizeTiB 5 -AutoScalePolicyEnforcement Enabled
        $elasticSan.Name | Should -Be $elasticSanName
        $elasticSan.BaseSizeTib | Should -Be $env.BaseSizeTib
        $elasticSan.ExtendedCapacitySizeTib | Should -Be $env.ExtendedCapacitySizeTib
        $elasticSan.Tag.Count | Should -BeGreaterOrEqual 2 
        $elasticSan.CapacityUnitScaleUpLimitTiB | Should -Be 24 
        $elasticSan.IncreaseCapacityUnitByTiB | Should -Be 1 
        $elasticSan.UnusedSizeTiB | Should -Be 5
        $elasticSan.AutoScalePolicyEnforcement | Should -Be "Enabled"

        $elasticSan = Update-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName -BaseSizeTib 2 -ExtendedCapacitySizeTib 7 -Tag @{"tag3" = "value3"} -CapacityUnitScaleUpLimitTiB 20 -IncreaseCapacityUnitByTiB 2 -UnusedSizeTiB 5 -AutoScalePolicyEnforcement Disabled
        $elasticSan.Name | Should -Be $elasticSanName
        $elasticSan.BaseSizeTib | Should -Be 2 
        $elasticSan.ExtendedCapacitySizeTib | Should -Be 7 
        $elasticSan.Tag.Count | Should -BeGreaterOrEqual 1 
        $elasticSan.CapacityUnitScaleUpLimitTiB | Should -Be 20
        $elasticSan.IncreaseCapacityUnitByTiB | Should -Be 2 
        $elasticSan.UnusedSizeTiB | Should -Be 5
        $elasticSan.AutoScalePolicyEnforcement | Should -Be "Disabled"

        Remove-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName
        $elasticSanList = Get-AzElasticSan
        $elasticSanList.Name | Should -Not -Contain $elasticSanName
    }
}
