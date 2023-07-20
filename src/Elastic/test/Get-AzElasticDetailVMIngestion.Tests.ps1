if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticDetailVMIngestion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticDetailVMIngestion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticDetailVMIngestion' {
    It 'Details' {
        {
            Get-AzElasticDetailVMIngestion -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
        } | Should -Not -Throw
    }

    It 'DetailsViaIdentity' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
            Get-AzElasticDetailVMIngestion -InputObject $monitor
        } | Should -Not -Throw
    }
}
