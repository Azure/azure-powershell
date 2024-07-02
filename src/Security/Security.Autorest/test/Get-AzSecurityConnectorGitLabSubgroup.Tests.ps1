if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorGitLabSubgroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorGitLabSubgroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorGitLabSubgroup' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $groups = Get-AzSecurityConnectorGitLabSubgroup -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gl-01" -GroupFqName "dfdsdktests"
        $groups.Count | Should -BeGreaterThan 0
    }
}
