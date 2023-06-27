if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWorkloadsSapVirtualInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWorkloadsSapVirtualInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWorkloadsSapVirtualInstance' {
    It 'UpdateExpanded' {
        $tags = @{ $env.TestType = $env.TestTypeValue}
        $sapInstance = Update-AzWorkloadsSapVirtualInstance -SubscriptionId $env.WaaSSubscriptionId  -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -Tag $tags
        $sapInstance.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'UpdateViaIdentityExpanded' {
        $tags = @{ $env.TestType = $env.TestTypeValue}
        $dbInstance = Update-AzWorkloadsSapVirtualInstance -InputObject $env.SapId -Tag $tags
        $dbInstance.Tag.Count | Should -BeGreaterOrEqual 1
    }
}
