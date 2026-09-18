if(($null -eq $TestName) -or ($TestName -contains 'Add-AzGuestSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..' 'loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzGuestSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Add-AzGuestSubscription' {
    It 'CreateExpanded' {
        $result = Add-AzGuestSubscription -Location $env.Location -Id $env.GuestSubscriptionId
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $env.GuestSubscriptionId
        $result.ProvisioningState | Should -Be 'Succeeded'
    }
}
