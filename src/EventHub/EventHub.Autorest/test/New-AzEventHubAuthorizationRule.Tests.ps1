if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHubAuthorizationRule' {
    It 'NewExpandedNamespace' {
        $authRule = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Manage", "Send", "Listen")
        $authRule.Name | Should -Be $env.authRule2
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        $listOfAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfAuthRules.Count | Should -Be 4
    }

    It 'NewExpandedEntity' {
        $authRule = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule2 -Rights @("Listen")
        $authRule.Name | Should -Be $env.eventHubAuthRule2
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 1

        $listOfAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub
        $listOfAuthRules.Count | Should -Be 2
    }
}
