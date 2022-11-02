if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHubNamespaceV2' {
    It 'SetExpanded' {

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace -KafkaEnabled -DisableLocalAuth -SkuCapacity 2 -IdentityType SystemAssigned -PublicNetworkAccess Disabled
        $eventhubNamespace.KafkaEnabled | Should -Be $true
        $eventhubNamespace.DisableLocalAuth | Should -Be $true
        $eventhubNamespace.SkuCapacity | Should -Be 2
        $eventhubNamespace.IdentityType | Should -Be SystemAssigned
        $eventhubNamespace.PublicNetworkAccess | Should be Disabled


        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $namespace -EnableAutoInflate:$false -MaximumThroughputUnits 0
        $eventhubNamespace.EnableAutoInflate = $false
        $eventhubNamespace.MaximumThroughputUnits = 0

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $namespace -EnableAutoInflate:$true -MaximumThroughputUnits 18
        $eventhubNamespace.EnableAutoInflate = $true
        $eventhubNamespace.MaximumThroughputUnits = 18

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace -SkuCapacity 12
        $eventhubNamespace.SkuCapacity = 12

        eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $namespace -MaximumThroughputUnits 13
        $eventhubNamespace.EnableAutoInflate = $true
        $eventhubNamespace.MaximumThroughputUnits = 13

        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace -MaximumThroughputUnits 25
        $eventhubNamespace.MaximumThroughputUnits = 25

        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace -MinimumTlsVersion 1.0
        $eventhubNamespace.MinimumTlsVersion = '1.0'

        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace -MinimumTlsVersion 1.2
        $eventhubNamespace.MinimumTlsVersion = '1.2'

        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $namespace -DisableLocalAuth:$false
        $eventhubNamespace.DisableLocalAuth = $false

        $ud1 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg01"
        $ud2 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg02"
        $ud3 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg03"

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespace -IdentityType "UserAssigned" -IdentityId $uad1,$uad2
        $eventhubNamespace.IdentityType | Should be UserAssigned
        $eventHubNamespace.IdenitityId.count | Should be 2
        $eventHubNamespace.Name | Should be $env.namespace


    }
}
