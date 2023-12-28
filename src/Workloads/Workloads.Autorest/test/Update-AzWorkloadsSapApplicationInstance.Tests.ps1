if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWorkloadsSapApplicationInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWorkloadsSapApplicationInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWorkloadsSapApplicationInstance' {
    It 'UpdateExpanded' {
        $tags = @{ $env.TestType = $env.TestTypeValue}
        $appInstance = Update-AzWorkloadsSapApplicationInstance -SubscriptionId $env.WaaSSubscriptionId -Name $env.SapApplicationInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Tag $tags
        $appInstance.Tag.Count | Should -BeGreaterOrEqual 1
    }

    It 'UpdateViaIdentityExpanded' {
        $tags = @{ $env.TestType = $env.TestTypeValue}
        $appInstance = Update-AzWorkloadsSapApplicationInstance -InputObject $env.AppServerIdSub2 -Tag $tags
        $appInstance.Tag.Count | Should -BeGreaterOrEqual 1
    }
}
