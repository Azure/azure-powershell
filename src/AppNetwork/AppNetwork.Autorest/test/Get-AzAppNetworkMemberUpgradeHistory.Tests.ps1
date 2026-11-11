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
    # Upgrade-history coverage lives in the consolidated New-AzAppNetworkMember lifecycle
    # test, which creates a member, reads it, then deletes it (one live member per AKS cluster).
    It 'List' -skip {
        # List upgrade history for the member; should not throw (may be empty).
        { Get-AzAppNetworkMemberUpgradeHistory -AppLinkName $env.appLinkName -AppLinkMemberName $env.memberName -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }
}
