if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEventHubKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEventHubKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEventHubKey' {
    It 'GetExpandedNamespace' {
        $namespaceKeys = Get-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $env.authRule
        $namespaceKeys.PrimaryKey | Should -Not -Be $null
        $namespaceKeys.SecondaryKey | Should -Not -Be $null
    }

    It 'GetExpandedEntity' {
        $eventHubKeys = Get-AzEventHubKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -EventHubName $env.eventHub -Name $env.eventHubAuthRule
        $eventHubKeys.PrimaryKey | Should -Not -Be $null
        $eventHubKeys.SecondaryKey | Should -Not -Be $null
    }
}
