if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWorkloadsSapDatabaseInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWorkloadsSapDatabaseInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWorkloadsSapDatabaseInstance' {
    It 'UpdateExpanded' {
        $tags = @{ $env.TestType = $env.TestTypeValue}
        $dbInstance = Update-AzWorkloadsSapDatabaseInstance -SubscriptionId $env.WaaSSubscriptionId  -Name $env.SapDatabseInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Tag $tags
        $dbInstance.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'UpdateViaIdentityExpanded' {
        $tags = @{ $env.TestType = $env.TestTypeValue}
        $dbInstance = Update-AzWorkloadsSapDatabaseInstance -InputObject $env.DbServerIdSub2 -Tag $tags
        $dbInstance.Tag.Count | Should -BeGreaterOrEqual 1
    }
}
