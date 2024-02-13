if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorGitLabProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorGitLabProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorGitLabProject' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $projects = Get-AzSecurityConnectorGitLabProject -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gl-01" -GroupFqName "dfdsdktests"
        $projects.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $project = Get-AzSecurityConnectorGitLabProject -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-gl-01" -GroupFqName "dfdsdktests" -ProjectName "testapp0"
        $project | Should -Not -Be $null
        $project.Name.Contains('testapp0') | Should -Be $true
    }

    It 'GetViaIdentity' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourcegroups/$rg/providers/Microsoft.Security/securityConnectors/dfdsdktests-gl-01/devops/default/gitlabgroups/dfdsdktests/projects/testapp0" }
        $project = Get-AzSecurityConnectorGitLabProject -InputObject $InputObject
        $project.Count | Should -Be 1
        $project.Name.Contains('testapp0') | Should -Be $true
    }
}
