if(($null -eq $TestName) -or ($TestName -contains 'AzEventGridPartner'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzEventGridPartner.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzEventGridPartner' {
    # When run Record, please remove this function's [-Skip]
    It 'New-AzEventGridCaCertificate' -Skip {
        {
            $crtData = Get-Content -Path ".\test\intermediate_ca.crt" -Raw
            $config = New-AzEventGridCaCertificate -Name $env.caCertificate -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -EncodedCertificate $crtData.Trim("`n")
            $config.Name | Should -Be $env.caCertificate
        } | Should -Not -Throw
    }

    It 'New-AzEventGridPartnerRegistration' {
        {
            $config = New-AzEventGridPartnerRegistration -Name $env.partnerRegistration -ResourceGroupName $env.resourceGroup -Location global
            $config.Name | Should -Be $env.partnerRegistration
        } | Should -Not -Throw
    }

    It 'New-AzEventGridPartnerNamespace' {
        {
            $config = New-AzEventGridPartnerNamespace -Name $env.partnerNamespace -ResourceGroupName $env.resourceGroup -Location $env.location -PartnerTopicRoutingMode SourceEventAttribute -PartnerRegistrationFullyQualifiedId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.EventGrid/partnerRegistrations/$($env.partnerRegistration)"
        } | Should -Not -Throw
    }

    It 'New-AzEventGridPartnerConfiguration' {
        {
            $partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName $env.resourceGroup -Name $env.partnerRegistration
            $partner = New-AzEventGridPartnerObject -AuthorizationExpirationTimeInUtc "2024-05-05T09:31:42.521Z" -RegistrationImmutableId $partnerRegistration.ImmutableId
            $config = New-AzEventGridPartnerConfiguration -ResourceGroupName $env.resourceGroup -Location global -PartnerAuthorizationDefaultMaximumExpirationTimeInDay 7 -PartnerAuthorizationAuthorizedPartnersList $partner
            $config.Name | Should -Be "default"
        } | Should -Not -Throw
    }

    It 'New-AzEventGridChannel' {
        {
            $dateObj = Get-Date -Year 2024 -Month 05 -Day 05 -Hour 11 -Minute 06 -Second 07
            $config = New-AzEventGridChannel -Name $env.channel -PartnerNamespaceName $env.partnerNamespace -ResourceGroupName $env.resourceGroup -ChannelType PartnerTopic -PartnerTopicInfoAzureSubscriptionId $env.SubscriptionId -PartnerTopicInfoResourceGroupName $env.resourceGroup -PartnerTopicInfoName "default" -PartnerTopicInfoSource "ContosoCorp.Accounts.User1" -ExpirationTimeIfNotActivatedUtc $dateObj.ToUniversalTime()
            $config.Name | Should -Be $env.channel
        } | Should -Not -Throw
    }

    It 'New-AzEventGridPartnerNamespaceKey' {
        {
            $config = New-AzEventGridPartnerNamespaceKey -PartnerNamespaceName $env.partnerNamespace -ResourceGroupName $env.resourceGroup -KeyName key1
            $config.key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'New-AzEventGridPartnerDestination' -Skip {
        {
            $config = New-AzEventGridPartnerDestination -Name $env.partnerDestination -ResourceGroupName $env.resourceGroup -Location $env.location -Tag @{"1"="a"}
            $config.Name | Should -Be $env.partnerDestination
        } | Should -Not -Throw
    }

    It 'New-AzEventGridPartnerTopic' {
        {
            $partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName $env.resourceGroup -Name $env.partnerRegistration
            $config = New-AzEventGridPartnerTopic -Name default -ResourceGroupName $env.resourceGroup -Location $env.location -partnerRegistrationImmutableId $partnerRegistration.ImmutableId -Source "ContosoCorp.Accounts.User1" -ExpirationTimeIfNotActivatedUtc "2024-03-09T11:06:13.109Z" -PartnerTopicFriendlyDescription "Example description" -MessageForActivation "Example message for activation"
            $config.Name | Should -Be "default"
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridChannel' {
        {
            $dateObj = Get-Date -Year 2024 -Month 05 -Day 5 -Hour 11 -Minute 06 -Second 07
            $config = Update-AzEventGridChannel -Name $env.channel -PartnerNamespaceName $env.partnerNamespace -ResourceGroupName $env.resourceGroup -ExpirationTimeIfNotActivatedUtc $dateObj.ToUniversalTime()
            $config.Name | Should -Be $env.channel
        } | Should -Not -Throw
    }

    It 'Enable-AzEventGridPartnerTopic' {
        {
            $config = Enable-AzEventGridPartnerTopic -Name default -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be "default"
        } | Should -Not -Throw
    }

    It 'New-AzEventGridPartnerTopicEventSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = New-AzEventGridPartnerTopicEventSubscription -EventSubscriptionName $env.partnerTopicEventSub -ResourceGroupName $env.resourceGroup -PartnerTopicName default -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -EventDeliverySchema CloudEventSchemaV1_0 -Destination $obj
            $config.Name | Should -Be $env.partnerTopicEventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridChannelFullUrl' -Skip {
        {
            $config = Get-AzEventGridChannelFullUrl -ResourceGroupName $env.resourceGroup -PartnerNamespaceName $env.partnerNamespace -ChannelName $env.channel
            $config.EndpointUrl | Should -Be $env.EndpointUrl
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridChannel' {
        {
            $config = Get-AzEventGridChannel -ResourceGroupName $env.resourceGroup -PartnerNamespaceName $env.partnerNamespace -Name $env.channel
            $config.Name | Should -Be $env.channel
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridCaCertificate' {
        {
            $config = Get-AzEventGridCaCertificate -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.caCertificate
            $config.Name | Should -Be $env.caCertificate
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridPartnerConfiguration' {
        {
            $config = Get-AzEventGridPartnerConfiguration -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be "default"
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridPartnerDestination' -Skip {
        {
            $config = Get-azeventGridPartnerDestination -ResourceGroupName $env.resourceGroup -Name $env.partnerDestination
            $config.Name | Should -Be $env.partnerDestination
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridPartnerNamespace' {
        {
            $config = Get-AzEventGridPartnerNamespace -ResourceGroupName $env.resourceGroup -Name $env.partnerNamespace
            $config.Name | Should -Be $env.partnerNamespace
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridPartnerNamespaceKey' {
        {
            $config = Get-AzEventGridPartnerNamespaceKey -PartnerNamespaceName $env.partnerNamespace -ResourceGroupName $env.resourceGroup
            $config.key1 | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridPartnerRegistration' {
        {
            $config = Get-AzEventGridPartnerRegistration -ResourceGroupName $env.resourceGroup -Name $env.partnerRegistration
            $config.Name | Should -Be $env.partnerRegistration
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridPartnerTopic' {
        {
            $config = Get-AzEventGridPartnerTopic -Name default -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be "default"
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridPartnerTopicEventSubscription' {
        {
            $config = Get-AzEventGridPartnerTopicEventSubscription -ResourceGroupName $env.resourceGroup -PartnerTopicName default -EventSubscriptionName $env.partnerTopicEventSub
            $config.Name | Should -Be $env.partnerTopicEventSub
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridPartnerTopicEventSubscriptionDeliveryAttribute' -Skip {
        {
            $config = Get-AzEventGridPartnerTopicEventSubscriptionDeliveryAttribute -PartnerTopicName default -EventSubscriptionName $env.partnerTopicEventSub -ResourceGroupName $env.resourceGroup
            $config.Count | Should -Be 0
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridFullUrlForPartnerTopicEventSubscription' {
        {
            $config = Get-AzEventGridFullUrlForPartnerTopicEventSubscription -ResourceGroupName $env.resourceGroup -PartnerTopicName default -EventSubscriptionName $env.partnerTopicEventSub
            $config.EndpointUrl | Should -Be $env.EndpointUrl
        } | Should -Not -Throw
    }

    It 'Get-AzEventGridVerifiedPartner' {
        {
            $config = Get-AzEventGridVerifiedPartner
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridPartnerConfiguration' {
        {
            $config = Update-AzEventGridPartnerConfiguration -ResourceGroupName $env.resourceGroup -DefaultMaximumExpirationTimeInDay 1 -Tag @{"abc"="123"}
            $config.Name | Should -Be "default"
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridPartnerDestination' -Skip {
        {
            $config = Update-AzEventGridPartnerDestination -Name $env.partnerDestination -ResourceGroupName $env.resourceGroup -Tag @{"123"="abc"} -DefaultProfile "test default"
            $config.Name | Should -Be $env.partnerDestination
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridPartnerNamespace' {
        {
            $config = Update-AzEventGridPartnerNamespace -Name $env.partnerNamespace -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"} -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridPartnerRegistration' -Skip {
        {
            $config = Update-AzEventGridPartnerRegistration -Name $env.partnerRegistration -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"} -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridPartnerTopic' {
        {
            $config = Update-AzEventGridPartnerTopic -Name default -ResourceGroupName $env.resourceGroup -UserAssignedIdentity "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uami03"
            $config.Name | Should -Be "default"
        } | Should -Not -Throw
    }

    It 'Update-AzEventGridPartnerTopicEventSubscription' {
        {
            $obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl $env.EndpointUrl
            $config = Update-AzEventGridPartnerTopicEventSubscription -EventSubscriptionName $env.partnerTopicEventSub -ResourceGroupName $env.resourceGroup -PartnerTopicName default -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -EventDeliverySchema CloudEventSchemaV1_0 -Destination $obj
            $config.Name | Should -Be $env.partnerTopicEventSub
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridPartnerTopicEventSubscription' {
        {
            Remove-AzEventGridPartnerTopicEventSubscription -EventSubscriptionName $env.partnerTopicEventSub -ResourceGroupName $env.resourceGroup -PartnerTopicName default
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridPartnerTopic' {
        {
            Remove-AzEventGridPartnerTopic -Name default -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridPartnerDestination' {
        {
            Remove-AzEventGridPartnerDestination -Name $env.partnerDestination -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridChannel' {
        {
            Remove-AzEventGridChannel -Name $env.channel -PartnerNamespaceName $env.partnerNamespace -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridPartnerConfiguration' {
        {
            Remove-AzEventGridPartnerConfiguration -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridPartnerNamespace' {
        {
            Remove-AzEventGridPartnerNamespace -Name $env.partnerNamespace -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridPartnerRegistration' {
        {
            Remove-AzEventGridPartnerRegistration -Name $env.partnerRegistration -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'Remove-AzEventGridCaCertificate' {
        {
            Remove-AzEventGridCaCertificate -Name $env.caCertificate -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
