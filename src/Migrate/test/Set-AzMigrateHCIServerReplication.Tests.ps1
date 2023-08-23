if(($null -eq $TestName) -or ($TestName -contains 'Set-AzMigrateHCIServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzMigrateHCIServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzMigrateHCIServerReplication' {
    It 'ByID' {
        $output = Set-AzMigrateHCIServerReplication -TargetObjectID $env.hciProtectedItem2 -TargetVMName $env.hciTgtVMNameEdit -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }
}
