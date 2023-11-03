if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelAlertRuleTemplate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelAlertRuleTemplate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelAlertRuleTemplate' {
    It 'List' {
        $alertRuleTemplates = Get-AzSentinelAlertRuleTemplate -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $alertRuleTemplates.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $alertRuleTemplate = Get-AzSentinelAlertRuleTemplate -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName | Where {$_.Kind -eq "Fusion"}
        $alertRuleTemplate.Kind | Should -Be "Fusion"
    }

    It 'GetViaIdentity' {
        $alertRuleTemplate = Get-AzSentinelAlertRuleTemplate -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName | where {$_.Kind -eq "Fusion"}
        $alertRuleTemplateViaIdentity = Get-AzSentinelAlertRuleTemplate -InputObject $alertRuleTemplate
        $alertRuleTemplateViaIdentity.Kind | Should -Be "Fusion"
    }
}
