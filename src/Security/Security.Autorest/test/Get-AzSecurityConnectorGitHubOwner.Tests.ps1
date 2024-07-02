if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorGitHubOwner'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorGitHubOwner.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorGitHubOwner' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $owners = Get-AzSecurityConnectorGitHubOwner -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gh-01"
        $owners.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $owner = Get-AzSecurityConnectorGitHubOwner -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gh-01" -OwnerName "dfdsdktests"
        $owner | Should -Not -Be $null
        $owner.Name.Contains('dfdsdktests') | Should -Be $true
    }

    It 'GetViaIdentity' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourcegroups/$rg/providers/Microsoft.Security/securityConnectors/dfdsdktests-gh-01/devops/default/githubOwners/dfdsdktests" }
        $owner = Get-AzSecurityConnectorGitHubOwner -InputObject $InputObject
        $owner.Count | Should -Be 1
        $owner.Name.Contains('dfdsdktests') | Should -Be $true
    }
}
