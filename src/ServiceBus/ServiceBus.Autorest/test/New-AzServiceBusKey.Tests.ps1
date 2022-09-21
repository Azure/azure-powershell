if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function GenerateSASKey {
    [Reflection.Assembly]::LoadWithPartialName("System.Web")| out-null
    $URI="myNamespace.servicebus.windows.net/myEventHub"
    $Access_Policy_Name="RootManageSharedAccessKey"
    $Access_Policy_Key="myPrimaryKey"
    #Token expires now+300
    $Expires=([DateTimeOffset]::Now.ToUnixTimeSeconds())+300
    $SignatureString=[System.Web.HttpUtility]::UrlEncode($URI)+ "`n" + [string]$Expires
    $HMAC = New-Object System.Security.Cryptography.HMACSHA256
    $HMAC.key = [Text.Encoding]::ASCII.GetBytes($Access_Policy_Key)
    $Signature = $HMAC.ComputeHash([Text.Encoding]::ASCII.GetBytes($SignatureString))
    $Signature = [Convert]::ToBase64String($Signature)
    $Signature
}

Describe 'New-AzServiceBusKey' {
    It 'NewExpandedNamespace' {
        $currentKeys = Get-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1
        
        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -KeyType PrimaryKey
        $newKeys.PrimaryKey | Should -Not -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -KeyType SecondaryKey
        $newKeys.PrimaryKey | Should -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Not -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newPrimaryKey = GenerateSASKey

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -KeyType PrimaryKey -KeyValue $newPrimaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newSecondaryKey = GenerateSASKey

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -KeyType SecondaryKey -KeyValue $newSecondaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $newSecondaryKey
    }

    It 'NewExpandedQueue' {
        $currentKeys = Get-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1
        
        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1 -KeyType PrimaryKey
        $newKeys.PrimaryKey | Should -Not -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1 -KeyType SecondaryKey
        $newKeys.PrimaryKey | Should -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Not -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newPrimaryKey = GenerateSASKey

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1 -KeyType PrimaryKey -KeyValue $newPrimaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newSecondaryKey = GenerateSASKey

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -QueueName queue1 -Name queueAuthRule1 -KeyType SecondaryKey -KeyValue $newSecondaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $newSecondaryKey
    }

    It 'NewExpandedTopic' {
        $currentKeys = Get-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1
        
        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -KeyType PrimaryKey
        $newKeys.PrimaryKey | Should -Not -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -KeyType SecondaryKey
        $newKeys.PrimaryKey | Should -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Not -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newPrimaryKey = GenerateSASKey

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -KeyType PrimaryKey -KeyValue $newPrimaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newSecondaryKey = GenerateSASKey

        $newKeys = New-AzServiceBusKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TopicName topic1 -Name topicAuthRule1 -KeyType SecondaryKey -KeyValue $newSecondaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $newSecondaryKey
    }
}
