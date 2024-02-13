if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorGitHubRepos'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorGitHubRepos.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorGitHubRepos' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $repos = Get-AzSecurityConnectorGitHubRepos -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gh-01" -OwnerName "dfdsdktests"
        $repos.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $repo = Get-AzSecurityConnectorGitHubRepos -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gh-01" -OwnerName "dfdsdktests" -RepoName "TestApp0"
        $repo | Should -Not -Be $null
        $repo.Name.Contains('TestApp0') | Should -Be $true
    }

    It 'GetViaIdentity' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourcegroups/$rg/providers/Microsoft.Security/securityConnectors/dfdsdktests-gh-01/devops/default/githubOwners/dfdsdktests/repos/TestApp0" }
        $repo = Get-AzSecurityConnectorGitHubRepos -InputObject $InputObject
        $repo.Count | Should -Be 1
        $repo.Name.Contains('TestApp0') | Should -Be $true
    }
}
