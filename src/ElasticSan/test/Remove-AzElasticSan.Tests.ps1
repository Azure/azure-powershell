if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzElasticSan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzElasticSan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzElasticSan' {
    It 'Delete' {
        $elasticSanName = "testsan5" + $env.RandomString
        $elasticSan = New-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName -BaseSizeTib $env.BaseSizeTib -ExtendedCapacitySizeTib $env.ExtendedCapacitySizeTib -Location $env.ElasticSanLocation -SkuName "Premium_LRS" 
        Remove-AzElasticSan -ResourceGroupName $env.ResourceGroupName -Name $elasticSanName
        $elasticSanList = Get-AzElasticSan
        $elasticSanList.Name | Should -Not -Contain $elasticSanName
    }
}
