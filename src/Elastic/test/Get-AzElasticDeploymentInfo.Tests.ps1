if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticDeploymentInfo'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticDeploymentInfo.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticDeploymentInfo' {
    It 'List' {
        {
            Get-AzElasticDeploymentInfo -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
        } | Should -Not -Throw
    }

    It 'ListViaIdentityMonitor' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
            Get-AzElasticDeploymentInfo -MonitorInputObject $monitor
        } | Should -Not -Throw
    }
}
