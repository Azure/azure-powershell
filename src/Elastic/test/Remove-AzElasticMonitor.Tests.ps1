if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzElasticMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzElasticMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzElasticMonitor' {
    It 'Delete' {
        New-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName04 -Location $env.location -Sku $env.sku -UserInfoEmailAddress $env.userEmail
        Remove-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName04
        $elasticList = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup
        $elasticList.Name | Should -Not -Contain $env.elasticName04
        
    }

    It 'DeleteViaIdentity' {
        $elastic = New-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName05 -Location $env.location -Sku $env.sku -UserInfoEmailAddress $env.userEmail
        Remove-AzElasticMonitor -InputObject $elastic
        $elasticList = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup
        $elasticList.Name | Should -Not -Contain $env.elasticName05   
     }
}
