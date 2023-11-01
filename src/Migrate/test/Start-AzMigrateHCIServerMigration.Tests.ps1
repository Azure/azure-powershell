if(($null -eq $TestName) -or ($TestName -contains 'Start-AzMigrateHCIServerMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzMigrateHCIServerMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzMigrateHCIServerMigration' {
    It 'ByID' {
        { Start-AzMigrateHCIServerMigration -TargetObjectID $env.hciProtectedItem1 -SubscriptionId $env.hciSubscriptionId } | Should -Not -Throw
    }

    It 'ByInputObject' {
        $obj = Get-AzMigrateHCIServerReplication -TargetObjectID  $env.hciProtectedItem2 -SubscriptionId $env.hciSubscriptionId
        $obj.Count | Should -BeGreaterOrEqual 1
        { Start-AzMigrateHCIServerMigration -InputObject $obj -SubscriptionId $env.hciSubscriptionId } | Should -Not -Throw
    }
}
