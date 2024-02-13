if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorGitHubOwnerAvailable'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorGitHubOwnerAvailable.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorGitHubOwnerAvailable' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $owners = Get-AzSecurityConnectorGitHubOwnerAvailable -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gh-01"
        $owners.Count | Should -BeGreaterThan 0
    }
}
