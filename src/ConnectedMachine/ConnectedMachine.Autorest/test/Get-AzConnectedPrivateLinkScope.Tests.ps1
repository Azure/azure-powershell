if(($null -eq $TestName) -or ($TestName -contains 'Get-AzConnectedPrivateLinkScope'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConnectedPrivateLinkScope.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzConnectedPrivateLinkScope' {
    It 'List' {
        $all = @(Get-AzConnectedPrivateLinkScope -ResourceGroupName $env.ResourceGroupName)
        $all | Should -Not -BeNullOrEmpty
    }

    It 'Get' {
        $all = @(Get-AzConnectedPrivateLinkScope -ResourceGroupName $env.ResourceGroupName -ScopeName $env.PrivateLinkScopeName)
        $all | Should -Not -BeNullOrEmpty
    }
}
