if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityConnectorAzureDevOpsProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityConnectorAzureDevOpsProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityConnectorAzureDevOpsProject' {
    It 'List' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $projects = Get-AzSecurityConnectorAzureDevOpsProject -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests"
        $projects.Count | Should -BeGreaterThan 0
    }

    It 'Get' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $project = Get-AzSecurityConnectorAzureDevOpsProject -SubscriptionId $sid -ResourceGroupName $rg -SecurityConnectorName "dfdsdktests-azdo-01" -OrgName "dfdsdktests" -ProjectName "ContosoSDKDfd"
        $project | Should -Not -Be $null
        $project.Name.Contains('ContosoSDKDfd') | Should -Be $true
    }

    It 'GetViaIdentity' {
        $rg = $env.SecurityConnectorsResourceGroupName
        $sid = $env.SubscriptionId
        $InputObject = @{Id = "/subscriptions/$sid/resourcegroups/$rg/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default/azureDevOpsOrgs/dfdsdktests/projects/ContosoSDKDfd" }
        $project = Get-AzSecurityConnectorAzureDevOpsProject -InputObject $InputObject
        $project.Count | Should -Be 1
        $project.Name.Contains('ContosoSDKDfd') | Should -Be $true
    }
}
