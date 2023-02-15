if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceBusRule' {
    It 'CreateExpanded' {
        # Create Sql Filter Rule
        $rule1 = New-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name sqlRule2 -FilterType SqlFilter -SqlExpression 1=2 -ActionSqlExpression "SET a=b"
        $rule1.Name | Should -Be "sqlRule2"
        $rule1.ResourceGroupName | Should -Be $env.resourceGroup
        $rule1.FilterType | Should -Be "SqlFilter"
        $rule1.SqlExpression | Should -Be "1=2"
        $rule1.ActionSqlExpression | Should -Be "SET a=b"

        $rule2 = New-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name correlationRule1 -FilterType CorrelationFilter -ContentType contenttype -CorrelationFilterProperty @{a='b';c='d'} -SessionId sessionid -CorrelationId correlationid -MessageId messageid -Label label -ReplyTo replyto -ReplyToSessionId replytosessionid
        $rule2.Name | Should -Be "correlationRule1"
        $rule2.ResourceGroupName | Should -Be $env.resourceGroup
        $rule2.FilterType | Should -Be "CorrelationFilter"
        $rule2.ContentType | Should -Be "contenttype"
        $rule2.CorrelationFilterProperty.Count | Should -Be 2
        $rule2.SessionId | Should -Be "sessionid"
        $rule2.CorrelationId | Should -Be "correlationid"
        $rule2.MessageId | Should -Be "messageid"
        $rule2.Label | Should -Be "label"
        $rule2.ReplyTo | Should -Be "replyto"
        $rule2.ReplyToSessionId | Should -Be "replytosessionid"
    }
}
