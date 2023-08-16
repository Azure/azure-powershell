if(($null -eq $TestName) -or ($TestName -contains 'Initialize-AzMigrateHCIReplicationInfrastructure'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Initialize-AzMigrateHCIReplicationInfrastructure.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Initialize-AzMigrateHCIReplicationInfrastructure' {
    It 'Default' -skip {
        $output = Initialize-AzMigrateHCIReplicationInfrastructure `
            -ProjectName $env.asrv2ProjectName `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -SubscriptionId $env.asrv2SubscriptionId `
            -SourceApplianceName $env.asrv2SourceApplianceName `
            -TargetApplianceName $env.asrv2TargetApplianceName `
            -PassThru
        $output | Should -Be $true
    }
}
