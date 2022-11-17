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
        $eventHubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuName Standard -Location eastus
        $eventHubNamespace.Name | Should -Be $env.namespaceV2
        $eventHubNamespace.SkuName | Should be Standard

        $eventHubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3 -SkuCapacity 10 -MaximumThroughputUnits 18 -SkuName Standard -Location southcentralus -Tag @{k1='v1'; k2='v2'} -EnableAutoInflate -DisableLocalAuth -KafkaEnabled -MinimumTlsVersion 1.1
        $eventHubNamespace.Name | Should be $env.namespaceV3
        $eventHubNamespace.SkuCapacity | Should be 10
        $eventHubNamespace.SkuName | Should be Standard
        $eventHubNamespace.MaximumThroughputUnits | Should be 18
        $eventHubNamespace.MinimumTlsVersion | Should be '1.1'
        $eventHubNamespace.Location | Should be "South Central Us"
        $eventHubNamespace.EnableAutoInflate | Should be $true
        $eventHubNamespace.DisableLocalAuth | Should be $true
        $eventHubNamespace.KafkaEnabled | Should be $true

        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned        
        $eventhubNamespace.MaximumThroughputUnits | Should -Be 0
        $eventhubNamespace.Name | Should -Be $env.namespaceV4
        $eventhubNamespace.IdentityType | Should -Be SystemAssigned
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.SkuTier | Should be Premium
        $eventhubNamespace.Location | Should -Be "East Us"

        # Create namespace with UserAssigned Encryption Enabled
        $a = New-AzEventHubUserAssignedIdentityObject -IdentityId $env.msi1, $env.msi2
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentity $a -KeyVaultProperty $ec1,$ec2
        $eventhubNamespace.IdentityType | Should -Be UserAssigned
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.SkuTier | Should -Be Premium
        $eventhubNamespace.Location | Should -Be "North Europe"
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 2
        $eventhubNamespace.RequireInfrastructureEncryption | Should -Be $false

        # Create namespace with UserAssigned Encryption Enabled and RequireInfrastructureEncryption true
        $a = New-AzEventHubUserAssignedIdentityObject -IdentityId $env.msi1, $env.msi2
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV7 -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentity $a -KeyVaultProperty $ec1,$ec2 -RequireInfrastructureEncryption
        $eventhubNamespace.IdentityType | Should -Be UserAssigned
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.SkuTier | Should -Be Premium
        $eventhubNamespace.Location | Should -Be "North Europe"
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 2
        $eventhubNamespace.RequireInfrastructureEncryption | Should -Be $true

        $eventhubNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5
        $eventhubNamespace.Name | Should -Be $env.namespaceV5
        $eventhubNamespace.IdentityType | Should -Be UserAssigned
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 2

    }
}
