if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEventHubAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEventHubAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEventHubAuthorizationRule' {
    New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 -Rights @("Manage", "Send", "Listen")
    $namespaceAuthRule = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule2 -Rights @("Manage", "Send", "Listen")

    $listOfNamespaceAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
    $listOfNamespaceAuthRules.Count | Should -Be 8

    $listOfEventHubAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub
    $listOfEventHubAuthRules.Count | Should -Be 2

    New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name entityAuthRule1 -Rights @("Manage", "Send", "Listen")
    $eventhubAuthRule = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name entityAuthRule2 -Rights @("Manage", "Send", "Listen")

    $listOfNamespaceAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
    $listOfNamespaceAuthRules.Count | Should -Be 8

    $listOfEventHubAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub
    $listOfEventHubAuthRules.Count | Should -Be 4

    It 'RemoveExpandedNamespace' {
        Remove-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1
        { Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule1 } | Should -Throw
    }

    It 'RemoveExpandedEntity'  {
        Remove-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name entityAuthRule1
        { Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name entityAuthRule1 } | Should -Throw
    }

    It 'RemoveViaIdentityExpanded'  {
        Remove-AzEventHubAuthorizationRule -InputObject $namespaceAuthRule
        { Get-AzEventHubAuthorizationRule -InputObject $namespaceAuthRule } | Should -Throw

        $listOfNamespaceAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfNamespaceAuthRules.Count | Should -Be 6

        $listOfEventHubAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub
        $listOfEventHubAuthRules.Count | Should -Be 3

        Remove-AzEventHubAuthorizationRule -InputObject $eventhubAuthRule
        { Get-AzEventHubAuthorizationRule -InputObject $eventhubAuthRule } | Should -Throw

        $listOfNamespaceAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfNamespaceAuthRules.Count | Should -Be 6

        $listOfEventHubAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub
        $listOfEventHubAuthRules.Count | Should -Be 2
    }
}
