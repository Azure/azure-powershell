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
    It 'NewExpandedNamespace' -skip {
        $authRule = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name namespaceAuthRule -Rights @("Manage", "Send", "Listen")
        $authRule.Name | Should -Be "namespaceAuthRule"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        $env.Add("authRule2", $authRule.Name)

        $listOfAuthRules = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfAuthRules.Count | Should -Be 3
    }

    It 'NewExpandedEntity' -skip {
        $authRule = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name eventHubAuthRule -Rights @("Listen")
        $authRule.Name | Should -Be "eventHubAuthRule"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 1

        $env.Add("eventHubAuthRule2", $authRule.Name)

        $listOfAuthRules = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $listOfAuthRules.Count | Should -Be 2
    }
}
