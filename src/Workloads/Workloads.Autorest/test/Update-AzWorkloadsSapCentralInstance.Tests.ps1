if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWorkloadsSapCentralInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWorkloadsSapCentralInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWorkloadsSapCentralInstance' {
    It 'UpdateExpanded' {
        $tags = @{ $env.TestType = $env.TestTypeValue}
        $csInstance = Update-AzWorkloadsSapCentralInstance -SubscriptionId $env.WaaSSubscriptionId  -Name $env.SapCentralInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Tag $tags
        $csInstance.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'UpdateViaIdentityExpanded' {
        $tags = @{ $env.TestType = $env.TestTypeValue}
        $csInstance = Update-AzWorkloadsSapCentralInstance -InputObject $env.CsServerIdSub2 -Tag $tags
        $csInstance.Tag.Count | Should -BeGreaterOrEqual 1
    }
}
