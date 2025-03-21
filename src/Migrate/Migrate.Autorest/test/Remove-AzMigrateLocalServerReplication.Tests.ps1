if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMigrateLocalServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMigrateLocalServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMigrateLocalServerReplication' {
    It 'ByID' {
        { Remove-AzMigrateLocalServerReplication -TargetObjectID $env.hciProtectedItem1 -SubscriptionId $env.hciSubscriptionId -ForceRemove "true" } | Should -Not -Throw
    }

    It 'ByInputObject' {
        $obj = Get-AzMigrateLocalServerReplication -TargetObjectID  $env.hciProtectedItem2 -SubscriptionId $env.hciSubscriptionId
        $obj.Count | Should -BeGreaterOrEqual 1
        { Remove-AzMigrateLocalServerReplication -InputObject $obj -SubscriptionId $env.hciSubscriptionId -ForceRemove "true" } | Should -Not -Throw
    }
}
