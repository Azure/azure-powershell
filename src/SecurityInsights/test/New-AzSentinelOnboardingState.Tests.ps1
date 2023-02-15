if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelOnboardingState'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelOnboardingState.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelOnboardingState' {
    It 'CreateExpanded' -skip {
        { New-AzSentinelOnboardingState -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.newOnboardingStateWS -Name "default" } | Should -Not -Throw
    }
}
 