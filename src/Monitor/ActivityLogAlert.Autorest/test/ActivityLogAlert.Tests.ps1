if(($null -eq $TestName) -or ($TestName -contains 'ActivityLogAlert'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'ActivityLogAlert.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ActivityLogAlert' {
    It 'CRUD' {
        $scope = $env.scope
        $actiongroup = New-AzActivityLogAlertActionGroupObject -Id $env.actionGroupResourceId -WebhookProperty @{"sampleWebhookProperty"="SamplePropertyValue"}
        $condition1=New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -Equal Administrative -Field category
        $condition2=New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -Equal Error -Field level
        $any1=New-AzActivityLogAlertAlertRuleLeafConditionObject -Field properties.incidentType -Equal Maintenance
        $any2=New-AzActivityLogAlertAlertRuleLeafConditionObject -Field properties.incidentType -Equal Incident
        $condition3=New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -AnyOf $any1,$any2
        New-AzActivityLogAlert -Name $env.alertName -ResourceGroupName $env.resourceGroupName -Action $actiongroup -Condition @($condition1,$condition2,$condition3) -Location global -Scope $scope

        $alert = Get-AzActivityLogAlert -ResourceGroupName $env.resourceGroupName -Name $env.alertName

        $alert.ActionGroup.Id | Should -Be $env.actionGroupResourceId

        Update-AzActivityLogAlert -ResourceGroupName $env.resourceGroupName -Name $env.alertName -Tag @{'key'='val'}
        $alert = Get-AzActivityLogAlert -ResourceGroupName $env.resourceGroupName -Name $env.alertName
        $alert.Tag['key'] | Should -Be 'val'

        Remove-AzActivityLogAlert -ResourceGroupName $env.resourceGroupName -Name $env.alertName
    }
}