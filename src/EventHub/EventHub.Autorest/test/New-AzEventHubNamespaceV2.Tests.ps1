if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHubNamespaceV2' {
    It 'SetExpanded' {
        $eventHubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuName Standard -Location $env.location
        $eventHubNamespace.Name | Should -Be $env.namespaceV2
        $eventHubNamespace.SkuName | Should -Be Standard
        $eventHubNamespace.SkuCapacity | Should -Be 1
        $eventHubNamespace.MaximumThroughputUnit | Should -Be 0
        $eventhubNamespace.MinimumTlsVersion | Should -Be "1.2"
        $eventhubNamespace.PublicNetworkAccess | Should -Be "Enabled"
        $eventHubNamespace.EnableAutoInflate | Should -Be $false
        $eventHubNamespace.ZoneRedundant | Should -Be $false
        $eventHubNamespace.DisableLocalAuth | Should -Be $false
        $eventHubNamespace.KafkaEnabled | Should be $true

        $eventHubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3 -SkuCapacity 10 -MaximumThroughputUnit 18 -SkuName Standard -Location $env.location -Tag @{k1='v1'; k2='v2'} -EnableAutoInflate -DisableLocalAuth -MinimumTlsVersion 1.1 -PublicNetworkAccess Disabled -ZoneRedundant:$env.useZoneRedundancy
        $eventHubNamespace.Name | Should be $env.namespaceV3
        $eventHubNamespace.SkuCapacity | Should be 10
        $eventHubNamespace.SkuName | Should be Standard
        $eventHubNamespace.MaximumThroughputUnit | Should be 18
        $eventHubNamespace.MinimumTlsVersion | Should be '1.1'
        $eventhubNamespace.Location.Replace(' ', '').ToLower() | Should -Be $env.location
        $eventHubNamespace.EnableAutoInflate | Should be $true
        $eventHubNamespace.DisableLocalAuth | Should be $true
        $eventHubNamespace.KafkaEnabled | Should be $true
        $eventHubNamespace.PublicNetworkAccess | Should -Be "Disabled"
        $eventHubNamespace.ZoneRedundant | Should -Be $env.useZoneRedundancy

        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location $env.location -IdentityType SystemAssigned
        $eventhubNamespace.MaximumThroughputUnit | Should -Be 0
        $eventhubNamespace.Name | Should -Be $env.namespaceV4
        $eventhubNamespace.IdentityType | Should -Be SystemAssigned
        $eventhubNamespace.ZoneRedundant | Should -Be $true
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.SkuTier | Should be Premium
        $eventhubNamespace.DisableLocalAuth | Should -Be $false
        $eventhubNamespace.Location.Replace(' ', '').ToLower() | Should -Be $env.location
        $eventhubNamespace.MinimumTlsVersion | Should -Be "1.2"
        $eventhubNamespace.KafkaEnabled | Should -Be $true

        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -SkuName Premium -Location $env.location -IdentityType UserAssigned -UserAssignedIdentityId $env.msi1,$env.msi2 -KeyVaultProperty $ec1,$ec2
        $eventhubNamespace.IdentityType | Should -Be UserAssigned
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.SkuTier | Should -Be Premium
        $eventhubNamespace.Location.Replace(' ', '').ToLower() | Should -Be $env.location
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 2
        $eventhubNamespace.RequireInfrastructureEncryption | Should -Be $false

        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV7 -SkuName Premium -Location $env.location -IdentityType UserAssigned -UserAssignedIdentityId $env.msi1,$env.msi2 -KeyVaultProperty $ec1,$ec2 -RequireInfrastructureEncryption
        $eventhubNamespace.IdentityType | Should -Be UserAssigned
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.SkuTier | Should -Be Premium
        $eventhubNamespace.Location.Replace(' ', '').ToLower() | Should -Be $env.location
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 2
        $eventhubNamespace.RequireInfrastructureEncryption | Should -Be $true

        # Create an EventHub namespace within a dedicated cluster
        $clusterNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV9 -SkuName Standard -Location $env.location
        $clusterNamespace.Name | Should -Be $env.namespaceV9
        $clusterNamespace.ClusterArmId | Should -Be $env.ClusterArmId
        $clusterNamespace.SkuName | Should -Be "Standard"

        # TODO REVERT COMMENTS BEFORE MERGING TO MAIN
        $eventhubNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5
        $eventhubNamespace.Name | Should -Be $env.namespaceV5
        $eventhubNamespace.IdentityType | Should -Be "UserAssigned"
        $eventhubNamespace.SkuName | Should -Be "Premium"
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 2

        $listOfNamespaces = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup
        $listOfNamespaces.Count | Should -BeGreaterOrEqual 5

    }
}
