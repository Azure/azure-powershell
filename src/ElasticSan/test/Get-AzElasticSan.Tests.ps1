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

        $elasticSan = Get-AzElasticSan -ResourceGroupName $env.ResourceGroupName2 -Name $env.ElasticSanName3
        $elasticSan.PrivateEndpointConnection.Count | Should -Be 3
        $elasticSan.PrivateEndpointConnection[0].name | Should -BeLike "testvg1*"
        $elasticSan.PrivateEndpointConnection[0].PrivateLinkServiceConnectionStateStatus | Should -Be "Approved"
        $elasticSan.PrivateEndpointConnection[0].PrivateEndpointId | Should -BeLike "*yifanz1*testconnection3*"
        $elasticSan.PrivateEndpointConnection.GroupId | Should -Contain "testvg1"
        $elasticSan.PrivateEndpointConnection[1].name | Should -BeLike "testvg1*"
        $elasticSan.PrivateEndpointConnection[1].PrivateLinkServiceConnectionStateStatus | Should -Be "Approved"
        $elasticSan.PrivateEndpointConnection[1].PrivateEndpointId | Should -BeLike "*yifanz1*testconnection1*"
        $elasticSan.PrivateEndpointConnection.GroupId | Should -Contain "testvg1"
        $elasticSan.PrivateEndpointConnection[2].name | Should -BeLike "testvg1*"
        $elasticSan.PrivateEndpointConnection[2].PrivateLinkServiceConnectionStateStatus | Should -Be "Pending"
        $elasticSan.PrivateEndpointConnection[2].PrivateEndpointId | Should -BeLike "*yifanz1*testconnection2*"
        $elasticSan.PrivateEndpointConnection.GroupId | Should -Contain "testvg1"
    }

    It 'List1' {
        $elasticSanList = Get-AzElasticSan -ResourceGroupName $env.ResourceGroupName
        $elasticSanList.Count | Should -BeGreaterOrEqual 1
    }
}
