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
        
        $elasticSan = New-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName -Location $env.ElasticSanLocation -SkuName "Premium_LRS" -AvailabilityZone 1 -CapacityUnitScaleUpLimitTiB 24 -IncreaseCapacityUnitByTiB 1 -UnusedSizeTiB 5 -AutoScalePolicyEnforcement Enabled
        $elasticSan.Name | Should -Be $elasticSanName
        $elasticSan.BaseSizeTib | Should -Be 20
        $elasticSan.ExtendedCapacitySizeTib | Should -Be 0
        # $elasticSan.CapacityUnitScaleUpLimitTiB | Should -Be 24
        # $elasticSan.IncreaseCapacityUnitByTiB | Should -Be 1
        # $elasticSan.UnusedSizeTiB | Should -Be 5
        # $elasticSan.AutoScalePolicyEnforcement | Should -Be "Enabled"

        $elasticSan = Get-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName
        $elasticSan.Name | Should -Be $elasticSanName
        $elasticSan.BaseSizeTib | Should -Be 20
        $elasticSan.ExtendedCapacitySizeTib | Should -Be 0
        $elasticSan.CapacityUnitScaleUpLimitTiB | Should -Be 24
        $elasticSan.IncreaseCapacityUnitByTiB | Should -Be 1
        $elasticSan.UnusedSizeTiB | Should -Be 5
        $elasticSan.AutoScalePolicyEnforcement | Should -Be "Enabled"

        $elasticSan = Update-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName -CapacityUnitScaleUpLimitTiB 30 -IncreaseCapacityUnitByTiB 2 -UnusedSizeTiB 6 -AutoScalePolicyEnforcement Disabled
        $elasticSan.Name | Should -Be $elasticSanName
        $elasticSan.CapacityUnitScaleUpLimitTiB | Should -Be 30
        $elasticSan.IncreaseCapacityUnitByTiB | Should -Be 2
        $elasticSan.UnusedSizeTiB | Should -Be 6
        $elasticSan.AutoScalePolicyEnforcement | Should -Be "Disabled"

        Remove-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName
        $elasticSanList = Get-AzElasticSan
        $elasticSanList.Name | Should -Not -Contain $elasticSanName

        $elasticSan = New-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName -BaseSizeTib $env.BaseSizeTib -ExtendedCapacitySizeTib $env.ExtendedCapacitySizeTib -Location $env.ElasticSanLocation -SkuName "Premium_LRS" -AvailabilityZone 1 -Tag @{tag1="value1";tag2="value2"} 
        $elasticSan.Name | Should -Be $elasticSanName
        $elasticSan.BaseSizeTib | Should -Be $env.BaseSizeTib
        $elasticSan.ExtendedCapacitySizeTib | Should -Be $env.ExtendedCapacitySizeTib
        $elasticSan.Tag.Count | Should -BeGreaterOrEqual 2 

        Remove-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName
        $elasticSanList = Get-AzElasticSan
        $elasticSanList.Name | Should -Not -Contain $elasticSanName
    }
}
