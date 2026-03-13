if(($null -eq $TestName) -or ($TestName -contains 'Get-AzGuestSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..' 'loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzGuestSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzGuestSubscription' {
    It 'List' {
        {
            Get-AzGuestSubscription -Location $env.Location
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzGuestSubscription -Location $env.Location -GuestSubscriptionId $env.GuestSubscriptionId
        } | Should -Not -Throw
    }
}
