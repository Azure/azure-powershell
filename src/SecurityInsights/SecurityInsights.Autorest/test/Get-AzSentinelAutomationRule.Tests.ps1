if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelAutomationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelAutomationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelAutomationRule' {
    It 'List' {
        $automationRules = Get-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $automationRules.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $automationRule = Get-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetAutomationRuleId
        $automationRule.Name | Should -Be $env.GetAutomationRuleId
    }

    It 'GetViaIdentity' {
        $automationRule = Get-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetAutomationRuleId
        $automationRuleViaIdentity = Get-AzSentinelAutomationRule -InputObject $automationRule
        $automationRuleViaIdentity.Name | Should -Be $env.GetAutomationRuleId
    }
}
