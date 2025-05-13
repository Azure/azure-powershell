if(($null -eq $TestName) -or ($TestName -contains 'Initialize-AzMigrateLocalReplicationInfrastructure'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Initialize-AzMigrateLocalReplicationInfrastructure.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Initialize-AzMigrateLocalReplicationInfrastructure' -Tag 'LiveOnly' {
    It 'Default' {
        $output = Initialize-AzMigrateLocalReplicationInfrastructure `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId `
            -SourceApplianceName $env.hciSourceApplianceName `
            -TargetApplianceName $env.hciTargetApplianceName `
            -PassThru
        $output | Should -Be $true
    }
}
