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

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType PrimaryKey -KeyValue $env.namespacePrimaryKey
        $newKeys.PrimaryKey | Should -Be $env.namespacePrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule -KeyType SecondaryKey -KeyValue $env.namespaceSecondaryKey
        $newKeys.PrimaryKey | Should -Be $env.namespacePrimaryKey
        $newKeys.SecondaryKey | Should -Be $env.namespaceSecondaryKey
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

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule -KeyType PrimaryKey -KeyValue $env.eventHubPrimaryKey
        $newKeys.PrimaryKey | Should -Be $env.eventHubPrimaryKey
        $newKeys.SecondaryKey | Should -Be $currentKeys.SecondaryKey

        $currentKeys = $newKeys

        $newKeys = New-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule -KeyType SecondaryKey -KeyValue $env.eventHubSecondaryKey
        $newKeys.PrimaryKey | Should -Be $env.eventHubPrimaryKey
        $newKeys.SecondaryKey | Should -Be $env.eventHubSecondaryKey
    }
}
