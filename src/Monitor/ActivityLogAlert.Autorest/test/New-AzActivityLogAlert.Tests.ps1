if(($null -eq $TestName) -or ($TestName -contains 'New-AzActivityLogAlert'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActivityLogAlert.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActivityLogAlert' -Tag 'LiveOnly' {
    It 'CreateExpanded' {
        #replace this string by a real action group resource id
        $ActionGroupResourceId = ""

        $actiongroup=New-AzActionGroupObject -Id $ActionGroupResourceId -WebhookProperty @{"sampleWebhookProperty"="SamplePropertyValue"}
        $condition1=New-AzAlertRuleAnyOfOrLeafConditionObject -Equal Administrative -Field category
        $condition2=New-AzAlertRuleAnyOfOrLeafConditionObject -Equal Error -Field level
        $any=New-AzAlertRuleLeafConditionObject -Field properties.incidentType -Equal Maintenance
        $condition3=New-AzAlertRuleAnyOfOrLeafConditionObject -AnyOf $any

        New-AzActivityLogAlert -Name $env.AlertName -ResourceGroupName $env.ResourceGroupName -Action $actiongroup -Condition @($condition1,$condition2,$condition3) -Location global -Scope $env.AlertScope

        $alert = Get-AzActivityLogAlert -Name $env.AlertName -ResourceGroupName $env.ResourceGroupName
        Update-AzActivityLogAlert -Name $env.AlertName -ResourceGroupName $env.ResourceGroupName -Enabled $false -Tag @{"key"="val"}
        $alert | Remove-AzActivityLogAlert
    }
}
