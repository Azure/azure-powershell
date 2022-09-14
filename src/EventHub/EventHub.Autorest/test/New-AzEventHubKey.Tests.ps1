if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubKey.Recording.json'
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

Describe 'New-AzEventHubKey' {
    It 'NewExpandedNamespace' {
        $currentKeys = Get-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule
        
        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType PrimaryKey
        $newKeys.PrimaryKey | Should -Not -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType SecondaryKey
        $newKeys.PrimaryKey | Should -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Not -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newPrimaryKey = GenerateSASKey

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType PrimaryKey -KeyValue $newPrimaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newSecondaryKey = GenerateSASKey

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType SecondaryKey -KeyValue $newSecondaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $newSecondaryKey
    }

    It 'NewExpandedEntity' {
        $currentKeys = Get-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule
        
        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule -KeyType PrimaryKey
        $newKeys.PrimaryKey | Should -Not -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule -KeyType SecondaryKey
        $newKeys.PrimaryKey | Should -Be $currentKeys.PrimaryKey
        $newKeys.SecondaryKey | Should -Not -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newPrimaryKey = GenerateSASKey

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule -KeyType PrimaryKey -KeyValue $newPrimaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys
        $newSecondaryKey = GenerateSASKey

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule -KeyType SecondaryKey -KeyValue $newSecondaryKey
        $newKeys.PrimaryKey | Should -Be $newPrimaryKey
        $newKeys.SecondaryKey | Should -Be $newSecondaryKey
    }
}
