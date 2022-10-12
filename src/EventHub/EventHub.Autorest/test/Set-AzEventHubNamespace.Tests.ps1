if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubNamespaceName'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubNamespaceName.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHubNamespace' {
        It 'SetExpanded' {
        $eventhubNamespace = Set-AzEventHubNamespace -ResourceGroupName $env.resourceGroup -Name $env.namespace -KafkaEnabled -MaximumThroughputUnits 4 -DisableLocalAuth -SkuCapacity 2 -IdentityType UserAssigned -PublicNetworkAccess Disabled
        $eventhubNamespace.KafkaEnabled | Should -Be $true
        $eventhubNamespace.MaximumThroughputUnits | Should -Be 4
        $eventhubNamespace.DisableLocalAuth | Should -Be $true
        $eventhubNamespace.SkuCapacity | Should -Be 2
        $eventhubNamespace.IdentityType | Should -Be UserAssigned
        $eventhubNamespace.PublicNetworkAccess | Should be Disabled

    }
}
