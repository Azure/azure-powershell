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
    It 'ByID' -skip {
        { Remove-AzMigrateHCIServerReplication -TargetObjectID $env.asrv2ProtectedItemId -SubscriptionId $env.asrv2SubscriptionId } | Should -Not -Throw
    }

    It 'ByInputObject' -skip {
        $obj = Get-AzMigrateHCIServerReplication -TargetObjectID  $env.asrv2ProtectedItemId -SubscriptionId $env.asrv2ProtectedItemId
        $obj.Count | Should -BeGreaterOrEqual 1
        { Remove-AzMigrateHCIServerReplication -InputObject $obj -SubscriptionId $env.asrv2ProtectedItemId } | Should -Not -Throw
    }
}
