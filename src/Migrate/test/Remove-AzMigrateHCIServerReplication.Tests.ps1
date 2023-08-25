if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMigrateHCIServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMigrateHCIServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMigrateHCIServerReplication' {
    It 'ByID' {
        { Remove-AzMigrateHCIServerReplication -TargetObjectID $env.hciProtectedItem3 -SubscriptionId $env.hciSubscriptionId } | Should -Not -Throw
    }

    It 'ByInputObject' -skip {
        $obj = Get-AzMigrateHCIServerReplication -TargetObjectID  $env.hciProtectedItem3 -SubscriptionId $env.hciProtectedItem3
        $obj.Count | Should -BeGreaterOrEqual 1
        { Remove-AzMigrateHCIServerReplication -InputObject $obj -SubscriptionId $env.hciProtectedItem3 } | Should -Not -Throw
    }
}
