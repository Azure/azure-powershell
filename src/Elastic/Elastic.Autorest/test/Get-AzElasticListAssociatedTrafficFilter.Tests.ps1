if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticListAssociatedTrafficFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticListAssociatedTrafficFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticListAssociatedTrafficFilter' {
    It 'List' {
        { Get-AzElasticListAssociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 } | Should -Not -Throw
    }
}
