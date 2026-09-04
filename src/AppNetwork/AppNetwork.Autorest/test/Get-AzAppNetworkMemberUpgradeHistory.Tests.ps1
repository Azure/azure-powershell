if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppNetworkMemberUpgradeHistory'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppNetworkMemberUpgradeHistory.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppNetworkMemberUpgradeHistory' {
    It 'List' {
        # List upgrade history for the member; should not throw (may be empty).
        { Get-AzAppNetworkMemberUpgradeHistory -AppLinkName $env.appLinkName -AppLinkMemberName $env.memberName -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }
}
