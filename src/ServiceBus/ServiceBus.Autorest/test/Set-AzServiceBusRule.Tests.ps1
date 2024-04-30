if(($null -eq $TestName) -or ($TestName -contains 'Set-AzServiceBusRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzServiceBusRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function AssertCorrelationFilterUpdates{
    param([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IRule]$expectedRule,[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IRule]$actualRule)
    $expectedRule.Name | Should -Be $actualRule.Name
    $expectedRule.ResourceGroupName | Should -Be $actualRule.ResourceGroupName
    $expectedRule.ContentType | Should -Be $actualRule.ContentType
    $expectedRule.CorrelationId | Should -Be $actualRule.CorrelationId
    $expectedRule.Label | Should -Be $actualRule.Label
    $expectedRule.MessageId | Should -Be $actualRule.MessageId
    $expectedRule.CorrelationFilterProperty.Count | Should -Be $actualRule.CorrelationFilterProperty.Count
    $expectedRule.ReplyTo | Should -Be $actualRule.ReplyTo
    $expectedRule.ReplyToSessionId | Should -Be $actualRule.ReplyToSessionId
    $expectedRule.CorrelationFilterRequiresPreprocessing | Should -Be $actualRule.CorrelationFilterRequiresPreprocessing
    $expectedRule.SessionId | Should -Be $actualRule.SessionId
    $expectedRule.To | Should -Be $actualRule.To
    $expectedRule.FilterType | Should -Be $actualRule.FilterType
}

Describe 'Set-AzServiceBusRule' {
    It 'SetExpanded'  {
        $rule1 = Set-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name sqlRule2 -FilterType SqlFilter -SqlExpression x=y
        $rule1.Name | Should -Be "sqlRule2"
        $rule1.ResourceGroupName | Should -Be $env.resourceGroup
        $rule1.FilterType | Should -Be "SqlFilter"
        $rule1.SqlExpression | Should -Be "x=y"
        $rule1.ActionSqlExpression | Should -Be "SET a=b"
    }

    It 'SetViaIdentityExpanded'  {
        $currentRule = Get-AzServiceBusRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -SubscriptionName subscription1 -Name correlationRule1
        
        $updatedRule = Set-AzServiceBusRule -InputObject $currentRule -ContentType secondcontenttype
        $currentRule.ContentType = "secondcontenttype"
        AssertCorrelationFilterUpdates $currentRule $updatedRule
        $currentRule = $updatedRule

        $updatedRule = Set-AzServiceBusRule -InputObject $currentRule -CorrelationId secondcorrelationid
        $currentRule.CorrelationId = "secondcorrelationid"
        AssertCorrelationFilterUpdates $currentRule $updatedRule
        $currentRule = $updatedRule

        $updatedRule = Set-AzServiceBusRule -InputObject $currentRule -Label secondlabel
        $currentRule.Label = "secondlabel"
        AssertCorrelationFilterUpdates $currentRule $updatedRule
        $currentRule = $updatedRule

        $updatedRule = Set-AzServiceBusRule -InputObject $currentRule -MessageId secondmessageid
        $currentRule.MessageId = "secondmessageid"
        AssertCorrelationFilterUpdates $currentRule $updatedRule
        $currentRule = $updatedRule

        $updatedRule = Set-AzServiceBusRule -InputObject $currentRule -CorrelationFilterProperty @{a='b'}
        $currentRule.CorrelationFilterProperty = @{a='b'}
        AssertCorrelationFilterUpdates $currentRule $updatedRule
        $currentRule = $updatedRule

        $updatedRule = Set-AzServiceBusRule -InputObject $currentRule -ReplyTo secondreplyto
        $currentRule.ReplyTo = "secondreplyto"
        AssertCorrelationFilterUpdates $currentRule $updatedRule
        $currentRule = $updatedRule

        $updatedRule = Set-AzServiceBusRule -InputObject $currentRule -ReplyToSessionId secondreplytosessionid
        $currentRule.ReplyToSessionId = "secondreplytosessionid"
        AssertCorrelationFilterUpdates $currentRule $updatedRule
        $currentRule = $updatedRule

        $updatedRule = Set-AzServiceBusRule -InputObject $currentRule -SessionId secondsessionid
        $currentRule.SessionId = "secondsessionid"
        AssertCorrelationFilterUpdates $currentRule $updatedRule
        $currentRule = $updatedRule

        $updatedRule = Set-AzServiceBusRule -InputObject $currentRule -To secondto
        $currentRule.To = "secondto"
        AssertCorrelationFilterUpdates $currentRule $updatedRule
        $currentRule = $updatedRule

        { Set-AzServiceBusRule -InputObject $currentRule -ErrorAction Stop } | Should -Throw 'Please specify the property you want to update on the -InputObject'
    }
}
