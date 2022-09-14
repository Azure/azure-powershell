if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEventHubAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHubAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEventHubAuthorizationRule' {
    It 'GetExpandedNamespace' {
        $authRule = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule
        $authRule.Name | Should -Be $env.authRule
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        $listOfAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfAuthRules.Count | Should -Be 2
    }

    It 'GetExpandedEntity' {
        $authRule = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule
        $authRule.Name | Should -Be $env.eventHubAuthRule
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        $authRule = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub
        $authRule.Count | Should -Be 1
    }

    It 'GetViaIdentityExpanded' {
        $authRule = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule
        
        $authRule = Get-AzEventHubAuthorizationRule -InputObject $authRule
        $authRule.Name | Should -Be $env.authRule
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        $authRule = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule
        $authRule = Get-AzEventHubAuthorizationRule -InputObject $authRule
        $authRule.Name | Should -Be $env.eventHubAuthRule
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3
    }
}
