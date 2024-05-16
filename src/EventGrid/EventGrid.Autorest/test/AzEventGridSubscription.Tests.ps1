if(($null -eq $TestName) -or ($TestName -contains 'AzEventGridSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzEventGridSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzEventGridSubscription' {
    It 'New-AzEventGridSubscription' {
        {
            $inboundIpRule = New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
            $config = New-AzEventGridTopic -Name $env.topic -ResourceGroupName $env.resourceGroup -Location $env.location -PublicNetworkAccess Enabled -InboundIPRule $inboundIpRule
            $topic = Get-AzEventGridTopic -ResourceGroupName $env.resourceGroup -Name $env.topic

            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = New-AzEventGridSubscription -Name $env.eventSub -Scope "subscriptions/$($env.SubscriptionId)" -Destination $obj -FilterIsSubjectCaseSensitive:$false
            # New-AzEventGridSubscription -Name $env.eventSub -Scope $topic.Id -Destination $obj -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix"
            $config.Name | Should -Be $env.eventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridSubscription' {
        {
            $config = Get-AzEventGridSubscription -Name $env.eventSub -Scope "/subscriptions/$($env.SubscriptionId)"
            $config.Name | Should -Be $env.eventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridSubscriptionDeliveryAttribute' {
        {
            $config = Get-AzEventGridSubscriptionDeliveryAttribute -EventSubscriptionName $env.eventSub -Scope "/subscriptions/$($env.SubscriptionId)"
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridSubscriptionFullUrl' {
        {
            $config = Get-AzEventGridSubscriptionFullUrl -EventSubscriptionName $env.eventSub -Scope "/subscriptions/$($env.SubscriptionId)"
            $config.EndpointUrl | Should -Be $env.EndpointUrl
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridSubscriptionGlobal' {
        {
            $config = Get-AzEventGridSubscriptionGlobal -ResourceGroupName $env.resourceGroup
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridSubscriptionRegional' {
        {
            $config = Get-AzEventGridSubscriptionRegional -Location $env.location -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = Update-AzEventGridSubscription -Name $env.eventSub -Scope "subscriptions/$($env.SubscriptionId)" -Destination $obj -FilterIsSubjectCaseSensitive:$false
            $config.Name | Should -Be $env.eventSub
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridSubscription' {
        {
            Remove-AzEventGridSubscription -Name $env.eventSub -Scope "subscriptions/$($env.SubscriptionId)"

            Remove-AzEventGridTopic -Name $env.topic -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
