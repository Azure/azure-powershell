if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorGitLabGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorGitLabGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorGitLabGroup' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $groups = Get-AzSecurityConnectorGitLabGroup -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gl-01"
        $groups.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $group = Get-AzSecurityConnectorGitLabGroup -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gl-01" -GroupFqName "dfdsdktests"
        $group | Should -Not -Be $null
        $group.Name.Contains('dfdsdktests') | Should -Be $true
    }

    It 'GetViaIdentity' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourcegroups/$rg/providers/Microsoft.Security/securityConnectors/dfdsdktests-gl-01/devops/default/gitlabgroups/dfdsdktests" }
        $group = Get-AzSecurityConnectorGitLabGroup -InputObject $InputObject
        $group.Count | Should -Be 1
        $group.Name.Contains('dfdsdktests') | Should -Be $true
    }
}
