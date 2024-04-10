if(($null -eq $TestName) -or ($TestName -contains 'AzEventGridEventSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzEventGridEventSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzEventGridEventSubscription' {
    It 'New-AzEventGridEventSubscription' {
        {
            $inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
            $config = New-AzEventGridTopic -Name $env.topic -ResourceGroupName $env.resourceGroup -Location $env.location -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
            $topic = Get-AzEventGridTopic -ResourceGroupName $env.resourceGroup -Name $env.topic

            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = New-AzEventGridEventSubscription -Name $env.eventSub -Scope "subscriptions/$($env.SubscriptionId)" -Destination $obj -FilterIsSubjectCaseSensitive:$false
            # New-AzEventGridEventSubscription -Name $env.eventSub -Scope $topic.Id -Destination $obj -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix"
            $config.Name | Should -Be $env.eventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridEventSubscription' {
        {
            $config = Get-AzEventGridEventSubscription -Name $env.eventSub -Scope "/subscriptions/$($env.SubscriptionId)"
            $config.Name | Should -Be $env.eventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridEventSubscriptionDeliveryAttribute' {
        {
            $config = Get-AzEventGridEventSubscriptionDeliveryAttribute -EventSubscriptionName $env.eventSub -Scope "/subscriptions/$($env.SubscriptionId)"
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridEventSubscriptionFullUrl' {
        {
            $config = Get-AzEventGridEventSubscriptionFullUrl -EventSubscriptionName $env.eventSub -Scope "/subscriptions/$($env.SubscriptionId)"
            $config.EndpointUrl | Should -Be $env.EndpointUrl
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridEventSubscriptionGlobal' {
        {
            $config = Get-AzEventGridEventSubscriptionGlobal -ResourceGroupName $env.resourceGroup
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridEventSubscriptionRegional' {
        {
            $config = Get-AzEventGridEventSubscriptionRegional -Location $env.location -ResourceGroupName $env.resourceGroup
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridEventSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = Update-AzEventGridEventSubscription -Name $env.eventSub -Scope "subscriptions/$($env.SubscriptionId)" -Destination $obj -FilterIsSubjectCaseSensitive:$false
            $config.Name | Should -Be $env.eventSub
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridEventSubscription' {
        {
            Remove-AzEventGridEventSubscription -Name $env.eventSub -Scope "subscriptions/$($env.SubscriptionId)"

            Remove-AzEventGridTopic -Name $env.topic -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
