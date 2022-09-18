if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHubAuthorizationRule' {
    It 'SetExpandedNamespace' {
        $authRule = Set-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2 -Rights @("Listen")
        $authRule.Name | Should -Be $env.authRule2
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 1
        $authRule.Rights[0] | Should -Be "Listen"
    }

    It 'SetExpandedEntity' {
        $authRule = Set-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule2 -Rights @("Send")
        $authRule.Name | Should -Be $env.eventHubAuthRule2
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 1
        $authRule.Rights[0] | Should -Be "Send"
    }

    It 'SetViaIdentityExpanded' {
        $authRule = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule2
        
        $authRule = Set-AzEventHubAuthorizationRule -InputObject $authRule -Rights @("Manage", "Send", "Listen")
        $authRule.Name | Should -Be $env.authRule2
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        $authRule = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule2
        $authRule = Set-AzEventHubAuthorizationRule -InputObject $authRule -Rights @("Manage", "Send", "Listen")
        $authRule.Name | Should -Be $env.eventHubAuthRule2
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3
    }
}
